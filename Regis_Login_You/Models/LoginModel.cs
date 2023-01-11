using System.ComponentModel.DataAnnotations;

namespace Regis_Login_You.Models
{
    public class LoginModel
    {


        [Required(AllowEmptyStrings = false, ErrorMessage = "E-Mail is Required")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]

        public string Password { get; set; }


    }
}