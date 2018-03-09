using DataLayer.Models;
using System;
using System.Data.Entity.ModelConfiguration;

namespace DataLayer.EntityFrameworkDAL
{
    public class UserEntityConfig : EntityTypeConfiguration<OUser>
    {
        public UserEntityConfig()
        {
            ToTable("User");
            HasKey<Guid>(k => k.Id)
                .Property(p => p.Id).HasColumnName("Id")
                .HasColumnOrder(1)
                .IsRequired();

            Property(p => p.UserId)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .HasColumnOrder(2)
                .IsRequired();

            Property(p => p.Username)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .HasColumnOrder(3)
                .IsRequired();

            Property(p => p.Password)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .HasColumnOrder(4)
                .IsOptional();

            Property(p => p.IsActiveDir)
                .HasColumnOrder(5)
                .IsOptional();

            Property(p => p.IsDeleted)
                .IsRequired();

            Property(p => p.CrtDateTime)
                .IsRequired();

            Property(p => p.CrtUsrName)
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.MdfDateTime)
                .IsRequired();

            Property(p => p.MdfUsrName)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
