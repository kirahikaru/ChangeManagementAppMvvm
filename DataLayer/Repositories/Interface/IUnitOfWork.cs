using System;

namespace DataLayer.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IActivityTypeRepository ActivityTypes { get; }
        IChangeRequestRepository ChangeRequests { get; }
        IChangeRequestActivityRepository ChangeRequestActivities { get; }
        IChangeRequestBusnReqSpecRepository ChangeRequestBusnReqSpecs { get; }
        IChangeRequestDocRepository ChangeRequestDocs { get; }
        IChangeTypeRepository ChangeTypes { get; }
        IEmployeeRepository Employees { get; }
        IPclaAppSysRepository PclaSysApps { get; }
        IUserRepository Users { get; }

        int Complete();
    }
}