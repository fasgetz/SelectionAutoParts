using DataBaseModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services_WebSelectionAutoParts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_WebSelectionAutoParts.Controllers
{

    class entity
    {
        public string name { get; set; }
        public string inputType { get; set; }
        public bool required { get; set; }
        public int? min { get; set; }
        public int? max { get; set; }
        public int? minLength { get; set; }
        public int? maxLength { get; set; }
    }

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


        /// <summary>
        /// Получить категорию по номеру
        /// </summary>
        /// <param name="id">Номер категории</param>
        /// <returns>Возвращает категорию</returns>
        /// <response code="200">Успешный запрос</response>
        /// <response code="400">Пустой параметр id</response>
        /// <response code="404">Не найдена категория</response>        
        [HttpGet("get")]
        public async Task<IActionResult> GetCategory(int id)
        {
            if (id == 0)
                return BadRequest("ID не может быть пустым/равным 0");


            var category = await service.getCategory(id);

            if (category == null)
                return new BadRequestObjectResult("NO CONTENT") { StatusCode = 404 };

            var obj = new
            {
                category = new
                {
                    name = category.Name,
                    id = category.id,
                    ParentCategoryId = category.ParentCategoryId,
                },
                properties = category.properties != null ? JsonConvert.DeserializeObject<entity[]>(category.properties) : null
            };

            return new JsonResult(obj);
        }

        /// <summary>
        /// Редактировать категорию
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT
        ///     {
        ///        "id": 12345,
        ///        "name": "value",
        ///        "properties": {
        ///             [
        ///                 {"name":"Размер диска","inputType":"text","required":true,"min":null,"max":null,"minLength":null,"maxLength":null},
        ///                 {"name":"Размер шины","inputType":"number","required":true,"min":null,"max":null,"minLength":null,"maxLength":null},
        ///                 {"name":"Ширина покрышки","inputType":"number","required":true,"min":null,"max":null,"minLength":null,"maxLength":null},
        ///                 {"name":"Высота профиля","inputType":"number","required":true,"min":null,"max":null,"minLength":null,"maxLength":null}
        ///             ]
        ///         }
        ///     }
        ///
        /// </remarks>
        /// <param name="category">Категория (json)</param>
        /// <returns>True в случае успешного редактирования. Иначе false</returns>
        /// <response code="200">Успешный запрос</response>
        /// <response code="400">В случае если передали пустой параметр</response>
        /// <response code="404">Неудачный запрос на редактирование</response>
        [HttpPut("EditCategory")]
        public async Task<IActionResult> EditCategory(Category category)
        {
            if (category == null)
                return BadRequest("Передан пустой параметр");

            var updated = await service.updateCategory(category);

            if (updated == false)
                return new BadRequestObjectResult($"Не удалось обновить категорию с идентификатором {category.id}") { StatusCode = 404 };


            return Ok($"Категория \"{category.Name}\" успешно обновлена");
        }



        /// <summary>
        /// Добавить категорию
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST
        ///     {
        ///        "idParent": 123,
        ///        "name": "NameValue",
        ///        "properties": {
        ///             [
        ///                 {"name":"Размер диска","inputType":"text","required":true,"min":null,"max":null,"minLength":null,"maxLength":null},
        ///                 {"name":"Размер шины","inputType":"number","required":true,"min":null,"max":null,"minLength":null,"maxLength":null},
        ///                 {"name":"Ширина покрышки","inputType":"number","required":true,"min":null,"max":null,"minLength":null,"maxLength":null},
        ///                 {"name":"Высота профиля","inputType":"number","required":true,"min":null,"max":null,"minLength":null,"maxLength":null}
        ///             ]
        ///         }
        ///     }
        ///
        /// </remarks>
        /// <param name="category">Категория (json)</param>
        /// <returns>True в случае успешного добавления. Иначе false</returns>
        /// <response code="200">Успешный запрос</response>
        /// <response code="400">В случае если передали пустой параметр</response>
        /// <response code="404">Неудачный запрос на добавление</response>
        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory(Category category)
        {
            if (category == null)
                return BadRequest("Передан пустой параметр");

            var added = await service.addCategoryAsync(category);

            if (added == false)
                return new BadRequestObjectResult($"Не удалось добавить категорию {category.Name}") { StatusCode = 404 };

            return Ok($"Категория {category.Name} успешно добавлена!");
        }
    }
}
