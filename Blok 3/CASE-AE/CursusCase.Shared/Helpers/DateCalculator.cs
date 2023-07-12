using System.Globalization;

namespace CursusCase.Shared.Helpers
{
    public class DateCalculator
    {
        public static DateTime FirstDateOfWeekISO8601(int year, int weekOfYear)
        {
            if (weekOfYear < 1 || weekOfYear > 53)
                throw new ArgumentException("weekOfYear must be in the range of 1 and 53");

            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            DateTime firstThursday = jan1.AddDays(daysOffset);
            Calendar cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            int weekNum = weekOfYear;

            if (firstWeek == 1)
            {
                weekNum -= 1;
            }

            DateTime result = firstThursday.AddDays(weekNum * 7);

            return result.AddDays(-3);

            // Source: https://stackoverflow.com/questions/662379/calculate-date-from-week-number
        }
    }
}