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
            Id(x => x.Id_obecnosci).GeneratedBy.Identity();
            Map(x => x.obecnosc).Nullable();
            References(x => x.Lekcja).Column("Id_lekcji").Cascade.All();
            References(x => x.Uczen).Column("Id_ucznia").Cascade.All();
            Table("Obecnosc");
        }
    }
}
