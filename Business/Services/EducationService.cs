using Core.Entities;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;

namespace Service.Services
{
    public class EducationService : Service<Education>, IEducationService
    {
        public EducationService(IGenericRepository<Education> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }

}
