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
    public class PostTypesController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly IHttpClientFactory _httpClientFactory;

        public PostTypesController(IOptions<AppSettings> appSettings, IHttpClientFactory httpClientFactory)
        {
            _appSettings = appSettings.Value;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<PostTypeVM> postTypes;

            var request = new HttpRequestMessage(HttpMethod.Get, _appSettings.BaseURL + "posttypes");
            Console.WriteLine(request.ToString());
            request.Headers.Add("Accept", "application/json");

            var client = _httpClientFactory.CreateClient();

            var response = await client.SendAsync(request).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
                postTypes = await JsonSerializer.DeserializeAsync<IEnumerable<PostTypeVM>>(responseStream);
            }
            else
            {
                postTypes = Array.Empty<PostTypeVM>();
            }

            return View(postTypes);
        }
    }
}
