using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Reports.Commands.Models
{
    public class DeleteReportCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteReportCommand(int id)
        {
            Id = id;

        }
    }
}
