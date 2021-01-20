using DataBaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseSelectionAutoParts.DataBase.Configurations
{

    /// <summary>
    /// Конфигурация категорий автозапчастей с бесконечной вложенностью подкатегорий
    /// </summary>
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.HasKey(i => i.id);

            builder.HasOne(i => i.ParentCategory)
                .WithMany(i => i.ChildrenCategories)

                .HasForeignKey(i => i.ParentCategoryId)

                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(i => i.ParentCategoryId).IsRequired(false);




        }
    }
}
