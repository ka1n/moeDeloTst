﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using moeDeloTst.Models;
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

        // POST: Individual/Create
        [HttpPost]
        public IActionResult Create(Individual ind)
        {
            if (ModelState.IsValid)
            {
                individualRepository.Add(ind);
                return RedirectToAction("Index");
            }
            return View(ind);
        }

        public IActionResult Create()
        {
            return View();
        }

        // GET: /Individual/Edit/1
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Individual obj = individualRepository.FindByID(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        // POST: /Individual/Edit   
        [HttpPost]
        public IActionResult Edit(Individual obj)
        {

            if (ModelState.IsValid)
            {
                individualRepository.Update(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET:/Individual/Delete/1
        public IActionResult Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            individualRepository.Remove(id.Value);
            return RedirectToAction("Index");
        }

    }
}