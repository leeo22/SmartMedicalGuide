using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Roles.Queries.Models;
using SmartMedicalGuide.Core.Features.Roles.Queries.Results;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Roles.Queries.Handlers
{
    public class RoleQueryHandler : ResponseHandler,
                                    IRequestHandler<GetAllRoleQuery, Response<List<GetAllRoleResponse>>>,
                                    IRequestHandler<GetRoleByIDQuery, Response<GetSingleRoleResponse>>
    {

        #region Fields
        private readonly IRoleServices _roleServices;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public RoleQueryHandler(IRoleServices roleServices, IMapper mapper)
        {
            _roleServices = roleServices;
            _mapper = mapper;
        }

        #endregion
        #region Handels Functions
        public async Task<Response<List<GetAllRoleResponse>>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            var roleList = await _roleServices.GetAllRolesAsync();
            var roleListmapper = _mapper.Map<List<GetAllRoleResponse>>(roleList);
            return Success(roleListmapper);
        }

        public async Task<Response<GetSingleRoleResponse>> Handle(GetRoleByIDQuery request, CancellationToken cancellationToken)
        {
            var role = await _roleServices.GetRoleByIdAsync(request.Id);
            if (role == null) return NotFound<GetSingleRoleResponse>("No Patient same ID");
            var result = _mapper.Map<GetSingleRoleResponse>(role);
            return Success(result);
        }
        #endregion


    }
}
