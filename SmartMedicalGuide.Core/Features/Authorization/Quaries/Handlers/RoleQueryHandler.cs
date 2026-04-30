using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Authorization.Quaries.Models;
using SmartMedicalGuide.Core.Features.Authorization.Quaries.Results;
using SmartMedicalGuide.Data.Entities.Identity;
using SmartMedicalGuide.Data.Results;
using SmartMedicalGuide.Service.Abstracts;

namespace SmartMedicalGuide.Core.Features.Authorization.Quaries.Handlers
{
    public class RoleQueryHandler : ResponseHandler,
       IRequestHandler<GetRolesListQuery, Response<List<GetRolesListResult>>>,
       IRequestHandler<GetRoleByIdQuery, Response<GetRoleByIdResult>>,
       IRequestHandler<ManageUserRolesQuery, Response<ManageUserRolesResult>>
    {
        #region Fields
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;

        private readonly UserManager<User> _userManager;
        #endregion
        #region Constructors
        public RoleQueryHandler(
                                IAuthorizationService authorizationService,
                                IMapper mapper,
                                UserManager<User> userManager) : base()
        {
            _authorizationService = authorizationService;
            _mapper = mapper;

            _userManager = userManager;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<List<GetRolesListResult>>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
        {
            var roles = await _authorizationService.GetRolesList();
            var result = _mapper.Map<List<GetRolesListResult>>(roles);
            return Success(result);
        }

        public async Task<Response<GetRoleByIdResult>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _authorizationService.GetRoleById(request.Id);
            if (role == null) return NotFound<GetRoleByIdResult>("");
            var result = _mapper.Map<GetRoleByIdResult>(role);
            return Success(result);
        }

        public async Task<Response<ManageUserRolesResult>> Handle(ManageUserRolesQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null) return NotFound<ManageUserRolesResult>("");
            var result = await _authorizationService.ManageUserRolesData(user);
            return Success(result);
        }
        #endregion
    }
}
