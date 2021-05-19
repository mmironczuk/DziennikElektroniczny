using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dziennik.DAL;
using Dziennik.Data;
using Dziennik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dziennik.Pages
{
    public class AddNauczycielModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public AddNauczycielModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Konto konto { get; set; }
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
        public void OnGet()
        {
            konto = new Konto();
            konto.typ_uzytkownika = 2;
            konto.active = 1;
        }
        public IActionResult OnPost(Konto konto, Konto nauczyciel)
        {
            //mainDatabase.CreateKonto(konto);
            ////nauczyciel.Konto.KontoId = konto.Konto;
            //mainDatabase.CreateNauczyciel(nauczyciel);
            string haslo = MD5Hash(konto.haslo);
            konto.haslo = haslo;
            _context.Add(konto);
            _context.SaveChanges();
            return RedirectToPage("/AddNauczyciel");
        }
    }
}