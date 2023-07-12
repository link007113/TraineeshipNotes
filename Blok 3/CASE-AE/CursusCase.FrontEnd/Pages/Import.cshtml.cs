using CursusCase.Shared.Exceptions;
using CursusCase.Shared.Helpers;
using CursusCase.Shared.Models;
using CursusCase.Shared.Repositories;
using CursusCase.Shared.Results;
using Microsoft.AspNetCore.Mvc;

namespace CursusCase.FrontEnd.Pages
{
    public class ImportModel : BaseModel
    {
        private List<CourseInstance> _cursusInstances;

        [BindProperty]
        public IFormFile Import { get; set; }

        public List<CourseInstance> CursusInstances
        {
            get { return _cursusInstances; }
            set { _cursusInstances = value; }
        }

        public string Message { get; set; }

        public bool IsSavedPressed { get; set; }
        public bool RetryButtonShown { get; set; }

        public ImportModel(ICursusInstanceRepo cursusInstanceRepo)
            : base(cursusInstanceRepo)
        {
            CursusInstances = _cursusInstances?.ToList();
        }

        public IActionResult OnPostSaveList()
        {
            IsSavedPressed = true;

            if (_cursusInstances != null)
            {
                CourseInstanceOperationResult result = CursusInstanceRepo.AddInstances(_cursusInstances);

                if (result != null)
                {
                    if (!result.ContainsError)
                    {
                        CursusInstances = result.CursusInstances.ToList();
                        GetMessageFromResult(result);
                        return Page();
                    }
                    else
                    {
                        if (result.CursusInstances != null && result.CursusInstances.Any())
                        {
                            GetMessageFromResult(result);
                            CursusInstances = result.CursusInstances.ToList();
                        }
                        else
                        {
                            CursusInstances = null;
                        }

                        Errors = result.Errors;
                        return Page();
                    }
                }
            }
            return Page();
        }

        private void GetMessageFromResult(CourseInstanceOperationResult result)
        {
            Message = "De volgende gegevens zijn geïmporteerd.";
            Message +=
                result.NewCourses > 0 ? $"\nEr zijn {result.NewCourses} cursussen aangemaakt." : "";
            Message +=
                result.NewInstances > 0
                    ? $"\nEr zijn {result.NewInstances} instanties aangemaakt."
                    : "";
        }

        public IActionResult OnPostRetry()
        {
            CursusInstances = null;
            Errors.Clear();
            Message = string.Empty;
            return Page();
        }

        public IActionResult OnPostImportFile(DateTime dateFrom, DateTime dateTo)
        {
            if (Import != null && Import.Length > 0)
            {
                string filePath = CreateFileFromIForm();

                try
                {
                    return ShowInstancesFromFileOnPage(dateFrom, dateTo, filePath);
                }
                catch (ImportException ex)
                {
                    Errors.Add(ex.Message);
                }
                finally
                {
                    System.IO.File.Delete(filePath);
                }
            }
            return Page();
        }

        private IActionResult ShowInstancesFromFileOnPage(
            DateTime dateFrom,
            DateTime dateTo,
            string filePath
        )
        {
            CursusImporter importer = new CursusImporter();
            List<CourseInstance> cursusInstances = new List<CourseInstance>();
            if (dateFrom.Year > 2000 && dateTo.Year > 2000)
            {
                Period period = new Period() { DateFrom = dateFrom, DateTo = dateTo };

                cursusInstances = importer.Import(filePath, period);
            }
            else
            {
                cursusInstances = importer.Import(filePath);
            }

            foreach (CourseInstance instance in cursusInstances)
            {
                instance.Students = new List<Student>();
            }

            CursusInstances = cursusInstances.ToList();
            _cursusInstances = CursusInstances;

            return Page();
        }

        private string CreateFileFromIForm()
        {
            string filePath = Path.GetTempFileName();

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                Import.CopyTo(stream);
            }

            return filePath;
        }
    }
}