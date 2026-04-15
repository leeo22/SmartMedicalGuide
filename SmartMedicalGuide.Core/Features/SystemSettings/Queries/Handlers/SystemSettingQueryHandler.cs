//using AutoMapper;
//using MediatR;
//using SmartMedicalGuide.Core.Bases;
//using SmartMedicalGuide.Core.Features.SystemSettings.Queries.Models;
//using SmartMedicalGuide.Core.Features.SystemSettings.Queries.Results;
//using SmartMedicalGuide.Services.Abstracts;

//namespace SmartMedicalGuide.Core.Features.SystemSettings.Queries.Handlers
//{
//    public class SystemSettingQueryHandler : ResponseHandler,
//                                    IRequestHandler<GetSystemSettingListQuery, Response<List<GetSystemSettingListResponse>>>,
//                                    IRequestHandler<GetSystemSettingByIDQuery, Response<GetSingleSystemSettingResponse>>
//    {
//        #region Fields
//        private readonly ISystemSettingServices _systemSettingServices;
//        private readonly IMapper _mapper;
//        #endregion
//        #region Constructors
//        public SystemSettingQueryHandler(ISystemSettingServices systemSettingServices, IMapper mapper)
//        {
//            _systemSettingServices = systemSettingServices;
//            _mapper = mapper;
//        }

//        #endregion
//        #region Handels Functions
//        public async Task<Response<List<GetSystemSettingListResponse>>> Handle(GetSystemSettingListQuery request, CancellationToken cancellationToken)
//        {
//            var sysList = await _systemSettingServices.GetAllSystemAsync();
//            var sysListmapper = _mapper.Map<List<GetSystemSettingListResponse>>(sysList);
//            return Success(sysListmapper);
//        }

//        public async Task<Response<GetSingleSystemSettingResponse>> Handle(GetSystemSettingByIDQuery request, CancellationToken cancellationToken)
//        {
//            var role = await _systemSettingServices.GetByIdAsync(request.Id);
//            if (role == null) return NotFound<GetSingleSystemSettingResponse>("No same ID");
//            var result = _mapper.Map<GetSingleSystemSettingResponse>(role);
//            return Success(result);
//        }




//        #endregion
//    }
//}
