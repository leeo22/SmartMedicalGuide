using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Users.Queries.Models;
using SmartMedicalGuide.Core.Features.Users.Queries.Results;
using SmartMedicalGuide.Data.Entities.Identity;

namespace SmartMedicalGuide.Core.Features.Users.Queries.Handlers
{
    public class GetUserHandler : ResponseHandler,
                                      IRequestHandler<GetUserListQuery, Response<List<GetUserListResponse>>>,
                                      IRequestHandler<GetUserByIDQuery, Response<GetSingleUserResponse>>
    {
        #region Fields
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public GetUserHandler(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        #endregion
        #region Handels Functions
        public async Task<Response<List<GetUserListResponse>>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var userList = _userManager.Users.AsQueryable();
            var userListMapper = _mapper.Map<List<GetUserListResponse>>(userList);
            return Success(userListMapper);
        }



        public async Task<Response<GetSingleUserResponse>> Handle(GetUserByIDQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (user == null) return NotFound<GetSingleUserResponse>("No User same ID");
            var result = _mapper.Map<GetSingleUserResponse>(user);
            return Success(result);
        }
        #endregion

    }
}
