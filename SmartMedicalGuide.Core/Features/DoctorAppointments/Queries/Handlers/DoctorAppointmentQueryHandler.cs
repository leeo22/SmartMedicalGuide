using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.DoctorAppointments.Queries.Models;
using SmartMedicalGuide.Core.Features.DoctorAppointments.Queries.Results;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.DoctorAppointments.Queries.Handlers
{
    public class DoctorAppointmentQueryHandler : ResponseHandler,
        IRequestHandler<GetDoctorAppointmentListQuery, Response<List<GetDoctorAppointmentListResponse>>>,
        IRequestHandler<GetDoctorAppointmentByIdQuery, Response<GetSingleDoctorAppointmentResponse>>
    {
        private readonly IDoctorAppointmentServices _appointmentServices;
        private readonly IMapper _mapper;

        public DoctorAppointmentQueryHandler(IDoctorAppointmentServices appointmentServices, IMapper mapper)
        {
            _appointmentServices = appointmentServices;
            _mapper = mapper;
        }

        public async Task<Response<List<GetDoctorAppointmentListResponse>>> Handle(GetDoctorAppointmentListQuery request, CancellationToken cancellationToken)
        {
            var appointments = await _appointmentServices.GetListAsync();
            var result = _mapper.Map<List<GetDoctorAppointmentListResponse>>(appointments);
            return Success(result);
        }

        public async Task<Response<GetSingleDoctorAppointmentResponse>> Handle(GetDoctorAppointmentByIdQuery request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentServices.GetByIDAsync(request.Id);
            if (appointment == null)
                return NotFound<GetSingleDoctorAppointmentResponse>("Appointment not found");

            var result = _mapper.Map<GetSingleDoctorAppointmentResponse>(appointment);
            return Success(result);
        }
        #region Additional Query Handlers
        public async Task<Response<List<GetDoctorAppointmentListResponse>>> Handle(GetDoctorAppointmentsByDoctorIdQuery request, CancellationToken cancellationToken)
        {
            var appointments = await _appointmentServices.GetByDoctorIdAsync(request.DoctorId);
            var result = _mapper.Map<List<GetDoctorAppointmentListResponse>>(appointments);
            return Success(result);
        }

        public async Task<Response<List<GetDoctorAppointmentListResponse>>> Handle(GetDoctorAppointmentsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            var appointments = await _appointmentServices.GetByPatientIdAsync(request.PatientId);
            var result = _mapper.Map<List<GetDoctorAppointmentListResponse>>(appointments);
            return Success(result);
        }

        public async Task<Response<List<GetDoctorAppointmentListResponse>>> Handle(GetDoctorAppointmentsByDateQuery request, CancellationToken cancellationToken)
        {
            var appointments = await _appointmentServices.GetByDateAsync(request.Date);
            var result = _mapper.Map<List<GetDoctorAppointmentListResponse>>(appointments);
            return Success(result);
        }

        public async Task<Response<List<GetDoctorAppointmentListResponse>>> Handle(GetDoctorAppointmentsByStatusQuery request, CancellationToken cancellationToken)
        {
            var appointments = await _appointmentServices.GetByStatusAsync(request.Status);
            var result = _mapper.Map<List<GetDoctorAppointmentListResponse>>(appointments);
            return Success(result);
        }

        public async Task<Response<List<GetDoctorAppointmentListResponse>>> Handle(GetDoctorUpcomingAppointmentsQuery request, CancellationToken cancellationToken)
        {
            var appointments = await _appointmentServices.GetDoctorUpcomingAppointmentsAsync(request.DoctorId);
            var result = _mapper.Map<List<GetDoctorAppointmentListResponse>>(appointments);
            return Success(result);
        }

        public async Task<Response<List<GetDoctorAppointmentListResponse>>> Handle(GetPatientUpcomingAppointmentsQuery request, CancellationToken cancellationToken)
        {
            var appointments = await _appointmentServices.GetPatientUpcomingAppointmentsAsync(request.PatientId);
            var result = _mapper.Map<List<GetDoctorAppointmentListResponse>>(appointments);
            return Success(result);
        }

        public async Task<Response<List<GetDoctorAppointmentListResponse>>> Handle(GetDoctorTodayAppointmentsQuery request, CancellationToken cancellationToken)
        {
            var appointments = await _appointmentServices.GetDoctorTodayAppointmentsAsync(request.DoctorId);
            var result = _mapper.Map<List<GetDoctorAppointmentListResponse>>(appointments);
            return Success(result);
        }

        public async Task<Response<List<GetDoctorAppointmentListResponse>>> Handle(GetDoctorAppointmentsByDateRangeQuery request, CancellationToken cancellationToken)
        {
            var appointments = await _appointmentServices.GetDoctorAppointmentsByDateRangeAsync(request.DoctorId, request.FromDate, request.ToDate);
            var result = _mapper.Map<List<GetDoctorAppointmentListResponse>>(appointments);
            return Success(result);
        }

        public async Task<Response<int>> Handle(GetDoctorAppointmentsCountQuery request, CancellationToken cancellationToken)
        {
            var count = await _appointmentServices.GetDoctorAppointmentsCountAsync(request.DoctorId);
            return Success(count);
        }

        public async Task<Response<bool>> Handle(CheckDoctorAvailabilityQuery request, CancellationToken cancellationToken)
        {
            var isAvailable = await _appointmentServices.CheckDoctorAvailabilityAsync(request.DoctorId, request.AppointmentDate);
            return Success(isAvailable);
        }

        public async Task<Response<object>> Handle(GetAppointmentsReportQuery request, CancellationToken cancellationToken)
        {
            var report = await _appointmentServices.GetAppointmentsReportAsync(request.FromDate, request.ToDate);
            return Success(report);
        }
        #endregion
    }
}