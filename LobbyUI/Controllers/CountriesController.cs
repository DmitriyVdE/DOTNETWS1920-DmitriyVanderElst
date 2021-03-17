using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using LobbyUI.Helper;
using LobbyUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LobbyUI.Controllers
{
    public class CountriesController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly IHttpClientFactory _httpClientFactory;

        public CountriesController(IOptions<AppSettings> appSettings, IHttpClientFactory httpClientFactory)
        {
            _appSettings = appSettings.Value;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<CountryVM> countries;

            var request = new HttpRequestMessage(HttpMethod.Get, _appSettings.BaseURL + "countries");
            Console.WriteLine(request.ToString());
            request.Headers.Add("Accept", "application/json");

            var client = _httpClientFactory.CreateClient();

            var response = await client.SendAsync(request).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
                countries = await JsonSerializer.DeserializeAsync<IEnumerable<CountryVM>>(responseStream);
            }
            else
            {
                countries = Array.Empty<CountryVM>();
            }

            return View(countries);
        }

        public async Task<IActionResult> Details(int id) 
        {
            CountryUsersVM countryUsers;

            var request = new HttpRequestMessage(HttpMethod.Get, _appSettings.BaseURL + "countries/" + id);
            request.Headers.Add("Accept", "application/json");

            var client = _httpClientFactory.CreateClient();

            var response = await client.SendAsync(request).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
                countryUsers = await JsonSerializer.DeserializeAsync<CountryUsersVM>(responseStream);
            }
            else
            {
                countryUsers = new CountryUsersVM();
            }

            return View(countryUsers);
        }
    }
}
