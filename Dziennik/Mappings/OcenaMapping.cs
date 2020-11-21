using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace Dziennik.Mappings
{
    public class OcenaMapping : ClassMap<Models.Ocena>
    {
        public OcenaMapping()
        {
            Id(x => x.Id_oceny).GeneratedBy.Identity();
            Map(x => x.ocena).Length(2).Nullable();
            Map(x => x.opis_oceny).Length(150).Nullable();
            References(x => x.Uczen).Column("Id_ucznia").Cascade.All();
            References(x => x.Nauczyciel).Column("Id_nauczyciela").Cascade.All();
            References(x => x.Przedmiot).Column("Id_przedmiotu").Cascade.All();
            Table("Przedmiot");
        }
    }
}
