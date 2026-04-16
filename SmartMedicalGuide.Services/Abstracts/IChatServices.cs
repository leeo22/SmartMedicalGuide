using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IChatServices
    {
        public Task<List<Chat>> GetListAsync();
        public Task<Chat> GetByIDAsync(int id);
        public Task<string> AddAsync(Chat chat);
        public Task<string> EditAsync(Chat chat);
        public Task<string> DeleteAsync(Chat chat);
        public Task<Chat> GetByPatientAndDoctorAsync(int patientId, int doctorId);
        public Task<List<Chat>> GetByPatientIdAsync(int patientId);
        public Task<List<Chat>> GetByDoctorIdAsync(int doctorId);
    }
}