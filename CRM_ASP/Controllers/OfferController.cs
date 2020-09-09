using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRM_MODEL_LIB;

namespace CRM_ASP.Controllers
{
    public class OfferController : Controller
    {
        private IOfferRepository repository;

        public OfferController(IOfferRepository repo)
        {
            repository = repo;
        }
        public IActionResult List()
        {
            return View(repository.Offers);
        }
    }
}