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
    public class NewStudentClassModel : PageModel
    {
        MainDatabase mainDatabase = new MainDatabase();
        [BindProperty]
        public ObservableCollection<Klasa> klasy { get; set; }
        [BindProperty]
        public int user_id { get; set; }
        [BindProperty]
        public int class_id { get; set; }
        [BindProperty]
        public int old_class_id { get; set; }
        public void OnGet(int id, int Old_class_id)
        {
            klasy = mainDatabase.GetKlasyAll();
            user_id = id;
            old_class_id = Old_class_id;
        }

        public IActionResult OnPost()
        {
            mainDatabase.UpdateStudentClass(user_id, class_id);
            return RedirectToPage("EditClassStudents", new { id = old_class_id });
        }
    }
}