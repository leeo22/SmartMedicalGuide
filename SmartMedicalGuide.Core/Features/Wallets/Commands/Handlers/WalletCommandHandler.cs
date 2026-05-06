using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Wallets.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Wallets.Commands.Handlers
{
    public class WalletCommandHandler : ResponseHandler,
        IRequestHandler<AddWalletCommand, Response<string>>,
        IRequestHandler<EditWalletCommand, Response<string>>,
        IRequestHandler<DeleteWalletCommand, Response<string>>,
        IRequestHandler<UpdateBalanceCommand, Response<bool>>,
        IRequestHandler<TransferBetweenWalletsCommand, Response<bool>>
    {
        private readonly IWalletServices _walletServices;
        private readonly IMapper _mapper;

        public WalletCommandHandler(IWalletServices walletServices, IMapper mapper)
        {
            _walletServices = walletServices;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddWalletCommand request, CancellationToken cancellationToken)
        {
            var wallet = _mapper.Map<Wallet>(request);
            var result = await _walletServices.AddAsync(wallet);

            if (result == "Wallet already exists for this user")
                return BadRequest<string>("Wallet already exists for this user");
            if (result != "Success")
                return BadRequest<string>(result);

            return Created("Wallet created successfully");
        }

        public async Task<Response<string>> Handle(EditWalletCommand request, CancellationToken cancellationToken)
        {
            var wallet = _mapper.Map<Wallet>(request);
            var result = await _walletServices.EditAsync(wallet);

            if (result == "Wallet not found")
                return NotFound<string>("Wallet not found");
            if (result != "Success")
                return BadRequest<string>(result);

            return Success("Wallet updated successfully");
        }

        public async Task<Response<string>> Handle(DeleteWalletCommand request, CancellationToken cancellationToken)
        {
            var wallet = await _walletServices.GetByIDAsync(request.Id);
            if (wallet == null)
                return NotFound<string>("Wallet not found");

            var result = await _walletServices.DeleteAsync(wallet);
            return result == "Success" ? Deleted<string>("Wallet deleted successfully") : BadRequest<string>(result);
        }

        public async Task<Response<bool>> Handle(UpdateBalanceCommand request, CancellationToken cancellationToken)
        {
            var result = await _walletServices.UpdateBalanceAsync(request.WalletId, request.Amount, request.IsAddition);

            if (!result)
                return BadRequest<bool>("Failed to update balance. Insufficient funds or wallet not found.");

            return Success(result);
        }

        public async Task<Response<bool>> Handle(TransferBetweenWalletsCommand request, CancellationToken cancellationToken)
        {
            var result = await _walletServices.TransferBetweenWalletsAsync(request.FromWalletId, request.ToWalletId, request.Amount);

            if (!result)
                return BadRequest<bool>("Transfer failed. Insufficient funds or wallet not found.");

            return Success(result);
        }
    }
}