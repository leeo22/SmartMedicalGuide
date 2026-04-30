using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Authorization.Commands.Models;
using SmartMedicalGuide.Service.Abstracts;

namespace SmartMedicalGuide.Core.Features.Authorization.Commands.Handlers
{
    public class ClaimsCommandHandler : ResponseHandler,
         IRequestHandler<UpdateUserClaimsCommand, Response<string>>
    {
        #region Fileds
        private readonly IAuthorizationService _authorizationService;

        #endregion
        #region Constructors
        public ClaimsCommandHandler(
                                    IAuthorizationService authorizationService) : base()
        {
            _authorizationService = authorizationService;

        }
        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(UpdateUserClaimsCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.UpdateUserClaims(request);
            switch (result)
            {
                case "UserIsNull": return NotFound<string>("");
                case "FailedToRemoveOldClaims": return BadRequest<string>("");
                case "FailedToAddNewClaims": return BadRequest<string>("");
                case "FailedToUpdateClaims": return BadRequest<string>("");
            }
            return Success<string>("Success");
        }
        #endregion
    }
}
