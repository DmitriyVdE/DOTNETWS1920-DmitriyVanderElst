using LobbyUI.Helper;
using LobbyUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LobbyUI.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly IHttpClientFactory _httpClientFactory;

        public UsersController(IOptions<AppSettings> appSettings, IHttpClientFactory httpClientFactory)
        {
            _appSettings = appSettings.Value;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<UserVM> users;

            var request = new HttpRequestMessage(HttpMethod.Get, _appSettings.BaseURL + "users");

            request.Headers.Add("Accept", "application/json");

            var client = _httpClientFactory.CreateClient();

            var response = await client.SendAsync(request).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
                users = await JsonSerializer.DeserializeAsync<IEnumerable<UserVM>>(responseStream);
            }
            else
            {
                users = Array.Empty<UserVM>();
            }

            return View(users);
        }

        public async Task<IActionResult> Details(string id)
        {
            UserDetailsVM userDetails;

            var request = new HttpRequestMessage(HttpMethod.Get, _appSettings.BaseURL + "users/" + id);
            request.Headers.Add("Accept", "application/json");

            var client = _httpClientFactory.CreateClient();

            var response = await client.SendAsync(request).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
                userDetails = await JsonSerializer.DeserializeAsync<UserDetailsVM>(responseStream);
            }
            else
            {
                userDetails = new UserDetailsVM();
            }

            return View(userDetails);
        }

        public async Task<IActionResult> Create()
        {
            if (!HttpContext.Session.Keys.Contains("users"))
            {
                using var userRequest = new HttpRequestMessage(HttpMethod.Get, _appSettings.BaseURL + "users");
                userRequest.Headers.Add("Accept", "application/json");

                var client = _httpClientFactory.CreateClient();

                var response = await client.SendAsync(userRequest).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    HttpContext.Session.SetString("users", responseString);
                }
            }

            if (!HttpContext.Session.Keys.Contains("roles"))
            {
                using var userRequest = new HttpRequestMessage(HttpMethod.Get, _appSettings.BaseURL + "roles");
                userRequest.Headers.Add("Accept", "application/json");

                var client = _httpClientFactory.CreateClient();

                var response = await client.SendAsync(userRequest).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    HttpContext.Session.SetString("roles", responseString);
                }
            }

            if (!HttpContext.Session.Keys.Contains("countries"))
            {
                using var userRequest = new HttpRequestMessage(HttpMethod.Get, _appSettings.BaseURL + "countries");
                userRequest.Headers.Add("Accept", "application/json");

                var client = _httpClientFactory.CreateClient();

                var response = await client.SendAsync(userRequest).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    HttpContext.Session.SetString("countries", responseString);
                }
            }

            return View();
        }

        // POST: Addresses/Create
        [HttpPost]
        [ValidateAntiForgeryToken] // Prevents XSRF/CSRF attacks
        public async Task<IActionResult> Create(UserPostVM user, string[] roleSelections)
        {
            if (roleSelections.Length != 0)
            {
                user.Roles = roleSelections;

                if (ModelState.IsValid)
                {
                    var client = _httpClientFactory.CreateClient();

                    var userContent = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");

                    Console.WriteLine(userContent.ToString());

                    HttpResponseMessage httpResponseMessage = await client.PostAsync(new Uri(_appSettings.BaseURL + "users"), userContent).ConfigureAwait(false);

                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }

            return View(user);
        }

        // GET: Addresses/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (!HttpContext.Session.Keys.Contains("roles"))
            {
                using var userRequest = new HttpRequestMessage(HttpMethod.Get, _appSettings.BaseURL + "roles");
                userRequest.Headers.Add("Accept", "application/json");

                var client1 = _httpClientFactory.CreateClient();

                var response1 = await client1.SendAsync(userRequest).ConfigureAwait(false);

                if (response1.IsSuccessStatusCode)
                {
                    string responseString = await response1.Content.ReadAsStringAsync().ConfigureAwait(false);
                    HttpContext.Session.SetString("roles", responseString);
                }
            }

            if (!HttpContext.Session.Keys.Contains("countries"))
            {
                using var userRequest = new HttpRequestMessage(HttpMethod.Get, _appSettings.BaseURL + "countries");
                userRequest.Headers.Add("Accept", "application/json");

                var client2 = _httpClientFactory.CreateClient();

                var response2 = await client2.SendAsync(userRequest).ConfigureAwait(false);

                if (response2.IsSuccessStatusCode)
                {
                    string responseString = await response2.Content.ReadAsStringAsync().ConfigureAwait(false);
                    HttpContext.Session.SetString("countries", responseString);
                }
            }

            UserPutVM user;

            var request = new HttpRequestMessage(HttpMethod.Get, _appSettings.BaseURL + "users/" + id);
            request.Headers.Add("Accept", "application/json");

            var client = _httpClientFactory.CreateClient();

            var response = await client.SendAsync(request).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
                user = await JsonSerializer.DeserializeAsync<UserPutVM>(responseStream);
            }
            else
            {
                user = new UserPutVM();
            }

            return View(user);
        }

        // POST: Addresses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken] // Prevents XSRF/CSRF attacks
        public async Task<IActionResult> Edit(string id, UserPutVM user)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();

                var addressContent = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await client.PutAsync(new Uri(_appSettings.BaseURL + "users/" + id), addressContent).ConfigureAwait(false);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(user);
        }

        // GET: Addresses/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            UserDeleteVM user;

            var request = new HttpRequestMessage(HttpMethod.Get, _appSettings.BaseURL + "users/" + id);
            request.Headers.Add("Accept", "application/json");

            var client = _httpClientFactory.CreateClient();

            var response = await client.SendAsync(request).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
                user = await JsonSerializer.DeserializeAsync<UserDeleteVM>(responseStream);
            }
            else
            {
                user = new UserDeleteVM();
            }

            return View(user);
        }

        // POST: Addresses/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken] // Prevents XSRF/CSRF attacks
        public async Task<IActionResult> Delete(string id, UserDeleteVM user)
        {
            var client = _httpClientFactory.CreateClient();

            HttpResponseMessage httpResponseMessage = await client.DeleteAsync(new Uri(_appSettings.BaseURL + "users/" + id)).ConfigureAwait(false);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }
    }
}
