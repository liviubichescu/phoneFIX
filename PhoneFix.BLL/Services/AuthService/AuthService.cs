using PhoneFix.BLL.Services.AuthService.UserModelDTO;
using PhoneFix.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneFix.BLL.Services.AuthService
{
    public class AuthService: BaseService
    {

        public int Login(string username, string password)
        {
            var user = DbContext.Users.FirstOrDefault(x => x.username == username && x.password == password);
            return user == null ? 0 : user.userID;
        }

        public async Task<User> RegisterUser(UserDTO uDto)
        {
            User user = new User
            {
                userID = uDto.userID,
                firstnname = uDto.firstnname,
                lastname = uDto.lastname,
                email = uDto.email,
                username = uDto.username,
                password = uDto.password,
                permisionID = uDto.permisionID
            };

            var result = DbContext.Users.Add(user);
            DbContext.SaveChanges();

            return result;
        }

        public async Task<User> FindUser(string username, string password)
        {
            var db = (from c in DbContext.Users
                      where c.username == username && c.password == password
                      select c).FirstOrDefault();

            return db;
        }



    }
}
