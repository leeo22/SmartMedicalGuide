using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Doctors.Queries.Models;
using SmartMedicalGuide.Core.Features.Doctors.Queries.Results;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Doctors.Queries.Handlers
{
    internal class DoctorQueryHandler : ResponseHandler,
                                        IRequestHandler<GetDoctorListQuery, Response<List<GetDoctorListRespones>>>,
                                        IRequestHandler<GetDoctorByIDQuery, Response<GetSingleDoctorResponse>>
    {
        #region Fields
        private readonly IDoctorServices _doctorServices;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors
        public DoctorQueryHandler(IDoctorServices DoctorServices, IMapper mapper)
        {
            _doctorServices = DoctorServices;
            _mapper = mapper;
        }
        #endregion

        #region Handels Functions
        public async Task<Response<List<GetDoctorListRespones>>> Handle(GetDoctorListQuery request, CancellationToken cancellationToken)
        {
            var doctorList = await _doctorServices.GetDoctorsListAsync();
            var doctorListMapper = _mapper.Map<List<GetDoctorListRespones>>(doctorList);
            return Success(doctorListMapper);
        }

        public async Task<Response<GetSingleDoctorResponse>> Handle(GetDoctorByIDQuery request, CancellationToken cancellationToken)
        {
            var doctor = await _doctorServices.GetDoctorByIDAsync(request.Id);
            if (doctor == null) return NotFound<GetSingleDoctorResponse>("No Patient same ID");
            var result = _mapper.Map<GetSingleDoctorResponse>(doctor);
            return Success(result);
        }
        #endregion
    }
}
