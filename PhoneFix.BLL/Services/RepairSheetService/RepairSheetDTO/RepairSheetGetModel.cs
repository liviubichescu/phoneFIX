using System;

namespace PhoneFix.BLL.Services.RepairSheetService.RepairSheetDTO
{
    public class RepairSheetGetModel
    {
        public int ID_repair { get; set; }
        public string phone { get; set; }
        public string IMEI { get; set; }
        public DateTime date { get; set; }
        public string status { get; set; }

    }
}
