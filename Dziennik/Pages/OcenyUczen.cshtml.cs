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
    public class OcenyUczenModel : PageModel
    {
        public ObservableCollection<Przedmiot> przedmioty = new ObservableCollection<Przedmiot>();
        private MainDatabase mainDatabase = new MainDatabase();
        public int id_ucznia = 0;
        public IList<Ocena> marks_all;
        public List<Ocena> marks;
        public void OnGet()
        {
            przedmioty = mainDatabase.GetPrzedmiotyAll();
            foreach(Przedmiot p in przedmioty)
            {
                marks = new List<Ocena>();
                marks_all = mainDatabase.GetOcenyPrzedmiot(p.Id_przedmiotu);
                foreach(Ocena o in marks_all)
                {
                    if (o.Uczen.Id_ucznia == id_ucznia) marks.Add(o);
                }
                p.Ocena = marks;
            }
        }
    }
}