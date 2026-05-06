using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Attachments.Queries.Models;
using SmartMedicalGuide.Core.Features.Attachments.Queries.Results;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Attachments.Queries.Handlers
{
    public class AttachmentQueryHandler : ResponseHandler,
        IRequestHandler<GetAttachmentListQuery, Response<List<GetAttachmentListResponse>>>,
        IRequestHandler<GetAttachmentByIdQuery, Response<GetSingleAttachmentResponse>>,
        IRequestHandler<DownloadFileQuery, Response<(string filePath, string fileName, string contentType)>>,
        IRequestHandler<GetTotalFileSizeQuery, Response<long>>
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
            List<Attachment> attachments;

            if (request.UserId.HasValue && !string.IsNullOrWhiteSpace(request.RelatedEntityType) && request.RelatedEntityId.HasValue)
            {
                attachments = await _attachmentServices.GetByUserIdAndEntityAsync(
                    request.UserId.Value, request.RelatedEntityType, request.RelatedEntityId.Value);
            }
            else if (request.UserId.HasValue)
            {
                attachments = await _attachmentServices.GetByUserIdAsync(request.UserId.Value);
            }
            else if (!string.IsNullOrWhiteSpace(request.RelatedEntityType) && request.RelatedEntityId.HasValue)
            {
                attachments = await _attachmentServices.GetByEntityAsync(request.RelatedEntityType, request.RelatedEntityId.Value);
            }
            else
            {
                attachments = await _attachmentServices.GetListAsync();
            }

            var result = _mapper.Map<List<GetAttachmentListResponse>>(attachments);
            return Success(result);
        }

        public async Task<Response<GetSingleAttachmentResponse>> Handle(GetAttachmentByIdQuery request, CancellationToken cancellationToken)
        {
            var attachment = await _attachmentServices.GetByIDAsync(request.Id);
            if (attachment == null)
                return NotFound<GetSingleAttachmentResponse>("Attachment not found");

            var result = _mapper.Map<GetSingleAttachmentResponse>(attachment);
            return Success(result);
        }

        public async Task<Response<(string filePath, string fileName, string contentType)>> Handle(DownloadFileQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _attachmentServices.DownloadFileAsync(request.AttachmentId);
                return Success(result);
            }
            catch (Exception ex)
            {
                return BadRequest<(string filePath, string fileName, string contentType)>(ex.Message);
            }
        }

        public async Task<Response<long>> Handle(GetTotalFileSizeQuery request, CancellationToken cancellationToken)
        {
            var totalSize = await _attachmentServices.GetTotalFileSizeByUserAsync(request.UserId);
            return Success(totalSize);
        }
    }
}