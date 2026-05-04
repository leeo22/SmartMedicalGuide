using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.DoctorCapacitySettings.Queries.Models;
using SmartMedicalGuide.Core.Features.DoctorCapacitySettings.Queries.Results;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.DoctorCapacitySettings.Queries.Handlers
{
    public class DoctorCapacitySettingQueryHandler : ResponseHandler,
        IRequestHandler<GetDoctorCapacitySettingListQuery, Response<List<GetDoctorCapacitySettingListResponse>>>,
        IRequestHandler<GetDoctorCapacitySettingByIDQuery, Response<GetSingleDoctorCapacitySettingResponse>>,
        IRequestHandler<GetRemainingCapacityQuery, Response<int>>,
        IRequestHandler<CheckAvailabilityQuery, Response<bool>>,
        IRequestHandler<GetCapacityReportQuery, Response<List<GetDoctorCapacitySettingListResponse>>>
    {
        #region Fields
        private readonly IDoctorCapacitySettingServices _services;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public DoctorCapacitySettingQueryHandler(IDoctorCapacitySettingServices services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }
        #endregion

        #region Handlers
        public async Task<Response<List<GetDoctorCapacitySettingListResponse>>> Handle(GetDoctorCapacitySettingListQuery request, CancellationToken cancellationToken)
        {
            var settings = await _services.GetListAsync();

            if (request.DoctorId.HasValue)
                settings = settings.Where(x => x.DoctorId == request.DoctorId.Value).ToList();
            if (request.IsActive.HasValue)
                settings = settings.Where(x => x.IsActive == request.IsActive.Value).ToList();
            if (request.MinCapacity.HasValue)
                settings = settings.Where(x => x.DailyCapacity >= request.MinCapacity.Value).ToList();
            if (request.ShiftType.HasValue)
                settings = settings.Where(x => x.ShiftType == request.ShiftType.Value).ToList();
            if (request.BookingType.HasValue)
                settings = settings.Where(x => x.BookingType == request.BookingType.Value).ToList();

            var result = _mapper.Map<List<GetDoctorCapacitySettingListResponse>>(settings);
            return Success(result);
        }

        public async Task<Response<GetSingleDoctorCapacitySettingResponse>> Handle(GetDoctorCapacitySettingByIDQuery request, CancellationToken cancellationToken)
        {
            var setting = await _services.GetByIDAsync(request.Id);
            if (setting == null)
                return NotFound<GetSingleDoctorCapacitySettingResponse>("Setting not found");

            var result = _mapper.Map<GetSingleDoctorCapacitySettingResponse>(setting);
            return Success(result);
        }

        public async Task<Response<int>> Handle(GetRemainingCapacityQuery request, CancellationToken cancellationToken)
        {
            var remaining = await _services.GetRemainingCapacityAsync(request.DoctorId, request.AppointmentDate);
            return Success(remaining);
        }

        public async Task<Response<bool>> Handle(CheckAvailabilityQuery request, CancellationToken cancellationToken)
        {
            var isAvailable = await _services.CheckAvailabilityAsync(request.DoctorId, request.AppointmentDate);
            return Success(isAvailable);
        }

        public async Task<Response<List<GetDoctorCapacitySettingListResponse>>> Handle(GetCapacityReportQuery request, CancellationToken cancellationToken)
        {
            var report = await _services.GetCapacityReportAsync(request.FromDate, request.ToDate);
            var result = _mapper.Map<List<GetDoctorCapacitySettingListResponse>>(report);
            return Success(result);
        }
        #endregion
    }
}