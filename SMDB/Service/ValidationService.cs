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
        public dynamic DailyPrice(long a)
        {
            return _smdps.DailyPrice(a);
        }
        public dynamic Fund()
        {
            return _smdps.Fund();
        }
        public dynamic Industry()
        {
            return _smdps.Industry();
        }
        public dynamic Instrument()
        {
            return _smdps.Instrument();
        }
        public dynamic Lettertype()
        {
            return _smdps.Lettertype();
        }
        
    }
}
