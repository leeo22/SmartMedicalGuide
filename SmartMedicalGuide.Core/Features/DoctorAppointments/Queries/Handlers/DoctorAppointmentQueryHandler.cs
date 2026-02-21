using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.DoctorAppointments.Queries.Results;
using SmartMedicalGuide.Core.Features.Doctors.Queries.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Doctors.Queries.Handlers
{
    internal class DoctorAppointmentQueryHandler : ResponseHandler,
                                        IRequestHandler<GetDoctorAppointmentListQuery, Response<List<GetDoctorAppointmentListRespones>>>,
                                        IRequestHandler<GetDoctorAppointmentByIDQuery, Response<GetSingleDoctorAppointmentResponse>>
    {
        #region Fields
        private readonly IDoctorAppointmentServices _doctorServices;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors
        public DoctorAppointmentQueryHandler(IDoctorAppointmentServices doctorServices, IMapper mapper)
        {
            _doctorServices = doctorServices;
            _mapper = mapper;
        }
        #endregion

        #region Handels Functions
        public async Task<Response<List<GetDoctorAppointmentListRespones>>> Handle(GetDoctorAppointmentListQuery request, CancellationToken cancellationToken)
        {
            var doctorList = await _doctorServices.GetDoctorAppointmentsListAsync();
            var doctorListMapper = _mapper.Map<List<GetDoctorAppointmentListRespones>>(doctorList);
            return Success(doctorListMapper);
        }

        public async Task<Response<GetSingleDoctorAppointmentResponse>> Handle(GetDoctorAppointmentByIDQuery request, CancellationToken cancellationToken)
        {
            var appointment = await _doctorServices.GetDoctorAppointmentByIDAsync(request.Id);
            if (appointment == null) return NotFound<GetSingleDoctorAppointmentResponse>("No Patient same ID");
            var result = _mapper.Map<GetSingleDoctorAppointmentResponse>(appointment);
            return Success(result);
        }
        #endregion
    }
}
