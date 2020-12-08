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
        public void OnGet(int id)
        {
            mark = new Ocena();
            mark.Id_oceny = id;
            mark = mainDatabase.GetOcena(id);
        }

        public IActionResult OnPost(int id)
        {
            if (id == 1) mainDatabase.UpdateOcena(mark);
            else if(id==2)mainDatabase.DeleteOcena(mark.Id_oceny);
            return RedirectToPage("/UsersList");
        }
    }
}