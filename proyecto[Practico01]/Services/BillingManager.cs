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
        IShapePayRepository _shapePayRepository;

        public BillingManager()
        {
            _articleRepository = new ArticleRepository();
            _shapePayRepository = new ShapePayRepository();
        }
        public bool AddArticle(Article article)
        {
            return _articleRepository.Add(article);
        }
        public List<ShapePay> GetShapePays()
        {
            return _shapePayRepository.GetAll();
        }
    }
}
