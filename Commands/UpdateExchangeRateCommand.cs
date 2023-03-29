using MediatR;

namespace ExchangeRate.Application.Commands
{
    public class UpdateExchangeRateCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Currency { get; set; }
        public double Buy { get; set; }
        public double Middle { get; set; }
        public double Sell { get; set; }

        public UpdateExchangeRateCommand(int id, string currency, double buy, double middle, double sell)
        {
            Id = id;
            Currency = currency;
            Buy = buy;
            Middle = middle;
            Sell = sell;
        }
    }
}