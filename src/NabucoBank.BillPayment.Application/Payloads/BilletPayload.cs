namespace NabucoBank.BillPayment.Application.Payloads
{
    public class BilletPayload
    {
        public string Cpf { get; set; }
        public string DigitableLine { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpiratedAt { get; set; }
    }
}
