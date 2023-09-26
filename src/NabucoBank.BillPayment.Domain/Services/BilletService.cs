using NabucoBank.BillPayment.Domain.Interfaces;
using NabucoBank.BillPayment.Domain.Models;

namespace NabucoBank.BillPayment.Domain.Services
{
    public class BilletService : IBilletRepository
    {
        public Task<BilletModel> CreateBilletAsync(BilletModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBilletAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BilletModel>> GetAllBilletsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BilletModel> GetBilletByIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateBilletAsync(BilletModel model, long id)
        {
            throw new NotImplementedException();
        }
    }
}
