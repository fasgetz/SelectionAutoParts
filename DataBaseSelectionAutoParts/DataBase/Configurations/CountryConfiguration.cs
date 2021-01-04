using DataBaseSelectionAutoParts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseSelectionAutoParts.DataBase.Configurations
{
    /// <summary>
    /// Конфигурация модели Страна
    /// </summary>
    internal class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(i => i.Id); // первичный ключ по номеру

            // 60 символов максимум у свойства Name, которое обязательно к заполнению
            builder.Property(i => i.Name).IsRequired().HasMaxLength(60); 
        }
    }
}
