using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ConfigurateMe.Models.Main
{
    public class Package
    {
        public Package()
        {
            //Options = new HashSet<Option>().ToList();
        }

        #region Fields

        /// <summary>
        /// Поле. Идентификатор
        /// </summary>
        private int _packageId;

        /// <summary>
        /// Поле. Название пакета
        /// </summary>
        private string _name;

        /// <summary>
        /// Поле. Стоимость пакета
        /// </summary>
        private double _price;

        /// <summary>
        /// Поле. Описание
        /// </summary>
        private string _description;

        /// <summary>
        /// Поле. Видны ли опции вне пакета
        /// </summary>
        private bool _optionVisible;

        /// <summary>
        /// Поле. Взаимоисключающий выбор
        /// </summary>
        private bool _optional;

        /// <summary>
        /// Поле. Флаг списка не совместимых опций
        /// </summary>
        private bool _uncompatibleOptions;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство. Идентификатор
        /// </summary>
        [Key]
        public int PackageId
        {
            get; set;
        }

        /// <summary>
        /// Свойство. Название опции
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// Свойство. Стоимость опции
        /// </summary>
        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }

        /// <summary>
        /// Свойство. Описание
        /// </summary>
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        /// <summary>
        /// Свойство. Видны ли опции вне пакета
        /// </summary>
        public bool OptionVisible
        {
            get
            {
                return _optionVisible;
            }
            set
            {
                _optionVisible = value;
            }
        }

        /// <summary>
        /// Свойство. Взаимоисключающий выбор
        /// </summary>
        public bool Optional
        {
            get
            {
                return _optional;
            }
            set
            {
                _optional = value;
            }
        }

        /// <summary>
        /// Свойство.  Флаг списка не совместимых опций
        /// </summary>
        public bool UncompatibleOptions
        {
            get
            {
                return _uncompatibleOptions;
            }
            set
            {
                _uncompatibleOptions = value;
            }
        }

        [ForeignKey("Bookmark")]
        public int BookmarkId { get; set; }

        /// <summary>
        /// Свойство. Ссылка на закладку
        /// </summary>
        
        [JsonIgnore]
        public virtual Bookmark Bookmark
        {
            get; set;
        }

      //  public int OptionId { get; set; }

        ///// <summary>
        ///// Свойство. Список опций в пакете
        ///// </summary>
        //public virtual List<Option> Options
        //{
        //    get; set;
        //}

        #endregion
    }
}
