namespace SMDP.Service
{
    public interface IValidationService
    {
        bool validateDailyPrice(long a);
        dynamic DailyPrice(long a);
        dynamic Fund();
        dynamic Industry();
        dynamic Instrument();
        dynamic Lettertype();
    }
}
