using Microsoft.AspNetCore.Mvc;
using NabucoBank.BillPayment.Application.Payloads;
using NabucoBank.BillPayment.Domain.Interfaces;

namespace NabucoBank.BillPayment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BilletController : ControllerBase
    {
        readonly IBilletServiceApp _billetServiceApp;
        public BilletController(IBilletServiceApp billetServiceApp)
        {
            _billetServiceApp = billetServiceApp;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _billetServiceApp.GetAllBilletsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            return Ok(await _billetServiceApp.GetBilletByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(BilletPayload payload)
        {
            return Ok(await _billetServiceApp.CreateBilletAsync(payload));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(BilletPayload payload, long id)
        {
            return Ok(await _billetServiceApp.UpdateBilletAsync(payload, id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            return Ok(await _billetServiceApp?.DeleteBilletAsync(id));
        }
    }
}
