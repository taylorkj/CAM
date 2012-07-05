using CAM.Core.Domain;
using UCDArch.Core.PersistanceSupport;

namespace CAM.Core.Repositories
{
    public interface IRepositoryFactory
    {
        IRepository<DistributionList> DistributionListRepository { get; set; }

        IRepository<NetworkShare> NetworkShareRepository { get; set; }

        IRepository<Request> RequestRepository { get; set; }

        IRepository<RequestTemplate> RequestTemplateRepository { get; set; }

        IRepositoryWithTypedId<Site, string> SiteRepository { get; set; }

        IRepository<Software> SoftwareRepository { get; set; }

        IRepository<Unit> UnitRepository { get; set; }

        IRepositoryWithTypedId<IpAddress, string> IpAddressRepository { get; set; }

        IRepositoryWithTypedId<IpAddressRange, string> IpAddressRangeRepository { get; set; }
    }

    public class RepositoryFactory : IRepositoryFactory
    {
        public IRepository<DistributionList> DistributionListRepository { get; set; }

        public IRepository<NetworkShare> NetworkShareRepository { get; set; }

        public IRepository<Request> RequestRepository { get; set; }

        public IRepository<RequestTemplate> RequestTemplateRepository { get; set; }

        public IRepositoryWithTypedId<Site, string> SiteRepository { get; set; }

        public IRepository<Software> SoftwareRepository { get; set; }

        public IRepository<Unit> UnitRepository { get; set; }

        public IRepositoryWithTypedId<IpAddress, string> IpAddressRepository { get; set; }

        public IRepositoryWithTypedId<IpAddressRange, string> IpAddressRangeRepository { get; set; }
    }
}