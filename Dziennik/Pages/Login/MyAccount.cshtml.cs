using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Dziennik.DAL;
using Dziennik.Data;
using Dziennik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dziennik.Pages.Login
{
    public class MyAccountModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public MainDatabase mainDatabase;
        public Konto konto { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string adres { get; set; }
        public string pesel { get; set; }
        public MyAccountModel(ApplicationDbContext context)
        {
            //mainDatabase = new MainDatabase();
            _context = context;
        }
        public void OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.Name);
            var login = claim.Value;
            //konto = mainDatabase.GetKontoLogin(login);
            konto= _context.Konto.Where(x => x.login == login).FirstOrDefault();
            imie = konto.imie;
            nazwisko = konto.nazwisko;
            adres = konto.adres;
            pesel = konto.pesel;
        }
    }
}