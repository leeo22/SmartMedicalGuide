using MediatR;
using Microsoft.AspNetCore.Identity;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Authorization.Quaries.Models;
using SmartMedicalGuide.Data.Entities.Identity;
using SmartMedicalGuide.Data.Results;
using SmartMedicalGuide.Service.Abstracts;

namespace SmartMedicalGuide.Core.Features.Authorization.Quaries.Handlers
{
    public class ClaimsQueryHandler : ResponseHandler,
        IRequestHandler<ManageUserClaimsQuery, Response<ManageUserClaimsResult>>
    {
        #region Fileds
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<User> _userManager;

        #endregion
        #region Constructors
        public ClaimsQueryHandler(
                                  IAuthorizationService authorizationService,
                                  UserManager<User> userManager) : base()
        {
            _authorizationService = authorizationService;
            _userManager = userManager;

        }
        #endregion
        #region Handle Functions
        public async Task<Response<ManageUserClaimsResult>> Handle(ManageUserClaimsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null) return NotFound<ManageUserClaimsResult>("");
            var result = await _authorizationService.ManageUserClaimData(user);
            return Success(result);
        }
        #endregion
    }
}
