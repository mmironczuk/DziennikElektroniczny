﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Models
{
    public class Uczen
    {
        public virtual int Id_ucznia { get; set; }
        public virtual string imie { get; set; }
        public virtual string nazwisko { get; set; }
        public virtual string adres { get; set; }
        public virtual string pesel { get; set; }
        public virtual Klasa Klasa { get; set; }
        public virtual Konto Konto { get; set; }
    }
}