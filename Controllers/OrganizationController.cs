using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using moeDeloTst.Models;
using moeDeloTst.Repository;

namespace moeDeloTst.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly OrganizationRepository organizationRepository;

        public OrganizationController(IConfiguration configuration)
        {
            organizationRepository = new OrganizationRepository(configuration);
        }
        // GET: Organization
        public ActionResult Index()
        {
            return View(organizationRepository.FindAll().ToList());
        }

        // POST: Organization/Create
        [HttpPost]
        public IActionResult Create(Organization org)
        {
            if (ModelState.IsValid)
            {
                organizationRepository.Add(org);
                return RedirectToAction("Index");
            }
            return View(org);
        }

        public IActionResult Create()
        {
            return View();
        }

        // GET: /Organization/Edit/1
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Organization obj = organizationRepository.FindByID(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        // POST: /Organization/Edit   
        [HttpPost]
        public IActionResult Edit(Organization obj)
        {

            if (ModelState.IsValid)
            {
                organizationRepository.Update(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET:/Organization/Delete/1
        public IActionResult Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            organizationRepository.Remove(id.Value);
            return RedirectToAction("Index");
        }
    }
}