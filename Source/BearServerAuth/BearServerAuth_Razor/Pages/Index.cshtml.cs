using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BearServerAuth.Pages
{
    public class IndexModel : PageModel
    {
        private MainDataContext db;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, MainDataContext context)
        {
            _logger = logger;
            db = context;
        }

        public void OnGet()
        {
        
        }
    }
}