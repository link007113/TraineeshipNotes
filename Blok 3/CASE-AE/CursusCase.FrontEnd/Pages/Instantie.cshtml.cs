using CursusCase.Shared.Models;
using CursusCase.Shared.Repositories;
using CursusCase.Shared.Results;

namespace CursusCase.FrontEnd.Pages
{
    public class InstanceModel : BaseModel
    {
        public CourseInstance CourseInstance { get; set; }
        private static CourseInstance _selectedCourseInstance;
        public string Message { get; set; }

        public InstanceModel(ICursusInstanceRepo cursusInstanceRepo)
            : base(cursusInstanceRepo) { }

        public void OnGet(int id)
        {
            CourseInstanceOperationResult result = CursusInstanceRepo.GetCursusInstanceById(id);
            AddToPage(result);
            Message = string.Empty;
        }

        public void OnPostAddStudent(string firstName, string lastName)
        {
            List<CourseInstance> instances = new List<CourseInstance>() { _selectedCourseInstance };

            Student student = new Student()
            {
                FirstName = firstName,
                LastName = lastName,
                CourseInstances = instances
            };

            CourseInstanceOperationResult result = CursusInstanceRepo.AddStudent(student, _selectedCourseInstance.Id);
            AddToPage(result);
            Message =
                $"Student {student.FirstName} {student.LastName} is succesvol toegevoegd aan deze instantie!";
        }

        private void AddToPage(CourseInstanceOperationResult result)
        {
            if (!result.ContainsError)
            {
                var firstInstance = result.CursusInstances.FirstOrDefault();

                if (firstInstance != null)
                {
                    _selectedCourseInstance = firstInstance;
                    CourseInstance = firstInstance;
                }
                else
                {
                    Errors.Add($"De gevraagde instantie kon niet gevonden worden");
                }
            }
            else
            {
                Errors = result.Errors.ToList();
            }
        }
    }
}