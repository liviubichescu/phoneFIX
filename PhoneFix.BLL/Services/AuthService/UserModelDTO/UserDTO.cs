using System.ComponentModel.DataAnnotations;

namespace PhoneFix.BLL.Services.AuthService.UserModelDTO
{
    public class UserDTO
    {

        public int userID { get; set; }
        //[Required]
        //[Display(Name = "First name")]
        public string firstnname { get; set; }

        //[Required]
        //[Display(Name = "Last name")]
        public string lastname { get; set; }

        //[Required]
        //[Display(Name = "Email")]
        public string email { get; set; }

        //[Required]
        //[Display(Name = "User Name")]
        public string username { get; set; }

        //[Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        //[Display(Name = "Password")]
        public string password { get; set; }

        public int permisionID { get; set; }


    }
}
