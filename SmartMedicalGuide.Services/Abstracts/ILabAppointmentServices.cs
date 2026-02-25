using SmartMedicalGuide.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface ILabAppointmentServices
    {
        public Task<List<LabAppointment>> GetLabAppointmentsListAsync();
        public Task<string> AddAsync(LabAppointment labAppointment);
        public Task<LabAppointment> GetLabAppointmentsByIDAsync(int id);
        public Task<string> EditAsync(LabAppointment labAppointment);
        public Task<string> DeleteAsync(LabAppointment labAppointment);

    }
}
