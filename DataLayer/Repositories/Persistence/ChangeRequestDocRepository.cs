using DataLayer.EntityFrameworkDAL;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class ChangeRequestDocRepository : Repository<OChangeRequestDoc>, IChangeRequestDocRepository
    {
        public ChangeRequestDocRepository(DatabaseContext dbContext)
            : base(dbContext)
        {

        }

        public DatabaseContext DbContext
        {
            get { return _dbContext as DatabaseContext; }
        }
    }
}
