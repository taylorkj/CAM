using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CAM.Core.Domain;
using CAM.Models;
using UCDArch.Core;
using UCDArch.Core.PersistanceSupport;
using UCDArch.Web.ActionResults;

namespace CAM.Controllers
{
    /// <summary>
    /// This controller is specifically for handling WebAPI calls.
    /// </summary>
    public class IpAddressApiController : ApiController
    {
        private readonly IRepositoryWithTypedId<IpAddress, string> _ipAddressRepository;

        public IpAddressApiController()
        {
            _ipAddressRepository = SmartServiceLocator<IRepositoryWithTypedId<IpAddress, string>>.GetService();
        }

        // This doesn't currently get called, so it has to be done in the default c'tor.
        public IpAddressApiController(IRepositoryWithTypedId<IpAddress, string> ipAddressRepository)
        {
            _ipAddressRepository = ipAddressRepository;
        }

        // PUT api/ipaddreses/(json IpAddressViewModel data)
        // The json databinding automatically occurs because I added Id and Host to the IpAddressViewModel class.  It did not work when I tried using the IpAddress domain class.
        public HttpResponseMessage Put(IpAddressViewModel ipAddress)
        {
            var id = ipAddress.Id;

            var host = (String.IsNullOrEmpty(ipAddress.Host) ? null : ipAddress.Host.Trim());

            var myIpAddress = _ipAddressRepository.GetNullableById(id);

            if (myIpAddress == null)
            {
                //throw new HttpResponseException("Invalid IP Address", HttpStatusCode.NotFound);  // This method signature does not exist in Asp.Net MVC 4 RC.
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            else
            {
                //var hostName = ipAddress.Host;
                if (!String.IsNullOrEmpty(host))
                    host.Trim();
                myIpAddress.Host = host;

                using (var ts = new TransactionScope())
                {
                    _ipAddressRepository.EnsurePersistent(myIpAddress);

                    ts.CommitTransaction();
                }
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
        }
    }
}