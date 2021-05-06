using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dziennik.DAL;
using Dziennik.Data;
using Dziennik.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dziennik.Pages.Login
{
    public class ZmienDaneModel : PageModel
    {
        //private MainDatabase db = new MainDatabase();
        private readonly ApplicationDbContext _context;
        public ZmienDaneModel(ApplicationDbContext context)
        {
            _context = context;
        }
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

        public void OnGet(int id)
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.Name);
            login = claim.Value.ToString();
            this.typUzytkownika = id;
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

        public IActionResult OnPost(int id)
        {
            //Konto konto = db.GetKontoLogin(login);
            Konto konto = _context.Konto.Where(x => x.login == login).FirstOrDefault();
            if (id == 1)
            {
                //if (konto.haslo == MD5Hash(passwordOld) && password == passwordConfirm) db.UpdatePassword(login, MD5Hash(password));
                if (konto.haslo == MD5Hash(passwordOld) && password == passwordConfirm)
                {
                    //db.UpdateEmail(login, MD5Hash(password));
                    Konto k = _context.Konto.Where(x => x.login == login).FirstOrDefault();
                    k.haslo = MD5Hash(password);
                    _context.Update(k);
                    _context.SaveChanges();
                }
                else return Page();
            }
            else
            {
                if (email == emailConfirm)
                {
                    //db.UpdateEmail(login, email);
                    Konto k = _context.Konto.Where(x => x.login == login).FirstOrDefault();
                    k.email = email;
                    _context.Update(k);
                    _context.SaveChanges();
                }
            }
            return RedirectToPage("./MyAccount");
        }
    }
}
