using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Wallets.Queries.Models;
using SmartMedicalGuide.Core.Features.Wallets.Queries.Results;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Wallets.Queries.Handlers
{
    public class WalletQueryHandler : ResponseHandler,
        IRequestHandler<GetWalletListQuery, Response<List<GetWalletListResponse>>>,
        IRequestHandler<GetWalletByIdQuery, Response<GetSingleWalletResponse>>,
        IRequestHandler<GetWalletByUserIdQuery, Response<GetSingleWalletResponse>>,
        IRequestHandler<GetWalletStatisticsQuery, Response<object>>
    {
        private readonly IWalletServices _walletServices;
        private readonly IMapper _mapper;

        public WalletQueryHandler(IWalletServices walletServices, IMapper mapper)
        {
            _walletServices = walletServices;
            _mapper = mapper;
        }

        public async Task<Response<List<GetWalletListResponse>>> Handle(GetWalletListQuery request, CancellationToken cancellationToken)
        {
            List<Wallet> wallets;

            if (request.OnlyDoctors.HasValue && request.OnlyDoctors.Value)
            {
                wallets = await _walletServices.GetDoctorWalletsAsync();
            }
            else if (request.OnlyActive.HasValue && request.OnlyActive.Value)
            {
                wallets = await _walletServices.GetActiveWalletsAsync();
            }
            else
            {
                wallets = await _walletServices.GetListAsync();
            }

            var result = _mapper.Map<List<GetWalletListResponse>>(wallets);
            return Success(result);
        }

        public async Task<Response<GetSingleWalletResponse>> Handle(GetWalletByIdQuery request, CancellationToken cancellationToken)
        {
            var wallet = await _walletServices.GetByIDAsync(request.Id);
            if (wallet == null)
                return NotFound<GetSingleWalletResponse>("Wallet not found");

            var result = _mapper.Map<GetSingleWalletResponse>(wallet);
            return Success(result);
        }

        public async Task<Response<GetSingleWalletResponse>> Handle(GetWalletByUserIdQuery request, CancellationToken cancellationToken)
        {
            var wallet = await _walletServices.GetByUserIdAsync(request.UserId);
            if (wallet == null)
                return NotFound<GetSingleWalletResponse>("Wallet not found for this user");

            var result = _mapper.Map<GetSingleWalletResponse>(wallet);
            return Success(result);
        }

        public async Task<Response<object>> Handle(GetWalletStatisticsQuery request, CancellationToken cancellationToken)
        {
            var statistics = await _walletServices.GetWalletStatisticsAsync();
            return Success(statistics);
        }
    }
}