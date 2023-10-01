using Dapper;
using NabucoBank.BillPayment.Domain.Interfaces.Repositories;
using NabucoBank.BillPayment.Domain.Models;
using System.Data;

namespace NabucoBank.BillPayment.Infrastructure.Repositories
{
    public class BilletRepository : IBilletRepository
    {
        readonly IDbConnection _connection;
        public BilletRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<BilletModel> CreateBilletAsync(BilletModel model)
        {
            _connection.Open();
            try
            {
                model.HashCode = Guid.NewGuid().ToString();
                model.ExpiratedAt = DateTime.Now.AddMonths(1);
                string sql = @"INSERT INTO billets (CPF, DIGITABLE_LINE, AMOUNT, DT_EXPIRATED, DT_CREATED, DT_UPDATED, DT_DELETED, HASH_CODE) 
                               VALUES (@Cpf, @DigitableLine, @Amount, @ExpiratedAt, @CreatedAt, @UpdatedAt, @DeletedAt, @HashCode);
                               SELECT * FROM billets WHERE ID = LAST_INSERT_ID();";
                return await _connection.QuerySingleAsync<BilletModel>(sql, model);
            }
            finally
            {
                _connection.Close();
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

        public Task<BilletModel> GetBilletByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateBilletAsync(BilletModel model, long id)
        {
            throw new NotImplementedException();
        }
    }
}
