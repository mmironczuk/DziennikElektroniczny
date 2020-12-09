using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;
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
        public int id_ucznia;
        public ObservableCollection<Ocena> marks_all = new ObservableCollection<Ocena>();
        public List<Ocena> marks;
        public void OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var id = Int32.Parse(claim.Value);
            //Uczen uczen = new Uczen();
            //uczen = mainDatabase.GetUczenKonto(id);
            id_ucznia = id;
            przedmioty = mainDatabase.GetPrzedmiotyAll();
            marks_all = mainDatabase.GetOcenyAll();
            foreach (Przedmiot p in przedmioty)
            {
                marks = new List<Ocena>();
                foreach(Ocena o in marks_all)
                {
                    if (o.Uczen.Id_ucznia == id_ucznia&&o.Przedmiot.Id_przedmiotu==p.Id_przedmiotu) marks.Add(o);
                }
                p.Ocena = marks;
            }
        }
    }
}