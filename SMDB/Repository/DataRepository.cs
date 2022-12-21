using SMDP.SMDPModels;
using SMDP.Controllers;
namespace SMDP.Repository
{
    public class DataRepository : IDataRepository
    {
        private readonly SmdpContext _db;

        public  DataRepository (SmdpContext db)
        {
            _db = db;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public dynamic DailyPrice(long a)
        {
            var dailypricelist = _db.DailyPrices.Where(i =>
              i.InsCode == a).ToList();
            return dailypricelist;

        }
        
        public dynamic Fund()
        {
            var fundlist = _db.Funds.Select(i =>
            new { i }).ToList();
            return fundlist;
        }

        public dynamic Industry()
        {           
            var industrylist = _db.Industries.Select(i =>
            new { i }).ToList();
            return industrylist;
        }

        public dynamic Instrument()
        {
            var instrumentlist = _db.Instruments.Select(i =>
            new { i }).ToList();
            return instrumentlist;
        }

        public dynamic Lettertype()
        {
            var letterTypelist = _db.LetterTypes.Select(i =>
            new { i }).ToList();
            return letterTypelist;
        }

    }
}
