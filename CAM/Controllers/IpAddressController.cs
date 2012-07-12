using System;
using System.Net;
using System.Web.Mvc;
using CAM.Core.Repositories;
using CAM.Models;

namespace CAM.Controllers
{
    public class IpAddressController : ApplicationController
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public IpAddressController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
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

        //
        // GET: /IpAddress/Delete/5

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