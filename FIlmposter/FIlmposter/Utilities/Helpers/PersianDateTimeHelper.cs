namespace FIlmposter.Utilities.Helpers
{
    public static class PersianDateTimeHelper
    {
        // NuGet\Install-Package PersianDateTime.Core -Version 2.0.5
        public static string ToShamsiDate(DateTime date)
        {
            PersianDateTime shamsiDate = new PersianDateTime(date);
            return shamsiDate.ToString("yyyy/MM/dd");
        }
    }
}
