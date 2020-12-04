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
    public class DetailsMarkModel : PageModel
    {
        public MainDatabase mainDatabase = new MainDatabase();
        [BindProperty]
        public Ocena ocena { get; set; }
        public void OnGet(int id)
        {
            ocena = new Ocena();
            ocena = mainDatabase.GetOcena(id);
        }
    }
}