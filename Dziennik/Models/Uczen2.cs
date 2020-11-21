using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Models
{
    public class Uczen2
    {
        [Display(Name="Id")]
        public int id { get; set; }
        [Display(Name = "Imię")]
        public string name { get; set; }
        [Display(Name = "Nazwisko")]
        public string surname { get; set; }
        [Display(Name ="Oceny")]
        public List<Ocena> oceny { get; set; }
    }
}
