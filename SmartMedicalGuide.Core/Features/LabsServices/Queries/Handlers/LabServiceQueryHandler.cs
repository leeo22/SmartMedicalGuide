using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.LabServices.Queries.Models;
using SmartMedicalGuide.Core.Features.LabServices.Queries.Results;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.LabServices.Queries.Handlers
{
    public class LabServiceQueryHandler : ResponseHandler,
        IRequestHandler<GetLabServiceListQuery, Response<List<GetLabServiceListResponse>>>,
        IRequestHandler<GetLabServiceByIdQuery, Response<GetSingleLabServiceResponse>>,
        IRequestHandler<GetLabServicesWithLabQuery, Response<List<GetLabServiceListResponse>>>
    {
        private readonly ILabServiceServices _serviceServices;
        private readonly IMapper _mapper;

        public LabServiceQueryHandler(ILabServiceServices serviceServices, IMapper mapper)
        {
            _serviceServices = serviceServices;
            _mapper = mapper;
        }

        public async Task<Response<List<GetLabServiceListResponse>>> Handle(GetLabServiceListQuery request, CancellationToken cancellationToken)
        {
            List<LabService> services;

            if (request.LabId.HasValue)
            {
                services = await _serviceServices.GetByLabIdAsync(request.LabId.Value);
            }
            else if (request.MinPrice.HasValue && request.MaxPrice.HasValue)
            {
                services = await _serviceServices.GetByPriceRangeAsync(request.MinPrice.Value, request.MaxPrice.Value);
            }
            else if (!string.IsNullOrWhiteSpace(request.SearchKeyword))
            {
                services = await _serviceServices.SearchServicesAsync(request.SearchKeyword);
            }
            else if (!string.IsNullOrWhiteSpace(request.Category))
            {
                services = await _serviceServices.GetListAsync();
                services = services.Where(x => x.Category == request.Category).ToList();
            }
            else
            {
                services = await _serviceServices.GetListAsync();
            }

            var result = _mapper.Map<List<GetLabServiceListResponse>>(services);

            // Calculate final price after discount
            foreach (var item in result)
            {
                if (item.DiscountPercentage.HasValue && item.DiscountPercentage.Value > 0)
                {
                    item.FinalPrice = item.Price - (item.Price * (item.DiscountPercentage.Value / 100));
                }
                else
                {
                    item.FinalPrice = item.Price;
                }
            }

            return Success(result);
        }

        public async Task<Response<GetSingleLabServiceResponse>> Handle(GetLabServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var service = await _serviceServices.GetByIDAsync(request.Id);
            if (service == null)
                return NotFound<GetSingleLabServiceResponse>("Service not found");

            var result = _mapper.Map<GetSingleLabServiceResponse>(service);

            // Calculate final price after discount
            if (result.DiscountPercentage.HasValue && result.DiscountPercentage.Value > 0)
            {
                result.FinalPrice = result.Price - (result.Price * (result.DiscountPercentage.Value / 100));
            }
            else
            {
                result.FinalPrice = result.Price;
            }

            return Success(result);
        }

        public async Task<Response<List<GetLabServiceListResponse>>> Handle(GetLabServicesWithLabQuery request, CancellationToken cancellationToken)
        {
            var services = await _serviceServices.GetLabServicesWithLabAsync(request.LabId);
            var result = _mapper.Map<List<GetLabServiceListResponse>>(services);

            // Calculate final price after discount
            foreach (var item in result)
            {
                if (item.DiscountPercentage.HasValue && item.DiscountPercentage.Value > 0)
                {
                    item.FinalPrice = item.Price - (item.Price * (item.DiscountPercentage.Value / 100));
                }
                else
                {
                    item.FinalPrice = item.Price;
                }
            }

            return Success(result);
        }
    }
}