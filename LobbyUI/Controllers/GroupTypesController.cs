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
    public class GroupTypesController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly IHttpClientFactory _httpClientFactory;

        public GroupTypesController(IOptions<AppSettings> appSettings, IHttpClientFactory httpClientFactory)
        {
            _appSettings = appSettings.Value;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<GroupTypeVM> groupTypes;

            var request = new HttpRequestMessage(HttpMethod.Get, _appSettings.BaseURL + "grouptypes");
            Console.WriteLine(request.ToString());
            request.Headers.Add("Accept", "application/json");

            var client = _httpClientFactory.CreateClient();

            var response = await client.SendAsync(request).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
                groupTypes = await JsonSerializer.DeserializeAsync<IEnumerable<GroupTypeVM>>(responseStream);
            }
            else
            {
                groupTypes = Array.Empty<GroupTypeVM>();
            }

            return View(groupTypes);
        }

        public async Task<IActionResult> Details(int id)
        {
            GroupTypeDetailsVM groupType;

            var request = new HttpRequestMessage(HttpMethod.Get, _appSettings.BaseURL + "groupTypes/" + id);
            request.Headers.Add("Accept", "application/json");

            var client = _httpClientFactory.CreateClient();

            var response = await client.SendAsync(request).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
                groupType = await JsonSerializer.DeserializeAsync<GroupTypeDetailsVM>(responseStream);
            }
            else
            {
                groupType = new GroupTypeDetailsVM();
            }

            return View(groupType);
        }
    }
}
