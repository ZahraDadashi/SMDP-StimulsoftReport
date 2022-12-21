namespace SMDP.Repository
{
    public interface IDataRepository : IDisposable
    {
        
        dynamic DailyPrice(long a);
        dynamic Fund();
        dynamic Industry();
        dynamic Instrument();
        dynamic Lettertype();     

    }
}
