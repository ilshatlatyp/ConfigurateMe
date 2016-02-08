using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ConfigurateMe.Models.Main
{
    public class ConfiguratorDBContext: DbContext
    {
        /// <summary>
        /// Свойство. Сущность связанная с таблицей Закладки
        /// </summary>
        public virtual DbSet<Bookmark> BookmarkSet { get; set; }

        /// <summary>
        /// Свойство. Сущность связанная с таблицей Компания
        /// </summary>
        public virtual DbSet<Company> CompanySet { get; set; }

        /// <summary>
        /// Свойство. Сущность связанная с таблицей Емайл
        /// </summary>
        public virtual DbSet<Email> EmailSet { get; set; }

        /// <summary>
        /// Свойство. Сущность связанная с таблицей Опция
        /// </summary>
        public virtual DbSet<Option> OptionSet { get; set; }

        /// <summary>
        /// Свойство. Сущность связанная с таблицей Пакет
        /// </summary>
        public virtual DbSet<Package> PackageSet { get; set; }

        /// <summary>
        /// Свойство. Сущность связанная с таблицей Картинка
        /// </summary>
        public virtual DbSet<Picture> PictureSet { get; set; }

        /// <summary>
        /// Свойство. Сущность связанная с таблицей Картинка
        /// </summary>
        public virtual DbSet<Rate> RateSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Option>().HasMany<Package>(x => x.Packages)
            //    .WithMany(p => p.Options)
            //    .Map(po =>
            //    {
            //        po.MapLeftKey("PackId");
            //        po.MapRightKey("OptId");
            //        po.ToTable("PackageOptions");
            //    });
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
