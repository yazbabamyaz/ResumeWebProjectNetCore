using Core.Entities;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;

namespace Service.Services
{
    public class MyServiceService : Service<MyService>, IMyServiceService
    {
        public MyServiceService(IGenericRepository<MyService> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
