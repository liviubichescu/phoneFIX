using System.Web.Http;
using PhoneFix.BLL.Services.ServSheetService;
using PhoneFix.BLL.Services.ServSheetService.ServSheetModelDTO;

namespace NTTDataWebFhone.Controllers
{
    //[Authorize]
    public class ServiceSheetsController : ApiController
    {

        private ServSheetServices serviceSheetService = new ServSheetServices();


        [HttpGet]
        public IHttpActionResult GetServiceSheetList()
        {
            return Ok(serviceSheetService.GetServiceSheetList());
        }

        [HttpGet]
        public IHttpActionResult GetDetailServiceSheet(int id)
        {
            return Ok(serviceSheetService.GetDetailsServiceSheet(id));
        }


        [HttpPut]
        public IHttpActionResult UpdateServiceSheet(int id, ServSheetDTO sheetDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            serviceSheetService.UpdateServiceSheet(id, sheetDto);
            return Ok("Service sheeet updated! ");
        }


        [HttpPost]
        public IHttpActionResult AddServiceSheet(ServSheetBaseDTO serviceSheetDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //System.Diagnostics.Debug.WriteLine("This is my AddServiceSheet() messaageeeeee!!!! " + serviceSheetDto);

            serviceSheetService.AddServiceSheet(serviceSheetDto);

            return Ok("Service sheet added succesfully");
        }

        // DELETE: api/Phone/5
        [HttpDelete]
        public IHttpActionResult DeleteServiceSheet(int id)
        {
            //System.Diagnostics.Debug.WriteLine("This is my DeleteServiceSheet() messaageeeeee!!!! " + id);

            serviceSheetService.DeleteServiceSheet(id);

            return Ok("Deleted the Service sheet with id = " + id);
        }


        // GET: api/GetClientPhones/5
        [HttpGet]
        public IHttpActionResult GetServiceSheetByClientId(int id)
        {
            //System.Diagnostics.Debug.WriteLine("This is my GetServiceSheetByClientId() messaageeeeee!!!! and id = " + id);

            return Ok(serviceSheetService.GetServiceSheetByPhoneId(id));
        }

        //// method for finding a client name based on my client ID
        //// GET: api/GetClientNameByClientId/5
        //[HttpGet]
        //public IHttpActionResult GetClientNameByClientId(int id)
        //{
        //    System.Diagnostics.Debug.WriteLine("This is my GetClientNameByClientId() messaageeeeee!!!! and id = " + id
        //    return Ok(serviceSheetService.findClientName(id));
        //}
    }
}