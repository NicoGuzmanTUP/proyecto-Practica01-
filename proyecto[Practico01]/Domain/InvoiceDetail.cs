using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practico01_.Entities
{
    public class InvoiceDetail
    {
        private Article? Article { get; set; }
        private int Lot { get; set; }
        private Invoice? Invoice { get; set; } //FK
    }
}
