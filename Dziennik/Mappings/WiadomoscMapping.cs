using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Mappings
{
    public class WiadomoscMapping : ClassMap<Models.Wiadomosc>
    {
        public WiadomoscMapping()
        {
            Id(x => x.Id_wiadomosci).GeneratedBy.Increment();
            Map(x => x.tytul).Length(50).Nullable();
            Map(x => x.tresc).Length(250).Nullable();
            References(x => x.konto_nadawcy).Column("Id_nadawcy").Not.LazyLoad();
            References(x => x.konto_odbiorcy).Column("Id_odbiorcy").Not.LazyLoad();
            Table("Wiadomosc");
        }
    }
}
