using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dziennik.DAL;
using Dziennik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dziennik.Pages
{
    public class EditObecnoscModel : PageModel
    {
        [BindProperty]
        public Obecnosc obecnosc { get; set; }
        private MainDatabase mainDatabase = new MainDatabase();
        public void OnGet(int id)
        {
            obecnosc = mainDatabase.GetObecnosc(id);
        }
        public IActionResult OnPost(int id)
        {
            if (id == 1) mainDatabase.UpdateObecnosc(obecnosc);
            else if (id == 2) mainDatabase.DeleteObecnosc(obecnosc.Id_obecnosci);
            return RedirectToPage("/NieobecnosciKlasy");
        }
    }
}