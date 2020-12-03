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
    public class AddObecnoscModel : PageModel
    {
        public MainDatabase mainDatabase = new MainDatabase();
        public ObservableCollection<Uczen> uczniowie = new ObservableCollection<Uczen>();
        [BindProperty]
        public int naucz_id { get; set; }
        public void OnGet(int NauczId, int ClassId)
        {
            uczniowie = mainDatabase.GetUczniowieKlasa(ClassId);
        }
    }
}