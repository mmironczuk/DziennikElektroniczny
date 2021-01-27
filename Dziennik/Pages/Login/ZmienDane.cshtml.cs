using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Dziennik.DAL;
using Dziennik.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dziennik.Pages.Login
{
    public class ZmienDaneModel : PageModel
    {
        private MainDatabase db = new MainDatabase();

		[BindProperty]
        public string passwordOld { get; set; }
        [BindProperty]
        public string password { get; set; }
        [BindProperty]
        public string passwordConfirm { get; set; }
        [BindProperty]
        public string email { get; set; }
        [BindProperty]
        public string emailConfirm { get; set; }

        [BindProperty]
        public string login { get; set; }

        [BindProperty]
        public int typUzytkownika { get; set; }

        public void OnGet(int typUzytkownika)
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.Name);
            login = claim.Value.ToString();
            this.typUzytkownika = typUzytkownika;
        }

        public IActionResult OnPost(int id)
        {
            if (id == 1 && password == passwordConfirm)
            {
                var passwordHasher = new PasswordHasher<string>();
                string hashOld = passwordHasher.HashPassword(login, passwordOld).Substring(0, 32);
                //string hashCurrent = db.GetHasloLogin(login);
                Konto konto = db.GetKontoLogin(login);
                if (passwordHasher.VerifyHashedPassword(null, konto.haslo, hashOld) == PasswordVerificationResult.Success)
                {
                    db.UpdatePassword(login, password);
                }
                else
                {
                    return Page();
                }
            }
            else
            {
                if (email == emailConfirm)
                {
                    db.UpdateEmail(login, email);
                }
            }
            return RedirectToPage("./MyAccount");
        }
    }
}
