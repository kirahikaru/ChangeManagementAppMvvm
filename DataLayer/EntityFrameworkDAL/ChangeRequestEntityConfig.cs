using DataLayer.Models;
using System;
using System.Data.Entity.ModelConfiguration;

namespace DataLayer.EntityFrameworkDAL
{
    public class ChangeRequestEntityConfig : EntityTypeConfiguration<OChangeRequest>
    {
        public ChangeRequestEntityConfig()
        {
            ToTable("ChangeRequest");

            HasKey<Guid>(k => k.Id)
                .Property(p => p.Id).HasColumnName("Id")
                .HasColumnOrder(1)
                .IsRequired();

            Property(p => p.ChgReqID)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            Property(p => p.RemedyForceId)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            Property(p => p.Title)
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();

            Property(p => p.Justification)
                .HasMaxLength(1000)
                .IsOptional();

            Property(p => p.Detail)
                .HasMaxLength(1000)
                .IsOptional();

            Property(p => p.Priority)
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsOptional();

            Property(p => p.DevManday).IsOptional();
            Property(p => p.DocManday).IsOptional();
            Property(p => p.OthManday).IsOptional();

            Property(p => p.RequestDate)
                .IsOptional();

            Property(p => p.TargetCompleteDate)
                .IsOptional();

            Property(p => p.TargetUatDate)
                .IsOptional();

            Property(p => p.ActualCompleteDate)
                .IsOptional();

            Property(p => p.ActualUatDate)
                .IsOptional();

            Property(p => p.CloseDate)
                .IsOptional();

            Property(p => p.WorkUnit)
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsOptional();

            Property(p => p.Remark)
                .HasColumnType("varchar")
                .HasMaxLength(500)
                .IsOptional();

            Property(p => p.Status)
                .HasColumnType("varchar")
                .HasMaxLength(50)
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

            HasOptional(s => s.Requestor).WithMany();
            HasOptional(s => s.ITBusnAnalyst).WithMany();
            HasMany<OEmployee>(p => p.AssignedDevelopers).WithMany()
                .Map(pf =>
                {
                    pf.MapLeftKey("ChangeRequestId");
                    pf.MapRightKey("EmployeeId");
                    pf.ToTable("ChangeRequestAssignedDeveloper");
                });
            HasOptional(s => s.ChangeType).WithMany().WillCascadeOnDelete(false);
            HasMany(s => s.Activities).WithRequired(c => c.ChangeRequest).HasForeignKey(f => f.ChangeRequestId).WillCascadeOnDelete(true);
            HasMany(s => s.BusnReqSpecs).WithRequired(c => c.ChangeRequest).HasForeignKey(f => f.ChangeRequestId).WillCascadeOnDelete(true);
            HasMany(s => s.SdlcDocs).WithOptional(c => c.ChangeRequest).HasForeignKey(f => f.ChgReqId).WillCascadeOnDelete(true);
        }
    }
}
