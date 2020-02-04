using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Redirecting.Models;
using System.Net;

namespace Redirecting.Controllers
{
    [Route("{**page}")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Get(string domainName, string domain)
        {
            string url = Request.Path.ToString().Substring(1).Replace("/", ".");
            return Redirect(url);
        }
    }
}
