using DataLayer.Models;
using System;
using System.Data.Entity.ModelConfiguration;

namespace DataLayer.EntityFrameworkDAL
{
    public class EmployeeEntityConfig : EntityTypeConfiguration<OEmployee>
    {
        public EmployeeEntityConfig()
        {
            ToTable("Employee");
            HasKey<Guid>(k => k.Id)
                .Property(p => p.Id).HasColumnName("Id")
                .HasColumnOrder(1)
                .IsRequired();

            Property(p => p.EmployeeID)
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsRequired();

            Property(p => p.GivenName)
                .HasMaxLength(100)
                .IsRequired();

            Property(p => p.Surname)
                .HasMaxLength(100)
                .IsRequired();

            Property(p => p.Fullname)
                .HasMaxLength(200)
                .IsOptional();

            Property(p => p.PositionTitle)
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsOptional();

            Property(p => p.Department)
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsOptional();

            Property(p => p.Function)
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsOptional();

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
