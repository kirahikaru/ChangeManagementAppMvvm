using DataLayer.Models;
using System;
using System.Data.Entity.ModelConfiguration;

namespace DataLayer.EntityFrameworkDAL
{
    public class ChangeRequestDocEntityConfig : EntityTypeConfiguration<OChangeRequestDoc>
    {
        public ChangeRequestDocEntityConfig()
        {
            ToTable("ChangeRequestDoc");

            HasKey<Guid>(k => k.Id)
                .Property(p => p.Id).HasColumnName("Id")
                .HasColumnOrder(1)
                .IsRequired();

            Property(p => p.ChgReqId)
                .IsOptional();

            Property(p => p.DocCode)
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsRequired();

            Property(p => p.DocName)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsOptional();

            Property(p => p.DocOwner)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsOptional();

            Property(p => p.DocPath)
                .HasColumnType("varchar")
                .HasMaxLength(500)
                .IsOptional();

            Property(p => p.IsDeleted)
                .HasColumnOrder(7)
                .IsRequired();

            Property(p => p.CrtDateTime)
                .HasColumnOrder(8)
                .IsRequired();

            Property(p => p.CrtUsrName)
                .HasColumnOrder(9)
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.MdfDateTime)
                .IsRequired();

            Property(p => p.MdfUsrName)
                .HasColumnOrder(10)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
