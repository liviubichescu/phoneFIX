using PhoneFix.BLL.Services.AuthService;
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
            var identity = User as ClaimsPrincipal;
            var value = identity.Claims.FirstOrDefault(x => x.Type == "sub").Value;
            System.Diagnostics.Debug.WriteLine("This is my value" + value);
            return Convert.ToInt32(value);
        }

        [Authorize]
        [HttpGet]
        public IHttpActionResult Test()
        {   
            // facem call pe test ar trebui sa avem si id-ul userului care il apeleaza
            int userID = GetUserID();
            System.Diagnostics.Debug.WriteLine("UserID = " + userID);
            return Ok("Works");
        }

        [HttpGet]
        public IHttpActionResult Test1()
        {
            int userID = GetUserID();
            return Ok("Works");
        }


    }
}
