using SmartMedicalGuide.Core.Features.DoctorAppointments.Queries.Results;
using SmartMedicalGuide.Core.Features.LabAppointments.Queries.Results;
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
        public void GetLabAppointmentListMapping()
        {
            CreateMap<LabAppointment, GetLabAppointmentListRespones>()
                .ForMember(dest => dest.FullName, opt => opt
                                                .MapFrom(src => src.FullName))
                                            .ForMember(dest => dest.PhoneNumber, opt => opt
                                                .MapFrom(src => src.PhoneNumber))
                                            .ForMember(dest => dest.TestType, opt => opt
                                                .MapFrom(src => src.TestType))
                                            .ForMember(dest => dest.Status, opt => opt
                                                .MapFrom(src => src.Status))
                                            .ForMember(dest => dest.Price, opt => opt
                                                .MapFrom(src => src.Price));
        }

    }
}
