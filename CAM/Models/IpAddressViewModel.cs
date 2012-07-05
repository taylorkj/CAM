using System.Collections.Generic;
using System.Linq;
using CAM.Core.Domain;
using CAM.Core.Repositories;

namespace CAM.Models
{
    public class IpAddressViewModel
    {
        // list values
        public IEnumerable<IpAddress> IpAddresses { get; set; }

        public IEnumerable<IpAddressRange> IpAddressRanges { get; set; }

        public static IpAddressViewModel Create(IRepositoryFactory repositoryFactory)
        {
            var viewModel = new IpAddressViewModel()
            {
                IpAddresses = repositoryFactory.IpAddressRepository.GetAll(),
                IpAddressRanges = repositoryFactory.IpAddressRangeRepository.GetAll()
            };

            return viewModel;
        }
    }
}