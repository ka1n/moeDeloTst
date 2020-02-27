using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using moeDeloTst.Models;
using moeDeloTst.Repository;

namespace moeDeloTst.Controllers
{
    public class DocumentController : Controller
    {
        private readonly DocumentRepository documentRepository;

        public DocumentController(IConfiguration configuration)
        {
            documentRepository = new DocumentRepository(configuration);
        }
        // GET: Document
        public ActionResult Index(int? id)
        {
            if (id == null)
                return View(documentRepository.FindAll().ToList());
            else
                return View(documentRepository.FindAllById(id).ToList());
        }

        // POST: Document/Create
        [HttpPost]
        public IActionResult Create(Document? doc)
        {
            if (ModelState.IsValid)
            {
                documentRepository.Add(doc);
                return RedirectToAction("Index");
            }
            return View(doc);
        }
        public IActionResult Create()
        {
            return View();
        }

        // GET: /Document/Edit/1
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Document obj = documentRepository.FindByID(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        // POST: /Document/Edit   
        [HttpPost]
        public IActionResult Edit(Document doc)
        {

            if (ModelState.IsValid)
            {
                documentRepository.Update(doc);
                return RedirectToAction("Index");
            }
            return View(doc);
        }

        // GET:/Document/Delete/1
        public IActionResult Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            documentRepository.Remove(id.Value);
            return RedirectToAction("Index");
        }
    }
}