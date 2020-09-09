using System;
using System.Collections.Generic;
using System.Text;

namespace CRM_MODEL_LIB
{
    public interface IArticleRepository
    {
        IEnumerable<Article> Articles { get; }
        void SaveArticle(Article article);
    }
}
