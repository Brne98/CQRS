namespace ExchangeRate.Core.Models
{
    public class ExchangeRateModel
    {
        public int Id { get; set; }
        public string Currency { get; set; }
        public double Buy { get; set; }
        public double Middle { get; set; }
        public double Sell { get; set; }

    }
}