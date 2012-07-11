using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentNHibernate.Mapping;
using UCDArch.Core.DomainModel;

namespace CAM.Core.Domain
{
    public class IpAddress : DomainObjectWithTypedId<string>
    {
        public IpAddress()
        {
            DnsNames = new List<DnsName>();
        }

        [StringLength(100)]
        public virtual string Host { get; set; }

        public virtual IList<DnsName> DnsNames { get; set; }

        [StringLength(11)]
        [Required]
        public virtual string RangeId { get; set; }

        public virtual int SortOrder { get; set; }
    }

    public class IpAddressMap : ClassMap<IpAddress>
    {
        public IpAddressMap()
        {
            Table("IpAddresses");
            Id(x => x.Id).GeneratedBy.Assigned();

            Map(x => x.Host);
            Map(x => x.RangeId);
            Map(x => x.SortOrder);
            HasMany(x => x.DnsNames).KeyColumn("IpAddress").Cascade.AllDeleteOrphan().Inverse();
        }
    }
}