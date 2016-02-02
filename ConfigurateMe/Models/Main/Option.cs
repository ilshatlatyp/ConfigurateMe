using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ConfigurateMe.Models.Main
{
    public class Option
    {
        public Option()
        {
            //Packages = new HashSet<Package>().ToList();
            //Packages = new List<Package>();
        }

        #region Fields

        /// <summary>
        /// Поле. Идентификатор
        /// </summary>
        private int _optionId;

        /// <summary>
        /// Поле. Название опции
        /// </summary>
        private string _name;

        /// <summary>
        /// Поле. Количество
        /// </summary>
        private int _quantity;

        /// <summary>
        /// Поле. Цена
        /// </summary>
        private double _price;

        /// <summary>
        /// Поле. Описание
        /// </summary>
        private string _description;

        /// <summary>
        /// Поле. Миниатюры
        /// </summary>
        private byte[] _pic;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство. Идентификатор
        /// <summary>
        [Key]
        public int OptionId
        {
            get; set;
        }

        /// <summary>
        /// Свойство. Название опции
        /// </summary>
        [Display(Name = "Название опции")]
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
        /// Свойство. Количество
        /// </summary>
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
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

        //[ForeignKey("Pictures")]
        //public int PictureId
        //{
        //    get; set;
        //}

        /// <summary>
        /// Свойство. Картинки опции
        /// </summary>
        public byte[] Pictures
        {
            get
            {
               return _pic;
            }
            set
            {
               _pic = value ;
            }
        }

 //       public int PackageId { get; set; }

        ///// <summary>
        ///// Свойство. Список пакетов, в которых содержится опция
        ///// </summary>
        //public virtual List<Package> Packages
        //{
        //    get; set;
        //}

        [ForeignKey("Bookmark")]
        public int BookmarkId
        {
            get; set;
        }

        /// <summary>
        /// Свойство. Ссылка на закладку
        /// </summary>
        
        [JsonIgnore]
        public virtual Bookmark Bookmark
        {
            get; set;
        }

        #endregion
    }
}
