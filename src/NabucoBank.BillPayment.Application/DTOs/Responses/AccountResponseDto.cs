namespace NabucoBank.BillPayment.Application.DTOs.Responses
{
    public class AccountResponseDto
    {
        public long UserId { get; set; }
        public string Number { get; set; }
        public decimal Balance { get; set; }
        public UserResponseDto User {  get; set; }

    }
}
