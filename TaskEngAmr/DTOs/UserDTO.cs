using System.ComponentModel.DataAnnotations;

namespace TaskEngAmr.DTOs
{
    public class UserDTO
    {
        public class Register
        {
            [Required(ErrorMessage ="Username Is Required")]
            public string UserName { get; set; }
            [Required(ErrorMessage = "Email Is Required")]
            public string Email { get; set; }
            [Required(ErrorMessage = "Email Is Required")]
            public string PhoneNumber { get; set; }
            [Required(ErrorMessage = "Password is required")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required(ErrorMessage = "Confirm Password is required")]
            [DataType(DataType.Password)]
            [Compare("Password")]
            public string ConfirmPassword { get; set; }
        }
        public class LoginResult
        {
            public string Id { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string Token{ get; set; }

        }
        public class Login
        {
            public string UserNameOrEmail { get; set; }
            public string Password{ get; set; }
        }
        public class Get
        {
            public string Id { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
        }
    }
}
