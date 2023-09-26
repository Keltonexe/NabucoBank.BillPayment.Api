using Dapper;
using NabucoBank.BillPayment.Domain.Interfaces.Repositories;
using NabucoBank.BillPayment.Domain.Models;
using System.Data;

namespace NabucoBank.BillPayment.Infrastructure.Repositories
{
    public class BilletRepository : IBilletRepository
    {
        readonly IDbConnection _connection;
        public BilletRepository(IBilletRepository billletRepository, IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<BilletModel> CreateBilletAsync(BilletModel model)
        {
            _connection.Open();
            try
            {
                string sql = "";
                return await _connection.QueryAsync<BilletModel>(sql);
            }
            finally
            {

            }
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
