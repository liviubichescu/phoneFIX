using System;
using System.Collections.Generic;
using System.Linq;
using PhoneFix.BLL.Services.Client.DTO;
using PhoneFix.DAL;

namespace PhoneFix.BLL.Services.Client
{
    public class ClientServices : BaseService
    {
        public IEnumerable<ClientDTO> getClients()
        {
            var rsp = DbContext.Clients.Select(x => new ClientDTO()
            {
                clientID = x.clientID,
                firstname = x.firstname,
                lastname = x.lastname,
                adress = x.adress,
                email = x.email,
                contactNumber = x.contactNumber
            });
            
            return rsp.ToList();
        }

        public void updateClient(int id, ClientDTO client)
        {
            var ant = DbContext.Clients.SingleOrDefault(b => b.clientID == id);

            if (ant != null)
            {
                ant.firstname = client.firstname;
                ant.lastname = client.lastname;
                ant.adress = client.adress;
                ant.email = client.email;
                ant.contactNumber = client.contactNumber;

                DbContext.SaveChanges();
            }
            
        }

        //public void GetClientPhones(int id)
        //{
        //    var qry = (from client in DbContext.Clients
        //            where client.clientID == id
        //            select client.Phones
        //            );
        //    qry.Count();

        //    return DbContext.Clients.Where(x=> x.clientID  == id).Select(x=> x.Phones).Select(x=>)
        //}


        public void addClient(ClientDTO client)
        {

            ConvertDTOtoMODEL convert = new ConvertDTOtoMODEL();

            //DbContext.Clients.Add(new DAL.Client()
            //{
            //    firstname = client.firstname,
            //});
            DbContext.SaveChanges();

        }

        public void deleteClient(int id)
        {

            var res = DbContext.Clients.Find(id);
            DbContext.Clients.Remove(res);
            DbContext.SaveChanges();

        }

    }
}
