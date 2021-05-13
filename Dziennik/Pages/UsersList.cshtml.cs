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
using Microsoft.EntityFrameworkCore;

namespace Dziennik.Pages
{
    public class UsersListModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public UsersListModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Konto> uczniowie=new List<Konto>();
        public List<Ocena> marks=new List<Ocena>();
        public List<Ocena> marks2=new List<Ocena>();
        [BindProperty]
        public int subjectId { get; set; }
        public int classId { get; set; }
        public void OnGet(int ClassId, int SubjectId)
        {
            subjectId = SubjectId;
            classId = ClassId;
            uczniowie= _context.Konto.Include(x=>x.Oceny).Where(x => x.KlasaId == ClassId).ToList();
            marks2 = _context.Ocena.Include(x=>x.Nauczanie).ToList();
            foreach (Konto u in uczniowie)
            {
                foreach(Ocena o in marks2)
                {
                    if (o.Nauczanie.PrzedmiotId == subjectId&&u.KontoId==o.KontoId) marks.Add(o);
                }
            }
        }
    }
}