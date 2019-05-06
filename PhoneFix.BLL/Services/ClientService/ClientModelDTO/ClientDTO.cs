using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneFix.BLL.Services.ClientModelDTO
{
    public class ClientDTO
    {
        public int clientID { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string adress { get; set; }
        public string email { get; set; }
        public string contactNumber { get; set; }
    }
}
