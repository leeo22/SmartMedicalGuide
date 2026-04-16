using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.PrescriptionItems.Queries.Models;
using SmartMedicalGuide.Core.Features.PrescriptionItems.Queries.Results;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.PrescriptionItems.Queries.Handlers
{
    public class PrescriptionItemQueryHandler : ResponseHandler,
        IRequestHandler<GetPrescriptionItemListQuery, Response<List<GetPrescriptionItemListResponse>>>,
        IRequestHandler<GetPrescriptionItemByIDQuery, Response<GetSinglePrescriptionItemResponse>>
    {
        private readonly IPrescriptionItemServices _prescriptionItemServices;
        private readonly IMapper _mapper;

        public PrescriptionItemQueryHandler(IPrescriptionItemServices prescriptionItemServices, IMapper mapper)
        {
            _prescriptionItemServices = prescriptionItemServices;
            _mapper = mapper;
        }

        public async Task<Response<List<GetPrescriptionItemListResponse>>> Handle(GetPrescriptionItemListQuery request, CancellationToken cancellationToken)
        {
            var resultList = await _prescriptionItemServices.GetListAsync();
            if (request.PrescriptionId.HasValue)
                resultList = resultList.Where(pi => pi.PrescriptionId == request.PrescriptionId.Value).ToList();
            var resultListMapper = _mapper.Map<List<GetPrescriptionItemListResponse>>(resultList);
            return Success(resultListMapper);
        }

        public async Task<Response<GetSinglePrescriptionItemResponse>> Handle(GetPrescriptionItemByIDQuery request, CancellationToken cancellationToken)
        {
            var result = await _prescriptionItemServices.GetByIDAsync(request.Id);
            if (result == null) return NotFound<GetSinglePrescriptionItemResponse>("No prescription item found");
            var result1 = _mapper.Map<GetSinglePrescriptionItemResponse>(result);
            return Success(result1);
        }
    }
}