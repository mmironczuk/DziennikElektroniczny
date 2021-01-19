using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Mappings
{
    public class KontoMapping : ClassMap<Models.Konto>
    {
        public KontoMapping()
        {
            Id(x => x.Id_konta).GeneratedBy.Increment();
            Map(x => x.login).Length(20).Nullable();
            Map(x => x.haslo).Length(32).Nullable();
            Map(x => x.email).Length(50).Nullable();
            Map(x => x.typ_uzytkownika).Nullable();
            HasOne(x => x.Nauczyciel).Not.LazyLoad();
            HasOne(x => x.Uczen).Not.LazyLoad();
            HasMany(x => x.wiadomosci_odebrane).Not.LazyLoad();
            HasMany(x => x.wiadomosci_wyslane).Not.LazyLoad();
            Table("Konto");
        }
    }
}
