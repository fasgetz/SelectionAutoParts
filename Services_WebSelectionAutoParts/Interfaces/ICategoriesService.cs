using DataBaseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services_WebSelectionAutoParts.Services
{
    public interface ICategoriesService
    {
        /// <summary>
        /// Добавление категории
        /// </summary>
        /// <param name="category">Категория</param>
        /// <returns>TRUE в случае успеха</returns>
        public Task<bool> addCategoryAsync(Category category);

        /// <summary>
        /// Получить полный список категорий
        /// </summary>
        /// <returns>Список категорий</returns>
        public Task<IEnumerable<Category>> getAllCategories();


        /// <summary>
        /// Получить категорию по ее номеру
        /// </summary>
        /// <param name="id">Номер категории</param>
        /// <returns>Категорию (подкатегорию)</returns>
        public Task<Category> getCategory(int id);


        /// <summary>
        /// Редактирование категории
        /// </summary>
        /// <param name="category">категория</param>
        /// <returns>true в случае успеха. Иначе false</returns>
        public Task<bool> updateCategory(Category category);
    }
}
