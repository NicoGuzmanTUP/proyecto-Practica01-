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
    public class InvoiceManager
    {
        private IinvoiceRepository _invoiceRepository;

        public InvoiceManager()
        {
            _invoiceRepository = new InvoiceRepository();
        }

        public List<Invoice> GetInvoices()
        {
            return _invoiceRepository.GetAll();
        }
        
    }
}
