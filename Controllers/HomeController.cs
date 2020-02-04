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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("www/{DomainName=DomainName}/{Domain=Domain}")]
        public IActionResult Get(string domainName, string domain)
        {
            string url = "https://www." + domainName + "." + domain;
            Uri urlCheck = new Uri(url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlCheck);
            request.Timeout = 15000;
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                return Redirect(url);
            }
            catch (Exception)    
            {
                return NotFound(); //could not connect to the internet (maybe) 
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
