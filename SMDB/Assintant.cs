using System.Globalization;

namespace SMDP
{
    public class Assintant
    {
    public static DateTime IntToDatetime(int? a)
        {

            DateTime dt;
            DateTime.TryParseExact(a.ToString(), "yyyyMMdd",
                          CultureInfo.InvariantCulture,
                          DateTimeStyles.None, out dt);           
            return dt;
        }
    public static string ConvertMiladiToShamsi(DateTime dt)
        {
            PersianCalendar p = new PersianCalendar();
            return string.Format("{0}/{1}/{2}",
                         p.GetYear(dt),
                         p.GetMonth(dt).ToString().PadLeft(2, '0'),
                         p.GetDayOfMonth(dt).ToString().PadLeft(2, '0'));
        }
    }
}
