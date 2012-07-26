using System;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using CAM.Core.Domain;
using CAM.Core.Repositories;
using CAM.Models;
using UCDArch.Core.PersistanceSupport;
using UCDArch.Web.ActionResults;

namespace CAM.Controllers
{
    public class IpAddressController : ApplicationController
    {
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IRepositoryWithTypedId<IpAddress, string> _ipAddressRepository;

        public IpAddressController(IRepositoryFactory repositoryFactory, IRepositoryWithTypedId<IpAddress, string> ipAddressRepository)
        {
            _repositoryFactory = repositoryFactory;
            _ipAddressRepository = ipAddressRepository;
        }

        //
        // GET: /IpAddress/

        public ActionResult Index()
        {
            var viewModel = IpAddressViewModel.Create(_repositoryFactory);

            //var ipAddressRangeEnum = viewModel.IpAddressRanges.GetEnumerator();

            //while (ipAddressRangeEnum.MoveNext())
            //{
            //    var ipRange = ipAddressRangeEnum.Current;
            //    var ipAddresses = ipRange.IpAddresses;
            //    foreach (var ipAddress in ipAddresses)
            //    {
            //        if (string.IsNullOrEmpty(ipAddress.Host))
            //        {
            //            try
            //            {
            //                IPHostEntry objIpHostEntry = System.Net.Dns.GetHostEntry(ipAddress.Id);

            //                var hostName = objIpHostEntry.HostName;
            //                if (!string.IsNullOrEmpty(hostName))
            //                {
            //                    var firstIndexOfDot = hostName.IndexOf(".");
            //                    if (firstIndexOfDot > 0)
            //                    {
            //                        //var domainName = hostName.Substring(firstIndexOfDot + 1);
            //                        hostName = hostName.Substring(0, firstIndexOfDot);
            //                        //viewModel.Domain = domainName;
            //                    }
            //                }

            //                ipAddress.Host = hostName;
            //            } // end try
            //            catch (Exception ex)
            //            {
            //                //viewModel.ExceptionMessage = ex.Message;
            //                // Do nothing
            //            }
            //        } // end  if (string.IsNullOrEmpty(ipAddress.Host))
            //    } // foreach (var ipAddress in ipAddresses)
            //} // end while (ipRange != null)

            return View(viewModel);
        }

        //
        // GET: /IpAddress/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /IpAddress/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /IpAddress/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /IpAddress/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /IpAddress/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // PUT api/ipaddreses/(json IpAddressViewModel data)
        // The json databinding automatically occurs because I added Id and Host to the IpAddressViewModel class.  It did not work when I tried using the IpAddress domain class.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonNetResult Post(IpAddressViewModel ipAddress)
        {
            HttpResponseMessage retval = null;

            var id = ipAddress.Id;

            var host = (String.IsNullOrEmpty(ipAddress.Host) ? null : ipAddress.Host.Trim());

            var myIpAddress = _ipAddressRepository.GetNullableById(id);

            if (myIpAddress == null)
            {
                //throw new HttpResponseException("Invalid IP Address", HttpStatusCode.NotFound);  // This method signature does not exist in Asp.Net MVC 4 RC.
                throw new System.Web.Http.HttpResponseException(new HttpResponseMessage(System.Net.HttpStatusCode.NotFound));
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
                if (String.IsNullOrEmpty(myIpAddress.Host))
                {
                    retval = new HttpResponseMessage(HttpStatusCode.NoContent);
                }
                else
                {
                    retval = new HttpResponseMessage(HttpStatusCode.OK);
                }
                return new JsonNetResult(retval);
            }
        }

        //
        // GET: /IpAddress/Get/5
        [HttpGet]
        public JsonNetResult Get(string id)
        {
            var viewModel = new IpAddressModel();

            if (!string.IsNullOrEmpty(id))
            {
                var ipAddress = _ipAddressRepository.GetNullableById(id);

                if (ipAddress != null)
                {
                    if (string.IsNullOrEmpty(ipAddress.Host))
                    {
                        try
                        {
                            System.Net.IPHostEntry objIpHostEntry = System.Net.Dns.GetHostEntry(id);

                            var hostName = objIpHostEntry.HostName;
                            if (!string.IsNullOrEmpty(hostName))
                            {
                                var firstIndexOfDot = hostName.IndexOf(".");
                                if (firstIndexOfDot > 0)
                                {
                                    //var domainName = hostName.Substring(firstIndexOfDot + 1);
                                    hostName = hostName.Substring(0, firstIndexOfDot);
                                    //viewModel.Domain = domainName;
                                }
                            }

                            ipAddress.Host = hostName;

                            viewModel.Id = ipAddress.Id;
                            viewModel.Host = ipAddress.Host;
                            viewModel.RangeId = ipAddress.RangeId;
                            viewModel.SortOrder = ipAddress.SortOrder;
                        } // end try
                        catch (Exception ex)
                        {
                            viewModel.ExceptionMessage = ex.Message;
                        }
                    } // end  if (string.IsNullOrEmpty(ipAddress.Host))
                }
            }
            return new JsonNetResult(viewModel);
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /IpAddress/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}