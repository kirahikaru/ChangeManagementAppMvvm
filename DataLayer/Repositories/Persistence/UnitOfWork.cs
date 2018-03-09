using DataLayer.EntityFrameworkDAL;
using System;

namespace DataLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _dbContext;

        public UnitOfWork(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
            ActivityTypes = new ActivityTypeRepository(_dbContext);
            ChangeRequests = new ChangeRequestRepository(_dbContext);
            ChangeRequestActivities = new ChangeRequestActivityRepository(_dbContext);
            ChangeRequestBusnReqSpecs = new ChangeRequestBusnReqSpecRepository(_dbContext);
            ChangeRequestDocs = new ChangeRequestDocRepository(_dbContext);
            ChangeTypes = new ChangeTypeRepository(_dbContext);
            Employees = new EmployeeRepository(_dbContext);
            PclaSysApps = new PclaAppSysRepository(_dbContext);
            Users = new UserRepository(_dbContext);
        }

        public IActivityTypeRepository ActivityTypes { get; private set; }
        public IChangeRequestRepository ChangeRequests { get; private set; }
        public IChangeRequestActivityRepository ChangeRequestActivities { get; private set; }
        public IChangeRequestBusnReqSpecRepository ChangeRequestBusnReqSpecs { get; private set; }
        public IChangeRequestDocRepository ChangeRequestDocs { get; private set; }
        public IChangeTypeRepository ChangeTypes { get; private set; }
        public IEmployeeRepository Employees { get; private set; }
        public IPclaAppSysRepository PclaSysApps { get; private set; }
        public IUserRepository Users { get; private set; }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
