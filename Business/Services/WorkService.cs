using Core.Entities;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;

namespace Service.Services
{
    public class WorkService : Service<Work>, IWorkService
    {
        public WorkService(IGenericRepository<Work> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }

}
