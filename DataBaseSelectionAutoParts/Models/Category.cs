using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseSelectionAutoParts.Models
{

    /// <summary>
    /// Категории запчатей
    /// </summary>
    public partial class Category
    {
        public int id { get; set; }

        /// <summary>
        /// Название категории
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Характеристики полей в JSON (схема)
        /// </summary>
        public string properties { get; set; }

        public int? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Category> ChildrenCategories { get; set; }


        /// <summary>
        /// Автозапчасти категории
        /// </summary>
        public virtual ICollection<AutoParts> AutoParts { get; set; }
    }
}
