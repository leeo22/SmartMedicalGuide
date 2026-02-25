using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Clinics.Commands.Models;
using SmartMedicalGuide.Core.Features.Patients.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;
using SmartMedicalGuide.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Core.Features.Clinics.Commands.Handlers
{
    public class ClinicCommandHandler : ResponseHandler,
                                       IRequestHandler<AddClinicCommand, Response<string>>,
                                       IRequestHandler<EditClinicCommand, Response<string>>,
                                       IRequestHandler<DeleteClinicCommand, Response<string>>
    {

        #region Fields
        private readonly IClinicServices _clinicServices;
        private readonly IMapper _mapper;
        #endregion


        #region Constructors
        public ClinicCommandHandler(IClinicServices clinicServices, IMapper mapper)
        {
            _clinicServices = clinicServices;
            _mapper = mapper;
        }





        #endregion


        #region Handle Functions

        public async Task<Response<string>> Handle(AddClinicCommand request, CancellationToken cancellationToken)
        {
            // mapping between request and patient
            var clinicMapper = _mapper.Map<Clinic>(request);
            //add
            var result = await _clinicServices.AddAsync(clinicMapper);
            //return response
            if (result == "Success") return Created("Added Sussessfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditClinicCommand request, CancellationToken cancellationToken)
        {
            var Clinic = await _clinicServices.GetClinicByIDAsync(request.ClinicId);
            if (Clinic == null) return NotFound<string>("Clinic is not found");
            var clinicMapper = _mapper.Map<Clinic>(request);
            var result = await _clinicServices.EditAsync(clinicMapper);
            if (result == "Success") return Success("Edited Sussessfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteClinicCommand request, CancellationToken cancellationToken)
        {
            var clinic = await _clinicServices.GetClinicByIDAsync(request.Id);
            if (clinic == null) return NotFound<string>("Clinic is not found");
            var result = await _clinicServices.DeleteAsync(clinic);
            if (result == "Success") return Deleted<string>($"Deleted Sussessfully {request.Id}");
            else return BadRequest<string>();
        }



        #endregion
    }
 }
