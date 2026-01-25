using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class UserServices : IUserServices
    {
        private readonly DbSet<User> _user;
        public UserServices(MedicalGuideDbContext dBContext)
        {
            _user = dBContext.Set<User>();

        }
        public Task<User> AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(ICollection<User> entities)
        {
            throw new NotImplementedException();
        }

        public IDbContextTransaction BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(ICollection<User> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllUserListAsync()
        {
            return await _user.ToListAsync();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetTableAsTracking()
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetTableNoTracking()
        {
            throw new NotImplementedException();
        }

        public void RollBack()
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRangeAsync(ICollection<User> entities)
        {
            throw new NotImplementedException();
        }
    }
}
