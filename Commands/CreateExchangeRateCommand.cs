using ExchangeRate.Core.Models;
using MediatR;

namespace ExchangeRate.Application.Commands
{
    public class CreateExchangeRateCommand : IRequest<ExchangeRateModel>
    {
        public string Currency { get; set; }
        public double Buy { get; set; }
        public double Middle { get; set; }
        public double Sell { get; set; }

        public CreateExchangeRateCommand(string currency, double buy, double middle, double sell)
        {
            Currency = currency;
            Buy = buy;
            Middle = middle;
            Sell = sell;
        }
    }
}