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
        public ObservableCollection<Uczen> uczniowie_test = new ObservableCollection<Uczen>();
        private MainDatabase mainDatabase = new MainDatabase();
        public Ocena ocena;
        public IList<Ocena> marks;
        public void OnGet()
        {
            uczniowie_test = mainDatabase.GetUczniowieAll();
            foreach (Uczen u in uczniowie_test)
            {
                marks = mainDatabase.GetOceny(u.Id_ucznia);
                u.Ocena = marks;
            }
        }
    }
}
