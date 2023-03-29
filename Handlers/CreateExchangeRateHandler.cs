using System.Threading;
using System.Threading.Tasks;
using ExchangeRate.Application.Commands;
using ExchangeRate.Application.Repositories;
using ExchangeRate.Core.Models;
using MediatR;

namespace ExchangeRate.Application.Handlers
{
    public class CreateExchangeRateHandler : IRequestHandler<CreateExchangeRateCommand, ExchangeRateModel>
    {
        private readonly IExchangeRate _exchangeRateRepository;

        public CreateExchangeRateHandler(IExchangeRate exchangeRateRepository)
        {
            _exchangeRateRepository = exchangeRateRepository;
        }

        public async Task<ExchangeRateModel> Handle(CreateExchangeRateCommand command, CancellationToken cancellationToken)
        {
            var exchangeRates = new ExchangeRateModel()
            {
                Currency = command.Currency,
                Buy = command.Buy,
                Middle = command.Middle,
                Sell = command.Sell,
            };

            return await _exchangeRateRepository.AddExchangeRateAsync(exchangeRates);
        }
    }
}