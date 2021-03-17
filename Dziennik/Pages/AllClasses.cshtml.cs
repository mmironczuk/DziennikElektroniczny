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
    public class AllClassesModel : PageModel
    {
        MainDatabase mainDatabase = new MainDatabase();
        public ObservableCollection<Klasa> klasy { get; set; }
        public void OnGet()
        {
            klasy = mainDatabase.GetKlasyAll();
        }
    }
}