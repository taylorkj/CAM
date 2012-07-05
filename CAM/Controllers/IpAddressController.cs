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