using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IApplicationUserService _applicationUserService;
        #endregion
        #region Constructors
        public UserCommandHandler(UserManager<User> userManager, IApplicationUserService applicationUserService, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _applicationUserService = applicationUserService;

        }
        #endregion
        #region Handels Functions
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var identityUser = _mapper.Map<User>(request);
            //Create
            var createResult = await _applicationUserService.AddUserAsync(identityUser, request.Password);
            switch (createResult)
            {
                case "EmailIsExist": return BadRequest<string>("");
                case "UserNameIsExist": return BadRequest<string>("");
                case "ErrorInCreateUser": return BadRequest<string>("");
                case "Failed": return BadRequest<string>("");
                case "Success": return Success<string>("");
                default: return BadRequest<string>(createResult);
            }
        }
        //public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        //{
        //    var user = await _userManager.FindByEmailAsync(request.Email);
        //    if (user != null) return BadRequest<string>("email is ex");
        //    var userByUserName = await _userManager.FindByNameAsync(request.UserName);
        //    if (userByUserName != null) return BadRequest<string>("userName is Exist");
        //    // mapping between request and user
        //    var identityUser = _mapper.Map<User>(request);
        //    //add
        //    var createResult = await _userManager.CreateAsync(identityUser, request.Password);
        //    //return response
        //    if (!createResult.Succeeded)
        //        return BadRequest<string>("Create faild");
        //    await _userManager.AddToRoleAsync(identityUser, "User");
        //    return Created("Success");
        //}

        public async Task<Response<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {

            var oldUser = await _userManager.FindByIdAsync(request.Id.ToString());
            if (oldUser == null) return NotFound<string>("user is not found");
            var userMapper = _mapper.Map(request, oldUser);
            //if username is Exist
            var userByUserName = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == userMapper.UserName && x.Id != userMapper.Id);
            //username is Exist
            if (userByUserName != null) return BadRequest<string>("User is Exist");
            //update
            var result = await _userManager.UpdateAsync(userMapper);
            //result is not success
            if (!result.Succeeded) return BadRequest<string>("Edited faild");
            return Success("Success");
        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null) return NotFound<string>("user is not found");
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded) return BadRequest<string>("Edited faild");
            return Success("");
        }

        public async Task<Response<string>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            //get user
            //check if user is exist
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            //if Not Exist notfound
            if (user == null) return NotFound<string>();

            //Change User Password
            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            //var user1=await _userManager.HasPasswordAsync(user);
            //await _userManager.RemovePasswordAsync(user);
            //await _userManager.AddPasswordAsync(user, request.NewPassword);

            //result
            if (!result.Succeeded) return BadRequest<string>(result.Errors.FirstOrDefault().Description);
            return Success((string)"Success");

        }
        #endregion

    }
}
