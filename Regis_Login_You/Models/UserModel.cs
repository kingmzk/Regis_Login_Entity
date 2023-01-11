using System;
using System.ComponentModel.DataAnnotations;

namespace Regis_Login_You.Models
{
    public class UserModel
    {

        public int UserId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is Required")]
        [Display(Name = "First Name : ")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is Required")]
        [Display(Name = "Last Name : ")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "E-Mail is Required")]
        [Display(Name = "Email : ")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password :  ")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm Password is Required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password :  ")]
        [Compare("Password", ErrorMessage = "Password and ConfirmPassword are Not Matching")]
        public string ConfirmPassword { get; set; }

        public DateTime CreatedOn { get; set; }

        public string SuccessMessage { get; set; }
    }
}