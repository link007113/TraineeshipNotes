using CursusCase.Backend.DAL.Context;
using CursusCase.Shared.Helpers;
using CursusCase.Shared.Models;
using CursusCase.Shared.Repositories;
using CursusCase.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace CursusCase.Backend.DAL.Repositories
{
    public class CursusInstanceRepo : ICursusInstanceRepo
    {
        private const string DuplicateCourseInstanceError =
            "Er is al een cursusinstantie voor {0} gepland voor dezelfde cursus op {1}.";

        private readonly CursusContext _context;

        public CursusInstanceRepo(CursusContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public CourseInstanceOperationResult AddInstances(List<CourseInstance> instances)
        {
            var wrapper = new CourseInstanceOperationResult();
            var newCourses = new Dictionary<string, Course>();
            var newCourseInstances = new HashSet<CourseInstance>();
            using (_context)
            {
                foreach (var instance in instances)
                {
                    var course = GetOrCreateCourse(instance.Cursus, newCourses, wrapper);

                    if (course == null)
                    {
                        continue;
                    }

                    instance.Cursus = course;

                    if (CourseInstanceExists(instance, newCourseInstances))
                    {
                        wrapper.Errors.Add(
                            string.Format(
                                DuplicateCourseInstanceError,
                                instance.Cursus.Code,
                                instance.StartDate.ToString("dd/MM/yyyy")
                            )
                        );
                        continue;
                    }

                    var instanceError = CheckInstanceBeforeImport(instance);

                    if (instanceError != null)
                    {
                        wrapper.Errors.Add(instanceError);
                        continue;
                    }

                    newCourseInstances.Add(instance);
                }

                AddCoursesAndInstancesToContext(newCourses.Values, newCourseInstances, wrapper);

                return wrapper;
            }
        }

        public CourseInstanceOperationResult AddStudent(Student student, int selectedId)
        {
            CourseInstanceOperationResult dto = new CourseInstanceOperationResult();
            using (_context)
            {
                Student? dbStudent = _context.Students.FirstOrDefault(
                    s => s.FirstName == student.FirstName && s.LastName == student.LastName
                );
                if (dbStudent != null)
                {
                    student = dbStudent;
                }
                else
                {
                    student.CourseInstances = null; // een klein beetje vage fix, maar nodig anders krijg ik bij het opslaan
                    // het probleem dat hij de course en courseinstance wilt inserten.
                    // Heb ik met JP naar gekeken, dit is de voorgestelde opplossing.
                    _context.Students.Add(student);
                }

                CourseInstance? instance = _context.CourseInstances
                    .Include(ci => ci.Students)
                    .Include(ci => ci.Cursus)
                    .FirstOrDefault(c => c.Id == selectedId);
                if (instance == null)
                {
                    dto.Errors.Add($"Geen instance met id {selectedId} gevonden.");
                    return dto;
                }
                else
                {
                    instance.Students.Add(student);
                }

                _context.SaveChanges();

                dto.CursusInstances.Add(instance);
                return dto;
            }
        }

        public CourseInstanceOperationResult GetAllInstances()
        {
            using (_context)
            {
                return new CourseInstanceOperationResult()
                {
                    CursusInstances = _context.CourseInstances
                        .AsNoTracking()
                        .Include(ci => ci.Cursus)
                        .Include(ci => ci.Students)
                        .ToList()
                };
            }
        }

        public CourseInstanceOperationResult GetCursusInstanceById(int id)
        {
            using (_context)
            {
                return new CourseInstanceOperationResult()
                {
                    CursusInstances = _context.CourseInstances
                        .AsNoTracking()
                        .Include(ci => ci.Students)
                        .Include(ci => ci.Cursus)
                        .Where(ci => ci.Id == id)
                        .ToList()
                };
            }
        }

        public CourseInstanceOperationResult GetInstancesBySearchPerPeriod(
            DateTime dateFrom,
            DateTime dateTo
        )
        {
            return GetInsancesForPeriod(dateFrom, dateTo);
        }

        public CourseInstanceOperationResult GetInstancesBySearchPerWeekAndYear(int year, int week)
        {
            DateTime dateFrom = DateCalculator.FirstDateOfWeekISO8601(year, week);
            DateTime dateTo = dateFrom.AddDays(7).AddMinutes(-1);

            return GetInsancesForPeriod(dateFrom, dateTo);
        }

        private static string ConvertToDutchDayOfWeek(string englishDayOfWeek)
        {
            return englishDayOfWeek.ToLower() switch
            {
                "monday" => "maandag",
                "tuesday" => "dinsdag",
                "wednesday" => "woensdag",
                "thursday" => "donderdag",
                "friday" => "vrijdag",
                "saturday" => "zaterdag",
                "sunday" => "zondag",
                _ => throw new ArgumentException("Invalid day of the week.")
            };
        }

        private static bool IsWeekdayRange(DateTime startDate, int numberOfDays)
        {
            for (int i = 0; i < numberOfDays; i++)
            {
                DateTime currentDate = startDate.AddDays(i);
                if (
                    currentDate.DayOfWeek == DayOfWeek.Saturday
                    || currentDate.DayOfWeek == DayOfWeek.Sunday
                )
                {
                    return false;
                }
            }

            return true;
        }

        private void AddCoursesAndInstancesToContext(
            IEnumerable<Course> newCourses,
            IEnumerable<CourseInstance> newCourseInstances,
            CourseInstanceOperationResult wrapper
        )
        {
            wrapper.NewCourses = newCourses.Count();
            wrapper.NewInstances = newCourseInstances.Count();

            _context.AddRange(newCourses);
            _context.AddRange(newCourseInstances);
            _context.SaveChanges();

            wrapper.CursusInstances = new List<CourseInstance>(newCourseInstances);
        }

        private string CheckCourseBeforeImport(Course course)
        {
            if (course.DurationInDays > 5)
            {
                return "De duur van de cursus mag niet meer dan 5 dagen bedragen.";
            }

            return null;
        }

        private string CheckInstanceBeforeImport(CourseInstance instance)
        {
            if (!IsWeekdayRange(instance.StartDate, instance.Cursus.DurationInDays))
            {
                return $"De cursus ({instance.Cursus.Code}) moet gepland worden binnen een week (maandag t/m vrijdag).\nDe cursus begint op {ConvertToDutchDayOfWeek(instance.StartDate.DayOfWeek.ToString())} en duurt {instance.Cursus.DurationInDays} dagen.";
            }

            return null;
        }

        private bool CourseInstanceExists(
            CourseInstance instance,
            HashSet<CourseInstance> newCourseInstances
        )
        {
            return _context.CourseInstances.Any(
                    ci =>
                        ci.Cursus.Code == instance.Cursus.Code
                        && ci.StartDate.Date == instance.StartDate.Date
                )
                || newCourseInstances.Any(
                    ci =>
                        ci.Cursus.Code == instance.Cursus.Code
                        && ci.StartDate.Date == instance.StartDate.Date
                );
        }

        private CourseInstanceOperationResult GetInsancesForPeriod(
            DateTime dateFrom,
            DateTime dateTo
        )
        {
            using (_context)
            {
                return new CourseInstanceOperationResult()
                {
                    CursusInstances = _context.CourseInstances
                        .AsNoTracking()
                        .Include(ci => ci.Cursus)
                        .Include(ci => ci.Students)
                        .Where(c => c.StartDate >= dateFrom && c.StartDate <= dateTo)
                        .ToList()
                };
            }
        }

        private Course GetOrCreateCourse(
            Course instanceCourse,
            Dictionary<string, Course> newCourses,
            CourseInstanceOperationResult wrapper
        )
        {
            var course = _context.Courses.FirstOrDefault(c => c.Code == instanceCourse.Code);

            if (course == null)
            {
                if (newCourses.TryGetValue(instanceCourse.Code, out var newCourse))
                {
                    course = newCourse;
                }
                else
                {
                    var error = CheckCourseBeforeImport(instanceCourse);

                    if (error != null)
                    {
                        wrapper.Errors.Add(error);
                        return null;
                    }

                    newCourses[instanceCourse.Code] = instanceCourse;
                    course = instanceCourse;
                }
            }

            return course;
        }
    }
}