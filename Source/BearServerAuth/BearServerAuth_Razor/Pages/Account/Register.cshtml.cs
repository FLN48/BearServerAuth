// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace BearServerAuth.Pages
{
    public class RegisterModel : PageModel
    {
        private MainDataContext db;
        private readonly ILogger<RegisterModel> m_logger;
        public RegisterViewModel m_viewModel { get; set; }
        public RegisterModel(ILogger<RegisterModel> logger, MainDataContext context)
        {
            m_logger = logger;
            db = context;
            m_viewModel = new RegisterViewModel();
        }


        public async Task OnGetAsync(string returnUrl = null)
        {

        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            return Page();
        }

    }
}
