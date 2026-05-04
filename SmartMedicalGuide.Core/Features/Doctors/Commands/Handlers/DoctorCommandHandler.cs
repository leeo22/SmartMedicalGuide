using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Doctors.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Doctors.Commands.Handlers
{
    public class DoctorCommandHandler : ResponseHandler,
        IRequestHandler<AddDoctorCommand, Response<string>>,
        IRequestHandler<EditDoctorCommand, Response<string>>,
        IRequestHandler<DeleteDoctorCommand, Response<string>>,
        IRequestHandler<UpdateVerificationStatusCommand, Response<string>>,
        IRequestHandler<ToggleAvailableForBookingCommand, Response<string>>
    {
        private readonly IDoctorServices _doctorServices;
        private readonly IMapper _mapper;

        public DoctorCommandHandler(IDoctorServices doctorServices, IMapper mapper)
        {
            _doctorServices = doctorServices;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = _mapper.Map<Doctor>(request);
            var result = await _doctorServices.AddAsync(doctor);

            if (result == "User is already registered as a doctor")
                return BadRequest<string>("User is already registered as a doctor");
            if (result != "Success")
                return BadRequest<string>("Failed to add doctor");

            return Created("Doctor added successfully");
        }

        public async Task<Response<string>> Handle(EditDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = _mapper.Map<Doctor>(request);
            var result = await _doctorServices.EditAsync(doctor);

            if (result == "Doctor not found")
                return NotFound<string>("Doctor not found");
            if (result != "Success")
                return BadRequest<string>("Failed to edit doctor");

            return Success("Doctor edited successfully");
        }

        public async Task<Response<string>> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _doctorServices.GetByIDAsync(request.Id);
            if (doctor == null)
                return NotFound<string>("Doctor not found");

            var result = await _doctorServices.DeleteAsync(doctor);
            return result == "Success" ? Deleted<string>("Doctor deleted successfully") : BadRequest<string>("Failed to delete doctor");
        }

        public async Task<Response<string>> Handle(UpdateVerificationStatusCommand request, CancellationToken cancellationToken)
        {
            var result = await _doctorServices.UpdateVerificationStatusAsync(request.DoctorId, request.VerificationStatus);

            if (result == "Doctor not found")
                return NotFound<string>("Doctor not found");
            if (result != "Success")
                return BadRequest<string>("Failed to update verification status");

            return Success("Verification status updated successfully");
        }

        public async Task<Response<string>> Handle(ToggleAvailableForBookingCommand request, CancellationToken cancellationToken)
        {
            var result = await _doctorServices.ToggleAvailableForBookingAsync(request.DoctorId, request.IsAvailableForBooking);

            if (result == "Doctor not found")
                return NotFound<string>("Doctor not found");
            if (result != "Success")
                return BadRequest<string>("Failed to update availability");

            return Success($"Doctor availability set to {request.IsAvailableForBooking}");
        }
    }
}