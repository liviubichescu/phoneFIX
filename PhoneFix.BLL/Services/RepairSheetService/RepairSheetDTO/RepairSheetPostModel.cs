using PhoneFix.BLL.Services.PartService;
using PhoneFix.BLL.Services.WorkmanshipService;
using PhoneFix.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneFix.BLL.Services.RepairSheetService.RepairSheetDTO
{
    public class RepairSheetPostModel
    {
        // fields for repair sheet
        public int ID_repair { get; set; }
        public string defect_conclusion { get; set; }
        public Nullable<decimal> totalCost { get; set; }
        public Nullable<DateTime> estimatedDate { get; set; }
        public string status { get; set; }
        public int service_ID { get; set; }
        public IEnumerable<WorkmanshipGetModel> workmanships { get; set; }
        public IEnumerable<PartGetModel> parts { get; set; }



        // fields for part
        //public int partsID { get; set; }
        //public int workmanshipID { get; set; }
        //public string partName { get; set; }
        //public decimal partPrice { get; set; }

    }
}
