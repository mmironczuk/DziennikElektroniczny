using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Dziennik.DAL;
using Dziennik.Data;
using Dziennik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Dziennik.Pages
{
    public class ListaWydarzenModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public ListaWydarzenModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public List<Wydarzenie> wydarzenia { get; set; }
        [BindProperty]
        public int typ_uzytkownika { get; set; }

        public void OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.Name);
            var login = claim.Value;
            wydarzenia = new List<Wydarzenie>();
            Konto konto = new Konto();
            konto= _context.Konto.Where(x => x.login == login).FirstOrDefault();
            typ_uzytkownika = konto.typ_uzytkownika;
            List<Wydarzenie> wszystkie_wydarzenia = _context.Wydarzenie.Include(x=>x.Nauczania).Include(x=>x.Nauczania.Przedmiot).ToList();
            if (typ_uzytkownika == 3)
            {
                foreach (Wydarzenie w in wszystkie_wydarzenia)
                {
                    if (w.Nauczania.KlasaId == konto.KlasaId)
                    {
                        wydarzenia.Add(w);
                    }
                }
            }
            else if (typ_uzytkownika == 2)
            {
                foreach (Wydarzenie w in wszystkie_wydarzenia)
                {
                    if (w.Nauczania.KontoId == konto.KontoId)
                    {
                        wydarzenia.Add(w);
                    }
                }

            }
        }
    }
}