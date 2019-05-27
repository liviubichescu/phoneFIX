using PhoneFix.BLL.Services.AuthService.UserModelDTO;
using PhoneFix.BLL.Services.UserService;
using System.Web.Http;

namespace NTTDataWebFhone.Controllers
{
    public class UserController : ApiController
    {
        private UserService UserService = new UserService();

        [HttpGet]
        public IHttpActionResult GetUsers()
        {
            return Ok(UserService.GetUsers());
        }

        [HttpPost]
        public IHttpActionResult RegisterUser(UserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            UserService.AddUser(user);

            return Ok(user);
        }

    }
}
