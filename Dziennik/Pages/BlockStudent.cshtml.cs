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
    public class BlockStudentModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public BlockStudentModel(ApplicationDbContext context)
        {
            _context = context;
        }
        //MainDatabase mainDatabase = new MainDatabase();
        public IActionResult OnGet(int id, int type)
        {
            if (type == 1)
            {
                //mainDatabase.BlockStudent(id);
                Konto konto = _context.Konto.Find(id);
                konto.active = 2;
                _context.Update(konto);
                _context.SaveChanges();
            }
            else
            {
                //mainDatabase.UnblockStudent(id);
                Konto konto = _context.Konto.Find(id);
                konto.active = 1;
                _context.Update(konto);
                _context.SaveChanges();
            }
            return RedirectToPage("AllUsers");
        }
    }
}