using SMDP.SMDPModels;

namespace SMDP.Service
{
    public interface IValidationService
    {
        bool validateDailyPrice(long a);
        List<DailyPrice> DailyPrice(long InsCode, DateTime FromD, DateTime ToD);
        List<Fund> Fund();
        List<Industry> Industry();
        List<Instrument> Instrument();
        List<LetterType> Lettertype();
    }
}
