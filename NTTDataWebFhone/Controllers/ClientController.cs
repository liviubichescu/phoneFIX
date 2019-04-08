using PhoneFix.BLL.Services.Client;
using PhoneFix.BLL.Services.Client.DTO;
using System.Net.Http;
using System.Web.Http;


namespace NTTDataWebFhone.Controllers
{
    public class ClientController:ApiController
    {
        private ClientServices clientSevices = new ClientServices();

        [HttpGet]
        public IHttpActionResult getClients()
        {
            System.Diagnostics.Debug.WriteLine("This is my getClients messaageeeeee!!!!!!!!!!!!! ");
            return Ok(clientSevices.getClients());
        }


        // GET: api/Client/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Client
        [HttpPost]
        public IHttpActionResult Post([FromBody]ClientDTO client)
        {
           System.Diagnostics.Debug.WriteLine("This is my messaageeeeee "+client.firstname+" " + client.lastname);

            clientSevices.addClient(client);
            return Ok(client);

        }

        // PUT: api/Client/5
        public IHttpActionResult Put(int id, [FromBody]ClientDTO client)
        {
            System.Diagnostics.Debug.WriteLine("This is my Put method! Client first name= " + client.firstname +" id = "+id);
            clientSevices.updateClient(id, client);

            return Ok(client);
        }

        // DELETE: api/Client/5
        public IHttpActionResult Delete(int id)
        {
            System.Diagnostics.Debug.WriteLine("This is my Delete method " + id);

            clientSevices.deleteClient(id);

            return Ok("ID client deleted "+id);
        }

    }
}