using SMDP.SMDPModels;
using SMDP.Controllers;
namespace SMDP.Repository
{
    public class DataRepository : IDataRepository
    {
        private readonly SmdpContext _db;        
        public DataRepository (SmdpContext db)
        {
            _db = db;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<DailyPrice> DailyPrice(long a)
        {
            var dailypricelist = _db.DailyPrices.ToList();
            return dailypricelist;
        }
        
        public List<Fund> Fund()
        {
            var fundlist = _db.Funds.ToList();
            return fundlist;
        }

        public List<Industry> Industry()
        {           
            var industrylist = _db.Industries.ToList();
            return industrylist;
        }

        public List<Instrument> Instrument()
        {
            var instrumentlist = _db.Instruments.ToList();
            return instrumentlist;
        }

        public List<LetterType> Lettertype()
        {
            var letterTypelist = _db.LetterTypes.ToList();
            return letterTypelist;
        }

    }
}
