using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Mappings
{
    public class PrzedmiotMapping : ClassMap<Models.Przedmiot>
    {
        public PrzedmiotMapping()
        {
            Id(x => x.Id_przedmiotu).GeneratedBy.Increment();
            Map(x => x.nazwa).Length(30).Nullable();
            Map(x => x.dziedzina).Length(30).Nullable();
            HasMany(x => x.Wydarzenie).Not.LazyLoad();
            HasMany(x => x.Nauczanie).Not.LazyLoad();
            HasMany(x => x.Ocena).Not.LazyLoad();
            Table("Przedmiot");
        }
    }
}
