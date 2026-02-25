using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Clinics.Queries.Models;
using SmartMedicalGuide.Core.Features.Clinics.Queries.Models;
using SmartMedicalGuide.Core.Features.Clinics.Queries.Results;
using SmartMedicalGuide.Core.Features.Clinics.Queries.Results;
using SmartMedicalGuide.Core.Features.Patients.Queries.Results;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;
using SmartMedicalGuide.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Core.Features.Clinics.Queries.Handlers
{
    public class ClinicQueryHandler : ResponseHandler,
                                       IRequestHandler<GetClinicListQuery, Response<List<GetClinicListResponse>>>,
                                       IRequestHandler<GetClinicByIDQuery, Response<GetSingleClinicResponse>>
    {
        #region Fields
        private readonly IClinicServices _clinicServices;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors
        public ClinicQueryHandler(IClinicServices clinicServices, IMapper mapper)
        {
            _clinicServices = clinicServices;
            _mapper = mapper;
        }

        #endregion

        #region Handels Functions

        public async Task<Response<List<GetClinicListResponse>>> Handle(GetClinicListQuery request, CancellationToken cancellationToken)
        {
            var clinicList = await _clinicServices.GetClinicsListAsync();
            var clinicListMapper = _mapper.Map<List<GetClinicListResponse>>(clinicList);
            return Success(clinicListMapper);
        }

        public async Task<Response<GetSingleClinicResponse>> Handle(GetClinicByIDQuery request, CancellationToken cancellationToken)
        {
            var clinic = await _clinicServices.GetClinicByIDAsync(request.Id);
            if (clinic == null) return NotFound<GetSingleClinicResponse>("No Clinic same ID");
            var result = _mapper.Map<GetSingleClinicResponse>(clinic);
            return Success(result);
        }
        #endregion



    }
}
