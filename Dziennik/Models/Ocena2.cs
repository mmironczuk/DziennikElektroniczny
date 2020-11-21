using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Models
{
    public class Ocena2
    {
        public int idoceny { get; set; }
        public int iducznia { get; set; }
        public int idprzedmiotu { get; set; }
        public int idnauczyciela { get; set; }
        public string mark { get; set; }
        public string opis { get; set; }
    }
}
