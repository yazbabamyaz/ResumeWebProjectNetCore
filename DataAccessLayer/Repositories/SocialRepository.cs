using Core.Entities;
using Core.Repositories;

namespace Repository.Repositories
{
    public class SocialRepository : GenericRepository<Social>, ISocialRepository
    {
        public SocialRepository(AppDbContext context) : base(context)
        {
        }
    }
}
