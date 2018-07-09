using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySite.Models;
using MySiteCore.Interfaces;
using MySiteCore.Models;

namespace MySite.Controllers
{
    public class HomeController : Controller
    {
        IMyRepository _repo;
        public HomeController(IMyRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("About/")]
        public IActionResult About()
        {
            MyDbModel model = _repo.getWebUrl(1).Result;
            return View(model);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
