﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Limit.Db.Attributes;
using System.Reflection;

namespace Limit.Db.Context
{
    public class EntityConfiguration<T> : IEntityTypeConfiguration<T>
        where T : class
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            var type = typeof(T);
            var typeAttribute = type.GetCustomAttribute<TableNameAttribute>();
            if (typeAttribute != null)
            {
                builder.ToTable(typeAttribute.Name);
            }
            else
            {
                builder.ToTable(type.Name);
            }

            foreach (var prop in type.GetProperties())
            {
                var ignore = prop.GetCustomAttribute<IgnoreAttribute>();
                if (ignore == null)
                {
                    var pkAttr = prop.GetCustomAttribute<Attributes.PrimaryKeyAttribute>();
                    if (pkAttr != null)
                    {
                        builder.HasKey(prop.Name);
                    }

                    var propAttribute = prop.GetCustomAttribute<ColumnNameAttribute>();
                    if (propAttribute != null)
                        builder.Property(prop.Name)
                            .HasColumnName(propAttribute.Name);
                    else
                        builder.Property(prop.Name)
                            .HasColumnName(prop.Name);

                    var ctAttr = prop.GetCustomAttribute<ColumnTypeAttribute>();
                    if (ctAttr != null)
                    {
                        builder.Property(prop.Name).HasColumnType(ctAttr.Name);
                    }
                }
                else
                {
                    builder.Ignore(prop.Name);
                }
            }
        }
    }
}
