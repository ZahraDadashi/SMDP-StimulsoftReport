using SMDP.SMDPModels;
using SMDP.GenericRepository;
using SMDP.Repository;
using SMDP.Controllers;

namespace SMDP.Service
{
    public class ValidationService : IValidationService
    {
        private readonly DataRepository _smdps;

        public ValidationService()
        {

            _smdps = new DataRepository(new SMDPModels.SmdpContext());

        }
        public bool validateDailyPrice(long a)
        {
            if (a == null)
            {
                return false;
            }
            else if (a <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public List<DailyPrice> DailyPrice(long InsCode, int FromDate, int ToDate)
        {
            return _smdps.DailyPrice(InsCode,FromDate,ToDate);
        }
        public List<Fund> Fund()
        {
            return _smdps.Fund();
        }
        public List<Industry> Industry()
        {
            return _smdps.Industry();
        }
        public List<Instrument> Instrument()
        {
            return _smdps.Instrument();
        }
        public List<LetterType> Lettertype()
        {
            return _smdps.Lettertype();
        }
        
    }
}
