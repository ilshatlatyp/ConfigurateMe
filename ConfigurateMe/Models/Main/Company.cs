using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ConfigurateMe.Models.Main
{
    public class Company
    {
        public Company()
        {
            Bookmarks = new HashSet<Bookmark>().ToList();
            Emails = new HashSet<Email>().ToList();

            Emails = new List<Email>();
            Bookmarks = new List<Bookmark>();
        }

       public enum CompanyTypes {Простой, Автомобильный, Мебельный }

        #region Fields

        /// <summary>
        /// Поле. Идентификатор
        /// </summary>
        private int _companyId;

        /// <summary>
        /// Поле. Название компании
        /// </summary>
        private string _name;

        /// <summary>
        /// Поле. Логин
        /// </summary>
        private string _accountName;

        /// <summary>
        /// Поле. Логотип
        /// </summary>
        private byte[] _logo;

        /// <summary>
        /// Поле. Дата регистрации
        /// </summary>
        private DateTime _dateOfRegistration;

        /// <summary>
        /// Поле. Баланс
        /// </summary>
        private double _balance;

        /// <summary>
        /// Поле. Адрес компании
        /// </summary>
        private string _address;

        /// <summary>
        /// Поле. Имя директора
        /// </summary>
        private string _nameOfBoss;

        /// <summary>
        /// Поле. Номер телефона
        /// </summary>
        private string _phone;

        /// <summary>
        /// Поле. Флаг приватности
        /// </summary>
        private bool _publ;

        /// <summary>
        /// Поле. 
        /// </summary>
        private Rate _type;

        #endregion

        #region Properties

        /// <summary>
        /// Свойство. Идентификатор
        /// </summary>
        [Key]
        public int CompanyId
        {
            get; set;
        }

        /// <summary>
        /// Свойство. Название компании
        /// </summary>
        [Display(Name = "Название компании")]
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
        /// Свойство. Баланс
        /// </summary>
        [Display(Name = "Баланс")]
        public double Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                _balance = value;
            }
        }

        /// <summary>
        /// Свойство. Логин
        /// </summary>
        [Display(Name = "Логин")]
        public string AccountName
        {
            get
            {
                return _accountName;
            }
            set
            {
                _accountName = value;
            }
        }

        /// <summary>
        /// Свойство. Логотип компании
        /// </summary>
        [Display(Name = "Логотип")]
        public virtual byte[] Logo
        {
            get
            {
                return _logo;
            }
            set
            {
                _logo = value;
            }
        }

        /// <summary>
        /// Свойство. Дата регистрации
        /// </summary>
        public DateTime DateOfRegistration
        {
            get
            {
                return _dateOfRegistration;
            }
            set
            {
                _dateOfRegistration = value;
            }
        }

        /// <summary>
        /// Свойство. Адрес компании
        /// </summary>
        [Display(Name = "Адрес")]
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }

        /// <summary>
        /// Свойство. Моб телефон контактного лица
        /// </summary>
        [Display(Name = "Телефон")]
        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
            }
        }

        /// <summary>
        /// Свойство. Приватность
        /// </summary>
        [Display(Name = "Приватность")]
        public bool Publ
        {
            get
            {
                return _publ;
            }
            set
            {
                _publ = value;
            }
        }

        [ForeignKey("CompanyRate")]
        public int RateId
        {
            get; set;
        }

        /// <summary>
        /// Свойство. Тариф компании
        /// </summary>
        [JsonIgnore]
        [Display(Name = "Тариф")]
        public virtual Rate CompanyRate { get; set; }

        /// <summary>
        /// Свойство. Список емайлов компании
        /// </summary>
        public virtual List<Email> Emails { get; set; }

        /// <summary>
        /// Свойство. Список разделов
        /// </summary>
        public virtual List<Bookmark> Bookmarks { get; set; }

        #endregion

    }
}
