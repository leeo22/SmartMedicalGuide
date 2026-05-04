using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.DoctorSchedules.Queries.Models;
using SmartMedicalGuide.Core.Features.DoctorSchedules.Queries.Results;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.DoctorSchedules.Queries.Handlers
{
    public class DoctorScheduleQueryHandler : ResponseHandler,
        IRequestHandler<GetDoctorScheduleListQuery, Response<List<GetDoctorScheduleListResponse>>>,
        IRequestHandler<GetDoctorScheduleByIdQuery, Response<GetSingleDoctorScheduleResponse>>,
        IRequestHandler<GetDoctorAvailableSlotsQuery, Response<List<string>>>,
        IRequestHandler<CheckDoctorAvailabilityQuery, Response<bool>>
    {
        private readonly IDoctorScheduleServices _scheduleServices;
        private readonly IMapper _mapper;

        public DoctorScheduleQueryHandler(IDoctorScheduleServices scheduleServices, IMapper mapper)
        {
            _scheduleServices = scheduleServices;
            _mapper = mapper;
        }

        public async Task<Response<List<GetDoctorScheduleListResponse>>> Handle(GetDoctorScheduleListQuery request, CancellationToken cancellationToken)
        {
            List<DoctorSchedule> schedules;

            if (request.DoctorId.HasValue)
                schedules = await _scheduleServices.GetByDoctorIdAsync(request.DoctorId.Value);
            else if (!string.IsNullOrWhiteSpace(request.DayOfWeek))
                schedules = await _scheduleServices.GetByDayOfWeekAsync(request.DayOfWeek);
            else
                schedules = await _scheduleServices.GetListAsync();

            var result = _mapper.Map<List<GetDoctorScheduleListResponse>>(schedules);
            return Success(result);
        }

        public async Task<Response<GetSingleDoctorScheduleResponse>> Handle(GetDoctorScheduleByIdQuery request, CancellationToken cancellationToken)
        {
            var schedule = await _scheduleServices.GetByIDAsync(request.Id);
            if (schedule == null)
                return NotFound<GetSingleDoctorScheduleResponse>("Schedule not found");

            var result = _mapper.Map<GetSingleDoctorScheduleResponse>(schedule);
            return Success(result);
        }

        public async Task<Response<List<string>>> Handle(GetDoctorAvailableSlotsQuery request, CancellationToken cancellationToken)
        {
            var slots = await _scheduleServices.GetDoctorAvailableSlotsAsync(request.DoctorId, request.Date);
            var formattedSlots = slots.Select(slot => slot.ToString(@"hh\:mm")).ToList();
            return Success(formattedSlots);
        }

        public async Task<Response<bool>> Handle(CheckDoctorAvailabilityQuery request, CancellationToken cancellationToken)
        {
            var isAvailable = await _scheduleServices.CheckDoctorAvailableAsync(request.DoctorId, request.DateTime);
            return Success(isAvailable);
        }
    }
}