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
    public class EditWydarzeniaModel : PageModel
    {
        [BindProperty]
        public Wydarzenie wydarzenie { get; set; }
        public MainDatabase mainDatabase = new MainDatabase();

        public void OnGet(int id)
        {
            wydarzenie = mainDatabase.GetWydarzenie(id);
        }

        public IActionResult OnPost(int id)
        {
            if (id == 1) mainDatabase.UpdateWydarzenie(wydarzenie);
            else if (id == 2) mainDatabase.DeleteWydarzenie(wydarzenie.Id_wydarzenia);
            return RedirectToPage("/ListaWydarzen");
        }
    }
}