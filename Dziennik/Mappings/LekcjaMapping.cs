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
            References(x => x.Nauczanie).Column("Id_nauczania");
            References(x => x.Klasa).Column("Id_klasy");
            HasMany(x => x.Obecnosc);
            Table("Lekcja");
        }
    }
}
