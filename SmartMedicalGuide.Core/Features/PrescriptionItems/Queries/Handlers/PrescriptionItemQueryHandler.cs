using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.PrescriptionItems.Queries.Models;
using SmartMedicalGuide.Core.Features.PrescriptionItems.Queries.Results;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.PrescriptionItems.Queries.Handlers
{
    public class PrescriptionItemQueryHandler : ResponseHandler,
        IRequestHandler<GetPrescriptionItemListQuery, Response<List<GetPrescriptionItemListResponse>>>,
        IRequestHandler<GetPrescriptionItemByIdQuery, Response<GetSinglePrescriptionItemResponse>>,
        IRequestHandler<GetPrescriptionItemsWithDetailsQuery, Response<List<GetPrescriptionItemWithDetailsResponse>>>
    {
        private readonly IPrescriptionItemServices _itemServices;
        private readonly IMapper _mapper;

        public PrescriptionItemQueryHandler(IPrescriptionItemServices itemServices, IMapper mapper)
        {
            _itemServices = itemServices;
            _mapper = mapper;
        }

        public async Task<Response<List<GetPrescriptionItemListResponse>>> Handle(GetPrescriptionItemListQuery request, CancellationToken cancellationToken)
        {
            List<PrescriptionItem> items;

            if (request.PrescriptionId.HasValue)
            {
                items = await _itemServices.GetByPrescriptionIdAsync(request.PrescriptionId.Value);
            }
            else if (!string.IsNullOrWhiteSpace(request.MedicineName))
            {
                items = await _itemServices.GetByMedicineNameAsync(request.MedicineName);
            }
            else
            {
                items = await _itemServices.GetListAsync();
            }

            var result = _mapper.Map<List<GetPrescriptionItemListResponse>>(items);
            return Success(result);
        }

        public async Task<Response<GetSinglePrescriptionItemResponse>> Handle(GetPrescriptionItemByIdQuery request, CancellationToken cancellationToken)
        {
            var item = await _itemServices.GetByIDAsync(request.Id);
            if (item == null)
                return NotFound<GetSinglePrescriptionItemResponse>("Item not found");

            var result = _mapper.Map<GetSinglePrescriptionItemResponse>(item);
            return Success(result);
        }

        public async Task<Response<List<GetPrescriptionItemWithDetailsResponse>>> Handle(GetPrescriptionItemsWithDetailsQuery request, CancellationToken cancellationToken)
        {
            var items = await _itemServices.GetPrescriptionItemsWithDetailsAsync(request.PrescriptionId);
            var result = _mapper.Map<List<GetPrescriptionItemWithDetailsResponse>>(items);
            return Success(result);
        }
    }
}