using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Payments.Queries.Models;
using SmartMedicalGuide.Core.Features.Payments.Queries.Results;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Payments.Queries.Handlers
{
    public class PaymentQueryHandler : ResponseHandler,
                                       IRequestHandler<GetPaymentListQuery, Response<List<GetPaymentListResponse>>>,
                                       IRequestHandler<GetPaymentByIDQuery, Response<GetSinglePaymentResponse>>
    {
        #region Fields
        private readonly IPaymentServices _paymentServices;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors
        public PaymentQueryHandler(IPaymentServices paymentServices, IMapper mapper)
        {
            _paymentServices = paymentServices;
            _mapper = mapper;
        }
        #endregion

        #region Handels Functions
        public async Task<Response<List<GetPaymentListResponse>>> Handle(GetPaymentListQuery request, CancellationToken cancellationToken)
        {
            var paymentList = await _paymentServices.GetPaymentsListAsync();
            var paymentListMapper = _mapper.Map<List<GetPaymentListResponse>>(paymentList);
            return Success(paymentListMapper);
        }

        public async Task<Response<GetSinglePaymentResponse>> Handle(GetPaymentByIDQuery request, CancellationToken cancellationToken)
        {
            var payment = await _paymentServices.GetPaymentByIDAsync(request.Id);
            if (payment == null) return NotFound<GetSinglePaymentResponse>("No Payment same ID");
            var result = _mapper.Map<GetSinglePaymentResponse>(payment);
            return Success(result);
        }
        #endregion

    }
}
