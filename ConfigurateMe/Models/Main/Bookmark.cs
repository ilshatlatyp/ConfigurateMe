using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurateMe.Models.Main
{
    public class Bookmark
    {
        public Bookmark()
        {
            Options = new HashSet<Option>().ToList();
            Packages = new HashSet<Package>().ToList();

            Packages = new List<Package>();
            Options = new List<Option>();
        }

        /// <summary>
        /// Свойство. Идентификатор
        /// </summary>
        [Display(Name = "Идентификатор")]
        [Key]
        public int BookmarkId { get; set; }

        /// <summary>
        /// Свойство. Название закладки
        /// </summary>
        [Display(Name = "Название закладки")]
        public string Name { get; set; }

        /// <summary>
        /// Свойство. Список опций в закладке
        /// </summary>
        [Display(Name = "Список опций в закладке")]
        public virtual List<Option> Options { get; set; }

        /// <summary>
        /// Свойство. Список пакетов
        /// </summary>
        [Display(Name = "Список пакетов")]
        public virtual List<Package> Packages { get; set; }

        [ForeignKey("Company")]
        public int CompanyId
        {
            get; set;
        }

        /// <summary>
        /// Свойство. Ссылка на компанию
        /// </summary>
        [Display(Name = "Компания")]
        [JsonIgnore]
        public virtual Company Company
        {
            get; set;
        }
    }
}
