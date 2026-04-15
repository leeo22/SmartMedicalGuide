//using AutoMapper;
//using MediatR;
//using SmartMedicalGuide.Core.Bases;
//using SmartMedicalGuide.Core.Features.SystemSettings.Commands.Models;
//using SmartMedicalGuide.Data.Entities;
//using SmartMedicalGuide.Services.Abstracts;

//namespace SmartMedicalGuide.Core.Features.SystemSettings.Commands.Handlers
//{
//    public class SystemSettingCommandHandler : ResponseHandler,
//                                       IRequestHandler<AddSystemSettingCommand, Response<string>>
//    {
//        #region Fields
//        private readonly ISystemSettingServices _systemSettingServices;
//        private readonly IMapper _mapper;
//        #endregion
//        #region Constructors
//        public SystemSettingCommandHandler(ISystemSettingServices systemSettingServices, IMapper mapper)
//        {
//            _systemSettingServices = systemSettingServices;
//            _mapper = mapper;
//        }

//        #endregion
//        #region Handels Functions
//        public async Task<Response<string>> Handle(AddSystemSettingCommand request, CancellationToken cancellationToken)
//        {
//            var roleMapper = _mapper.Map<SystemSetting>(request);
//            //add
//            var result = await _systemSettingServices.AddAsync(roleMapper);
//            //return response
//            if (result != null) return Created("Added Sussessfully");
//            else return BadRequest<string>();
//        }
//        #endregion

//    }

//}
