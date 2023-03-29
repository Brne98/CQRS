using ExchangeRate.Application.Commands;
using ExchangeRate.Application.Queries;
using ExchangeRate.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExchangeRateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<ExchangeRateModel>> GetExchangeRate()
        {
            return await _mediator.Send(new GetExchangeRateListQuery());
        }
        
        [HttpGet("{id}")]
        public async Task<ExchangeRateModel> GetExchangeRateById(int id)
        {
            var exchangeRates = await _mediator.Send(new GetExchangeRateByIdQuery() {Id = id});
            
            return exchangeRates;
        }

        [HttpPost]
        public async Task<ExchangeRateModel> AddExchangeRateAsync(ExchangeRateModel exchangeRateModel)
        {
            var exchangeRate = await _mediator.Send(new CreateExchangeRateCommand(
                exchangeRateModel.Currency,
                exchangeRateModel.Buy,
                exchangeRateModel.Middle,
                exchangeRateModel.Sell));

            return exchangeRate;
        }
        
        [HttpPut]
        public async Task<int> UpdateExchangeRateAsync(ExchangeRateModel exchangeRateModel)
        {
            var exchangeRate = await _mediator.Send(new UpdateExchangeRateCommand(
                exchangeRateModel.Id,
                exchangeRateModel.Currency,
                exchangeRateModel.Buy,
                exchangeRateModel.Middle,
                exchangeRateModel.Sell));

            return exchangeRate;
        }
        
        [HttpDelete]
        public async Task<int> DeleteExchangeRateAsync(int Id)
        {
            return await _mediator.Send(new DeleteExchangeRateCommand() { Id = Id });
        }
    }
}