using System.Net;
using System.Web.Http;
using PhoneFix.BLL.Services.PhoneService;

namespace NTTDataWebFhone.Controllers
{
    [Authorize]
    public class PhonesController : ApiController
    {

        private PhoneServices phoneServices = new PhoneServices();


        // GET: api/Phones
        [HttpGet]
        public IHttpActionResult GetPhones()
        {
            System.Diagnostics.Debug.WriteLine("This is my GetPhones() messaageeeeee!!!! ");
            return Ok(phoneServices.GetPhones());
        }

        // GET: api/Phone/5
        [HttpGet]
        public IHttpActionResult GetOnePhone(int id)
        {
            System.Diagnostics.Debug.WriteLine("This is my GetOnePhone() messaageeeeee!!!! ");
            return Ok(phoneServices.findPhoneById(id));
        }


        // PUT: api/Phone/5
        [HttpPut]
        public IHttpActionResult UpdatePhone(int id, PhoneDTO phoneDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            System.Diagnostics.Debug.WriteLine("This is my UpdatePhone() messaageeeeee!!! "+id+" phone = "+phoneDto);

            phoneServices.UpdatePhone(id, phoneDto);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Phone
        [HttpPost]
        public IHttpActionResult AddPhone(PhoneDTO phoneDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            System.Diagnostics.Debug.WriteLine("This is my AddPhone() messaageeeeee!!!! "+phoneDto);

            phoneServices.AddPhone(phoneDto);

            return Ok(phoneDto);
        }

        // DELETE: api/Phone/5
        [HttpDelete]
        public IHttpActionResult DeletePhone(int id)
        {
            System.Diagnostics.Debug.WriteLine("This is my DeletePhone() messaageeeeee!!!! " + id);

            phoneServices.DeletePhone(id);

            return Ok("Deleted the phone with id = " + id);
        }


        // GET: api/GetClientPhones/5
        [HttpGet]
        public IHttpActionResult GetClientPhones(int id)
        {
            System.Diagnostics.Debug.WriteLine("This is my GetClientPhones() messaageeeeee!!!! and id = "+id);

            

            return Ok(phoneServices.GetClientPhones(id));
        }

    }
}