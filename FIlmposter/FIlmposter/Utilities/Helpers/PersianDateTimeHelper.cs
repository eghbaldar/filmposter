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
        public static string GetShamsiProductionDate(DateOnly date)
        {
            // Convert DateOnly to DateTime
            var dateTime = date.ToDateTime(TimeOnly.MinValue);

            // Convert to Persian date
            var shamsiDate = new PersianDateTime(dateTime);
            var shamsiDateString = shamsiDate.ToString("yyyy/MM/dd");

            // Convert numbers to Persian format
            var persianDateString = PersianNumberHelper.ConvertToPersian(shamsiDateString);

            return persianDateString;
        }

    }
}
