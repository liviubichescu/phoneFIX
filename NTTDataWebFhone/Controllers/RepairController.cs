using System.Web.Http;
using PhoneFix.BLL.Services.RepairSheetService;
using PhoneFix.BLL.Services.RepairSheetService.RepairSheetDTO;

namespace NTTDataWebFhone.Controllers
{
    public class RepairController : ApiController
    {
        private RepairService repairService = new RepairService();

        // GET: api/Repair
        [HttpGet]
        public IHttpActionResult GetRepairSheets()
        {
            return Ok(repairService.GetRepairList());
        }
        [HttpGet]
        public IHttpActionResult GetDetailsRepairSheet(int id)
        {
            return Ok(repairService.GetDetailsRepairSheet(id));
        }
        [HttpGet]
        public IHttpActionResult GetRepairSheetUpdateModel(int id)
        {
            return Ok(repairService.GetRepairSheetUpdateModel(id));
        }

        // POST: api/Repair
        [HttpPost]
        public IHttpActionResult PostRepairSheet(RepairSheetPostModel repairSheet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repairService.AddRepairSheet(repairSheet);

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateRepairSheet(int id, RepairSheetPostModel repairSheet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            repairService.UpdateRepairSheet(id, repairSheet);
            return Ok("Service sheeet updated! ");
        }
        
        [HttpDelete]
        public IHttpActionResult DeleteRepairSheet(int id)
        {
            if (id== null)
            {
                return BadRequest();
            }
            repairService.DeleteRepairSheet(id);
            return Ok("Service sheeet deleted! ");
        }
    }
}