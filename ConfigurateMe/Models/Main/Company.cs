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
        /// Поле. 
        /// </summary>
        private CompanyTypes _type;

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
        /// Свойство. Имя директора
        /// </summary>
        //public string NameOfBoss
        //{
        //    get
        //    {
        //        return _nameOfBoss;
        //    }
        //    set
        //    {
        //        _nameOfBoss = value;
        //    }
        //}

        /// <summary>
        /// Свойство. Моб телефон контактного лица
        /// </summary>
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
        /// Свойство. Тип компании
        /// </summary>
        public CompanyTypes CompanyType
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

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
