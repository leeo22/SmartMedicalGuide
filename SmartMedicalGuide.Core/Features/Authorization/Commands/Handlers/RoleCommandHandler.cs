using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Authorization.Commands.Models;
using SmartMedicalGuide.Service.Abstracts;
namespace SmartMedicalGuide.Core.Features.Authorization.Commands.Handlers
{
    public class RoleCommandHandler : ResponseHandler,
        IRequestHandler<AddRoleCommand, Response<string>>,
        IRequestHandler<EditRoleCommand, Response<string>>,
        IRequestHandler<DeleteRoleCommand, Response<string>>,
        IRequestHandler<UpdateUserRolesCommand, Response<string>>
    {
        #region MyRegion

        private readonly IAuthorizationService _authorizationService;

        #endregion
        #region MyRegion
        public RoleCommandHandler(IAuthorizationService authorizationService) : base()
        {

            _authorizationService = authorizationService;
        }

        #endregion
        #region MyRegion
        public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.AddRoleAsync(request.RoleName);
            if (result == "Success") return Success("");
            return BadRequest<string>("An error Add Role");
        }

        public async Task<Response<string>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.EditRoleAsync(request);
            if (result == "notFound") return NotFound<string>();
            else if (result == "Success") return Success((string)"An Error in Edit");
            else
                return BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.DeleteRoleAsync(request.Id);
            if (result == "NotFound") return NotFound<string>();
            else if (result == "Used") return BadRequest<string>("");
            else if (result == "Success") return Success((string)"");
            else
                return BadRequest<string>(result);
        }
        public async Task<Response<string>> Handle(UpdateUserRolesCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.UpdateUserRoles(request);
            switch (result)
            {
                case "UserIsNull": return NotFound<string>("");
                case "FailedToRemoveOldRoles": return BadRequest<string>("");
                case "FailedToAddNewRoles": return BadRequest<string>("");
                case "FailedToUpdateUserRoles": return BadRequest<string>("");
            }
            return Success<string>("");
        }
        #endregion

    }
}
