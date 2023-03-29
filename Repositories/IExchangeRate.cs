using System.Collections.Generic;
using System.Threading.Tasks;
using ExchangeRate.Core.Models;

namespace ExchangeRate.Application.Repositories
{
    public interface IExchangeRate
    {
        public Task<List<ExchangeRateModel>> GetExchangeRateListAsync();
        public Task<ExchangeRateModel> GetExchangeRateByIdAsync(int Id);
        public Task<ExchangeRateModel> AddExchangeRateAsync(ExchangeRateModel studentDetails);
        public Task<int> UpdateExchangeRateAsync(ExchangeRateModel studentDetails);
        public Task<int> DeleteExchangeRateAsync(int Id);
    }
}