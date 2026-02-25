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
                                       IRequestHandler<DeletePaymentCommand, Response<string>>
    {

        #region Fields
        private readonly IPaymentServices _paymentServices;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public PaymentCommandHandler(IPaymentServices paymentServices, IMapper mapper)
        {
            _paymentServices = paymentServices;
            _mapper = mapper;
        }

        #endregion
        #region Handels Functions

        public async Task<Response<string>> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = await _paymentServices.GetPaymentByIDAsync(request.Id);
            if (payment == null) return NotFound<string>("user is not found");
            var result = await _paymentServices.DeleteAsync(payment);
            if (result == "Success") return Deleted<string>($"Deleted Sussessfully {request.Id}");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditPaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = await _paymentServices.GetPaymentByIDAsync(request.PaymentId);
            if (payment == null) return NotFound<string>("user is not found");
            var paymentMapper = _mapper.Map<Payment>(request);
            var result = await _paymentServices.EditAsync(paymentMapper);
            if (result == "Success") return Success("Edited Sussessfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(AddPaymentCommand request, CancellationToken cancellationToken)
        {
            // mapping between request and user
            var paymentMapper = _mapper.Map<Payment>(request);
            //add
            var result = await _paymentServices.AddAsync(paymentMapper);
            //return response
            if (result == "Success") return Created("Added Sussessfully");
            else return BadRequest<string>();


        }
        #endregion
    }

}