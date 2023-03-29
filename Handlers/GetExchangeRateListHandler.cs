using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ExchangeRate.Application.Queries;
using ExchangeRate.Application.Repositories;
using ExchangeRate.Core.Models;
using MediatR;

namespace ExchangeRate.Application.Handlers
{
    public class GetExchangeRateListHandler : IRequestHandler<GetExchangeRateListQuery, List<ExchangeRateModel>>
    {
        private readonly IExchangeRate _exchangeRateRepository;

        public GetExchangeRateListHandler(IExchangeRate exchangeRateRepository)
        {
            _exchangeRateRepository = exchangeRateRepository;
        }

        public async Task<List<ExchangeRateModel>> Handle(GetExchangeRateListQuery request, CancellationToken cancellationToken)
        {
            return await _exchangeRateRepository.GetExchangeRateListAsync();
        }
    }
}