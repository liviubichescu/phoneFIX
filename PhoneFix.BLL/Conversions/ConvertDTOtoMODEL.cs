using PhoneFix.BLL.Services.Client.DTO;
using PhoneFix.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneFix.BLL
{
    public class ConvertDTOtoMODEL
    {
        
        public Client convertClient(ClientDTO client)
        {


            Client ant = new Client();

           // ant.clientID = client.clientID;
            ant.firstname = client.firstname;
            ant.lastname = client.lastname;
            ant.adress = client.adress;
            ant.email = client.email;
            ant.contactNumber = client.contactNumber;


            return ant;
        }
    }
}
