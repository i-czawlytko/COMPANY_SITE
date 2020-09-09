using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRM_MODEL_LIB;
using CRM_ASP.Models;

namespace CRM_ASP.Controllers
{
    public class HomeController : Controller
    {
        private IBidRepository repository;
        private IEnumerable<BidStatus> statuses;

        public HomeController(IBidRepository repo, EFStatuses sts)
        {
            repository = repo;
            statuses = sts.Statuses;
        }
        public IActionResult Index()
        {
            return View(new Bid());
        }

        [HttpPost]
        public IActionResult Index(Bid bid)
        {
            repository.SaveBid(bid);
            return RedirectToAction("Index");
        }
    }
}