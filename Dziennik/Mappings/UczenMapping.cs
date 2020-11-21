﻿using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Mappings
{
    public class UczenMapping : ClassMap<Models.Uczen>
    {
        public UczenMapping()
        {
            Id(x => x.Id_ucznia).GeneratedBy.Identity();
            Map(x => x.imie).Length(15).Nullable();
            Map(x => x.nazwisko).Length(30).Nullable();
            Map(x => x.adres).Length(50).Nullable();
            Map(x => x.pesel).Length(11).Nullable();
            References(x => x.Klasa).Column("Id_klasy").Cascade.All();
            References(x => x.Konto).Column("Id_konto").Cascade.All();
            Table("Uczen");
        }
    }
}