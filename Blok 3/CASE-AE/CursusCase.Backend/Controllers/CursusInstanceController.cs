using CursusCase.Shared.Models;
using CursusCase.Shared.Repositories;
using CursusCase.Shared.Results;
using Microsoft.AspNetCore.Mvc;

namespace CursusCase.Backend.Controllers
{
    [ApiController]
    [Route("api/cursusinstanties")]
    public class CursusInstanceController : ControllerBase
    {
        private readonly ICursusInstanceRepo _cursusInstanceRepo;

        public CursusInstanceController(ICursusInstanceRepo cursusInstanceRepo)
        {
            _cursusInstanceRepo = cursusInstanceRepo;
        }

        [HttpGet]
        public IActionResult GetAllCursusInstances()
        {
            return Ok(_cursusInstanceRepo.GetAllInstances());
        }

        [HttpGet("{year:int?}/{week:int?}")]
        public IActionResult GetAllCursusInstancesFromTillToDate(int year, int week)
        {
            return Ok(_cursusInstanceRepo.GetInstancesBySearchPerWeekAndYear(year, week));
        }

        [HttpPost("date")]
        public IActionResult GetInstancesBySearchPerPeriod(Period period)
        {
            return Ok(
                _cursusInstanceRepo.GetInstancesBySearchPerPeriod(period.DateFrom, period.DateTo)
            );
        }

        [HttpGet("{id:int?}")]
        public IActionResult GetCursusInstanceById(int id)
        {
            return Ok(_cursusInstanceRepo.GetCursusInstanceById(id));
        }

        [HttpPost("{id:int?}/newstudent")]
        public IActionResult AddStudentToInstance(int id, Student student)
        {
            return Ok(_cursusInstanceRepo.AddStudent(student, id));
        }

        [HttpPost("new")]
        public CourseInstanceOperationResult AddCursusInstances(List<CourseInstance> cursusInstances)
        {
            try
            {
                return _cursusInstanceRepo.AddInstances(cursusInstances);
            }
            catch (Exception e)
            {
                CourseInstanceOperationResult result = new CourseInstanceOperationResult();
                result.Errors.Add($"{e.Message}\n{e.InnerException}");
                return result;
            }
        }
    }
}