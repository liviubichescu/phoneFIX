using PhoneFix.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneFix.BLL.Services.WorkmanshipService
{
    public class WorkmanshipGetModel
    {
        // fields for workmanship
        public int workmanshipID { get; set; }
        public Nullable<decimal> time { get; set; }
        public Nullable<decimal> price { get; set; }
        public string operations { get; set; }
        public int ID_repair { get; set; }

    }
}
