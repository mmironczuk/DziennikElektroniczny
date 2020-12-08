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
        public IList<Ocena> marks2;
        [BindProperty]
        public int subjectId { get; set; }
        public void OnGet(int ClassId, int SubjectId)
        {
            subjectId = SubjectId;
            uczniowie = mainDatabase.GetUczniowieKlasa(ClassId);
            foreach (Uczen u in uczniowie)
            {
                marks = new List<Ocena>();
                marks2 = mainDatabase.GetOcenyUczen(u.Id_ucznia);
                foreach(Ocena o in marks2)
                {
                    if (o.Przedmiot.Id_przedmiotu == subjectId) marks.Add(o);
                }
                u.Ocena = marks;
            }
        }
    }
}