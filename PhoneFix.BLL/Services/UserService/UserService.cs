using PhoneFix.BLL.Services.AuthService.UserModelDTO;
using PhoneFix.DAL;
using System.Collections.Generic;
using System.Linq;

namespace PhoneFix.BLL.Services.UserService
{
    public class UserService : BaseService
    {

        public IEnumerable<UserDTO> GetUsers()
        {
            var users = DbContext.Users.Select( user => new UserDTO()
            {
                userID = user.userID,
                firstnname = user.firstnname,
                lastname = user.lastname,
                email = user.email,
                username = user.username,
                password = user.password,
                ID_Roll =  user.ID_Roll
            });
            return users.ToList();
        }

    
        public void AddUser(UserDTO userdto)
        {
            if (userdto == null)
                return;
            User user = new User()
            {
                firstnname = userdto.firstnname,
                lastname = userdto.lastname,
                email = userdto.email,
                username = userdto.username,
                password = userdto.password

            };
            DbContext.Users.Add(user);
            DbContext.SaveChanges();

        }

        
    }

}
