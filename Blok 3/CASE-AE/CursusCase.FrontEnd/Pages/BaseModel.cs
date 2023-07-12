using CursusCase.Shared.Models;
using CursusCase.Shared.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CursusCase.FrontEnd.Pages
{
    public class BaseModel : PageModel
    {
        public readonly ICursusInstanceRepo CursusInstanceRepo;

        public List<CourseInstance> CursusInstances;
        public List<string> Errors;

        public BaseModel(ICursusInstanceRepo cursusInstanceRepo)
        {
            CursusInstanceRepo = cursusInstanceRepo;
            Errors = new List<string>();
        }
    }
}