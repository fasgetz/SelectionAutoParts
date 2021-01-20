using DataBaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseSelectionAutoParts.DataBase.Configurations
{

    /// <summary>
    /// Конфигурация сущности производитель автомобиля
    /// </summary>
    internal class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.HasKey(i => i.Id); // Первичный ключ по номеру

            // Установим тип связи один ко многим (одна страна - много производетелей авто),
            // что у сущности есть внешний ключ - номер страны к которой можно обращаться
            // по виртуальному свойству country
            // с каскадным удалением
            builder
                .HasOne(i => i.country)
                .WithMany(i => i.manufacturers)
                .HasForeignKey(i => i.idCountry)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ManufacturerCountry");

            builder.Property(i => i.idCountry).IsRequired(); // Номер страны производителя должен быть обязательно указан

            // Установим максимальное количество символов 40 с обязательным заполнением для поля название производителя авто
            builder.Property(i => i.Name).HasMaxLength(40).IsRequired();


        }
    }
}
