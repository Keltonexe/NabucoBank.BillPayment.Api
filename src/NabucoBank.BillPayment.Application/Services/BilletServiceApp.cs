using NabucoBank.BillPayment.Application.Payloads;
using NabucoBank.BillPayment.Application.ViewModels;
using NabucoBank.BillPayment.Domain.Interfaces;

namespace NabucoBank.BillPayment.Application.Services
{
    public class BilletServiceApp : IBilletServiceApp
    {
        public Task<BilletPayload> CreateBilletAsync(BilletPayload payload)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBilletAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BilletViewModel>> GetAllBilletsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BilletViewModel> GetBilletByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateBilletAsync(BilletPayload payload, long id)
        {
            throw new NotImplementedException();
        }
    }
}
