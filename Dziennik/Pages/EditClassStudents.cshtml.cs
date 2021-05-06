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
    public class EditClassStudentsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditClassStudentsModel(ApplicationDbContext context)
        {
            _context = context;
        }
        //MainDatabase mainDatabase = new MainDatabase();
        [BindProperty]
        public ICollection<Konto> uczniowie { get; set; }
        public void OnGet(int id)
        {
            //uczniowie = new ObservableCollection<Konto>();
            //uczniowie = mainDatabase.GetUczniowieKlasa(id);
            uczniowie= _context.Konto.Where(x => x.KlasaId == id).ToList();
        }
    }
}