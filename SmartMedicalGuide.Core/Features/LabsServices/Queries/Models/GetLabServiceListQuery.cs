using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.LabServices.Queries.Results;

namespace SmartMedicalGuide.Core.Features.LabServices.Queries.Models
{
    public class GetLabServiceListQuery : IRequest<Response<List<GetLabServiceListResponse>>>
    {
        public int? LabId { get; set; }
        public string? SearchKeyword { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? Category { get; set; }
    }
}