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
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
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
            
            var form = HttpContext.Request.Form;
            
            m_viewModel = new RegisterViewModel()
            {
                ConfirmPassword = form["m_viewModel.confirmpassword"],
                Email = form["m_viewModel.email"],
                Login = form["m_viewModel.login"],
                Password = form["m_viewModel.password"]
            };

            User? person = db.Users
                .Include(a => a.Account)
                    .ThenInclude(r => r.Role)
                .FirstOrDefault(p => p.UserEmail == m_viewModel.Email);
            if (person != null)
            {
                ModelState.AddModelError("m_viewModel.email", "Пользователь с такой почтой уже зарегистрирован");
                return Page();
            }

            Guid guid = Guid.NewGuid();
            string user_guid = Guid.NewGuid().ToString();
            string user_security_stamp = Guid.NewGuid().ToString();
            string user_concurency_stamp = Guid.NewGuid().ToString();

            var user = new User
            {
                UserId = user_guid,
                UserLogin = m_viewModel.Login,
                UserEmail = m_viewModel.Email,
                SecurityStamp = user_security_stamp,
                ConcurrencyStamp = user_concurency_stamp,
                UserWorking = true,
                UserEmailConfirmed = true
            };
            user.UserPasswordHash = new PasswordHasher<User>().HashPassword(user, m_viewModel.Password);

            user.AddSimpleUser(db);

            return RedirectToPage("Login");
        }

    }
}
