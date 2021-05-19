using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dziennik.DAL;
using Dziennik.Data;
using Dziennik.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dziennik.Pages.Login
{
    public class UserLoginModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public UserLoginModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public string login { get; set; }
        [BindProperty]
        public string password { get; set; }
        public Konto konto = new Konto();
        public void OnGet()
        {

        }
        public int ValidateUser(string log, string pswd)
        {
            //konto.login = log;
            //konto.haslo = MD5Hash(pswd);
            //konto.typ_uzytkownika = 1;
            //konto.active = 1;
            //_context.Add(konto);
            //_context.SaveChanges();
            //return 1;
            int type = -1;
            //konto = mainDatabase.GetKontoLogin(log);
            konto = _context.Konto.Where(x => x.login == login).FirstOrDefault();
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
            type = ValidateUser(login, password);
            int id = 0;
            if(konto!=null) id = konto.KontoId;
            if (type != -1 && konto.active==1)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, konto.login),
                    new Claim(ClaimTypes.NameIdentifier, id.ToString())
                };
                var claimsIdentity = new ClaimsIdentity(claims, "CookieAuthentication");
                await HttpContext.SignInAsync("CookieAuthentication", new ClaimsPrincipal(claimsIdentity));
                if (type == 2) return RedirectToPage("/MainNauczyciel");
                if (type == 3) return RedirectToPage("/MainUczen");
                if (type == 1) return RedirectToPage("/AdminPage");
            }
            return Page();
        }
    }
}