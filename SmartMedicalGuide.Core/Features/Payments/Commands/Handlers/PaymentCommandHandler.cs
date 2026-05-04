using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Payments.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Payments.Commands.Handlers
{
    public class PaymentCommandHandler : ResponseHandler,
        IRequestHandler<AddPaymentCommand, Response<string>>,
        IRequestHandler<EditPaymentCommand, Response<string>>,
        IRequestHandler<DeletePaymentCommand, Response<string>>,
        IRequestHandler<UpdatePaymentStatusCommand, Response<string>>,
        IRequestHandler<VerifyPaymentCommand, Response<string>>
    {
        private readonly IPaymentServices _paymentServices;
        private readonly IMapper _mapper;

        public PaymentCommandHandler(IPaymentServices paymentServices, IMapper mapper)
        {
            _paymentServices = paymentServices;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddPaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = _mapper.Map<Payment>(request);
            var result = await _paymentServices.AddAsync(payment);

            if (result != "Success")
                return BadRequest<string>(result);

            return Created("Payment added successfully");
        }

        public async Task<Response<string>> Handle(EditPaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = _mapper.Map<Payment>(request);
            var result = await _paymentServices.EditAsync(payment);

            if (result == "Payment not found")
                return NotFound<string>("Payment not found");
            if (result != "Success")
                return BadRequest<string>(result);

            return Success("Payment edited successfully");
        }

        public async Task<Response<string>> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = await _paymentServices.GetByIDAsync(request.Id);
            if (payment == null)
                return NotFound<string>("Payment not found");

            var result = await _paymentServices.DeleteAsync(payment);
            return result == "Success" ? Deleted<string>("Payment deleted successfully") : BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(UpdatePaymentStatusCommand request, CancellationToken cancellationToken)
        {
            var result = await _paymentServices.UpdatePaymentStatusAsync(request.PaymentId, request.Status);

            if (result == "Payment not found")
                return NotFound<string>("Payment not found");
            if (result != "Success")
                return BadRequest<string>(result);

            return Success($"Payment status updated to {request.Status}");
        }

        public async Task<Response<string>> Handle(VerifyPaymentCommand request, CancellationToken cancellationToken)
        {
            var result = await _paymentServices.VerifyPaymentAsync(request.PaymentId);

            if (result == "Payment not found")
                return NotFound<string>("Payment not found");
            if (result != "Success")
                return BadRequest<string>(result);

            return Success("Payment verified successfully");
        }
    }
}