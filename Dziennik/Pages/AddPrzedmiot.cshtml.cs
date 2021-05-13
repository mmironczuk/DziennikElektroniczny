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
    public class AddPrzedmiotModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public AddPrzedmiotModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Przedmiot przedmiot { get; set; }
        //public MainDatabase mainDatabase = new MainDatabase();
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            //mainDatabase.CreatePrzedmiot(przedmiot);
            _context.Add(przedmiot);
            _context.SaveChanges();
            return RedirectToPage("/AddPrzedmiot");
        }
    }
}