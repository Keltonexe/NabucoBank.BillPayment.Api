using Dapper.FluentMap;
using NabucoBank.BillPayment.CrossCutting.Mapping;

namespace NabucoBank.BillPayment.CrossCutting.Config
{
    public class DbMapping
    {
        public static void InitializeMapping()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new BilletMap());
            });
        }
    }
}
