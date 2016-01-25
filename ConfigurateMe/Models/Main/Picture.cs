using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ConfigurateMe.Models.Main
{
    public class Picture
    {
        /// <summary>
        /// Свойство. Идентификатор
        /// </summary>
        [Key]
        public int PictureId { get; set; }

        /// <summary>
        /// Свойство. Картинка
        /// </summary>
        public byte[] Image { get; set; }

        [ForeignKey("Option")]
        public int OptionId { get; set; }

        /// <summary>
        /// Свойство. Опция
        /// </summary>
        [JsonIgnore]
        public virtual Option Option { get; set; }

    }
}
