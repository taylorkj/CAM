﻿using System.Collections.Generic;
using System.Linq;
using FluentNHibernate.Mapping;
using UCDArch.Core.DomainModel;

namespace CAM.Core.Domain
{
    public class Site : DomainObjectWithTypedId<string>
    {
        public Site()
        {
            Units = new List<Unit>();
        }

        public virtual string Name { get; set; }
        public virtual IList<Unit> Units { get; set; }

        public virtual bool HasUnits()
        {
            return Units.Any();
        }
    }

    public class SiteMap : ClassMap<Site>
    {
        public SiteMap()
        {
            Id(x => x.Id);

            Map(x => x.Name);
            HasMany(x => x.Units);
        }
    }
}
