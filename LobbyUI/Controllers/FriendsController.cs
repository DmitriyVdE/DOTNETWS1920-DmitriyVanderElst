using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LobbyUI.Controllers
{
    public class FriendsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FriendsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
