using DataLayer.EntityFrameworkDAL;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class ChangeRequestActivityRepository : Repository<OChangeRequestActivity>, IChangeRequestActivityRepository
    {
        public ChangeRequestActivityRepository(DatabaseContext dbContext)
            : base(dbContext)
        {

        }

        public DatabaseContext DbContext
        {
            get { return _dbContext as DatabaseContext; }
        }
    }
}
