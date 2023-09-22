using Core.Entities;
using Core.Repositories;

namespace Repository.Repositories
{
    public class ContactAddressRepository : GenericRepository<ContactAddress>, IContactAddressRepository
    {
        public ContactAddressRepository(AppDbContext context) : base(context)
        {
        }
    }
}
