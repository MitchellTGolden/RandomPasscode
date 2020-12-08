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
        public static int PassCodeNum = 0;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Passcode Code = new Passcode();
            ViewBag.PassCode = Code.CodePass;
            PassCodeNum += 1;
            ViewBag.PassCodeNum = PassCodeNum;
            return View("Index");
        }

        [HttpGet("/ajax")]
        public IActionResult Ajax(){
            Console.WriteLine("Made it to the Ajax route");
            Passcode code = new Passcode();
            PassCodeNum ++;
            return Json(new {passcode=code.CodePass,num=PassCodeNum});
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
