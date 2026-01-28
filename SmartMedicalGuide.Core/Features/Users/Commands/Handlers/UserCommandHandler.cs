using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Users.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Users.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler,
                                       IRequestHandler<AddUserCommand, Response<string>>
    {
        #region Fields
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public UserCommandHandler(IUserServices userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }
        #endregion
        #region Handels Functions
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            // mapping between request and patient
            var userMapper = _mapper.Map<User>(request);
            //add
            var result = await _userServices.AddAsync(userMapper);
            //return response
            if (result == "Success") return Created("Added Sussessfully");
            else return BadRequest<string>();
        }
        #endregion

    }
}
