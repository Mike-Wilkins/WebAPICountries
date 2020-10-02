using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPICountries.ViewModels
{
    public class Country
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        public string Capital { get; set; }
        public int Population { get; set; }
        public string Flag { get; set; }
        
    }
}
