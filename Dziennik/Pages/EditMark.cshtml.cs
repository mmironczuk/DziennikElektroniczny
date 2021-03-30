using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dziennik.DAL;
using Dziennik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dziennik.Pages
{
    public class EditMarkModel : PageModel
    {
        [BindProperty]
        public Ocena mark { get; set; }
        public MainDatabase mainDatabase = new MainDatabase();
        [BindProperty]
        public int Class_id { get; set; }
        [BindProperty]
        public int Subject_id { get; set; }
        [BindProperty]
        public int mark_type { get; set; }
        public void OnGet(int id, int class_id, int subject_id, int type)
        {
            Class_id = class_id;
            Subject_id = subject_id;
            mark_type = type;
            mark = new Ocena();
            mark = mainDatabase.GetOcena(id);
        }

        public IActionResult OnPost(int id)
        {
            if (id == 1) mainDatabase.UpdateOcena(mark);
            else if(id==2)mainDatabase.DeleteOcena(mark.Id_oceny);
            return RedirectToPage("/UsersList", new {ClassId=Class_id, SubjectId=Subject_id });
        }
    }
}