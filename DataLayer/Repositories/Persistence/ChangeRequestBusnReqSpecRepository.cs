using DataLayer.EntityFrameworkDAL;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class ChangeRequestBusnReqSpecRepository : Repository<OChangeRequestBusnReqSpec>, IChangeRequestBusnReqSpecRepository
    {
        public ChangeRequestBusnReqSpecRepository(DatabaseContext dbContext)
            : base(dbContext)
        {

        }

        public DatabaseContext DbContext
        {
            get { return _dbContext as DatabaseContext; }
        }
    }
}
