using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Prescriptions.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Prescriptions.Commands.Handlers
{
    public class PrescriptionCommandHandler : ResponseHandler,
        IRequestHandler<AddPrescriptionCommand, Response<string>>,
        IRequestHandler<EditPrescriptionCommand, Response<string>>,
        IRequestHandler<DeletePrescriptionCommand, Response<string>>
    {
        private readonly IPrescriptionServices _prescriptionServices;
        private readonly IMapper _mapper;

        public PrescriptionCommandHandler(IPrescriptionServices prescriptionServices, IMapper mapper)
        {
            _prescriptionServices = prescriptionServices;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddPrescriptionCommand request, CancellationToken cancellationToken)
        {
            var resultMapper = _mapper.Map<Prescription>(request);
            var result = await _prescriptionServices.AddAsync(resultMapper);
            return result == "Success" ? Created("Prescription added successfully") : BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditPrescriptionCommand request, CancellationToken cancellationToken)
        {
            var result = await _prescriptionServices.GetByIDAsync(request.PrescriptionId);
            if (result == null) return NotFound<string>("Prescription not found");
            var resultMapper = _mapper.Map<Prescription>(request);
            var result1 = await _prescriptionServices.EditAsync(resultMapper);
            return result1 == "Success" ? Success("Prescription edited successfully") : BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeletePrescriptionCommand request, CancellationToken cancellationToken)
        {
            var result = await _prescriptionServices.GetByIDAsync(request.Id);
            if (result == null) return NotFound<string>("Prescription not found");
            var result1 = await _prescriptionServices.DeleteAsync(result);
            return result1 == "Success" ? Deleted<string>($"Prescription deleted successfully: {request.Id}") : BadRequest<string>();
        }
    }
}