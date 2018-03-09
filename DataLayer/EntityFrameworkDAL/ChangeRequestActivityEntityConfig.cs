using DataLayer.Models;
using System;
using System.Data.Entity.ModelConfiguration;

namespace DataLayer.EntityFrameworkDAL
{
    public class ChangeRequestActivityEntityConfig : EntityTypeConfiguration<OChangeRequestActivity>
    {
        public ChangeRequestActivityEntityConfig()
        {
            ToTable("ChangeRequestActivity");

            HasKey<Guid>(k => k.Id)
                .Property(p => p.Id).HasColumnName("Id")
                .HasColumnOrder(1)
                .IsRequired();

            Property(p => p.ActivityTypeId)
                .HasColumnOrder(2)
                .IsOptional();

            Property(p => p.ChangeRequestId)
                .HasColumnOrder(3)
                .IsOptional();

            Property(p => p.Remark)
                .HasMaxLength(500)
                .HasColumnOrder(4)
                .IsOptional();

            Property(p => p.UserId)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .HasColumnOrder(5)
                .IsOptional();

            Property(p => p.Username)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .HasColumnOrder(6)
                .IsOptional();

            Property(p => p.IsDeleted)
                .HasColumnOrder(7)
                .IsRequired();

            Property(p => p.SysTimestamp)
                .HasColumnOrder(8)
                .IsRequired();

            HasOptional(s => s.ActivityType).WithMany();

        }
    }
}
