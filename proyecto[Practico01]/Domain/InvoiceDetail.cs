using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practico01_.Entities
{
    public class InvoiceDetail
    {
        public int Id { get; set; }
        public Article? Article { get; set; }
        public int Lot { get; set; }
        public Invoice? Invoice { get; set; } //FK

    }
}
