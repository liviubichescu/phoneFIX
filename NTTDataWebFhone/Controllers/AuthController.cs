using PhoneFix.BLL.Services.AuthService;
using PhoneFix.BLL.Services.AuthService.PermisionDTO;
using PhoneFix.BLL.Services.AuthService.RollDTO;
using PhoneFix.BLL.Services.UserService;
using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace NTTDataWebFhone.Controllers
{
    public class AuthController : ApiController
    {

        AuthService AuthService = new AuthService();

        // returneaza id-ul userului logat din DB
        private int GetUserID()
        {
            System.Diagnostics.Debug.WriteLine("This is GetUserID()");
            string value;
            try
            {
                var identity = User as ClaimsPrincipal;
                value = identity.Claims.FirstOrDefault(x => x.Type == "sub").Value;
            }
            catch (Exception ex)
            {
                return 0;
            }
            
            return Convert.ToInt32(value);
        }

        //[Authorize]
        [HttpGet]
        public IHttpActionResult getLogedUser()
        {   
            // facem call pe test ar trebui sa avem si id-ul userului care il apeleaza
            int userID = GetUserID();

            return Ok(AuthService.getLogedUser(userID));
        }

        //[Authorize]
        [HttpGet]
        public IHttpActionResult getUserRoll()
        {
            // facem call pe test ar trebui sa avem si id-ul userului care il apeleaza
            int userID = GetUserID();
            if (userID == 0)
            {
                return Ok(new RollModelDTO());
            }
            
            return Ok(AuthService.getRollForUser(userID));
        }

        //[Authorize]
        [HttpGet]
        public IHttpActionResult getPermisionForUser()
        {
            // facem call pe test ar trebui sa avem si id-ul userului care il apeleaza
            int userID = GetUserID();
            if (userID == 0)
            {
                return Ok(new PermisionModelDTO());
            }

            return Ok(AuthService.getPermisionForUser(userID));
        }
        



        [HttpGet]
        public IHttpActionResult Test1()
        {
            int userID = GetUserID();
            return Ok("Works");
        }
        
    }
}
