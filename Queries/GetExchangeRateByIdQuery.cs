using ExchangeRate.Core.Models;
using MediatR;

namespace ExchangeRate.Application.Queries
{
    public class GetExchangeRateByIdQuery : IRequest<ExchangeRateModel>
    {
        public int Id { get; set; }
    }
}