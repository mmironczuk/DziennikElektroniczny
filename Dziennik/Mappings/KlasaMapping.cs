using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Mappings
{
    public class KlasaMapping : ClassMap<Models.Klasa>
    {
        public KlasaMapping()
        {
            Id(x => x.Id_klasy).GeneratedBy.Increment();
            Map(x => x.nazwa).Length(10).Nullable();
            References(x => x.Nauczyciel).Column("Id_wychowawcy");
            HasMany(x => x.Uczen);
            HasMany(x => x.Lekcja);
            HasMany(x => x.Wydarzenie);
            Table("Klasa");
        }
    }
}
