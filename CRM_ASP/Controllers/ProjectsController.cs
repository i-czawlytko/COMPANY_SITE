using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using CRM_MODEL_LIB;
using Microsoft.AspNetCore.Authorization;

namespace CRM_ASP.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private IProjectRepository repository;

        public ProjectsController(IProjectRepository repo)
        {
            repository = repo;
        }

        [AllowAnonymous]
        public IActionResult List()
        {
            return View(repository.Projects);
        }


        public IActionResult Create()
        {
            return View(new Project());
        }

        [HttpPost]
        public IActionResult Create(Project project, IFormFile fileData)
        {

            if (fileData != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(fileData.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)fileData.Length);
                }
                // установка массива байтов
                project.imageData = imageData;
            }

            repository.SaveProject(project);
            return RedirectToAction("List");
        }
    }
}