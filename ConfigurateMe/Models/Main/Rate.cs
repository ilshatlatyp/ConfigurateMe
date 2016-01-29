using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ConfigurateMe.Models.Main
{
    public class Rate
    {
        /// <summary>
        /// Свойство. Идентификатор
        /// </summary>
        [Key]
        public int RateId { get; set; }

        /// <summary>
        /// Свойство. Название тарифа
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Свойство. Стоимость
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Свойство. Список компаний
        /// </summary>
        public List<Company> Companies { get; set; }
    }
}