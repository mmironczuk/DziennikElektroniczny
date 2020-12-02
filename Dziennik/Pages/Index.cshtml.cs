using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Dziennik.DAL;
using Dziennik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Oracle.ManagedDataAccess.Client;

namespace TestApp2.Pages
{
    public class IndexModel : PageModel
    {
        public ObservableCollection<Uczen> uczniowie = new ObservableCollection<Uczen>();
        private MainDatabase mainDatabase = new MainDatabase();
        public IList<Ocena> marks;
        public IActionResult OnGet()
        {
            uczniowie= mainDatabase.GetUczniowieAll();
            foreach (Uczen u in uczniowie)
            {
                marks = mainDatabase.GetOcenyUczen(u.Id_ucznia);
                u.Ocena = marks;
            }
            return RedirectToPage("/Login/UserLogin");
        }
    }
}
