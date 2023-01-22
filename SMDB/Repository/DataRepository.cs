using SMDP.SMDPModels;
using SMDP.Controllers;
using SMDP;
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

        public List<DailyPrice> DailyPrice(long InsCode,DateTime FromD, DateTime ToD)
        {            
            string start = Assintant.ConvertShamsiToMiladi(FromD);
            string end = Assintant.ConvertShamsiToMiladi(ToD);
            Int32.TryParse(start,out int FromDate);
            Int32.TryParse(end,out int ToDate);            
            var dailypricelist = _db.DailyPrices.Where(i =>
              i.InsCode == InsCode && i.Deven>= FromDate && i.Deven<= ToDate)
              .ToList();
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
