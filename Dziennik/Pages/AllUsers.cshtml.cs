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
    public class AllUsersModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public AllUsersModel(ApplicationDbContext context)
        {
            _context = context;
        }
        //MainDatabase mainDatabase = new MainDatabase();
        //public ObservableCollection<Konto> uczniowie = new ObservableCollection<Konto>();
        public List<Konto> uczniowie=new List<Konto>();

        [BindProperty]
        public string findUser { get; set; }
        public void OnGet(string imie)
        {
            //ObservableCollection<Konto> uczniowieCopy = mainDatabase.GetUczniowieAll();
            List<Konto> uczniowieCopy= _context.Konto.Where(x => x.typ_uzytkownika == 3).ToList();

            if (imie != null)
            {
                foreach(Konto k in uczniowieCopy)
                {
                    if ((k.imie + " " + k.nazwisko).Contains(imie) ||
                        (k.nazwisko + " " + k.imie).Contains(imie)) uczniowie.Add(k);
                }
            }
            else uczniowie = uczniowieCopy;
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("AllUsers", new { imie = findUser });
        }
    }
}