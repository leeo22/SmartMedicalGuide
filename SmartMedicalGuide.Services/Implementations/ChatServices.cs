using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;

namespace SmartMedicalGuide.Services.Abstracts
{
    public class ChatServices : IChatServices
    {
        #region Fields
        private readonly IChatRepository _chatRepository;
        #endregion

        #region Constructors
        public ChatServices(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }
        #endregion

        #region Handlers Functions
        public async Task<string> AddAsync(Chat chat)
        {
            await _chatRepository.AddAsync(chat);
            return "Success";
        }

        public async Task<string> DeleteAsync(Chat chat)
        {
            var trans = _chatRepository.BeginTransaction();
            try
            {
                await _chatRepository.DeleteAsync(chat);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }

        public async Task<string> EditAsync(Chat chat)
        {
            await _chatRepository.UpdateAsync(chat);
            return "Success";
        }

        public async Task<Chat> GetByPatientAndDoctorAsync(int patientId, int doctorId)
        {
            return await _chatRepository.GetTableAsTracking()
                .Where(x => x.PatientId == patientId && x.DoctorId == doctorId)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Chat>> GetByPatientIdAsync(int patientId)
        {
            return await _chatRepository.GetTableAsTracking()
                .Where(x => x.PatientId == patientId)
                .ToListAsync();
        }

        public async Task<List<Chat>> GetByDoctorIdAsync(int doctorId)
        {
            return await _chatRepository.GetTableAsTracking()
                .Where(x => x.DoctorId == doctorId)
                .ToListAsync();
        }

        public async Task<Chat> GetByIDAsync(int id)
        {
            var result = _chatRepository.GetByIdAsync()
                                            .Where(x => x.ChatId == id)
                                            .FirstOrDefault();
            return result;
        }

        public async Task<List<Chat>> GetListAsync()
        {
            return await _chatRepository.GetTableAsTracking().ToListAsync();
        }
        #endregion
    }
}