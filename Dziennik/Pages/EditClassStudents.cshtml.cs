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
    public class EditClassStudentsModel : PageModel
    {
        MainDatabase mainDatabase = new MainDatabase();
        [BindProperty]
        public ObservableCollection<Uczen> uczniowie { get; set; }
        public void OnGet(int id)
        {
            uczniowie = new ObservableCollection<Uczen>();
            uczniowie = mainDatabase.GetUczniowieKlasa(id);
        }
    }
}