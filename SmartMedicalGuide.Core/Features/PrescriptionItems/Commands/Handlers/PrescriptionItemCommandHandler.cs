using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.PrescriptionItems.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.PrescriptionItems.Commands.Handlers
{
    public class PrescriptionItemCommandHandler : ResponseHandler,
        IRequestHandler<AddPrescriptionItemCommand, Response<string>>,
        IRequestHandler<EditPrescriptionItemCommand, Response<string>>,
        IRequestHandler<DeletePrescriptionItemCommand, Response<string>>
    {
        private readonly IPrescriptionItemServices _prescriptionItemServices;
        private readonly IMapper _mapper;

        public PrescriptionItemCommandHandler(IPrescriptionItemServices prescriptionItemServices, IMapper mapper)
        {
            _prescriptionItemServices = prescriptionItemServices;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddPrescriptionItemCommand request, CancellationToken cancellationToken)
        {
            var resultMapper = _mapper.Map<PrescriptionItem>(request);
            var result = await _prescriptionItemServices.AddAsync(resultMapper);
            return result == "Success" ? Created("Prescription item added successfully") : BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditPrescriptionItemCommand request, CancellationToken cancellationToken)
        {
            var result = await _prescriptionItemServices.GetByIDAsync(request.ItemId);
            if (result == null) return NotFound<string>("Prescription item not found");
            var resultMapper = _mapper.Map<PrescriptionItem>(request);
            var result1 = await _prescriptionItemServices.EditAsync(resultMapper);
            return result1 == "Success" ? Success("Prescription item edited successfully") : BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeletePrescriptionItemCommand request, CancellationToken cancellationToken)
        {
            var result = await _prescriptionItemServices.GetByIDAsync(request.Id);
            if (result == null) return NotFound<string>("Prescription item not found");
            var result1 = await _prescriptionItemServices.DeleteAsync(result);
            return result1 == "Success" ? Deleted<string>($"Prescription item deleted successfully: {request.Id}") : BadRequest<string>();
        }
    }
}