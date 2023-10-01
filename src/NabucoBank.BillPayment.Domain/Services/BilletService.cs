using NabucoBank.BillPayment.Domain.Interfaces;
using NabucoBank.BillPayment.Domain.Interfaces.Repositories;
using NabucoBank.BillPayment.Domain.Models;

namespace NabucoBank.BillPayment.Domain.Services
{
    public class BilletService : IBilletService
    {
        readonly IBilletRepository _billetRepository;
        public BilletService(IBilletRepository billetRepository)
        {
            _billetRepository = billetRepository;
        }
        public async Task<BilletModel> CreateBilletAsync(BilletModel model)
        {
            return await _billetRepository.CreateBilletAsync(model);
        }

        public async Task<bool> DeleteBilletAsync(long id)
        {
            return await _billetRepository.DeleteBilletAsync(id);
        }

        public async Task<IEnumerable<BilletModel>> GetAllBilletsAsync()
        {
            return await _billetRepository.GetAllBilletsAsync();
        }

        public async Task<BilletModel> GetBilletByIdAsync(long id)
        {
            return await _billetRepository.GetBilletByIdAsync(id);
        }

        public async Task<bool> UpdateBilletAsync(BilletModel model, long id)
        {
            return await _billetRepository.UpdateBilletAsync(model, id);
        }
    }
}
