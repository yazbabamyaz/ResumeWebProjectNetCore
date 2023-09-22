using Core.Entities;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;

namespace Service.Services
{
    public class SocialService : Service<Social>, ISocialService
    {
        public SocialService(IGenericRepository<Social> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
