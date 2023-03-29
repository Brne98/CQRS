using System.Threading;
using System.Threading.Tasks;
using ExchangeRate.Application.Commands;
using ExchangeRate.Application.Repositories;
using MediatR;

namespace ExchangeRate.Application.Handlers
{
    public class UpdateExchangeRateHandler : IRequestHandler<UpdateExchangeRateCommand, int>
    {
        private readonly IExchangeRate _exchangeRateRepository;

        public UpdateExchangeRateHandler(IExchangeRate exchangeRateRepository)
        {
            _exchangeRateRepository = exchangeRateRepository;
        }

        public async Task<int> Handle(UpdateExchangeRateCommand command, CancellationToken cancellationToken)
        {
            var exchangeRates = await _exchangeRateRepository.GetExchangeRateByIdAsync(command.Id);

            if (exchangeRates is null)
                return default;

            exchangeRates.Currency = command.Currency;
            exchangeRates.Buy = command.Buy;
            exchangeRates.Middle = command.Middle;
            exchangeRates.Sell = command.Sell;

            return await _exchangeRateRepository.UpdateExchangeRateAsync(exchangeRates);
        }
    }
}