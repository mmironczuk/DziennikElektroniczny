using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Mappings
{
    public class NauczycielMapping : ClassMap<Models.Nauczyciel>
    {
        public NauczycielMapping()
        {
            Id(x => x.Id_nauczyciela).GeneratedBy.Increment();
            Map(x => x.imie).Length(15).Nullable();
            Map(x => x.nazwisko).Length(30).Nullable();
            Map(x => x.adres).Length(50).Nullable();
            Map(x => x.pesel).Length(11).Nullable();
            HasMany(x => x.Nauczanie);
            HasMany(x => x.Ocena);
            HasMany(x => x.Wydarzenie);
            References(x => x.Konto).Column("Id_konta");
            HasOne(x => x.Klasa);
            Table("Nauczyciel");
        }
    }
}
