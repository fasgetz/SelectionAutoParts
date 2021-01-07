using DataBaseSelectionAutoParts.Models;
using Microsoft.AspNetCore.Mvc;
using Services_WebSelectionAutoParts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_WebSelectionAutoParts.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoriesService service;

        public CategoryController(ICategoriesService service)
        {
            this.service = service;
        }


        /// <summary>
        /// Полный перечень категорий
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var categories = await service.getAllCategories();

            return categories;

        }
    }
}
