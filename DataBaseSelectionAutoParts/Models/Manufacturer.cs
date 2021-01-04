using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseSelectionAutoParts.Models
{

    /// <summary>
    /// Компания-производитель автомобиля
    /// </summary>
    public partial class Manufacturer
    {
        /// <summary>
        /// Номер производителя
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя производителя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Страна производителя
        /// </summary>
        public virtual Country country { get; set; }

        /// <summary>
        /// Номер страны производителя
        /// </summary>
        public int idCountry { get; set; }

        /// <summary>
        /// Логотип производителя
        /// </summary>
        public byte[] imageLogo { get; set; }


        /// <summary>
        /// О компании
        /// </summary>
        public string aboutCompany { get; set; }
    }
}
