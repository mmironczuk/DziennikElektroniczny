using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Dziennik.DAL;
using Dziennik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dziennik.Pages
{
    public class WyborKlasyModel : PageModel
    {
        public MainDatabase mainDatabase = new MainDatabase();
        public int teacher_id { get; set; }
        public ObservableCollection<Nauczanie> nauczania { get; set; }
        public ObservableCollection<Lekcja> lekcje { get; set; }
        public List<Lekcja> lekcje2;
        [BindProperty]
        public int type { get; set; }
        public void OnGet(int TypeId)
        {
            type = TypeId;
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var id = Int32.Parse(claim.Value);
            teacher_id = id;
            nauczania = mainDatabase.GetNauczaniaNauczyciel(teacher_id);
            lekcje = mainDatabase.GetLekcjeDate();
            foreach(Nauczanie n in nauczania)
            {
                lekcje2 = new List<Lekcja>();
                foreach(Lekcja l in lekcje)
                {
                    if (n.Id_nauczania == l.Nauczanie.Id_nauczania) lekcje2.Add(l);
                }
                n.Lekcja = lekcje2;
            }
        }
    }
}