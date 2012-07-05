using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentNHibernate.Mapping;
using UCDArch.Core.DomainModel;

namespace CAM.Core.Domain
{
    public class IpAddressRange : DomainObjectWithTypedId<string>
    {
        public IpAddressRange()
        {
            IpAddresses = new List<IpAddress>();
        }

        public virtual IList<IpAddress> IpAddresses { get; set; }

        public virtual int TabOrder { get; set; }
    }

    public class IpAddressRangeMap : ClassMap<IpAddressRange>
    {
        public IpAddressRangeMap()
        {
            Table("IpAddressRanges_v");
            Id(x => x.Id);

            Map(x => x.TabOrder);
            HasMany(x => x.IpAddresses).KeyColumn("RangeId").Cascade.AllDeleteOrphan().Inverse();
        }
    }
}