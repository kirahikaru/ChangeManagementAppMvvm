using DataLayer.Models;
using System;
using System.Data.Entity.ModelConfiguration;

namespace DataLayer.EntityFrameworkDAL
{
    public class ActivityTypeEntityConfig : EntityTypeConfiguration<OActivityType>
    {
        public ActivityTypeEntityConfig()
        {
            ToTable("ActivityType");
            HasKey<Guid>(k => k.Id)
                .Property(p => p.Id).HasColumnName("Id")
                .HasColumnOrder(1)
                .IsRequired();

            Property(p => p.Code)
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsRequired();

            Property(p => p.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.IsDeleted)
                .IsRequired();

            Property(p => p.CrtDateTime)
                .IsRequired();

            Property(p => p.CrtUsrName)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.MdfDateTime)
                .IsRequired();

            Property(p => p.MdfUsrName)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
