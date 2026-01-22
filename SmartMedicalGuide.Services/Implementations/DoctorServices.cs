using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class DoctorServices : IDoctorServices
    {
        #region Fields

        private readonly DbSet<Doctor> _doctors;
        public DoctorServices(MedicalGuideDbContext dBContext)
        {
            _doctors = dBContext.Set<Doctor>();

        }

        public Task<Doctor> AddAsync(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(ICollection<Doctor> entities)
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

        public Task DeleteAsync(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(ICollection<Doctor> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Doctor>> GetAllDoctorListAsync()
        {
            return await _doctors.ToListAsync();
        }

        public Task<Doctor> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Doctor> GetTableAsTracking()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Doctor> GetTableNoTracking()
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

        public Task UpdateAsync(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRangeAsync(ICollection<Doctor> entities)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Constructors

        #endregion

        #region Handels Functions

        #endregion
    }
}
