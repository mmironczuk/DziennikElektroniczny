using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Mappings
{
    public class LekcjaMapping : ClassMap<Models.Lekcja>
    {
        public LekcjaMapping()
        {
            Id(x => x.Id_lekcji).GeneratedBy.Increment();
            Map(x => x.data).Nullable();
            References(x => x.Nauczanie).Column("Id_nauczania").Not.LazyLoad();
            References(x => x.Klasa).Column("Id_klasy").Not.LazyLoad();
            HasMany(x => x.Obecnosc).Not.LazyLoad();
            Table("Lekcja");
        }
    }
}
