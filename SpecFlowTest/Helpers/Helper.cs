using System.Globalization;

namespace SpecFlowTest.Helpers;

public interface Helper
{
    public static string getWeekOfYear()
    {
        Calendar cal = CultureInfo.InvariantCulture.Calendar;
        DayOfWeek day = cal.GetDayOfWeek(DateTime.Today);
        DateTime time = (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            ? DateTime.Today.AddDays(3)
            : DateTime.Today;

        return cal.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString();
    }

}