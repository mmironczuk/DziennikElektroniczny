using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Dziennik.DAL;
using Dziennik.Data;
using Dziennik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dziennik.Pages
{
    public class AllSemestryModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public AllSemestryModel(ApplicationDbContext context)
        {
            _context = context;
        }
        //MainDatabase mainDatabase = new MainDatabase();
        //public ObservableCollection<Semestr> semestry = new ObservableCollection<Semestr>();
        public ICollection<Semestr> semestry;

        [BindProperty]
        public Semestr newSemestr { get; set; }

        public void OnGet()
        {
            //semestry = mainDatabase.GetSemestryAll();
            semestry = _context.Semestr.ToList();
        }

        public IActionResult OnPost()
        {
            //mainDatabase.CreateSemestr(newSemestr);
            _context.Add(newSemestr);
            _context.SaveChanges();
            return RedirectToPage("AllSemestry");
        }
    }
}