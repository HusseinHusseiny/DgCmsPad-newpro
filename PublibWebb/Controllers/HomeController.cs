using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PublibWebb.Models;

namespace PublibWebb.Controllers
{
    public class HomeController : Controller
    {



        public IActionResult Index()
        {
            return View();
        }  
        public IActionResult Category()
        {
            return View();
        }  
        public IActionResult Contact()
        {
            return View();
        }  
        public IActionResult Single()
        {
            return View();
        }





    }
}
