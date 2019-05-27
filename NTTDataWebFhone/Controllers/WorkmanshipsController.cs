using System.Collections.Generic;
using System.Web.Http;
using PhoneFix.BLL.Services.WorkmanshipService;

namespace NTTDataWebFhone.Controllers
{
    public class WorkmanshipController : ApiController
    {
        private WorkmanshipService service = new WorkmanshipService();

        // GET: api/Workmanships
        [HttpGet]
        public IEnumerable<WorkmanshipGetModel> GetWorkmanships()
        {
            return service.GetWorkmanships();
        }

        [HttpGet]
        public WorkmanshipGetModel GetWorkmanship(int id)
        {
            return service.GetWorkmanship(id);
        }


        // POST: api/Workmanships
        [HttpPost]
        public IHttpActionResult PostWorkmanship(WorkmanshipPostModel workmanship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.AddWorkmanship(workmanship);


            return Ok(workmanship);
        }

        [HttpPut]
        public IHttpActionResult UpdateWorkmanship(int id, WorkmanshipPostModel workmanship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.UpdateWorkmanship(id, workmanship);


            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult RemoveWorkmanship(int id)
        {
           
            if (id==null)
            {
                return BadRequest(ModelState);
            }

            service.RemoveWorkmanship(id);
            
            return Ok();
        }



    }
}