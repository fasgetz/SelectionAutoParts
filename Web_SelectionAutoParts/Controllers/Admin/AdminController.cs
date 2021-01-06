using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_SelectionAutoParts.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return PartialView();
        }

        public IActionResult Main()
        {
            return PartialView();
        }

        public IActionResult test()
        {
            return PartialView();
        }

        public IActionResult categories()
        {
            return PartialView();
        }
    }
}
