using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Dziennik.DAL;
using Dziennik.Data;
using Dziennik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dziennik.Pages
{
    public class AddKlasaModel : PageModel
    {
        [BindProperty]
        public Klasa klasa { get; set; }
        //public MainDatabase mainDatabase = new MainDatabase();
        private readonly ApplicationDbContext _context;
        public AddKlasaModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public ICollection<Konto> nauczyciele {get;set;}
        public void OnGet()
        {
            //nauczyciele = mainDatabase.GetNauczycielAll();
            nauczyciele= _context.Konto.Where(x => x.typ_uzytkownika == 2).ToList();
        }
        public IActionResult OnPost()
        {
            //mainDatabase.CreateKlasa(klasa);
            _context.Add(klasa);
            _context.SaveChanges();
            return RedirectToPage("/AddKlasa");
        }
    }
}