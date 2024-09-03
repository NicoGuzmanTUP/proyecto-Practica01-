using proyecto_Practico01_.Entities;
using proyecto_Practico01_.Repositories.Contracts;
using proyecto_Practico01_.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practico01_.Services
{
    public class BillingManager
    {
        IArticleRepository _articleRepository;

        public BillingManager()
        {
            _articleRepository = new ArticleRepository();
        }
        public bool AddArticle(Article article)
        {
            return _articleRepository.Add(article);
        }
    }
}
