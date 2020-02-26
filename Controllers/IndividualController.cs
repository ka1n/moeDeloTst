using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using moeDeloTst.Repository;

namespace moeDeloTst.Controllers
{
    public class IndividualController : Controller
    {
        private readonly IndividualRepository individualRepository;

        public IndividualController(IConfiguration configuration)
        {
            individualRepository = new IndividualRepository(configuration);
        }
        // GET: Individual
        public ActionResult Index()
        {
            return View(individualRepository.FindAll().ToList());
        }

        // GET: Individual/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Individual/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Individual/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Individual/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Individual/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Individual/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Individual/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}