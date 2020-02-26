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
    public class ContragentController : Controller
    {
        private readonly ContragentRepository contragentRepository;
        private readonly OrganizationRepository organizationRepository;
        private readonly IndividualRepository individualRepository;
        private readonly DocumentRepository documentRepository;


        IEnumerable<Organization> organizations;
        IEnumerable<Individual> individuals;


        public ContragentController(IConfiguration configuration)
        {
            contragentRepository = new ContragentRepository(configuration);
            organizationRepository = new OrganizationRepository(configuration);
            individualRepository = new IndividualRepository(configuration);
            documentRepository = new DocumentRepository(configuration);
        }

        // GET: Document
        //public ActionResult Index()
        //{
        //    return View(contragentRepository.FindAll().ToList());
        //}

        public IActionResult Index()
        {
            organizations = organizationRepository.FindAll();
            individuals = individualRepository.FindAll();
            Contragent ivm = new Contragent { Organization = organizations, Individual = individuals};


            return View(ivm);
        }
    }
}