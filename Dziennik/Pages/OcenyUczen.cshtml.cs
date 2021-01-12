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
        public void OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var id = Int32.Parse(claim.Value);
            id_ucznia = id;
            przedmioty = mainDatabase.GetPrzedmiotyAll();
        }
    }
}