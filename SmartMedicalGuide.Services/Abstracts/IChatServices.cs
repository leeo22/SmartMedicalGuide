using SmartMedicalGuide.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IChatServices
    {
        public Task<List<Chat>> GetChatsListAsync();
        public Task<string> AddAsync(Chat chat);
        public Task<Chat> GetChatByIDAsync(int id);
        public Task<string> EditAsync(Chat chat);
        public Task<string> DeleteAsync(Chat chat);
    }
}
