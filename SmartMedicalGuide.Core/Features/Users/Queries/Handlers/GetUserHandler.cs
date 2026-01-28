using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Users.Queries.Models;
using SmartMedicalGuide.Core.Features.Users.Queries.Results;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Users.Queries.Handlers
{
    public class GetUserHandler : ResponseHandler,
                                      IRequestHandler<GetUserListQuery, Response<List<GetUserListResponse>>>,
                                      IRequestHandler<GetUserByIDQuery, Response<GetSingleUserResponse>>
    {
        #region Fields
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public GetUserHandler(IUserServices userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }
        #endregion
        #region Handels Functions
        public async Task<Response<List<GetUserListResponse>>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var userList = await _userServices.GetUsersListAsync();
            var userListMapper = _mapper.Map<List<GetUserListResponse>>(userList);
            return Success(userListMapper);
        }



        public async Task<Response<GetSingleUserResponse>> Handle(GetUserByIDQuery request, CancellationToken cancellationToken)
        {
            var user = await _userServices.GetUserByIDAsync(request.Id);
            if (user == null) return NotFound<GetSingleUserResponse>("No Patient same ID");
            var result = _mapper.Map<GetSingleUserResponse>(user);
            return Success(result);
        }
        #endregion

    }
}
