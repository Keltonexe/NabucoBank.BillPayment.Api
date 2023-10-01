using NabucoBank.BillPayment.Application.DTOs.Requests;
using NabucoBank.BillPayment.Application.DTOs.Responses;

namespace NabucoBank.BillPayment.Application.Interfaces
{
    public interface IAccountApi
    {
        Task<AccountResponseDto> GetAccountRequestAsync(string cpf);
    }
}
