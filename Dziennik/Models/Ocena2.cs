using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Models
{
    public class Ocena2
    {
        public int Id_oceny { get; set; }
        public int Id_ucznia { get; set; }
        public int Id_przedmiotu { get; set; }
        public int Id_nauczyciela { get; set; }
        public string ocena { get; set; }
        public string opis_oceny { get; set; }
    }
}
