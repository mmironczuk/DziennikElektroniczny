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
    public class EditPrzedmiotModel : PageModel
    {
        MainDatabase mainDatabase = new MainDatabase();
        [BindProperty]
        public Przedmiot newPrzedmiot { get; set; }

        public string dziedzina { get; set; }
        public string nazwa { get; set; }

        public void OnGet(int id)
        {
            newPrzedmiot = new Przedmiot();
            newPrzedmiot = mainDatabase.GetPrzedmiot(id);
        }

        public IActionResult OnPost(int id)
        {
            if (id == 1) mainDatabase.UpdatePrzedmiot(newPrzedmiot);
            if (id == 2) mainDatabase.DeletePrzedmiot(newPrzedmiot.Id_przedmiotu);
            return RedirectToPage("/AllPrzedmioty");
        }
    }
}