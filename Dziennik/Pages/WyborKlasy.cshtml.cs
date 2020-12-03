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
    public class WyborKlasyModel : PageModel
    {
        public MainDatabase mainDatabase = new MainDatabase();
        public int teacher_id { get; set; }
        public ObservableCollection<Nauczanie> nauczania { get; set; }
        public IList<Lekcja> lekcje;
        public void OnGet()
        {
            nauczania = new ObservableCollection<Nauczanie>();
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.Name);
            var login = claim.Value;
            Konto konto =new Konto();
            konto = mainDatabase.GetKontoLogin(login);
            teacher_id = mainDatabase.GetNauczycielKonto(konto.Id_konta).Id_nauczyciela;
            nauczania = mainDatabase.GetNauczaniaNauczyciel(teacher_id);
            foreach(Nauczanie n in nauczania)
            {
                n.Lekcja = mainDatabase.GetLekcjeNauczanie(n.Id_nauczania);
            }
        }
    }
}