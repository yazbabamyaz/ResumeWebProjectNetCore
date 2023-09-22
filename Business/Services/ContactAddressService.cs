using Core.Entities;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;

namespace Service.Services
{
    public class ContactAddressService : Service<ContactAddress>, IContactAddressService
    {
        public ContactAddressService(IGenericRepository<ContactAddress> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }

}
