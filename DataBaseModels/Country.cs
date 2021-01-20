using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseModels
{
    /// <summary>
    /// Страна
    /// </summary>
    public partial class Country
    {

        public Country()
        {
            manufacturers = new HashSet<Manufacturer>();
        }


        /// <summary>
        /// Номер страны
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название страны
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Производители страны
        /// </summary>
        public virtual ICollection<Manufacturer> manufacturers { get; set; }
    }
}
