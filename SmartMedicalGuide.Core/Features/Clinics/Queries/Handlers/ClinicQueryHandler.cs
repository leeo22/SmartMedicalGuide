using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Clinics.Queries.Models;
using SmartMedicalGuide.Core.Features.Clinics.Queries.Results;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Clinics.Queries.Handlers
{
    public class ClinicQueryHandler : ResponseHandler,
        IRequestHandler<GetClinicListQuery, Response<List<GetClinicListResponse>>>,
        IRequestHandler<GetClinicByIdQuery, Response<GetSingleClinicResponse>>,
        IRequestHandler<GetClinicWithDoctorQuery, Response<GetSingleClinicResponse>>
    {
        private readonly IClinicServices _clinicServices;
        private readonly IMapper _mapper;

        public ClinicQueryHandler(IClinicServices clinicServices, IMapper mapper)
        {
            _clinicServices = clinicServices;
            _mapper = mapper;
        }

        public async Task<Response<List<GetClinicListResponse>>> Handle(GetClinicListQuery request, CancellationToken cancellationToken)
        {
            List<Clinic> clinics;

            if (request.DoctorId.HasValue)
            {
                clinics = await _clinicServices.GetByDoctorIdAsync(request.DoctorId.Value);
            }
            else if (!string.IsNullOrWhiteSpace(request.Location))
            {
                clinics = await _clinicServices.GetByLocationAsync(request.Location);
            }
            else if (!string.IsNullOrWhiteSpace(request.SearchKeyword))
            {
                clinics = await _clinicServices.SearchClinicsAsync(request.SearchKeyword);
            }
            else if (request.IsActive.HasValue)
            {
                clinics = request.IsActive.Value
                    ? await _clinicServices.GetActiveClinicsAsync()
                    : await _clinicServices.GetListAsync();
            }
            else
            {
                clinics = await _clinicServices.GetListAsync();
            }

            var result = _mapper.Map<List<GetClinicListResponse>>(clinics);
            return Success(result);
        }

        public async Task<Response<GetSingleClinicResponse>> Handle(GetClinicByIdQuery request, CancellationToken cancellationToken)
        {
            var clinic = await _clinicServices.GetByIDAsync(request.Id);
            if (clinic == null)
                return NotFound<GetSingleClinicResponse>("Clinic not found");

            var result = _mapper.Map<GetSingleClinicResponse>(clinic);
            return Success(result);
        }

        public async Task<Response<GetSingleClinicResponse>> Handle(GetClinicWithDoctorQuery request, CancellationToken cancellationToken)
        {
            var clinic = await _clinicServices.GetClinicWithDoctorAsync(request.Id);
            if (clinic == null)
                return NotFound<GetSingleClinicResponse>("Clinic not found");

            var result = _mapper.Map<GetSingleClinicResponse>(clinic);
            return Success(result);
        }
    }
}