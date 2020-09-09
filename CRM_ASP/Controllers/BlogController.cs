using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRM_MODEL_LIB;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace CRM_ASP.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private IArticleRepository repository;

        public BlogController(IArticleRepository repo)
        {
            repository = repo;
        }

        [AllowAnonymous]
        public IActionResult Articles()
        {
            return View(repository.Articles);
        }

        [AllowAnonymous]
        public IActionResult Show(int id)
        {
            var article = repository.Articles.FirstOrDefault(a => a.id == id);
            return View(article);
        }

        public IActionResult Create()
        {
            return View(new Article());
        }

        [HttpPost]
        public IActionResult Create(Article article, IFormFile fileData)
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
                article.imageData = imageData;
            }

            repository.SaveArticle(article);
            return RedirectToAction(nameof(Articles));
        }
    }
}