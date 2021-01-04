using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseSelectionAutoParts.Models
{

    /// <summary>
    /// Сущность автозапчастей автомобиля
    /// </summary>
    public partial class AutoParts
    {

        /// <summary>
        /// Номер в базе данных
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Номер
        /// </summary>
        public string number { get; set; }


        /// <summary>
        /// Характеристики
        /// </summary>
        public string properties { get; set; }



        /// <summary>
        /// Номер категории автозапчасти
        /// </summary>
        public int idCategory { get; set; }

        /// <summary>
        /// Категория автозапчасти
        /// </summary>
        public Category category { get; set; }
    }
}
