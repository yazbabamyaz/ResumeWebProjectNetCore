using Core.Entities;
using Core.Repositories;

namespace Repository.Repositories
{
    public class WorkRepository : GenericRepository<Work>, IWorkRepository
    {
        public WorkRepository(AppDbContext context) : base(context)
        {
        }
    }



}
