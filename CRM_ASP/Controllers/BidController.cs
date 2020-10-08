using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRM_MODEL_LIB;
using CRM_ASP.Models;
using CRM_ASP.Models.ViewModels;
using CRM_ASP.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace CRM_ASP.Controllers
{
    [Authorize]
    public class BidController : Controller
    {
        private IBidRepository repository;
        private IEnumerable<BidStatus> statuses;
        public int PageSize = 3;

        public BidController(IBidRepository repo, EFStatuses sts)
        {
            repository = repo;
            statuses = sts.Statuses;

        }

        public IActionResult Show(int id)
        {
            var bid = repository.Bids.FirstOrDefault(a => a.id == id);
            return View(bid);
        }

        public IActionResult All(int? StatusId,int productPage = 1)
        {
            var r_url = HttpContext.Request.PathAndQuery();
            if (HttpContext.Request.Method == "POST")
            {
                r_url += '?';
                if (!(StatusId is null)) r_url += $"StatusId={StatusId}&";
                r_url += $"productPage={productPage}";
            }


            ViewBag.r_url = r_url;
            ViewBag.ActionName = RouteData.Values["action"].ToString();
            var query = repository.Bids.Where(b => StatusId == null || b.BidStatusId == StatusId);
            return View("List", new BidsListViewModel
            {
                Bids = query.Skip((productPage - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = query.Count()
                },
                BidStatuses = statuses,
                FilterInfo = new FilterInfo
                {
                    BidStatusId = StatusId
                }
            });
        }

        public IActionResult ConcreteDay(int date_ofset, int? StatusId, int productPage = 1)
        {
            var r_url = HttpContext.Request.PathAndQuery();
            if (HttpContext.Request.Method == "POST")
            {
                r_url += '?';
                if (!(StatusId is null)) r_url += $"StatusId={StatusId}&";
                r_url += $"date_ofset={date_ofset}&";
                r_url += $"productPage={productPage}";
            }
            ViewBag.r_url = r_url;

            ViewBag.ActionName = RouteData.Values["action"].ToString();
            var query = repository.GetConcreteDayBids(date_ofset).Where(b => StatusId == null || b.BidStatusId == StatusId);
            return View("List", new BidsListViewModel
            {
                Bids = query.Skip((productPage - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = query.Count()
                },
                BidStatuses = statuses,
                FilterInfo = new FilterInfo
                {
                    DateOfset = date_ofset,
                    BidStatusId = StatusId
                }
            });
        }

        public IActionResult LastDays(int days_left, int? StatusId, int productPage = 1)
        {
            var r_url = HttpContext.Request.PathAndQuery();
            if (HttpContext.Request.Method == "POST")
            {
                r_url += '?';
                if (!(StatusId is null)) r_url += $"StatusId={StatusId}&";
                r_url += $"days_left={days_left}&";
                r_url += $"productPage={productPage}";
            }
            ViewBag.r_url = r_url;

            ViewBag.ActionName = RouteData.Values["action"].ToString();
            var query = repository.GetLastBids(days_left).Where(b => StatusId == null || b.BidStatusId == StatusId);
            return View("List", new BidsListViewModel
            {
                Bids = query.Skip((productPage - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = query.Count()
                },
                BidStatuses = statuses,
                FilterInfo = new FilterInfo
                {
                    DaysLeft = days_left,
                    BidStatusId = StatusId
                }
            });
        }

        public IActionResult DateRange(DateTime left_date, int? StatusId, DateTime right_date, int productPage = 1)
        {
            var r_url = HttpContext.Request.PathAndQuery();
            if (HttpContext.Request.Method == "POST")
            {
                r_url += '?';
                if (!(StatusId is null)) r_url += $"StatusId={StatusId}&";
                r_url += $"left_date={left_date.ToString("MM.dd.yyyy").Replace(".","%2F")}&";
                r_url += $"right_date={right_date.ToString("MM.dd.yyyy").Replace(".", "%2F")}&";
                r_url += $"productPage={productPage}";
            }
            ViewBag.r_url = r_url;

            ViewBag.ActionName = RouteData.Values["action"].ToString();
            var query = repository.GetDateRangeBids(left_date, right_date).Where(b => StatusId == null || b.BidStatusId == StatusId);
            return View("List", new BidsListViewModel
            {
                Bids = query.Skip((productPage - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = query.Count()
                },
                BidStatuses = statuses,
                FilterInfo = new FilterInfo
                {
                    LeftDate = left_date,
                    RightDate = right_date,
                    BidStatusId = StatusId
                }
            });
        }

        public IActionResult Update(Bid bid, string returnUrl)
        {
            repository.UpdateStatus(bid);
            return Redirect(returnUrl);
        }
    }
}