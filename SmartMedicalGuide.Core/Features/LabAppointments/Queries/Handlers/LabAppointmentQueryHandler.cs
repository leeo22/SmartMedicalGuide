using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.LabAppointments.Queries.Models;
using SmartMedicalGuide.Core.Features.LabAppointments.Queries.Results;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.LabAppointments.Queries.Handlers
{
    public class LabAppointmentQueryHandler : ResponseHandler,
        IRequestHandler<GetLabAppointmentListQuery, Response<List<GetLabAppointmentListResponse>>>,
        IRequestHandler<GetLabAppointmentByIdQuery, Response<GetSingleLabAppointmentResponse>>,
        IRequestHandler<CheckLabAvailabilityQuery, Response<bool>>
    {
        private readonly ILabAppointmentServices _appointmentServices;
        private readonly IMapper _mapper;

        public LabAppointmentQueryHandler(ILabAppointmentServices appointmentServices, IMapper mapper)
        {
            _appointmentServices = appointmentServices;
            _mapper = mapper;
        }

        public async Task<Response<List<GetLabAppointmentListResponse>>> Handle(GetLabAppointmentListQuery request, CancellationToken cancellationToken)
        {
            List<LabAppointment> appointments;

            if (request.Upcoming.HasValue && request.Upcoming.Value && request.LabId.HasValue)
            {
                appointments = await _appointmentServices.GetLabUpcomingAppointmentsAsync(request.LabId.Value);
            }
            else if (request.LabId.HasValue)
            {
                appointments = await _appointmentServices.GetByLabIdAsync(request.LabId.Value);
            }
            else if (request.PatientId.HasValue)
            {
                appointments = await _appointmentServices.GetByPatientIdAsync(request.PatientId.Value);
            }
            else if (!string.IsNullOrWhiteSpace(request.Status))
            {
                appointments = await _appointmentServices.GetByStatusAsync(request.Status);
            }
            else if (request.Date.HasValue)
            {
                appointments = await _appointmentServices.GetListAsync();
                appointments = appointments.Where(x => x.AppointmentDate.Date == request.Date.Value.Date).ToList();
            }
            else
            {
                appointments = await _appointmentServices.GetListAsync();
            }

            var result = _mapper.Map<List<GetLabAppointmentListResponse>>(appointments);
            return Success(result);
        }

        public async Task<Response<GetSingleLabAppointmentResponse>> Handle(GetLabAppointmentByIdQuery request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentServices.GetByIDAsync(request.Id);
            if (appointment == null)
                return NotFound<GetSingleLabAppointmentResponse>("Appointment not found");

            var result = _mapper.Map<GetSingleLabAppointmentResponse>(appointment);
            return Success(result);
        }

        public async Task<Response<bool>> Handle(CheckLabAvailabilityQuery request, CancellationToken cancellationToken)
        {
            var isAvailable = await _appointmentServices.CheckLabAvailabilityAsync(request.LabId, request.AppointmentDate);
            return Success(isAvailable);
        }
    }
}