using DataLayer.EntityFrameworkDAL;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class UserRepository : Repository<OUser>, IUserRepository
    {
        public UserRepository(DatabaseContext dbContext)
            : base(dbContext)
        {

        }

        public DatabaseContext DbContext
        {
            get { return _dbContext as DatabaseContext; }
        }
    }
}
