using SMDP.SMDPModels;

namespace SMDP.Repository
{
    public interface IDataRepository : IDisposable
    {

        List<DailyPrice> DailyPrice(long InsCode, int FromDate, int ToDate);
        List<Fund> Fund();
        List<Industry> Industry();
        List<Instrument> Instrument();
        List<LetterType> Lettertype();     

    }
}
