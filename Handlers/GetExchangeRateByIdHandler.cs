using System.Threading;
using System.Threading.Tasks;
using ExchangeRate.Application.Queries;
using ExchangeRate.Application.Repositories;
using ExchangeRate.Core.Models;
using MediatR;

namespace ExchangeRate.Application.Handlers
{
    public class GetExchangeRateByIdHandler : IRequestHandler<GetExchangeRateByIdQuery, ExchangeRateModel>
    {
        private readonly IExchangeRate _exchangeRateRepository;

        public GetExchangeRateByIdHandler(IExchangeRate exchangeRateRepository)
        {
            _exchangeRateRepository = exchangeRateRepository;
        }

        public async Task<ExchangeRateModel> Handle(GetExchangeRateByIdQuery query, CancellationToken cancellationToken)
        {
            return await _exchangeRateRepository.GetExchangeRateByIdAsync(query.Id);
        }
    }
}