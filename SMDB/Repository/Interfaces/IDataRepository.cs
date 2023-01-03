using SMDP.SMDPModels;

namespace SMDP.Repository
{
    public interface IDataRepository : IDisposable
    {
        
        List<DailyPrice> DailyPrice(long a);
        List<Fund> Fund();
        List<Industry> Industry();
        List<Instrument> Instrument();
        List<LetterType> Lettertype();     

    }
}
