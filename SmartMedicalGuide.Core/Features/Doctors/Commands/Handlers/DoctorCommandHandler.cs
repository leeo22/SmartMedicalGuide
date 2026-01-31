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
                                       IRequestHandler<DeleteDoctorCommand, Response<string>>
    {
        #region Fields
        private readonly IDoctorServices _doctorServices;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public DoctorCommandHandler(IDoctorServices doctorServices, IMapper mapper)
        {
            _doctorServices = doctorServices;
            _mapper = mapper;
        }
        #endregion
        #region Handels Functions
        public async Task<Response<string>> Handle(AddDoctorCommand request, CancellationToken cancellationToken)
        {
            // mapping between request and user
            var doctorMapper = _mapper.Map<Doctor>(request);
            //add
            var result = await _doctorServices.AddAsync(doctorMapper);
            //return response
            if (result == "Success") return Created("Added Sussessfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _doctorServices.GetDoctorByIDAsync(request.Id);
            if (doctor == null) return NotFound<string>("user is not found");
            var result = await _doctorServices.DeleteAsync(doctor);
            if (result == "Success") return Deleted<string>($"Deleted Sussessfully {request.Id}");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _doctorServices.GetDoctorByIDAsync(request.DoctorId);
            if (doctor == null) return NotFound<string>("user is not found");
            var doctorMapper = _mapper.Map<Doctor>(request);
            var result = await _doctorServices.EditAsync(doctorMapper);
            if (result == "Success") return Success("Edited Sussessfully");
            else return BadRequest<string>();
        }
        #endregion

    }
}
