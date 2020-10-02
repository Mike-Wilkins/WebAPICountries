using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebAPICountries.ViewModels;

namespace WebAPICountries.Controllers
{
    public class CountryController : Controller
    {
        HttpClient client = new HttpClient();
        public IActionResult Index()
        {
            List<Country> countryList = GetWebAPI().Result;

            var model = new CountryViewModel
            {
                Country = countryList.OrderByDescending(m => m.Population).ToList()
            };
            return View(model);
        }

        public IActionResult GetSearch(CountryViewModel search)
        {
            List<Country> countryList = GetWebAPI().Result;

            if (search.SearchTerm == null)
            {
                var modelList = new CountryViewModel
                {
                    Country = countryList.OrderByDescending(m => m.Population).ToList().Take(10)
                };
                return View("Index", modelList);
            }

            var model = new CountryViewModel
            {
                Country = countryList.FindAll(m => m.Name == search.SearchTerm || m.Region == search.SearchTerm || m.Capital == search.SearchTerm).ToList().Take(10)
            };
            return View("Index", model);
        }


        public IActionResult GetFilter(CountryViewModel filterCounties)
        {
            List<Country> countryList = GetWebAPI().Result;

            var model = new CountryViewModel();

            switch (filterCounties.Filter)
            {
                case "Max Population":
                    model.Country = countryList.OrderByDescending(m => m.Population).ToList().Take(10);
                    return View("Index", model);

                case "Min Population":
                    model.Country = countryList.OrderBy(m => m.Population).ToList().Take(10);
                    return View("Index", model);

                case "A-Z":
                    model.Country = countryList.OrderBy(m => m.Name).ToList();
                    return View("Index", model);
            }

            return View("Index", model);
        }


        public IActionResult GetListSize(CountryViewModel countryListSize)
        {
            List<Country> countryList = GetWebAPI().Result;

            var model = new CountryViewModel();

            switch (countryListSize.ListSize)
            {
                case 10:
                    model.Country = countryList.OrderByDescending(m => m.Population).ToList().Take(10);
                    return View("Index", model);
                case 20:
                    model.Country = countryList.OrderByDescending(m => m.Population).ToList().Take(20);
                    return View("Index", model);
                case 50:
                    model.Country = countryList.OrderByDescending(m => m.Population).ToList().Take(50);
                    return View("Index", model);
                case 100:
                    model.Country = countryList.OrderByDescending(m => m.Population).ToList().Take(100);
                    return View("Index", model);
                case 200:
                    model.Country = countryList.OrderByDescending(m => m.Population).ToList().Take(200);
                    return View("Index", model);
            }

            return View("Index", model);

        }

        public async Task<List<Country>> GetWebAPI()
        {

            ViewBag.FilterOptions = new List<string>() { "Max Population", "Min Population","A-Z" };
            ViewBag.ListSize = new List<int>() { 10, 20, 50, 100, 200 };

            string response = await client.GetStringAsync(
               "https://restcountries.eu/rest/v2/all");
            List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(response);

            return (countries);
        }
    }
}
