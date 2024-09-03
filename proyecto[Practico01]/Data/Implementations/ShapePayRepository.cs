using proyecto_Practico01_.Entities;
using proyecto_Practico01_.Repositories.Contracts;
using proyecto_Practico01_.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practico01_.Repositories.Implementations
{
    public class ShapePayRepository : IShapePayRepository
    {
        public List<ShapePay> GetAll()
        {
            DataTable dataTable = DataHelper.GetInstance().ExecuteSpQuery("SP_OBTENER_FORMAS_PAGOS", null);
            var shapePays = new List<ShapePay>();

            if(dataTable != null)
            {
                foreach(DataRow row in dataTable.Rows)
                {
                    ShapePay shapePayD = new ShapePay
                    {
                        Id = Convert.ToInt32(row["id_forma_pago"]),
                        Name = Convert.ToString(row["nombre"])
                    };
                    shapePays.Add(shapePayD);
                }
            }

            return shapePays;
        }
    }
}
