using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class UserServices : IUserServices
    {
        #region Fields
        public readonly IUserRepository _userRepository;

        #endregion
        #region Constructors
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> AddAsync(User user)
        {
            await _userRepository.AddAsync(user);
            return "Success";
        }

        public async Task<User> GetUserByIDAsync(int id)
        {
            var user = _userRepository.GetByIdAsync()
                                      .Include(x => x.Role)
                                      .Where(x => x.UserId.Equals(id))
                                      .FirstOrDefault();

            return user;

        }
        #endregion
        #region Handels Functions
        public async Task<List<User>> GetUsersListAsync()
        {
            return await _userRepository.GetUsersListAsync();
        }
        #endregion


    }
}
