using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Users.Queries.Models;
using SmartMedicalGuide.Core.Features.Users.Queries.Results;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Users.Queries.Handlers
{
    public class UserQueryHandler : ResponseHandler,
                                       IRequestHandler<GetUserListQuery, Response<List<GetUserListResponse>>>
    {
        #region Fields
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors
        public UserQueryHandler(IUserServices UserServices, IMapper mapper)
        {
            _userServices = UserServices;
            _mapper = mapper;
        }
        #endregion

        public async Task<Response<List<GetUserListResponse>>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var userList = await _userServices.GetAllUserListAsync();
            var userListMapper = _mapper.Map<List<GetUserListResponse>>(userList);
            return Success(userListMapper);

        }
    }
}
