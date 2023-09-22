using Core.Entities;
using Core.Repositories;

namespace Repository.Repositories
{
    public class ContactFormRepository : GenericRepository<ContactForm>, IContactFormRepository
    {
        public ContactFormRepository(AppDbContext context) : base(context)
        {
        }
    }



}
