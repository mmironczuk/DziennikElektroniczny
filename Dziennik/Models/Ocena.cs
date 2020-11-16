using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Models
{
    public class Ocena
    {
        public int iducznia { get; set; }
        public int idprzedmiotu { get; set; }
        public int idnauczyciela { get; set; }
        public decimal mark { get; set; }
        public string opis { get; set; }
    }
}
