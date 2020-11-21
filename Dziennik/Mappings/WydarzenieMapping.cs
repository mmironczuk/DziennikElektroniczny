﻿using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Mappings
{
    public class WydarzenieMapping : ClassMap<Models.Wydarzenie>
    {
        public WydarzenieMapping()
        {
            Id(x => x.Id_wydarzenia).GeneratedBy.Identity();
            Map(x => x.nazwa).Length(50).Nullable();
            Map(x => x.data).Nullable();
            Map(x => x.opis).Length(150).Nullable();
            References(x => x.Klasa).Column("Id_klasy").Cascade.All();
            References(x => x.Nauczyciel).Column("Id_nauczyciela").Cascade.All();
            References(x => x.Przedmiot).Column("Id_przedmiotu").Cascade.All();
            Table("Wydarzenie");
        }
    }
}