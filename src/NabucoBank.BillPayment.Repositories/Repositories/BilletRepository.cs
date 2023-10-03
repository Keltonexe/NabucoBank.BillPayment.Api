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
            _connection.Open();
            try
            {
                string sql = "DELETE * FROM billets WHERE ID = @id";
                return _connection.QueryFirstAsync<bool>(sql);
            }
            finally
            {
                _connection.Close();
            }
        }

        public async Task<IEnumerable<BilletModel>> GetAllBilletsAsync()
        {
            _connection.Open();
            try
            {
                string sql = "SELECT * FROM billets WHERE IS_PAYED = 0;";
                return await _connection.QueryAsync<BilletModel>(sql);
            }
            finally
            {
                _connection.Close();
            }
        }

        public async Task<BilletModel> GetBilletByIdAsync(long id)
        {
            _connection.Open();
            try
            {
                string sql = "SELECT * FROM billets WHERE ID = @id;";
                return await _connection.QuerySingleAsync<BilletModel>(sql, new { id });
            }
            finally
            {
                _connection.Close();
            }
        }

        public async Task<bool> UpdateBilletAsync(BilletModel model, long id)
        {
            _connection.Open();
            try
            {
                string sql = @"UPDATE billets (CPF, DIGITABLE_LINE, AMOUNT, DT_UPDATED, DT_DELETED, IS_PAYED) 
                               VALUES (@Cpf, @DigitableLine, @Amount, @ExpiratedAt, @DeletedAt, @IsPayed);
                               SELECT * FROM billets WHERE ID = LAST_INSERT_ID();";
                return await _connection.QuerySingleAsync(sql, model);
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
