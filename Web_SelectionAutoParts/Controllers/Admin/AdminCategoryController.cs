using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_SelectionAutoParts.Controllers.Admin
{

    public class AdminCategoryController : Controller
    {
        public IActionResult editCategory(int id)
        {
            return PartialView(id);
        }
    }
}
