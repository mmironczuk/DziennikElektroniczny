using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Dziennik.DAL;
using Dziennik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dziennik.Pages
{
    public class UsersListModel : PageModel
    {
        public ObservableCollection<Uczen> uczniowie = new ObservableCollection<Uczen>();
        private MainDatabase mainDatabase = new MainDatabase();
        public List<Ocena> marks;
        public ObservableCollection<Ocena> marks2;
        [BindProperty]
        public int subjectId { get; set; }
        public int classId { get; set; }
        public void OnGet(int ClassId, int SubjectId)
        {
            subjectId = SubjectId;
            classId = ClassId;
            uczniowie = mainDatabase.GetUczniowieKlasa(ClassId);
            marks2 = mainDatabase.GetOcenyAll();
            foreach (Uczen u in uczniowie)
            {
                marks = new List<Ocena>();
                foreach(Ocena o in marks2)
                {
                    if (o.Przedmiot.Id_przedmiotu == subjectId&&u.Id_ucznia==o.Uczen.Id_ucznia) marks.Add(o);
                }
                u.Ocena = marks;
            }
        }
    }
}