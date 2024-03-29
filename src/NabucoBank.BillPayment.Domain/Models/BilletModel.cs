﻿namespace NabucoBank.BillPayment.Domain.Models
{
    public class BilletModel : BaseModel
    {
        public string Cpf { get; set; }
        public string DigitableLine { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpiratedAt { get; set; }
    }
}
