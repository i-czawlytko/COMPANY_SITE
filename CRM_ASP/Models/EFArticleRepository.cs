using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM_MODEL_LIB;

namespace CRM_ASP.Models
{
    public class EFArticleRepository : IArticleRepository
    {
        private AppDbContext context;

        public EFArticleRepository(AppDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Article> Articles => context.Articles;

        public void SaveArticle(Article article)
        {
            context.Articles.Add(article);
            context.SaveChanges();
        }
    }
}
