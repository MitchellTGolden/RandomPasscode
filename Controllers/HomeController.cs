using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RandomPasscode.Models;
using Microsoft.AspNetCore.Http;

namespace RandomPasscode.Controllers
{
    public class HomeController : Controller
    {
        public static string Main = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public static int PassCodeNum = 0;
        public static Random rand = new Random();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string PassCode = "";
            for (int i = 0; i < 11; i++)
            {
                char r = Main[rand.Next(0, Main.Length)];
                PassCode += r;
            }
            ViewBag.PassCode = PassCode;
            PassCodeNum += 1;
            ViewBag.PassCodeNum = PassCodeNum;
            return View("Index");
        }
        [HttpGet("reset")]
        public IActionResult Reset()
        {
            PassCodeNum = 0;
            return View("Index", PassCodeNum);
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
