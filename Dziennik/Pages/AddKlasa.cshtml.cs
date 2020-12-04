using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Dziennik.DAL;
using Dziennik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dziennik.Pages
{
    public class AddKlasaModel : PageModel
    {
        [BindProperty]
        public Klasa klasa { get; set; }
        public MainDatabase mainDatabase = new MainDatabase();
        [BindProperty]
        public ObservableCollection<Nauczyciel> nauczyciele {get;set;}
        public void OnGet()
        {
            nauczyciele = new ObservableCollection<Nauczyciel>();
            nauczyciele = mainDatabase.GetNauczycielAll();
        }
        public IActionResult OnPost()
        {
            mainDatabase.CreateKlasa(klasa);
            return RedirectToPage("/AddKlasa");
        }
    }
}