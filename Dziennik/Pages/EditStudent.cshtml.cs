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
    public class EditStudentModel : PageModel
    {
        [BindProperty]
        public Uczen uczen { get; set; }
        MainDatabase mainDatabase = new MainDatabase();
        public void OnGet(int id)
        {
            uczen = mainDatabase.GetUczen(id);
        }
        public IActionResult OnPost()
        {
            mainDatabase.UpdateStudent(uczen);
            return RedirectToPage("/AllUsers");
        }
    }
}