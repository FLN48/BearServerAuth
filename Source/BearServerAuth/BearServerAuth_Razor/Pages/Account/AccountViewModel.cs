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
        [EmailAddress(ErrorMessage = "Не верный формат Email")]
        [Required(ErrorMessage = "Данное поле обязательно.")]
        public string Email { get; set; } = "";
        [DataType(DataType.Password, ErrorMessage = "Не верный формат Пароля")]
        [Required(ErrorMessage = "Данное поле обязательно.")]
        public string Password { get; set; } = "";
    }
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Данное поле обязательно.")]
        [StringLength(30, ErrorMessage = "Длина Логина должна быть не менее {2} и не более {1} символов.", MinimumLength = 5)]
        [DataType(DataType.Text)]
        public string Login { get; set; } = "";
        [Required(ErrorMessage = "Данное поле обязательно.")]
        [EmailAddress(ErrorMessage = "Не верный формат Email")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Данное поле обязательно.")]
        [StringLength(100, ErrorMessage = "Длина пароля должна быть не менее {2} и не более {1} символов.", MinimumLength = 6)]
        [DataType(DataType.Password, ErrorMessage = "Не верный формат Пароля")]
        public string Password { get; set; } = "";

        [Required(ErrorMessage = "Данное поле обязательно.")]
        [DataType(DataType.Password, ErrorMessage = "Не верный формат Пароля")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        public string ConfirmPassword { get; set; } = "";
    }
}
