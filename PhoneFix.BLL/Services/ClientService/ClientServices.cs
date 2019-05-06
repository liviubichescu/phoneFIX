using PhoneFix.BLL.Services.ClientModelDTO;
using PhoneFix.BLL.Services.ClientService.ClientModelDTO;
using PhoneFix.DAL;
using System.Collections.Generic;
using System.Linq;


namespace PhoneFix.BLL.Services.ClientService
{
    public class ClientServices : BaseService
    {
        private IQueryable<ClientDTO> GetClient_QRY()
        {
            return DbContext.Clients.Select(x => new ClientDTO()
            {
                clientID = x.clientID,
                firstname = x.firstname,
                lastname = x.lastname,
                adress = x.adress,
                email = x.email,
                contactNumber = x.contactNumber
            });
        }
        public IEnumerable<ClientDTO> getClients(string filter)
        {
            bool filterClient = true;
            if (string.IsNullOrEmpty(filter))
                filterClient = false;

            var qry = GetClient_QRY().Where(x =>

               filterClient ? x.firstname.Contains(filter) || x.lastname.Contains(filter) ||
                              x.adress.Contains(filter) || x.email.Contains(filter) || x.contactNumber.Contains(filter) : true

           ).OrderBy(x => x.firstname);

            // var count = qry.Count();

            //var result = qry.Skip(skip).Take(take).Select(x => new ClientDTO()

            return qry.ToList();
        }


        public ClientDTO updateClient(int id, ClientDTO client)
        {
            var dbClient = DbContext.Clients.SingleOrDefault(b => b.clientID == id);

            if (dbClient != null)
            {
                dbClient.firstname = client.firstname;
                dbClient.lastname = client.lastname;
                dbClient.adress = client.adress;
                dbClient.email = client.email;
                dbClient.contactNumber = client.contactNumber;

                DbContext.SaveChanges();
            }
            return GetClient_QRY().FirstOrDefault(x => x.clientID == dbClient.clientID);
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


        public ClientDTO AddClient(ClientDTO client)
        {

            //DbContext.Clients.Add(new DAL.Client()
            //{
            //    firstname = client.firstname,
            //});

            Client dbClient = new Client();

            dbClient.firstname = client.firstname;
            dbClient.lastname = client.lastname;
            dbClient.adress = client.adress;
            dbClient.email = client.email;
            dbClient.contactNumber = client.contactNumber;

            DbContext.Clients.Add(dbClient);
            DbContext.SaveChanges();
            return GetClient_QRY().FirstOrDefault(x => x.clientID == dbClient.clientID);
        }

        public void deleteClient(int id)
        {

            var res = DbContext.Clients.Find(id);
            DbContext.Clients.Remove(res);
            DbContext.SaveChanges();

        }

        //public string findClientName(int clientId)
        //{
        //    var qry = (from client in DbContext.Clients
        //               where client.clientID == clientId
        //               select client.firstname
        //            );
        //    if (qry == null)
        //    {
        //        return "Client id not in db!!!";
        //    }
            
        //    return qry.FirstOrDefault();
        //}

    }
}
