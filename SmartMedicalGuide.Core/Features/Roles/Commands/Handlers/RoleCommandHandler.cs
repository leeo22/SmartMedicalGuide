using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Roles.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;


namespace SmartMedicalGuide.Core.Features.Roles.Commands.Handlers
{
    public class RoleCommandHandler : ResponseHandler,
                                       IRequestHandler<AddRoleCommand, Response<string>>
    {
        #region Fields
        private readonly IRoleServices _roleServices;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public RoleCommandHandler(IRoleServices roleServices, IMapper mapper)
        {
            _roleServices = roleServices;
            _mapper = mapper;
        }

        #endregion
        #region Handels Functions
        public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var roleMapper = _mapper.Map<Role>(request);
            //add
            var result = await _roleServices.AddAsync(roleMapper);
            //return response
            if (result == "Success") return Created("Added Sussessfully");
            else return BadRequest<string>();
        }
        #endregion

    }
}
