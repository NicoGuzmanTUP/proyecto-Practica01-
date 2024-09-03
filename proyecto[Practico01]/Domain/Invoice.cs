using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practico01_.Entities
{
    public class Invoice
    {
        private int Code { get; set; }
        private DateTime Date { get; set; }
        private ShapePay? ShapePay { get; set; }
        private string? Client { get; set; }
    }
}
