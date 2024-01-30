using System.ComponentModel.DataAnnotations;

namespace BearServerAuth.Pages
{
    public class AccountViewModel
    {
        public LoginViewModel loginViewModel { get; set; }
        public RegisterViewModel registerViewModel { get; set; }   
    }
    public class LoginViewModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "Данное поле обязательно.")]
        public string Email { get; set; } = "";
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Данное поле обязательно.")]
        public string Password { get; set; } = "";
    }
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Данное поле обязательно.")]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Данное поле обязательно.")]
        [StringLength(100, ErrorMessage = "Длина пароля должна быть не менее {2} и не более {1} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";

        [Required(ErrorMessage = "Данное поле обязательно.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Ппроли не совпадают.")]
        public string ConfirmPassword { get; set; } = "";
    }
}
