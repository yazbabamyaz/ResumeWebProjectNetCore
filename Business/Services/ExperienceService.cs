using Core.Entities;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;

namespace Service.Services
{
    public class ExperienceService : Service<Experience>, IExperienceService
    {
        public ExperienceService(IGenericRepository<Experience> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
