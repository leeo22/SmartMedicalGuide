using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Patients.Queries.Models;
using SmartMedicalGuide.Core.Features.Patients.Queries.Results;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Patients.Queries.Handlers
{
    public class PatientQueryHandler : ResponseHandler,
        IRequestHandler<GetPatientListQuery, Response<List<GetPatientListResponse>>>,
        IRequestHandler<GetPatientByIdQuery, Response<GetSinglePatientResponse>>,
        IRequestHandler<GetPatientByUserIdQuery, Response<GetSinglePatientResponse>>,
        IRequestHandler<GetPatientAppointmentsQuery, Response<object>>,
        IRequestHandler<GetPatientPrescriptionsQuery, Response<object>>,
        IRequestHandler<GetPatientMedicalReportsQuery, Response<object>>,
        IRequestHandler<GetPatientPaymentHistoryQuery, Response<object>>,
        IRequestHandler<GetPatientUpcomingAppointmentsQuery, Response<object>>,
        IRequestHandler<GetPatientPastAppointmentsQuery, Response<object>>,
        IRequestHandler<GetPatientFavoriteDoctorsQuery, Response<object>>,
        IRequestHandler<GetPatientReviewsQuery, Response<object>>,
        IRequestHandler<GetPatientStatisticsQuery, Response<object>>
    {
        private readonly IPatientServices _patientServices;
        private readonly IMapper _mapper;

        public PatientQueryHandler(IPatientServices patientServices, IMapper mapper)
        {
            _patientServices = patientServices;
            _mapper = mapper;
        }

        public async Task<Response<List<GetPatientListResponse>>> Handle(GetPatientListQuery request, CancellationToken cancellationToken)
        {
            List<Patient> patients;

            if (!string.IsNullOrWhiteSpace(request.SearchKeyword))
                patients = await _patientServices.SearchPatientsAsync(request.SearchKeyword);
            else
                patients = await _patientServices.GetListAsync();

            var result = _mapper.Map<List<GetPatientListResponse>>(patients);
            return Success(result);
        }

        public async Task<Response<GetSinglePatientResponse>> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            var patient = await _patientServices.GetByIDAsync(request.Id);
            if (patient == null)
                return NotFound<GetSinglePatientResponse>("Patient not found");

            var result = _mapper.Map<GetSinglePatientResponse>(patient);
            return Success(result);
        }

        public async Task<Response<GetSinglePatientResponse>> Handle(GetPatientByUserIdQuery request, CancellationToken cancellationToken)
        {
            var patient = await _patientServices.GetByUserIdAsync(request.UserId);
            if (patient == null)
                return NotFound<GetSinglePatientResponse>("Patient not found for this user");

            var result = _mapper.Map<GetSinglePatientResponse>(patient);
            return Success(result);
        }

        public async Task<Response<object>> Handle(GetPatientAppointmentsQuery request, CancellationToken cancellationToken)
        {
            var result = await _patientServices.GetPatientAppointmentsAsync(request.PatientId);
            return Success(result);
        }

        public async Task<Response<object>> Handle(GetPatientPrescriptionsQuery request, CancellationToken cancellationToken)
        {
            var result = await _patientServices.GetPatientPrescriptionsAsync(request.PatientId);
            return Success(result);
        }

        public async Task<Response<object>> Handle(GetPatientMedicalReportsQuery request, CancellationToken cancellationToken)
        {
            var result = await _patientServices.GetPatientMedicalReportsAsync(request.PatientId);
            return Success(result);
        }

        public async Task<Response<object>> Handle(GetPatientPaymentHistoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _patientServices.GetPatientPaymentHistoryAsync(request.PatientId);
            return Success(result);
        }

        public async Task<Response<object>> Handle(GetPatientUpcomingAppointmentsQuery request, CancellationToken cancellationToken)
        {
            var result = await _patientServices.GetPatientUpcomingAppointmentsAsync(request.PatientId);
            return Success(result);
        }

        public async Task<Response<object>> Handle(GetPatientPastAppointmentsQuery request, CancellationToken cancellationToken)
        {
            var result = await _patientServices.GetPatientPastAppointmentsAsync(request.PatientId);
            return Success(result);
        }

        public async Task<Response<object>> Handle(GetPatientFavoriteDoctorsQuery request, CancellationToken cancellationToken)
        {
            var result = await _patientServices.GetPatientFavoriteDoctorsAsync(request.PatientId);
            return Success(result);
        }

        public async Task<Response<object>> Handle(GetPatientReviewsQuery request, CancellationToken cancellationToken)
        {
            var result = await _patientServices.GetPatientReviewsAsync(request.PatientId);
            return Success(result);
        }

        public async Task<Response<object>> Handle(GetPatientStatisticsQuery request, CancellationToken cancellationToken)
        {
            var result = await _patientServices.GetPatientStatisticsAsync(request.PatientId);
            return Success(result);
        }
    }
}