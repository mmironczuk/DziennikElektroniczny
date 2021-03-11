using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dziennik.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dziennik.Pages
{
    public class DeleteUczenModel : PageModel
    {
        MainDatabase mainDatabase = new MainDatabase();
        public IActionResult OnGet(int id)
        {
            mainDatabase.DeleteUczen(id);
            return RedirectToPage("AllUsers");
        }
    }
}