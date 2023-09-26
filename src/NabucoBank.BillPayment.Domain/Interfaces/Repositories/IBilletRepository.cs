using NabucoBank.BillPayment.Domain.Models;

namespace NabucoBank.BillPayment.Domain.Interfaces.Repositories
{
    public interface IBilletRepository
    {
        Task<IEnumerable<BilletModel>> GetAllBilletsAsync();
        Task<BilletModel> GetBilletByIdAsync();
        Task<BilletModel> CreateBilletAsync(BilletModel model);
        Task<bool> UpdateBilletAsync(BilletModel model, long id);
        Task<bool> DeleteBilletAsync(long id);
    }
}
