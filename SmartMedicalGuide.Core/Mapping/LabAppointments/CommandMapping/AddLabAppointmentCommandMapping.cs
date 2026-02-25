using SmartMedicalGuide.Core.Features.LabAppointments.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Core.Mapping.LabAppointments
{
    public partial class LabAppointmentProfile
    {

        public void AddLabAppointmentCommandMapping()
        {
            CreateMap<AddLabAppointmentCommand, LabAppointment>()
                .ForMember(dest => dest.PatientId, opt => opt
                .MapFrom(src => src.PatientId))
                .ForMember(dest => dest.LabAppointmentId, opt => opt
                .MapFrom(src => src.LabAppointmentId));
        }
    }
}
