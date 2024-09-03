using proyecto_Practico01_.Entities;
using proyecto_Practico01_.Repositories.Contracts;
using proyecto_Practico01_.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practico01_.Repositories.Implementations
{
    public class ArticleRepository : IArticleRepository
    {
        public bool Add(Article article)
        {
            var parameters = new List<ParameterSQL>()
            {
                new ParameterSQL("nombre", article.Name),
                new ParameterSQL("precio_unitario", article.Price)
            };
            int filasAfectadas = DataHelper.GetInstance().ExecuteSPDML("EXEC SP_GUARDAR_ARTICULO", parameters);

            return filasAfectadas > 0;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Article article)
        {
            throw new NotImplementedException();
        }
    }
}
