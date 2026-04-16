using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Chats.Queries.Models;
using SmartMedicalGuide.Core.Features.Chats.Queries.Results;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Chats.Queries.Handlers
{
    public class ChatQueryHandler : ResponseHandler,
        IRequestHandler<GetChatListQuery, Response<List<GetChatListResponse>>>,
        IRequestHandler<GetChatByIDQuery, Response<GetSingleChatResponse>>
    {
        private readonly IChatServices _chatServices;
        private readonly IMapper _mapper;

        public ChatQueryHandler(IChatServices chatServices, IMapper mapper)
        {
            _chatServices = chatServices;
            _mapper = mapper;
        }

        public async Task<Response<List<GetChatListResponse>>> Handle(GetChatListQuery request, CancellationToken cancellationToken)
        {
            var resultList = await _chatServices.GetListAsync();
            if (request.PatientId.HasValue)
                resultList = resultList.Where(c => c.PatientId == request.PatientId.Value).ToList();
            if (request.DoctorId.HasValue)
                resultList = resultList.Where(c => c.DoctorId == request.DoctorId.Value).ToList();
            var resultListMapper = _mapper.Map<List<GetChatListResponse>>(resultList);
            return Success(resultListMapper);
        }

        public async Task<Response<GetSingleChatResponse>> Handle(GetChatByIDQuery request, CancellationToken cancellationToken)
        {
            var result = await _chatServices.GetByIDAsync(request.Id);
            if (result == null) return NotFound<GetSingleChatResponse>("No chat found");
            var result1 = _mapper.Map<GetSingleChatResponse>(result);
            return Success(result1);
        }
    }
}