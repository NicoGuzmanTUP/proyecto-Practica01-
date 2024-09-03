using proyecto_Practico01_.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practico01_.Repositories.Contracts
{
    public interface IinvoiceDetailRepository
    {
        List<InvoiceDetail> GetAll();
        bool Add(InvoiceDetail invoiceDetail);
    }
}
