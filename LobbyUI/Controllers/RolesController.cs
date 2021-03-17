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
    public class RolesController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly IHttpClientFactory _httpClientFactory;

        public RolesController(IOptions<AppSettings> appSettings, IHttpClientFactory httpClientFactory)
        {
            _appSettings = appSettings.Value;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<RoleVM> roles;

            var request = new HttpRequestMessage(HttpMethod.Get, _appSettings.BaseURL + "roles");
            Console.WriteLine(request.ToString());
            request.Headers.Add("Accept", "application/json");

            var client = _httpClientFactory.CreateClient();

            var response = await client.SendAsync(request).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
                roles = await JsonSerializer.DeserializeAsync<IEnumerable<RoleVM>>(responseStream);
            }
            else
            {
                roles = Array.Empty<RoleVM>();
            }

            return View(roles);
        }

        public async Task<IActionResult> Details(string id)
        {
            RoleDetailsVM roleDetails;

            var request = new HttpRequestMessage(HttpMethod.Get, _appSettings.BaseURL + "roles/" + id);
            request.Headers.Add("Accept", "application/json");

            var client = _httpClientFactory.CreateClient();

            var response = await client.SendAsync(request).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
                roleDetails = await JsonSerializer.DeserializeAsync<RoleDetailsVM>(responseStream);
            }
            else
            {
                roleDetails = new RoleDetailsVM();
            }

            return View(roleDetails);
        }
    }
}
