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
    public class AllSemestryModel : PageModel
    {
        MainDatabase mainDatabase = new MainDatabase();
        public ObservableCollection<Semestr> semestry = new ObservableCollection<Semestr>();

        [BindProperty]
        public Semestr newSemestr { get; set; }

        public void OnGet()
        {
            semestry = mainDatabase.GetSemestryAll();
        }

        public IActionResult OnPost()
        {
            mainDatabase.CreateSemestr(newSemestr);
            return RedirectToPage("AllSemestry");
        }
    }
}