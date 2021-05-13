using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dziennik.DAL;
using Dziennik.Data;
using Dziennik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dziennik.Pages
{
    public class ObecnoscHelperModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public ObecnoscHelperModel(ApplicationDbContext context)
        {
            _context = context;
        }
        //public MainDatabase mainDatabase = new MainDatabase();
        public IActionResult OnGet(int UczenId, int LekcjaId, int ob)
        {
            Obecnosc obecnosc = new Obecnosc();
            obecnosc.KontoId = UczenId;
            obecnosc.LekcjaId = LekcjaId;
            obecnosc.typ_obecnosci = ob;
            //mainDatabase.CreateObecnosc(obecnosc);
            _context.Add(obecnosc);
            _context.SaveChanges();
            return RedirectToPage("/AddObecnosc", new { LekcjaId = LekcjaId });
        }
    }
}