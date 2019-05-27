using PhoneFix.BLL.Services.PartService;
using PhoneFix.BLL.Services.WorkmanshipService;
using PhoneFix.DAL;
using System;
using System.Collections.Generic;

namespace PhoneFix.BLL.Services.RepairSheetService.RepairSheetDTO
{
    public class RepairSheetDetailsModel
    {
        public int ID_repair { get; set; }
        public string owner { get; set; }
        public string phone { get; set; }
        public string IMEI { get; set; }
        public string status { get; set; }
        public string defect_conclusion { get; set; }
        public Nullable<decimal> totalCost { get; set; }
        public DateTime date { get; set; }
        public Nullable<DateTime> estimatedDate { get; set; }
        public int service_ID { get; set; }
        public IEnumerable<WorkmanshipGetModel> workmanships { get; set; }
        public IEnumerable<PartGetModel> parts { get; set; }

    }
}
