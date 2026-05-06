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
        IRequestHandler<DeleteAttachmentCommand, Response<string>>,
        IRequestHandler<UploadFileCommand, Response<string>>,
        IRequestHandler<DeleteFileCommand, Response<string>>,
        IRequestHandler<UpdateFileCommand, Response<string>>
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
            var attachment = _mapper.Map<Attachment>(request);
            var result = await _attachmentServices.AddAsync(attachment);

            if (result != "Success")
                return BadRequest<string>(result);

            return Created("Attachment added successfully");
        }

        public async Task<Response<string>> Handle(EditAttachmentCommand request, CancellationToken cancellationToken)
        {
            var attachment = _mapper.Map<Attachment>(request);
            var result = await _attachmentServices.EditAsync(attachment);

            if (result == "Attachment not found")
                return NotFound<string>("Attachment not found");
            if (result != "Success")
                return BadRequest<string>(result);

            return Success("Attachment edited successfully");
        }

        public async Task<Response<string>> Handle(DeleteAttachmentCommand request, CancellationToken cancellationToken)
        {
            var attachment = await _attachmentServices.GetByIDAsync(request.Id);
            if (attachment == null)
                return NotFound<string>("Attachment not found");

            var result = await _attachmentServices.DeleteAsync(attachment);
            return result == "Success" ? Deleted<string>("Attachment deleted successfully") : BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            var result = await _attachmentServices.UploadFileAsync(
                request.UserId, request.File, request.RelatedEntityType, request.RelatedEntityId, request.Description);

            if (result != "Success")
                return BadRequest<string>(result);

            return Success("File uploaded successfully");
        }

        public async Task<Response<string>> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
        {
            var result = await _attachmentServices.DeleteFileAsync(request.AttachmentId);

            if (result == "Attachment not found")
                return NotFound<string>("Attachment not found");
            if (result != "Success")
                return BadRequest<string>(result);

            return Success("File deleted successfully");
        }

        public async Task<Response<string>> Handle(UpdateFileCommand request, CancellationToken cancellationToken)
        {
            var result = await _attachmentServices.UpdateFileAsync(request.AttachmentId, request.File);

            if (result == "Attachment not found")
                return NotFound<string>("Attachment not found");
            if (result != "Success")
                return BadRequest<string>(result);

            return Success("File updated successfully");
        }
    }
}