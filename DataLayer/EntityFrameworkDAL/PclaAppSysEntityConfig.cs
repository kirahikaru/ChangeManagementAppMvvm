using DataLayer.Models;
using System;
using System.Data.Entity.ModelConfiguration;

namespace DataLayer.EntityFrameworkDAL
{
    public class PclaAppSysEntityConfig : EntityTypeConfiguration<OPclaAppSys>
    {
        public PclaAppSysEntityConfig()
        {
            ToTable("PclaAppSys");
            HasKey<Guid>(k => k.Id)
                .Property(p => p.Id).HasColumnName("Id")
                .HasColumnOrder(1)
                .IsRequired();

            Property(p => p.Code)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            Property(p => p.Name)
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();

            Property(p => p.TypeCode)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsOptional();

            Property(p => p.LatestVersion)
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsRequired();

            Property(p => p.Remark)
                .HasMaxLength(500)
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

            HasMany(s => s.ChangeRequests).WithOptional(c => c.PclaAppSys).HasForeignKey(x => x.PclaAppSysId).WillCascadeOnDelete(true);
        }
    }
}
