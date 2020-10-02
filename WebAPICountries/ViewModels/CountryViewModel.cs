using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPICountries.ViewModels
{
    public class CountryViewModel
    {
        public string SearchTerm { get; set; }

        public string Filter { get; set; }

        public int ListSize { get; set; }
        public Country GetCountry { get; set; }
        public IEnumerable<Country> Country { get; set; }
    }
}
