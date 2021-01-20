using DataBaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseSelectionAutoParts.DataBase.Configurations
{

    /// <summary>
    /// Конфигурация модели автозапчастей
    /// </summary>
    internal class AutoPartsConfiguration : IEntityTypeConfiguration<AutoParts>
    {
        public void Configure(EntityTypeBuilder<AutoParts> builder)
        {
            builder.HasKey(i => i.id);

            builder
                .HasOne(i => i.category)
                .WithMany(i => i.AutoParts)
                .HasForeignKey(i => i.idCategory)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(i => i.idCategory).IsRequired(true);
            builder.Property(i => i.name).IsRequired(true);

        }
    }
}
