using NabucoBank.BillPayment.Application.ViewModels;
using NabucoBank.BillPayment.Application.Payloads;

namespace NabucoBank.BillPayment.Domain.Interfaces
{
    public interface IBilletServiceApp
    {
        Task<IEnumerable<BilletViewModel>> GetAllBilletsAsync();
        Task<BilletViewModel> GetBilletByIdAsync(long id);
        Task<BilletPayload> CreateBilletAsync(BilletPayload payload);
        Task<bool> UpdateBilletAsync(BilletPayload payload, long id);
        Task<bool> DeleteBilletAsync(long id);
    }
}
