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
        IRequestHandler<GetPaymentByIdQuery, Response<GetSinglePaymentResponse>>,
        IRequestHandler<GetPaymentsByPatientIdQuery, Response<List<GetPaymentListResponse>>>,
        IRequestHandler<GetPaymentsByDoctorIdQuery, Response<List<GetPaymentListResponse>>>,
        IRequestHandler<GetPaymentsByStatusQuery, Response<List<GetPaymentListResponse>>>,
        IRequestHandler<GetPaymentsByDateRangeQuery, Response<List<GetPaymentListResponse>>>,
        IRequestHandler<GetPaymentsByMethodQuery, Response<List<GetPaymentListResponse>>>,
        IRequestHandler<GetDoctorRevenueQuery, Response<decimal>>,
        IRequestHandler<GetPlatformRevenueQuery, Response<object>>,
        IRequestHandler<GetRevenueReportQuery, Response<object>>,
        IRequestHandler<GetPendingPaymentsQuery, Response<List<GetPaymentListResponse>>>,
        IRequestHandler<GetPaymentStatisticsQuery, Response<object>>,
        IRequestHandler<GetWalletPaymentsQuery, Response<List<GetPaymentListResponse>>>,
        IRequestHandler<GetTransferPaymentsQuery, Response<List<GetPaymentListResponse>>>
    {
        private readonly IPaymentServices _paymentServices;
        private readonly IMapper _mapper;

        public PaymentQueryHandler(IPaymentServices paymentServices, IMapper mapper)
        {
            _paymentServices = paymentServices;
            _mapper = mapper;
        }

        public async Task<Response<List<GetPaymentListResponse>>> Handle(GetPaymentListQuery request, CancellationToken cancellationToken)
        {
            var payments = await _paymentServices.GetListAsync();
            var result = _mapper.Map<List<GetPaymentListResponse>>(payments);
            return Success(result);
        }

        public async Task<Response<GetSinglePaymentResponse>> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
        {
            var payment = await _paymentServices.GetByIDAsync(request.Id);
            if (payment == null)
                return NotFound<GetSinglePaymentResponse>("Payment not found");

            var result = _mapper.Map<GetSinglePaymentResponse>(payment);
            return Success(result);
        }

        public async Task<Response<List<GetPaymentListResponse>>> Handle(GetPaymentsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            var payments = await _paymentServices.GetByPatientIdAsync(request.PatientId);
            var result = _mapper.Map<List<GetPaymentListResponse>>(payments);
            return Success(result);
        }

        public async Task<Response<List<GetPaymentListResponse>>> Handle(GetPaymentsByDoctorIdQuery request, CancellationToken cancellationToken)
        {
            var payments = await _paymentServices.GetByDoctorIdAsync(request.DoctorId);
            var result = _mapper.Map<List<GetPaymentListResponse>>(payments);
            return Success(result);
        }

        public async Task<Response<List<GetPaymentListResponse>>> Handle(GetPaymentsByStatusQuery request, CancellationToken cancellationToken)
        {
            var payments = await _paymentServices.GetByPaymentStatusAsync(request.Status);
            var result = _mapper.Map<List<GetPaymentListResponse>>(payments);
            return Success(result);
        }

        public async Task<Response<List<GetPaymentListResponse>>> Handle(GetPaymentsByDateRangeQuery request, CancellationToken cancellationToken)
        {
            var payments = await _paymentServices.GetByDateRangeAsync(request.FromDate, request.ToDate);
            var result = _mapper.Map<List<GetPaymentListResponse>>(payments);
            return Success(result);
        }

        public async Task<Response<List<GetPaymentListResponse>>> Handle(GetPaymentsByMethodQuery request, CancellationToken cancellationToken)
        {
            var payments = await _paymentServices.GetByPaymentMethodAsync(request.Method);
            var result = _mapper.Map<List<GetPaymentListResponse>>(payments);
            return Success(result);
        }

        public async Task<Response<decimal>> Handle(GetDoctorRevenueQuery request, CancellationToken cancellationToken)
        {
            var revenue = await _paymentServices.GetDoctorRevenueAsync(request.DoctorId);
            return Success(revenue);
        }

        public async Task<Response<object>> Handle(GetPlatformRevenueQuery request, CancellationToken cancellationToken)
        {
            var revenue = await _paymentServices.GetPlatformRevenueAsync();
            return Success(revenue);
        }

        public async Task<Response<object>> Handle(GetRevenueReportQuery request, CancellationToken cancellationToken)
        {
            var report = await _paymentServices.GetRevenueReportAsync(request.FromDate, request.ToDate);
            return Success(report);
        }

        public async Task<Response<List<GetPaymentListResponse>>> Handle(GetPendingPaymentsQuery request, CancellationToken cancellationToken)
        {
            var payments = await _paymentServices.GetPendingPaymentsAsync();
            var result = _mapper.Map<List<GetPaymentListResponse>>(payments);
            return Success(result);
        }

        public async Task<Response<object>> Handle(GetPaymentStatisticsQuery request, CancellationToken cancellationToken)
        {
            var statistics = await _paymentServices.GetPaymentStatisticsAsync();
            return Success(statistics);
        }

        public async Task<Response<List<GetPaymentListResponse>>> Handle(GetWalletPaymentsQuery request, CancellationToken cancellationToken)
        {
            var payments = await _paymentServices.GetWalletPaymentsAsync();
            var result = _mapper.Map<List<GetPaymentListResponse>>(payments);
            return Success(result);
        }

        public async Task<Response<List<GetPaymentListResponse>>> Handle(GetTransferPaymentsQuery request, CancellationToken cancellationToken)
        {
            var payments = await _paymentServices.GetTransferPaymentsAsync();
            var result = _mapper.Map<List<GetPaymentListResponse>>(payments);
            return Success(result);
        }
    }
}