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
    public class ObecnosciListModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public ObecnosciListModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Obecnosc> obecnosci = new List<Obecnosc>();
        public List<Przedmiot> przedmioty = new List<Przedmiot>();
        public int uczen_id;
        public int class_id;
        public void OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var id = Int32.Parse(claim.Value);
            uczen_id = id;
            obecnosci= _context.Obecnosc.Include(x=>x.Lekcja.Nauczanie.Przedmiot).Where(x => x.KontoId == id).ToList();
            przedmioty = _context.Przedmiot.ToList();
        }
    }
}