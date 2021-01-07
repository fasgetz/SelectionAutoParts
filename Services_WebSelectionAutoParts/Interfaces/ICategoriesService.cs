using DataBaseSelectionAutoParts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services_WebSelectionAutoParts.Services
{
    public interface ICategoriesService
    {

        /// <summary>
        /// Получить полный список категорий
        /// </summary>
        /// <returns>Список категорий</returns>
        public Task<IEnumerable<Category>> getAllCategories();
    }
}
