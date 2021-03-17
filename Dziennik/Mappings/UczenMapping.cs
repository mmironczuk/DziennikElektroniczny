using FluentNHibernate.Mapping;
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
            Id(x => x.Id_ucznia).GeneratedBy.Increment();
            Map(x => x.imie).Length(15).Nullable();
            Map(x => x.nazwisko).Length(30).Nullable();
            Map(x => x.adres).Length(50).Nullable();
            Map(x => x.pesel).Length(11).Nullable();
            References(x => x.Klasa).Column("Id_klasy").Not.LazyLoad();
            References(x => x.Konto).Column("Id_konta").Not.LazyLoad();
            HasMany(x => x.Ocena).Not.LazyLoad().Inverse();
            HasMany(x => x.Obecnosc).Not.LazyLoad().Inverse();
            Table("Uczen");
        }
    }
}
