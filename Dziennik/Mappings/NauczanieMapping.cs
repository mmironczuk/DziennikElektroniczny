using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Mappings
{
    public class NauczanieMapping : ClassMap<Models.Nauczanie>
    {
        public NauczanieMapping()
        {
            Id(x => x.Id_nauczania).GeneratedBy.Increment();
            References(x => x.Nauczyciel).Column("Id_nauczyciela");
            References(x => x.Przedmiot).Column("Id_przedmiotu");
            HasMany(x => x.Lekcja);
            Table("Nauczanie");
        }
    }
}
