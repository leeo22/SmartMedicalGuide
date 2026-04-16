using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Prescriptions.Queries.Models;
using SmartMedicalGuide.Core.Features.Prescriptions.Queries.Results;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Prescriptions.Queries.Handlers
{
    public class PrescriptionQueryHandler : ResponseHandler,
        IRequestHandler<GetPrescriptionListQuery, Response<List<GetPrescriptionListResponse>>>,
        IRequestHandler<GetPrescriptionByIDQuery, Response<GetSinglePrescriptionResponse>>
    {
        private readonly IPrescriptionServices _prescriptionServices;
        private readonly IMapper _mapper;

        public PrescriptionQueryHandler(IPrescriptionServices prescriptionServices, IMapper mapper)
        {
            _prescriptionServices = prescriptionServices;
            _mapper = mapper;
        }

        public async Task<Response<List<GetPrescriptionListResponse>>> Handle(GetPrescriptionListQuery request, CancellationToken cancellationToken)
        {
            var resultList = await _prescriptionServices.GetListAsync();
            if (request.PatientId.HasValue)
                resultList = resultList.Where(p => p.PatientId == request.PatientId.Value).ToList();
            if (request.DoctorId.HasValue)
                resultList = resultList.Where(p => p.DoctorId == request.DoctorId.Value).ToList();
            if (request.DoctorAppointmentId.HasValue)
                resultList = resultList.Where(p => p.DoctorAppointmentId == request.DoctorAppointmentId.Value).ToList();
            var resultListMapper = _mapper.Map<List<GetPrescriptionListResponse>>(resultList);
            return Success(resultListMapper);
        }

        public async Task<Response<GetSinglePrescriptionResponse>> Handle(GetPrescriptionByIDQuery request, CancellationToken cancellationToken)
        {
            var result = await _prescriptionServices.GetByIDAsync(request.Id);
            if (result == null) return NotFound<GetSinglePrescriptionResponse>("No prescription found");
            var result1 = _mapper.Map<GetSinglePrescriptionResponse>(result);
            return Success(result1);
        }
    }
}