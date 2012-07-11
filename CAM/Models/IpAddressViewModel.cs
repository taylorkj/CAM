using System.Collections.Generic;
using CAM.Core.Domain;
using CAM.Core.Repositories;

namespace CAM.Models
{
    public class IpAddressViewModel
    {
        #region WebAPI_variables

        // The following 2 variables are for handling the model binding for JSON and WebAPI:
        public string Id { get; set; }

        public string Host { get; set; }

        #endregion WebAPI_variables

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