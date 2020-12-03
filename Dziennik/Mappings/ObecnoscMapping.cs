using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Mappings
{
    public class ObecnoscMapping : ClassMap<Models.Obecnosc>
    {
        public ObecnoscMapping()
        {
            Id(x => x.Id_obecnosci).GeneratedBy.Increment();
            Map(x => x.obecnosc).Nullable();
            References(x => x.Lekcja).Column("Id_lekcji").Not.LazyLoad();
            References(x => x.Uczen).Column("Id_ucznia").Not.LazyLoad();
            Table("Obecnosc");
        }
    }
}
