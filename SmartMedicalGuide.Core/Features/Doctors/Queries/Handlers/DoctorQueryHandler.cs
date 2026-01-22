using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Doctors.Queries.Models;
using SmartMedicalGuide.Core.Features.Doctors.Queries.Results;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Doctors.Queries.Handlers
{
    internal class DoctorQueryHandler : ResponseHandler, IRequestHandler<GetDoctorListQuery, Response<List<GetDoctorListRespones>>>
    {
        #region Fields
        private readonly IDoctorServices _DoctorServices;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors
        public DoctorQueryHandler(IDoctorServices DoctorServices, IMapper mapper)
        {
            _DoctorServices = DoctorServices;
            _mapper = mapper;
        }
        #endregion
        public async Task<Response<List<GetDoctorListRespones>>> Handle(GetDoctorListQuery request, CancellationToken cancellationToken)
        {
            var doctorList = await _DoctorServices.GetAllDoctorListAsync();
            var doctorListMapper = _mapper.Map<List<GetDoctorListRespones>>(doctorList);
            return Success(doctorListMapper);
        }
    }
}
