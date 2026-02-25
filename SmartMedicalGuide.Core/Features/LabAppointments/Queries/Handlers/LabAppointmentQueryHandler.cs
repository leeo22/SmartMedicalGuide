using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.DoctorAppointments.Queries.Results;
using SmartMedicalGuide.Core.Features.LabAppointments.Queries.Models;
using SmartMedicalGuide.Core.Features.LabAppointments.Queries.Results;
using SmartMedicalGuide.Services.Abstracts;
using SmartMedicalGuide.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Core.Features.LabAppointments.Queries.Handlers
{
    public class LabAppointmentQueryHandler : ResponseHandler,
                                        IRequestHandler<GetLabAppointmentListQuery, Response<List<GetLabAppointmentListRespones>>>,
                                        IRequestHandler<GetLabAppointmentByIDQuery, Response<GetSingleLabAppointmentResponse>>
    {

        #region Fields
        private readonly ILabAppointmentServices _labServices;
        private readonly IMapper _mapper;

        #endregion



        #region Constructors
        public LabAppointmentQueryHandler(ILabAppointmentServices labServices, IMapper mapper)
        {
            _labServices = labServices;
            _mapper = mapper;
        }
        #endregion



        #region Handels Functions
        public async Task<Response<GetSingleLabAppointmentResponse>> Handle(GetLabAppointmentByIDQuery request, CancellationToken cancellationToken)
        {
            var appointment = await _labServices.GetLabAppointmentsByIDAsync(request.Id);
            if (appointment == null) return NotFound<GetSingleLabAppointmentResponse>("No Patient same ID");
            var result = _mapper.Map<GetSingleLabAppointmentResponse>(appointment);
            return Success(result);
        }

        public async Task<Response<List<GetLabAppointmentListRespones>>> Handle(GetLabAppointmentListQuery request, CancellationToken cancellationToken)
        {
            var labList = await _labServices.GetLabAppointmentsListAsync();
            var labListMapper = _mapper.Map<List<GetLabAppointmentListRespones>>(labList);
            return Success(labListMapper);
        }
        #endregion
    }
}
