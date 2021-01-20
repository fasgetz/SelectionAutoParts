using DataBaseModels;
using DataBaseSelectionAutoParts.DataBase;
using Microsoft.EntityFrameworkCore;
using Services_WebSelectionAutoParts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_WebSelectionAutoParts.Realisation
{
    public class CategoriesService : ICategoriesService
    {
        private readonly AutoPartsContext db;

        public CategoriesService(AutoPartsContext db)
        {
            this.db = db;
        }


        /// <summary>
        /// Получить полный список категорий
        /// </summary>
        /// <returns>Список категорий</returns>
        public async Task<IEnumerable<Category>> getAllCategories()
        {

            IQueryable<Category> categoryQuery = db.categories;

            //categoryQuery = categoryQuery.Where(i => i.ParentCategoryId == null);
            //categoryQuery = categoryQuery.Where(i => i.Name.StartsWith("a"));

            IEnumerable<Category> data = await categoryQuery.ToListAsync();

            // Фильтруем чтобы возвращались только родители
            IEnumerable<Category> filtered = data.Where(i => i.ParentCategoryId == null);

            // Возвращаем родителей с потомками
            return filtered;
        }


        /// <summary>
        /// Получить категорию по ее номеру
        /// </summary>
        /// <param name="id">Номер категории</param>
        /// <returns>Категорию (подкатегорию)</returns>
        public async Task<Category> getCategory(int id)
        {
            IQueryable<Category> categoryQuery = db.categories;

            // Логика выборки
            var item = await categoryQuery
                .Select(item => new Category()
                {
                    id = item.id,
                    Name = item.Name,
                    ParentCategoryId = item.ParentCategoryId,
                    properties = item.properties
                })
                .FirstOrDefaultAsync(i => i.id == id);

            return item;

        }


        /// <summary>
        /// Редактирование категории
        /// </summary>
        /// <param name="category">категория</param>
        /// <returns>true в случае успеха. Иначе false</returns>
        public async Task<bool> updateCategory(Category category)
        {
            try
            {
                db.categories.Update(category);
                await db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
