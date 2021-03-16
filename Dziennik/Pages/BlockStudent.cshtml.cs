using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dziennik.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dziennik.Pages
{
    public class BlockStudentModel : PageModel
    {
        MainDatabase mainDatabase = new MainDatabase();
        public IActionResult OnGet(int id, int type)
        {
            if(type==1) mainDatabase.BlockStudent(id);
            else mainDatabase.UnblockStudent(id);
            return RedirectToPage("AllUsers");
        }
    }
}