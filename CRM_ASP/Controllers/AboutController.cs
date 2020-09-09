using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRM_MODEL_LIB;

namespace CRM_ASP.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View(new AboutInfo {
                name="CRM project",
                adress="Автомобилистов 56, г.Пыть-ях",
                tel="2233223",
                fax="435434",
                email="mizantrop@gmail.com",
                manager = "Маврикий Евграфович Цепало"
            });
        }
    }
}