using SmartMedicalGuide.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IMessageServices
    {
        public Task<List<Message>> GetMessagesListAsync();
        public Task<string> AddAsync(Message message);
        public Task<Message> GetMessageByIDAsync(int id);
        public Task<string> EditAsync(Message message);
        public Task<string> DeleteAsync(Message message);
    }
}
