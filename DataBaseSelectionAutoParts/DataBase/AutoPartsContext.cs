using System;
using DataBaseSelectionAutoParts.DataBase.Configurations;
using DataBaseSelectionAutoParts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataBaseSelectionAutoParts.DataBase
{
    public partial class AutoPartsContext : DbContext
    {

        /// <summary>
        /// Страны
        /// </summary>
        public virtual DbSet<Country> countries { get; set; }

        /// <summary>
        /// Производители автомобилей
        /// </summary>
        public virtual DbSet<Manufacturer> manufacturers { get; set; }


        /// <summary>
        /// Категории автозапчастей
        /// </summary>
        public virtual DbSet<Category> categories { get; set; }

        /// <summary>
        /// Автозапчасти
        /// </summary>
        public virtual DbSet<AutoParts> autoParts { get; set; }


        public AutoPartsContext()
        {
        }

        public AutoPartsContext(DbContextOptions<AutoPartsContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp: 192.168.1.66, 1433;Database=AutoParts;Trusted_Connection=False;MultipleActiveResultSets=false;User ID=fasgetz;Password=andrey061");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            // Применяем конфигурации
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new ManufacturerConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new AutoPartsConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
