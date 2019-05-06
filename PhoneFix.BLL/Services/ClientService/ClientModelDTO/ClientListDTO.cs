using PhoneFix.BLL.Services.ClientModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneFix.BLL.Services.ClientService.ClientModelDTO
{
    public class ClientListDTO
    {
        public IEnumerable<ClientDTO> ClientList { get; set; }
        public int Count { get; set; }
    }
}
