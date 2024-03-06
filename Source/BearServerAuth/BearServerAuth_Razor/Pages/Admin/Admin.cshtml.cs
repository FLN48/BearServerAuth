using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BearServerAuth.Pages.Admin
{
    public class AdminModel : PageModel
    {
        private MainDataContext db;
        private readonly ILogger<LoginModel> m_logger;
        public LoginViewModel m_viewModel { get; set; }
        public AdminModel(ILogger<LoginModel> _logger, MainDataContext context)
        {
            m_logger = _logger;
            db = context;
            m_viewModel = new LoginViewModel();
        }
        public void OnGet()
        {
        }
    }
}
