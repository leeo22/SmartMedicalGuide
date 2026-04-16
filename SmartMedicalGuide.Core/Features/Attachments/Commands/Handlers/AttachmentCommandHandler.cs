using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Attachments.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Attachments.Commands.Handlers
{
    public class AttachmentCommandHandler : ResponseHandler,
        IRequestHandler<AddAttachmentCommand, Response<string>>,
        IRequestHandler<EditAttachmentCommand, Response<string>>,
        IRequestHandler<DeleteAttachmentCommand, Response<string>>
    {
        private readonly IAttachmentServices _attachmentServices;
        private readonly IMapper _mapper;

        public AttachmentCommandHandler(IAttachmentServices attachmentServices, IMapper mapper)
        {
            _attachmentServices = attachmentServices;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddAttachmentCommand request, CancellationToken cancellationToken)
        {
            var resultMapper = _mapper.Map<Attachment>(request);
            var result = await _attachmentServices.AddAsync(resultMapper);
            return result == "Success" ? Created("Attachment added successfully") : BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditAttachmentCommand request, CancellationToken cancellationToken)
        {
            var result = await _attachmentServices.GetByIDAsync(request.AttachmentId);
            if (result == null) return NotFound<string>("Attachment not found");
            var resultMapper = _mapper.Map<Attachment>(request);
            var result1 = await _attachmentServices.EditAsync(resultMapper);
            return result1 == "Success" ? Success("Attachment edited successfully") : BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteAttachmentCommand request, CancellationToken cancellationToken)
        {
            var result = await _attachmentServices.GetByIDAsync(request.Id);
            if (result == null) return NotFound<string>("Attachment not found");
            var result1 = await _attachmentServices.DeleteAsync(result);
            return result1 == "Success" ? Deleted<string>($"Attachment deleted successfully: {request.Id}") : BadRequest<string>();
        }
    }
}