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
        public IList<Ocena> marks_all;
        public List<Ocena> marks;
        public void OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.Name);
            var login = claim.Value;
            Konto konto = new Konto();
            konto = mainDatabase.GetKontoLogin(login);
            Uczen uczen = new Uczen();
            uczen = mainDatabase.GetUczenKonto(konto.Id_konta);
            id_ucznia = uczen.Id_ucznia;
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