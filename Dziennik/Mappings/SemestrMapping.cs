using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Mappings
{
    public class SemestrMapping : ClassMap<Models.Semestr>
    {
        public SemestrMapping()
        {
            Id(x => x.Id_semestru).GeneratedBy.Increment();
            Map(x => x.data_rozpoczecia).Nullable();
            Map(x => x.data_zakonczenia).Nullable();
            HasMany(x => x.oceny).Not.LazyLoad();
            Table("Semestr");
        }
    }
}
