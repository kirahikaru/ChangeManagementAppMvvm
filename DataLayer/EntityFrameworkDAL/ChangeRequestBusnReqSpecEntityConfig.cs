using DataLayer.Models;
using System;
using System.Data.Entity.ModelConfiguration;

namespace DataLayer.EntityFrameworkDAL
{
    public class ChangeRequestBusnReqSpecEntityConfig : EntityTypeConfiguration<OChangeRequestBusnReqSpec>
    {
        public ChangeRequestBusnReqSpecEntityConfig()
        {
            ToTable("ChangeRequestBusnReqSpec");
            HasKey<Guid>(k => k.Id)
                .Property(p => p.Id).HasColumnName("Id")
                .HasColumnOrder(1)
                .IsRequired();

            Property(p => p.RequirementId)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsOptional();

            Property(p => p.RequirementId)
                .HasColumnType("varchar")
                .HasMaxLength(500)
                .IsOptional();

            Property(p => p.Priority)
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
