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
    public class WyborKlasyModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public WyborKlasyModel(ApplicationDbContext context)
        {
            _context = context;
        }
        //public MainDatabase mainDatabase = new MainDatabase();
        public int teacher_id { get; set; }
        public ICollection<Nauczanie> nauczania { get; set; }
        public ICollection<Lekcja> lekcje { get; set; }
        public ICollection<Lekcja> lekcje2;
        [BindProperty]
        public int type { get; set; }
        public void OnGet(int TypeId)
        {
            type = TypeId;
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var id = Int32.Parse(claim.Value);
            teacher_id = id;
            nauczania= _context.Nauczanie.Include(x=>x.Przedmiot).Include(x=>x.Klasa).Where(x => x.KontoId == id).ToList();
            lekcje= _context.Lekcja.Where(x => x.data == null).ToList();
            foreach (Nauczanie n in nauczania)
            {
                lekcje2 = new List<Lekcja>();
                foreach (Lekcja l in lekcje)
                {
                    if (n.NauczanieId == l.NauczanieId) lekcje2.Add(l);
                }
                n.Lekcje = lekcje2;
            }
        }
    }
}