﻿using System.Diagnostics;
using ASP_CORE_MVC_DAPPER_STORED_PROCEDURES_REPOSITORY.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_CORE_MVC_DAPPER_STORED_PROCEDURES_REPOSITORY.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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