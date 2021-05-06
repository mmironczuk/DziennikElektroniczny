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
    public class UsersListModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public UsersListModel(ApplicationDbContext context)
        {
            _context = context;
        }
        //public ObservableCollection<Konto> uczniowie = new ObservableCollection<Konto>();
        public ICollection<Konto> uczniowie;
        //private MainDatabase mainDatabase = new MainDatabase();
        public ICollection<Ocena> marks;
        public ICollection<Ocena> marks2;
        [BindProperty]
        public int subjectId { get; set; }
        public int classId { get; set; }
        public void OnGet(int ClassId, int SubjectId)
        {
            subjectId = SubjectId;
            classId = ClassId;
            //uczniowie = mainDatabase.GetUczniowieKlasa(ClassId);
            uczniowie= _context.Konto.Where(x => x.KlasaId == ClassId).ToList();
            marks2 = _context.Ocena.ToList();
            //marks2 = mainDatabase.GetOcenyAll();
            foreach (Konto u in uczniowie)
            {
                foreach(Ocena o in marks2)
                {
                    if (o.Nauczanie.PrzedmiotId == subjectId&&u.KontoId==o.KontoId) marks.Add(o);
                }
                //u.Ocena = marks;
            }
        }
    }
}