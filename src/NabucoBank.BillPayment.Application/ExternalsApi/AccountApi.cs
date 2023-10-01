using Flurl.Http;
using NabucoBank.BillPayment.Application.DTOs.Responses;
using NabucoBank.BillPayment.Application.Interfaces;
using System.Net;

namespace NabucoBank.BillPayment.Application.ExternalsApi
{
    public class AccountApi : IAccountApi
    {
        public async Task<AccountResponseDto> GetAccountRequestAsync(string cpf)
        {
            string url = $"http://localhost:5077/accounts-api/account/cpf/{cpf}";

            var response = await url
                .WithHeader("Accept", "application/json")
                .AllowAnyHttpStatus()
                .GetAsync();

            if (!ValidateStatusCode(response)) 
            {
                return null;
            }

            return await response.GetJsonAsync<AccountResponseDto>();

        }
        private bool ValidateStatusCode(IFlurlResponse response)
        {
            if (response.StatusCode != (int)HttpStatusCode.OK && response.StatusCode != (int)HttpStatusCode.Created)
            {
                return false;
            }
            return true;
        }
    }
}
