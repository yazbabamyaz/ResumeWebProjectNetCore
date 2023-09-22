using Core.Entities;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;

namespace Service.Services
{
    public class ContactFormService : Service<ContactForm>, IContactFormService
    {
        public ContactFormService(IGenericRepository<ContactForm> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }

}
