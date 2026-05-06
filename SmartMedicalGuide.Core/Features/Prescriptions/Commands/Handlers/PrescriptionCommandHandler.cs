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
        IRequestHandler<DeletePrescriptionCommand, Response<string>>,
        IRequestHandler<UpdatePrescriptionStatusCommand, Response<string>>
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
            var prescription = _mapper.Map<Prescription>(request);
            var result = await _prescriptionServices.AddAsync(prescription);

            if (result != "Success")
                return BadRequest<string>(result);

            return Created("Prescription added successfully");
        }

        public async Task<Response<string>> Handle(EditPrescriptionCommand request, CancellationToken cancellationToken)
        {
            var prescription = _mapper.Map<Prescription>(request);
            var result = await _prescriptionServices.EditAsync(prescription);

            if (result == "Prescription not found")
                return NotFound<string>("Prescription not found");
            if (result != "Success")
                return BadRequest<string>(result);

            return Success("Prescription edited successfully");
        }

        public async Task<Response<string>> Handle(DeletePrescriptionCommand request, CancellationToken cancellationToken)
        {
            var prescription = await _prescriptionServices.GetByIDAsync(request.Id);
            if (prescription == null)
                return NotFound<string>("Prescription not found");

            var result = await _prescriptionServices.DeleteAsync(prescription);
            return result == "Success" ? Deleted<string>("Prescription deleted successfully") : BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(UpdatePrescriptionStatusCommand request, CancellationToken cancellationToken)
        {
            var result = await _prescriptionServices.UpdatePrescriptionStatusAsync(request.PrescriptionId, request.Status);

            if (result == "Prescription not found")
                return NotFound<string>("Prescription not found");
            if (result != "Success")
                return BadRequest<string>(result);

            return Success($"Prescription status updated to {request.Status}");
        }
    }
}