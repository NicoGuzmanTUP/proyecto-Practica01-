using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practico01_.Entities
{
    public class Invoice
    {
        public int Code { get; set; }
        public DateTime Date { get; set; }
        //public ShapePay? pShapePay { get; set; }
        public int ShapePayId { get; set; }

        public string? Client { get; set; }

        private List<InvoiceDetail> details;

        public List<InvoiceDetail> GetDetail()
        {
            return details;
        }

        public Invoice()
        {
            details = new List<InvoiceDetail>();
        }
        
        public void AddDetail(InvoiceDetail detail)
        {
            if (detail != null)
                details.Add(detail);            
        }
    }
}
