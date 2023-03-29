using System.Threading;
using System.Threading.Tasks;
using ExchangeRate.Application.Commands;
using ExchangeRate.Application.Repositories;
using MediatR;

namespace ExchangeRate.Application.Handlers
{
    public class DeleteExchangeRateHandler : IRequestHandler<DeleteExchangeRateCommand, int>
    {
        private readonly IExchangeRate _exchangeRateRepository;

        public DeleteExchangeRateHandler(IExchangeRate exchangeRateRepository)
        {
            _exchangeRateRepository = exchangeRateRepository;
        }

        public async Task<int> Handle(DeleteExchangeRateCommand command, CancellationToken cancellationToken)
        {
            var exchangeRates = await _exchangeRateRepository.GetExchangeRateByIdAsync(command.Id);

            if (exchangeRates is null)
                return default;

            return await _exchangeRateRepository.DeleteExchangeRateAsync(exchangeRates.Id);
        }
    }
}