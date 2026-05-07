using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Transactions.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Transactions.Commands.Handlers
{
    public class TransactionCommandHandler : ResponseHandler,
        IRequestHandler<AddTransactionCommand, Response<string>>,
        IRequestHandler<EditTransactionCommand, Response<string>>,
        IRequestHandler<DeleteTransactionCommand, Response<string>>
    {
        private readonly ITransactionServices _transactionServices;
        private readonly IMapper _mapper;

        public TransactionCommandHandler(ITransactionServices transactionServices, IMapper mapper)
        {
            _transactionServices = transactionServices;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = _mapper.Map<Transaction>(request);
            var result = await _transactionServices.AddAsync(transaction);

            if (result != "Success")
                return BadRequest<string>(result);

            return Created("Transaction added successfully");
        }

        public async Task<Response<string>> Handle(EditTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = _mapper.Map<Transaction>(request);
            var result = await _transactionServices.EditAsync(transaction);

            if (result == "Transaction not found")
                return NotFound<string>("Transaction not found");
            if (result != "Success")
                return BadRequest<string>(result);

            return Success("Transaction edited successfully");
        }

        public async Task<Response<string>> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionServices.GetByIDAsync(request.Id);
            if (transaction == null)
                return NotFound<string>("Transaction not found");

            var result = await _transactionServices.DeleteAsync(transaction);
            return result == "Success" ? Deleted<string>("Transaction deleted successfully") : BadRequest<string>(result);
        }
    }
}