using CursusCase.Shared.Repositories;
using CursusCase.Shared.Results;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CursusCase.FrontEnd.Pages
{
    public class PlanningModel : BaseModel
    {
        public int SearchWeek;
        public int SearchYear;

        private static int _searchWeek;
        private static int _searchYear;

        public DateTime DateFrom;
        public DateTime DateTo;

        public int CurrentWeek = ISOWeek.GetWeekOfYear(DateTime.Now);

        public PlanningModel(ICursusInstanceRepo cursusInstanceRepo)
            : base(cursusInstanceRepo)
        {
            if (_searchWeek != 0)
            {
                SearchWeek = _searchWeek;
            }
            else
            {
                SearchWeek = CurrentWeek;
            }

            if (_searchYear != 0)
            {
                SearchYear = _searchYear;
            }
            else
            {
                SearchYear = DateTime.Now.Year;
            }
        }

        public void OnGet(int year, int week)
        {
            if (year == 0)
            {
                year = DateTime.Now.Year;
            }

            if (week == 0)
            {
                week = CurrentWeek;
            }

            if (year < 2000 || year > 2099)
            {
                Errors.Add("Het jaar moet binnen het bereik van 2000 tot en met 2099 liggen");
                return;
            }
            if (week < 1 || week > 53)
            {
                Errors.Add("De week moet binnen het bereik van 1 tot en met 53 liggen");
                return;
            }

            LoadCursusInstancesForWeekInYear(year, week);
        }

        public IActionResult OnPostSearchPerWeekAndYear(int year, int week)
        {
            SearchYear = year;
            SearchWeek = week;

            return RedirectToPage($"/Planning", new { year = year, week = week });
        }

        public void OnPostSearchPerDateRange(DateTime dateFrom, DateTime dateTo)
        {
            LoadInstancesForPeriod(dateFrom, dateTo);
        }

        private void LoadCursusInstancesForWeekInYear(int year, int week)
        {
            _searchWeek = week;
            SearchWeek = week;
            _searchYear = year;
            SearchYear = year;

            LoadInstancesForYearAndWeek(year, week);
        }

        private void LoadInstancesForYearAndWeek(int year, int week)
        {
            CourseInstanceOperationResult? result = CursusInstanceRepo.GetInstancesBySearchPerWeekAndYear(year, week);
            if (result != null && !result.ContainsError)
            {
                CursusInstances = result.CursusInstances.ToList();
            }
            else
            {
                Errors = result.Errors.ToList();
            }
        }

        private void LoadInstancesForPeriod(DateTime dateFrom, DateTime dateTo)
        {
            CourseInstanceOperationResult result = CursusInstanceRepo.GetInstancesBySearchPerPeriod(dateFrom, dateTo);
            if (!result.ContainsError)
            {
                CursusInstances = result.CursusInstances.ToList();
            }
            else
            {
                Errors = result.Errors.ToList();
            }
        }
    }
}