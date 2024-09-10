using proyecto_Practico01_.Entities;
using proyecto_Practico01_.Repositories.Contracts;
using proyecto_Practico01_.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practico01_.Repositories.Implementations
{
    public class InvoiceRepository : IinvoiceRepository
    {
        public List<Invoice> GetAll()
        { 
            List<Invoice> list = new List<Invoice>();
            var helper = DataHelper.GetInstance();
            var t = helper.ExecuteSpQuery("SP_OBTENER_FACTURAS", null);

            foreach(DataRow row in t.Rows)
            {                
                int id = Convert.ToInt32(row["nroFactura"].ToString());
                DateTime dateTime = Convert.ToDateTime(row["fecha"].ToString());
                string client = row["cliente"].ToString();
                int shapePayId = Convert.ToInt32(row["forma_pago"].ToString());

                Invoice oInvoice = new Invoice()
                {
                    Code = id,
                    Date = dateTime,
                    Client = client,
                    ShapePayId = shapePayId,
                };
                list.Add(oInvoice);
            }

            return list;
        }

        private InvoiceDetail ReadDetail(DataRow row)
        {
            InvoiceDetail detail = new InvoiceDetail();
            detail.Article = new Article
            {
                Id = Convert.ToInt32(row["id_articulo"].ToString()),
                Name = row["nombre"].ToString(),
                Price = Convert.ToInt32(row["precio_unitario"].ToString())
            };
            detail.Lot = Convert.ToInt32(row["cantidad"]);
            
            return detail;
        }

        public bool save(Invoice invoice)
        {
            bool result = true;
            SqlTransaction? t = null;
            SqlConnection? cnn = null;

            try
            {
                cnn = DataHelper.GetInstance().GetConnection();
                cnn.Open();
                t = cnn.BeginTransaction();

                var cmd = new SqlCommand("SP_INSERTAR_MESTRO", cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@code", invoice.Code);
                cmd.Parameters.AddWithValue("@fecha", invoice.Date);
                cmd.Parameters.AddWithValue("@forma_pago", invoice.ShapePayId);
                cmd.Parameters.AddWithValue("@cliente", invoice.Client);

                SqlParameter param = new SqlParameter("@id", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();

                int invoiceId = (int)param.Value;

                int nroDetail = 1;
                foreach(var detail in invoice.GetDetail())
                {
                    var cmdDetail = new SqlCommand("SP_INSERTAR_NUEVO_DETALLE", cnn, t);
                    cmdDetail.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cod_detalle_factura", nroDetail);
                    cmd.Parameters.AddWithValue("@id_articulo", detail.Id);
                    cmd.Parameters.AddWithValue("@cantidad", detail.Lot);
                    cmd.Parameters.AddWithValue("@nro_factura", invoiceId);
                    nroDetail++;
                }
                t.Commit();
            }
            catch (SqlException)
            {
                if(t != null)
                {
                    t.Rollback();
                }
                return false;
            }
            finally
            {
                if(cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }

            return result;
        }
    }
}
