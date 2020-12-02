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
    public class AddMarkModel : PageModel
    {
        public Ocena mark { get; set; }
        public Uczen uczen;
        public Nauczyciel nauczyciel;
        public Przedmiot przedmiot;
        MainDatabase database = new MainDatabase();
        public void OnGet(int id)
        {
            uczen = database.GetUczen(id);
            mark = new Ocena();
            mark.Uczen = uczen;
        }
        public IActionResult OnPost(Ocena mark)
        {
            /*uczen = database.GetUczen(0);
            nauczyciel = database.GetNauczyciel(0);
            przedmiot = database.GetPrzedmiot(0);
            uczen.Ocena.Add(mark);
            nauczyciel.Ocena.Add(mark);*/
            //przedmiot.Ocena.Add(mark);
            database.DodajOcene(mark,0,0,0);
            return RedirectToPage("Index");
        }
    }
}