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
    public class ObecnosciListModel : PageModel
    {
        public ObservableCollection<Obecnosc> obecnosci = new ObservableCollection<Obecnosc>();
        private MainDatabase mainDatabase = new MainDatabase();
        public ObservableCollection<Przedmiot> przedmioty = new ObservableCollection<Przedmiot>();
        public int uczen_id;
        public int class_id;
        public void OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var id = Int32.Parse(claim.Value);
            uczen_id = id;
            obecnosci = mainDatabase.GetObecnosciUczen(uczen_id);
            przedmioty = mainDatabase.GetPrzedmiotyAll();
        }
    }
}