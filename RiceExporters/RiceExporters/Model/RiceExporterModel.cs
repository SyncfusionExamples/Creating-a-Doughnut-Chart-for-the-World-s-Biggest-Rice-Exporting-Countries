using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiceExporters
{
    public class RiceExporterModel
    {
        public string Country { get; set; }
        public Double Value { get; set; }

        public RiceExporterModel(string country, Double value)
        {
            Country = country;
            Value = value/1000;
        }
    }
}
