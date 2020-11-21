using FluentNHibernate.Mapping;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dziennik.Mappings
{
    public class TestMapping:ClassMap<Models.Test>
    {
        public TestMapping()
        {
            Id(x => x.Id);
            Map(x => x.name).Not.Nullable();
            Map(x => x.surname).Not.Nullable();
            Table("Test");
        }
    }
}
