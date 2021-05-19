using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dziennik.DAL;
using Dziennik.Data;
using Dziennik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Dziennik.Pages
{
    public class DetailsObecnoscModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public DetailsObecnoscModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public Obecnosc obecnosc;
        public void OnGet(int id)
        {
            obecnosc = _context.Obecnosc.Include(x=>x.Lekcja).Where(x=>x.ObecnoscId==id).FirstOrDefault();
        }
    }
}