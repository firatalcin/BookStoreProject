using Business.Services;
using Entities.Model;

namespace Business.Managers
{
    public class AuthorManager : IAuthorService
    {
        public Task<Author> AddAsync(Author entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Author>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Author> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Author entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Author entity)
        {
            throw new NotImplementedException();
        }
    }
}