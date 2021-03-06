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

namespace Dziennik.Pages
{
    public class NieobecnosciKlasyModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public NieobecnosciKlasyModel(ApplicationDbContext context)
        {
            _context = context;
        }
        //private MainDatabase mainDatabase = new MainDatabase();
        [BindProperty]
        public ICollection<Konto> uczniowie { get; set; }
        [BindProperty]
        public ICollection<Obecnosc> obecnosci { get; set; }
        public void OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var id = Int32.Parse(claim.Value);
            //uczniowie = mainDatabase.GetUczniowieWychowawca(id);
            //obecnosci = mainDatabase.GetObecnosciAll();
            obecnosci = _context.Obecnosc.ToList();
        }
    }
}