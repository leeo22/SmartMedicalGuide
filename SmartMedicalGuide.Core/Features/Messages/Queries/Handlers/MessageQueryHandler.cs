using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Messages.Queries.Models;
using SmartMedicalGuide.Core.Features.Messages.Queries.Results;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Messages.Queries.Handlers
{
    public class MessageQueryHandler : ResponseHandler,
        IRequestHandler<GetMessageListQuery, Response<List<GetMessageListResponse>>>,
        IRequestHandler<GetMessageByIDQuery, Response<GetSingleMessageResponse>>
    {
        private readonly IMessageServices _messageServices;
        private readonly IMapper _mapper;

        public MessageQueryHandler(IMessageServices messageServices, IMapper mapper)
        {
            _messageServices = messageServices;
            _mapper = mapper;
        }

        public async Task<Response<List<GetMessageListResponse>>> Handle(GetMessageListQuery request, CancellationToken cancellationToken)
        {
            var resultList = await _messageServices.GetListAsync();
            if (request.ChatId.HasValue)
                resultList = resultList.Where(m => m.ChatId == request.ChatId.Value).ToList();
            if (request.SenderId.HasValue)
                resultList = resultList.Where(m => m.SenderId == request.SenderId.Value).ToList();
            var resultListMapper = _mapper.Map<List<GetMessageListResponse>>(resultList);
            return Success(resultListMapper);
        }

        public async Task<Response<GetSingleMessageResponse>> Handle(GetMessageByIDQuery request, CancellationToken cancellationToken)
        {
            var result = await _messageServices.GetByIDAsync(request.Id);
            if (result == null) return NotFound<GetSingleMessageResponse>("No message found");
            var result1 = _mapper.Map<GetSingleMessageResponse>(result);
            return Success(result1);
        }
    }
}