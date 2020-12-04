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
    public class DetailsObecnoscModel : PageModel
    {
        public MainDatabase mainDatabase = new MainDatabase();
        public Obecnosc obecnosc;
        public void OnGet(int id)
        {
            obecnosc = mainDatabase.GetObecnosc(id);
        }
    }
}