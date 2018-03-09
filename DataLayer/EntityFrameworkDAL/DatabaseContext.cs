using DataLayer.Models;
using System.Data.Entity;

namespace DataLayer.EntityFrameworkDAL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<OActivityType> ActivityTypes { get; set; }
        public DbSet<OChangeRequest> ChangeRequests { get; set; }
        public DbSet<OChangeRequestActivity> ChangeRequestActivities { get; set; }
        public DbSet<OChangeRequestDoc> ChangeRequestDocs { get; set; }
        public DbSet<OChangeType> ChangeTypes { get; set; }
        public DbSet<OEmployee> Employees { get; set; }
        public DbSet<OPclaAppSys> PclaSysApps { get; set; }
        public DbSet<OUser> Users { get; set; }

        public DatabaseContext()
            : base("CRDBConnStr")
        {
        }

        //public DatabaseContext(string connStr)
        //    : base(connStr)
        //{
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ActivityTypeEntityConfig());
            modelBuilder.Configurations.Add(new ChangeRequestEntityConfig());
            modelBuilder.Configurations.Add(new ChangeRequestActivityEntityConfig());
            modelBuilder.Configurations.Add(new ChangeRequestDocEntityConfig());
            modelBuilder.Configurations.Add(new ChangeTypeEntityConfig());
            modelBuilder.Configurations.Add(new ChangeRequestBusnReqSpecEntityConfig());
            modelBuilder.Configurations.Add(new EmployeeEntityConfig());
            modelBuilder.Configurations.Add(new PclaAppSysEntityConfig());
            modelBuilder.Configurations.Add(new UserEntityConfig());

        }

        //public override int SaveChanges()
        //{
        //    DateTime now = DateTime.Now;
        //    foreach (ObjectStateEntry entry in (this as IObjectContextAdapter).ObjectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified))
        //    {
        //        if (!entry.IsRelationship && entry.Entity != null)
        //        {
        //            if (entry.Entity is PclaAuditObjectBase)
        //            {
        //                PclaAuditObjectBase obj = entry.Entity as PclaAuditObjectBase;
        //                obj.MdfDateTime = now;
        //            }
        //            else if (entry.Entity is PclaObjectBase)
        //            {
        //                PclaObjectBase obj = entry.Entity as PclaObjectBase;
        //                obj.SysTimestamp = now;
        //            }
        //        }
        //    }
        //    return base.SaveChanges();
        //}
    }
}
