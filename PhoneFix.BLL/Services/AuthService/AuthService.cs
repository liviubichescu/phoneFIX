using PhoneFix.BLL.Services.AuthService.PermisionDTO;
using PhoneFix.BLL.Services.AuthService.RollDTO;
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
                ID_Roll = uDto.ID_Roll
            };

            var result =  DbContext.Users.Add(user);
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

        public UserDisplayDTO getLogedUser(int id)
        {
            var user = DbContext.Users.Find(id);
            if (user == null)
                return null;

            return new UserDisplayDTO
            {
                firstnname = user.firstnname,
                lastname = user.lastname,
                email = user.email
            };
        }

        public RollModelDTO getRollForUser(int userID)
        {

            var rolle = (from user in DbContext.Users
                             join roll in DbContext.Rolls on user.ID_Roll equals roll.ID_Roll
                             where user.userID == userID
                             select roll).FirstOrDefault();
            if (rolle != null)
            {
                return new RollModelDTO
                {
                    ID_Roll = rolle.ID_Roll,
                    Name = rolle.Name,
                    permisionID = rolle.permisionID

                };
            }
            return null;            
        }

        public PermisionModelDTO getPermisionForUser(int userID)
        {

            var permission = (from user in DbContext.Users
                        join roll in DbContext.Rolls on user.ID_Roll equals roll.ID_Roll
                        where user.userID == userID
                        select roll).FirstOrDefault();
            if (permission != null)
            {
                var perms = (from perm in DbContext.Permisions
                             join roll in DbContext.Rolls on perm.permisionID equals roll.permisionID
                             where perm.permisionID == permission.permisionID
                             select perm).FirstOrDefault();

                return new PermisionModelDTO
                {
                    permisionID = perms.permisionID,
                    viewClients = perms.viewClients,
                    viewPhones = perms.viewPhones,
                    viewService = perms.viewService,
                    viewRepair = perms.viewRepair,
                    addClient = perms.addClient,
                    addPhones = perms.addPhones,
                    addService = perms.addService,
                    addRepair = perms.addRepair
                };
            }
            return null;
            
        }

    }
}
