using Core.Entities;
using Core.Repositories;

namespace Repository.Repositories
{
    public class CounterRepository : GenericRepository<Counter>, ICounterRepository
    {
        public CounterRepository(AppDbContext context) : base(context)
        {
        }
    }

}
