using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Patients.Queries.Models;
using SmartMedicalGuide.Core.Features.Patients.Queries.Results;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Patients.Queries.Handlers
{
    public class PatientQueryHandler : ResponseHandler,
                                       IRequestHandler<GetPatientListQuery, Response<List<GetPatientListResponse>>>,
                                       IRequestHandler<GetPatientByIDQuery, Response<GetSinglePatientResponse>>
    {
        #region Fields
        private readonly IPatientServices _patientServices;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors
        public PatientQueryHandler(IPatientServices PatientServices, IMapper mapper)
        {
            _patientServices = PatientServices;
            _mapper = mapper;
        }
        #endregion

        #region Handels Functions
        public async Task<Response<List<GetPatientListResponse>>> Handle(GetPatientListQuery request, CancellationToken cancellationToken)
        {
            var patientList = await _patientServices.GetPatientsListAsync();
            var patientListMapper = _mapper.Map<List<GetPatientListResponse>>(patientList);
            return Success(patientListMapper);
        }

        public async Task<Response<GetSinglePatientResponse>> Handle(GetPatientByIDQuery request, CancellationToken cancellationToken)
        {
            var patient = await _patientServices.GetPatientByIdAsync(request.Id);
            if (patient == null) return NotFound<GetSinglePatientResponse>("No Patient same ID");
            var result = _mapper.Map<GetSinglePatientResponse>(patient);
            return Success(result);
        }
        #endregion

    }
}
