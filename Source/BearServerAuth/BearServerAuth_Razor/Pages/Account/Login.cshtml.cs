// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace BearServerAuth.Pages
{
    public class LoginModel : PageModel
    {
        private MainDataContext db;
        private readonly ILogger<LoginModel> m_logger;
        private readonly IPasswordHasher<User> m_passwordHasher;
        public LoginViewModel m_viewModel { get; set; }
        public LoginModel(ILogger<LoginModel> _logger, MainDataContext context)
        {
            m_logger = _logger;
            m_passwordHasher = new PasswordHasher<User>();
            db = context;
            m_viewModel = new LoginViewModel();
        }
        #region Методы
         
        public async Task OnGetAsync(string returnUrl = null)
        {
            
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            var form = HttpContext.Request.Form;

            string email = form["m_viewModel.email"];
            string password = form["m_viewModel.password"];

            User? person = db.Users
                .Include(a=>a.Account)
                    .ThenInclude(r=>r.Role)
                .FirstOrDefault(p => p.UserEmail == email);
            
            var hasedPassword = m_passwordHasher.VerifyHashedPassword(null, person.UserPasswordHash, password);
            // находим пользователя 
            
            // если пользователь не найден, отправляем статусный код 401
            if (person is null)
                return (IActionResult) Results.Unauthorized();
            // если пользователь найден, но пароль не верен отправляем статусный код 403
            if (hasedPassword != PasswordVerificationResult.Success)
                return (IActionResult)Results.StatusCode(403);
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.UserEmail),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Account.Role.RoleName),
                    new Claim("Login", person.UserLogin)
                };
            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(claimsPrincipal);       
            return Redirect("/Index");
        }
        #endregion


    }
}
