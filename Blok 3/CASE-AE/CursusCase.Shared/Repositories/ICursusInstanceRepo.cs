using CursusCase.Shared.Models;
using CursusCase.Shared.Results;

namespace CursusCase.Shared.Repositories
{
    public interface ICursusInstanceRepo
    {
        CourseInstanceOperationResult GetAllInstances();

        CourseInstanceOperationResult GetInstancesBySearchPerPeriod(DateTime dateFrom, DateTime dateTill);

        CourseInstanceOperationResult GetInstancesBySearchPerWeekAndYear(int year, int week);

        CourseInstanceOperationResult GetCursusInstanceById(int id);

        CourseInstanceOperationResult AddInstances(List<CourseInstance> instances);

        CourseInstanceOperationResult AddStudent(Student student, int selectedId);
    }
}