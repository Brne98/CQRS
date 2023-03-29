using System.Collections.Generic;
using ExchangeRate.Core.Models;
using MediatR;

namespace ExchangeRate.Application.Queries
{
    public class GetExchangeRateListQuery : IRequest<List<ExchangeRateModel>>
    { }
}