using DataBaseModels;
using DataBaseSelectionAutoParts.DataBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_WebSelectionAutoParts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly AutoPartsContext db;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, AutoPartsContext db)
        {
            _logger = logger;
            this.db = db;
        }

        /// <summary>
        /// Тестируем возвращение результатов
        /// </summary>
        /// <returns></returns>
        [HttpGet("getCountries")]
        public async Task<IEnumerable<Country>> GetCountries()
        {
            var countries = await db.countries.Include(i => i.manufacturers).ToListAsync();

            return countries;
        }

        /// <summary>
        /// Тестируем возвращение категорий
        /// </summary>
        /// <returns></returns>
        [HttpGet("getCategories")]
        public async Task<IEnumerable<Category>> getCategories()
        {
            // Список категорий с подкатегориями


            //var test3 = await db.categories.Where(i => i.ParentCategory == null).ToListAsync();
            var categories = await db.categories.ToListAsync();

            //var categories = await db.categories.Include(i => i.ChildrenCategories).Where(i => i.ParentCategory == null).ToListAsync();
            /*
                        var test1 = await db.categories.Where(i => i.ParentCategory == null).SingleOrDefaultAsync();
                        var test2 = await db.categories.FirstOrDefaultAsync();
                        var test3 = await db.categories.Where(i => i.ParentCategory == null).ToListAsync();
                        var test4 = await db.categories.Where(i => i.ParentCategory == null).FirstOrDefaultAsync();

                        var categories = await db.categories.ToListAsync();*/

            //var test1 = await db.categories.Where(i => i.ParentCategory == null).SingleOrDefaultAsync();

            return categories.Where(i => i.ParentCategory == null);
        }

        /// <summary>
        /// Тестовый метод
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }


        /// <summary>
        /// Получить имя пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     GET
        ///     {
        ///        "name": "value"
        ///     }
        ///
        /// </remarks>
        /// <returns>Имя пользователя</returns>
        /// <response code="200">Возвращае успешно добавленный продукт</response>
        /// <response code="400">Пустой параметр name</response>              
        [HttpGet("getMyName")]
        public IActionResult GetName(string name)
        {
            if (!string.IsNullOrEmpty(name))
                return Ok(name);

            return BadRequest("Пустой параметр name");
        }
    }
}
