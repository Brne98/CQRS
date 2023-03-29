using MediatR;

namespace ExchangeRate.Application.Commands
{
    public class DeleteExchangeRateCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}