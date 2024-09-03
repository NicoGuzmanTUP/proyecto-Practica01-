using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practico01_.Utils
{
    public class ParameterSQL
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public ParameterSQL(string name, object value)
        {
            Name = name;
            Value = value;
        }

    }
}
