using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Städteliste
{
    internal class staedte
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int Population { get; set; }
        public bool isCapital { get; set; }

        public staedte(string name, string country, int population, bool isCapital)
        {
            Name = name;
            Country = country;
            Population = population;
            this.isCapital = isCapital;
        }
    }
}
