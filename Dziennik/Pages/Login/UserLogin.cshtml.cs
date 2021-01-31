using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dziennik.DAL;
using Dziennik.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dziennik.Pages.Login
{
    public class UserLoginModel : PageModel
    {
        [BindProperty]
        public string login { get; set; }
        [BindProperty]
        public string password { get; set; }
        public MainDatabase mainDatabase = new MainDatabase();
        public Konto konto = new Konto();
        public void OnGet()
        {

        }
        public int ValidateUser(string log, string pswd)
        {
            int type = -1;
            konto = mainDatabase.GetKontoLogin(log);
            if (konto != null)
            {
                if (konto.haslo == MD5Hash(pswd)) type = konto.typ_uzytkownika;
            }
            return type;
        }

        public static string MD5Hash(string text)
        {
            byte[] hash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(text));
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                strBuilder.Append(hash[i].ToString("X2"));
            }
            return strBuilder.ToString();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            int type = -1;
            int id = 1;
            type = ValidateUser(login, password);
            if (type == 1) id = mainDatabase.GetNauczycielKonto(konto.Id_konta).Id_nauczyciela;
            else if (type == 2) id = mainDatabase.GetUczenKonto(konto.Id_konta).Id_ucznia;
            if (type != -1)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, konto.login),
                    new Claim(ClaimTypes.NameIdentifier, id.ToString())
                };
                var claimsIdentity = new ClaimsIdentity(claims, "CookieAuthentication");
                await HttpContext.SignInAsync("CookieAuthentication", new ClaimsPrincipal(claimsIdentity));
                if (type == 1) return RedirectToPage("/MainNauczyciel");
                if (type == 2) return RedirectToPage("/MainUczen");
                if (type == 0) return RedirectToPage("/AdminPage");
            }
            return Page();
        }
    }
}