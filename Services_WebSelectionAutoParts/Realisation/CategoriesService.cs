using DataBaseSelectionAutoParts.DataBase;
using DataBaseSelectionAutoParts.Models;
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
    }
}
