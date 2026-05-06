using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Labs.Queries.Models;
using SmartMedicalGuide.Core.Features.Labs.Queries.Results;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Labs.Queries.Handlers
{
    public class LabQueryHandler : ResponseHandler,
        IRequestHandler<GetLabListQuery, Response<List<GetLabListResponse>>>,
        IRequestHandler<GetLabByIdQuery, Response<GetSingleLabResponse>>,
        IRequestHandler<GetLabByUserIdQuery, Response<GetSingleLabResponse>>,
        IRequestHandler<GetLabWithServicesQuery, Response<GetLabWithServicesResponse>>
    {
        private readonly ILabServices _labServices;
        private readonly IMapper _mapper;

        public LabQueryHandler(ILabServices labServices, IMapper mapper)
        {
            _labServices = labServices;
            _mapper = mapper;
        }

        public async Task<Response<List<GetLabListResponse>>> Handle(GetLabListQuery request, CancellationToken cancellationToken)
        {
            List<Lab> labs;

            if (request.IsVerified.HasValue && request.IsVerified.Value)
            {
                labs = await _labServices.GetVerifiedLabsAsync();
            }
            else if (!string.IsNullOrWhiteSpace(request.Location))
            {
                labs = await _labServices.GetByLocationAsync(request.Location);
            }
            else if (!string.IsNullOrWhiteSpace(request.SearchKeyword))
            {
                labs = await _labServices.SearchLabsAsync(request.SearchKeyword);
            }
            else
            {
                labs = await _labServices.GetListAsync();
            }

            var result = _mapper.Map<List<GetLabListResponse>>(labs);
            return Success(result);
        }

        public async Task<Response<GetSingleLabResponse>> Handle(GetLabByIdQuery request, CancellationToken cancellationToken)
        {
            var lab = await _labServices.GetByIDAsync(request.Id);
            if (lab == null)
                return NotFound<GetSingleLabResponse>("Lab not found");

            var result = _mapper.Map<GetSingleLabResponse>(lab);
            return Success(result);
        }

        public async Task<Response<GetSingleLabResponse>> Handle(GetLabByUserIdQuery request, CancellationToken cancellationToken)
        {
            var lab = await _labServices.GetByUserIdAsync(request.UserId);
            if (lab == null)
                return NotFound<GetSingleLabResponse>("Lab not found for this user");

            var result = _mapper.Map<GetSingleLabResponse>(lab);
            return Success(result);
        }

        public async Task<Response<GetLabWithServicesResponse>> Handle(GetLabWithServicesQuery request, CancellationToken cancellationToken)
        {
            var lab = await _labServices.GetLabWithServicesAsync(request.Id);
            if (lab == null)
                return NotFound<GetLabWithServicesResponse>("Lab not found");

            var result = new GetLabWithServicesResponse
            {
                LabId = lab.LabId,
                LabName = lab.User?.FullName ?? "Unknown",
                CenterName = lab.CenterName,
                CenterType = lab.CenterType,
                PhoneNumber = lab.PhoneNumber,
                Location = lab.Location,
                VerificationStatus = lab.VerificationStatus,
                LabImageUrl = lab.LabImageUrl,
                Description = lab.Description,
                Email = lab.Email,
                WorkingHours = lab.WorkingHours,
                Services = lab.LabServices?.Select(s => new LabServiceDto
                {
                    ServiceId = s.ServiceId,
                    ServiceName = s.ServiceName,
                    Description = s.Description,
                    Price = s.Price
                }).ToList() ?? new List<LabServiceDto>()
            };

            return Success(result);
        }
    }
}