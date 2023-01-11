using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace SMDP.SMDPModels
{
    public partial class DailyPrice
    {
        [NotMapped]
        public string Shamsidate
        {
            get
            {
                DateTime _Deven = Assintant.IntToDatetime(Deven);
                string _shamsidate = Assintant.ConvertMiladiToShamsi(_Deven);
                return _shamsidate;
            }
            set
            {

            }
        }

    }
}
