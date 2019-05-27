using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneFix.BLL.Services.ServSheetService.ServSheetModelDTO
{
    public class ServSheetBaseDTO
    {
        public int ID_Service { get; set; }
        public int phoneID { get; set; }
        public string accesories { get; set; }
        public string phone_description_on_reception { get; set; }
        public string claimed_defect { get; set; }
        public DateTime date { get; set; }

    }
}
