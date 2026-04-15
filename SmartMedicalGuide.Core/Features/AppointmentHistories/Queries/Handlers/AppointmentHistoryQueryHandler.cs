using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.AppointmentHistories.Queries.Models;
using SmartMedicalGuide.Core.Features.AppointmentHistories.Queries.Results;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.AppointmentHistories.Queries.Handlers
{
    public class AppointmentHistoryQueryHandler : ResponseHandler,
        IRequestHandler<GetAppointmentHistoryListQuery, Response<List<GetAppointmentHistoryListResponse>>>,
        IRequestHandler<GetAppointmentHistoryByIDQuery, Response<GetSingleAppointmentHistoryResponse>>
    {
        private readonly IAppointmentHistoryServices _appointmentHistoryServices;
        private readonly IMapper _mapper;

        public AppointmentHistoryQueryHandler(IAppointmentHistoryServices appointmentHistoryServices, IMapper mapper)
        {
            _appointmentHistoryServices = appointmentHistoryServices;
            _mapper = mapper;
        }

        public async Task<Response<List<GetAppointmentHistoryListResponse>>> Handle(GetAppointmentHistoryListQuery request, CancellationToken cancellationToken)
        {
            var resultList = await _appointmentHistoryServices.GetListAsync();
            if (request.AppointmentId.HasValue)
                resultList = resultList.Where(h => h.AppointmentId == request.AppointmentId.Value).ToList();
            if (!string.IsNullOrEmpty(request.AppointmentType))
                resultList = resultList.Where(h => h.AppointmentType == request.AppointmentType).ToList();
            var resultListMapper = _mapper.Map<List<GetAppointmentHistoryListResponse>>(resultList);
            return Success(resultListMapper);
        }

        public async Task<Response<GetSingleAppointmentHistoryResponse>> Handle(GetAppointmentHistoryByIDQuery request, CancellationToken cancellationToken)
        {
            var result = await _appointmentHistoryServices.GetByIDAsync(request.Id);
            if (result == null) return NotFound<GetSingleAppointmentHistoryResponse>("No appointment history found");
            var result1 = _mapper.Map<GetSingleAppointmentHistoryResponse>(result);
            return Success(result1);
        }
    }
}