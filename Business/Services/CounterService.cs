using Core.Entities;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;

namespace Service.Services
{
    public class CounterService : Service<Counter>, ICounterService
    {
        public CounterService(IGenericRepository<Counter> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
