using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AsyncAwaitPractice.Models;
using AsyncAwaitPractice.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AsyncAwaitPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        static readonly HttpClient client = new HttpClient();


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new ApiViewModel();

            vm.RandomNumber = await client.GetStringAsync("https://seriouslyfundata.azurewebsites.net/api/generatearandomnumber");
            
            string punchlineJSON = await client.GetStringAsync("https://seriouslyfundata.azurewebsites.net/api/chucknorrisfact");
            var punchline = JsonConvert.DeserializeObject<Punchline>(punchlineJSON);
            vm.Punchline = punchline;

            string seleucidJSON = await client.GetStringAsync("https://seriouslyfundata.azurewebsites.net/api/seleucids");
            var seleucidList = JsonConvert.DeserializeObject<SeleucidList>(seleucidJSON);
            vm.SeleucidList = seleucidList;

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
