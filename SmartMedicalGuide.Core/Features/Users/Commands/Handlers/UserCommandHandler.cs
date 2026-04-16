using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Users.Commands.Models;
using SmartMedicalGuide.Data.Entities.Identity;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Users.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler,
                                       IRequestHandler<AddUserCommand, Response<string>>,
                                       IRequestHandler<EditUserCommand, Response<string>>,
                                       IRequestHandler<DeleteUserCommand, Response<string>>
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
            // mapping between request and user
            var userMapper = _mapper.Map<User>(request);
            //add
            var result = await _userServices.AddAsync(userMapper);
            //return response
            if (result == "Success") return Created("Added Sussessfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userServices.GetUserByIDAsync(request.UserId);
            if (user == null) return NotFound<string>("user is not found");
            var userMapper = _mapper.Map<User>(request);
            var result = await _userServices.EditAsync(userMapper);
            if (result == "Success") return Success("Edited Sussessfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userServices.GetUserByIDAsync(request.Id);
            if (user == null) return NotFound<string>("user is not found");
            var result = await _userServices.DeleteAsync(user);
            if (result == "Success") return Deleted<string>($"Deleted Sussessfully {request.Id}");
            else return BadRequest<string>();
        }
        #endregion

    }
}
