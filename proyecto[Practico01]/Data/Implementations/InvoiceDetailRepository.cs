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
    public class InvoiceDetailRepository : IinvoiceDetailRepository
    {

        public List<InvoiceDetail> GetCount()
        {
            List<InvoiceDetail> list = new List<InvoiceDetail>();
            var helper = DataHelper.GetInstance();
            var t = helper.ExecuteSpQuery("SP_OBTENER_CANT_ARTICULOS", null);

            foreach ( DataRow row in t.Rows )
            {
                int count = Convert.ToInt32(row["cantidad"].ToString());

                InvoiceDetail oInvoiceDetail = new InvoiceDetail()
                {
                    Lot = count
                };
                list.Add(oInvoiceDetail);
            }

            return list;
        }
    }
}
