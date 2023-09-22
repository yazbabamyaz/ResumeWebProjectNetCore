using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Service.Exceptions;
using System.Linq.Expressions;

namespace Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Service(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            _unitOfWork.CommitAsync();//savechanges ile id değeri olacak.
            //return entity;//id değeri var mı bak ???
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();//IQueryable geldi biz TolistAsync dedik
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var hasValue = await _repository.GetByIdAsync(id);
            if (hasValue == null)
            {    
                throw new NotFoundException($"{typeof(T).Name}({id})  dosya bulunamadı....!");                
            }
            return hasValue;
        }

        public async Task RemoveAsync(T entity)
        {

            try
            {

                //if (entity!=null)
                //{
                _repository.Remove(entity);
                await _unitOfWork.CommitAsync();
                //}

            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task UpdateAsync(T entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            //geriye tolist değil IQueryable dönüyor. tolisti web tarafında kullancaz
            return _repository.Where(expression);
        }
    }
}
