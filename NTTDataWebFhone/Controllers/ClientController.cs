
using PhoneFix.BLL.Services.ClientModelDTO;
using PhoneFix.BLL.Services.ClientService;
using System.Web.Http;


namespace NTTDataWebFhone.Controllers
{
    [Authorize]
    public class ClientController : ApiController
    {
        private ClientServices clientSevices = new ClientServices();

        
        [HttpGet]
        public IHttpActionResult getClients([FromUri] string filter)
        {
            //System.Diagnostics.Debug.WriteLine("This is my getClients messaageeeeee!! + my filter = " + filter);
            return Ok(clientSevices.getClients(filter));
        }

        // POST: api/Client
        [HttpPost]
        public IHttpActionResult PostClient([FromBody]ClientDTO client)
        {
           //System.Diagnostics.Debug.WriteLine("This is my messaageeeeee "+client.firstname+" " + client.lastname);

            return Ok(clientSevices.AddClient(client));

        }

        // PUT: api/Client/5
        public IHttpActionResult Put(int id, [FromBody]ClientDTO client)
        {
            //System.Diagnostics.Debug.WriteLine("This is my Put method! Client first name= " + client.firstname +" id = "+id);
            clientSevices.updateClient(id, client);

            return Ok(client);
        }

        // DELETE: api/Client/5
        public IHttpActionResult Delete(int id)
        {
            //System.Diagnostics.Debug.WriteLine("This is my Delete method " + id);

            clientSevices.deleteClient(id);

            return Ok("ID client deleted "+id);
        }

    }
}