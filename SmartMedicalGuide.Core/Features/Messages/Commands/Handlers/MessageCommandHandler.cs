using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Messages.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Messages.Commands.Handlers
{
    public class MessageCommandHandler : ResponseHandler,
        IRequestHandler<AddMessageCommand, Response<string>>,
        IRequestHandler<EditMessageCommand, Response<string>>,
        IRequestHandler<DeleteMessageCommand, Response<string>>
    {
        private readonly IMessageServices _messageServices;
        private readonly IMapper _mapper;

        public MessageCommandHandler(IMessageServices messageServices, IMapper mapper)
        {
            _messageServices = messageServices;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddMessageCommand request, CancellationToken cancellationToken)
        {
            var resultMapper = _mapper.Map<Message>(request);
            var result = await _messageServices.AddAsync(resultMapper);
            return result == "Success" ? Created("Message added successfully") : BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditMessageCommand request, CancellationToken cancellationToken)
        {
            var result = await _messageServices.GetByIDAsync(request.MessageId);
            if (result == null) return NotFound<string>("Message not found");
            var resultMapper = _mapper.Map<Message>(request);
            var result1 = await _messageServices.EditAsync(resultMapper);
            return result1 == "Success" ? Success("Message edited successfully") : BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            var result = await _messageServices.GetByIDAsync(request.Id);
            if (result == null) return NotFound<string>("Message not found");
            var result1 = await _messageServices.DeleteAsync(result);
            return result1 == "Success" ? Deleted<string>($"Message deleted successfully: {request.Id}") : BadRequest<string>();
        }
    }
}