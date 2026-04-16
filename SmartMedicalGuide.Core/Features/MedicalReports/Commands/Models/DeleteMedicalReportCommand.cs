using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.MedicalReports.Commands.Models
{
    public class DeleteMedicalReportCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteMedicalReportCommand(int id) => Id = id;
    }
}