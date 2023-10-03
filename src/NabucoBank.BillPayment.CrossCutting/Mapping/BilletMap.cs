using Dapper.FluentMap.Mapping;
using NabucoBank.BillPayment.Domain.Models;

namespace NabucoBank.BillPayment.CrossCutting.Mapping
{
    public class BilletMap : EntityMap<BilletModel>
    {
        public BilletMap()
        {
            Map(m => m.Id).ToColumn("ID");
            Map(m => m.Cpf).ToColumn("CPF");
            Map(m => m.DigitableLine).ToColumn("DIGITABLE_LINE");
            Map(m => m.Amount).ToColumn("AMOUNT");
            Map(m => m.CreatedAt).ToColumn("DT_CREATED");
            Map(m => m.UpdatedAt).ToColumn("DT_UPDATED");
            Map(m => m.DeletedAt).ToColumn("DT_DELETED");
            Map(m => m.ExpiratedAt).ToColumn("DT_EXPIRATED");
            Map(m => m.HashCode).ToColumn("HASH_CODE");
            Map(m => m.IsPayed).ToColumn("IS_PAYED");
        }
    }
}
