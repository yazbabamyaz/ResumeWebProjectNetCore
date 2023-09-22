using Core.Entities;
using Core.Repositories;

namespace Repository.Repositories
{
    public class ExperienceRepository : GenericRepository<Experience>, IExperienceRepository
    {
        public ExperienceRepository(AppDbContext context) : base(context)
        {
        }
    }




}
