using ExchangeRate.Application.Repositories;
using ExchangeRate.Core.Models;
using ExchangeRate.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Exchange.Repositories
{
    public class ExchangeRateRepository : IExchangeRate
    {
        private readonly DataContext _context;

        public ExchangeRateRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<ExchangeRateModel>> GetExchangeRateListAsync()
        {
            return await _context.ExchangeRates.ToListAsync();
        }

        public async Task<ExchangeRateModel> GetExchangeRateByIdAsync(int Id)
        {
            return await _context.ExchangeRates.Where(x => x.Id == Id).FirstOrDefaultAsync() ?? throw new InvalidOperationException();
        }

        public async Task<ExchangeRateModel> AddExchangeRateAsync(ExchangeRateModel exchangeRates)
        {
            var result = _context.ExchangeRates.Add(exchangeRates);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> UpdateExchangeRateAsync(ExchangeRateModel exchangeRates)
        {
            _context.ExchangeRates.Update(exchangeRates);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteExchangeRateAsync(int Id)
        {
            var filteredData = _context.ExchangeRates.Where(x => x.Id == Id).FirstOrDefault();
            _context.ExchangeRates.Remove(filteredData);
            return await _context.SaveChangesAsync();
        }
    }
}