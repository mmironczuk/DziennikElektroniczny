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
            Id(x => x.Id_oceny).GeneratedBy.Increment();
            Map(x => x.ocena).Length(2).Nullable();
            Map(x => x.opis_oceny).Length(150).Nullable();
            Map(x => x.czy_koncowa).Nullable();
            References(x => x.Uczen).Column("Id_ucznia").Not.LazyLoad();
            References(x => x.Nauczyciel).Column("Id_nauczyciela").Not.LazyLoad();
            References(x => x.Przedmiot).Column("Id_przedmiotu").Not.LazyLoad();
            References(x => x.Semestr).Column("Id_semestru").Not.LazyLoad();
            Table("Ocena");
        }
    }
}
