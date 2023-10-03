using NabucoBank.BillPayment.Application.DTOs.Responses;

namespace NabucoBank.BillPayment.Application.ViewModels
{
    public class BilletViewModel
    {
        public string Cpf { get; set; }
        public string DigitableLine { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpiratedAt { get; set; }
        public DateTime CreatedAt { get; set;}
        public bool IsPayed { get; set; }
        public AccountResponseDto Account { get; set; }
    }
}
