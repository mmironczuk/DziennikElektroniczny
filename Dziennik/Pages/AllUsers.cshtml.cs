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
    public class AllUsersModel : PageModel
    {
        MainDatabase mainDatabase = new MainDatabase();
        public ObservableCollection<Uczen> uczniowie = new ObservableCollection<Uczen>();

        [BindProperty]
        public string findUser { get; set; }
        public void OnGet(string imie)
        {
            ObservableCollection<Uczen> uczniowieCopy = mainDatabase.GetUczniowieAll();

            if (imie != null)
            {
                for (int i = 0; i < uczniowieCopy.Count; i++)
                {
                    if ((uczniowieCopy[i].imie + " " + uczniowieCopy[i].nazwisko).Contains(imie) ||
                        (uczniowieCopy[i].nazwisko + " " + uczniowieCopy[i].imie).Contains(imie)) uczniowie.Add(uczniowieCopy[i]);
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