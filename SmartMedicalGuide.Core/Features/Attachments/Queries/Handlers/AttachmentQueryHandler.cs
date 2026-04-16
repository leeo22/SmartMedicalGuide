using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Attachments.Queries.Models;
using SmartMedicalGuide.Core.Features.Attachments.Queries.Results;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Attachments.Queries.Handlers
{
    public class AttachmentQueryHandler : ResponseHandler,
        IRequestHandler<GetAttachmentListQuery, Response<List<GetAttachmentListResponse>>>,
        IRequestHandler<GetAttachmentByIDQuery, Response<GetSingleAttachmentResponse>>
    {
        private readonly IAttachmentServices _attachmentServices;
        private readonly IMapper _mapper;

        public AttachmentQueryHandler(IAttachmentServices attachmentServices, IMapper mapper)
        {
            _attachmentServices = attachmentServices;
            _mapper = mapper;
        }

        public async Task<Response<List<GetAttachmentListResponse>>> Handle(GetAttachmentListQuery request, CancellationToken cancellationToken)
        {
            var resultList = await _attachmentServices.GetListAsync();
            if (request.UserId.HasValue)
                resultList = resultList.Where(a => a.UserId == request.UserId.Value).ToList();
            var resultListMapper = _mapper.Map<List<GetAttachmentListResponse>>(resultList);
            return Success(resultListMapper);
        }

        public async Task<Response<GetSingleAttachmentResponse>> Handle(GetAttachmentByIDQuery request, CancellationToken cancellationToken)
        {
            var result = await _attachmentServices.GetByIDAsync(request.Id);
            if (result == null) return NotFound<GetSingleAttachmentResponse>("No attachment found");
            var result1 = _mapper.Map<GetSingleAttachmentResponse>(result);
            return Success(result1);
        }
    }
}