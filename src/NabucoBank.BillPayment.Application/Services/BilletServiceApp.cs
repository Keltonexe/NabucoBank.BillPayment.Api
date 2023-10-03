using AutoMapper;
using Flurl.Util;
using NabucoBank.BillPayment.Application.Interfaces;
using NabucoBank.BillPayment.Application.Payloads;
using NabucoBank.BillPayment.Application.ViewModels;
using NabucoBank.BillPayment.Domain.Interfaces;
using NabucoBank.BillPayment.Domain.Models;

namespace NabucoBank.BillPayment.Application.Services
{
    public class BilletServiceApp : IBilletServiceApp
    {
        readonly IBilletService _billetService;
        readonly IMapper _mapper;
        readonly IAccountApi _accountApi;
        public BilletServiceApp(IBilletService billetService, IMapper mapper, IAccountApi accountApi)
        {
            _billetService = billetService;
            _mapper = mapper;
            _accountApi = accountApi;
        }
        public async Task<BilletViewModel> CreateBilletAsync(BilletPayload payload)
        {
            var account = await _accountApi.GetAccountRequestAsync(payload.Cpf);
            
            if (account is null)
                return null;
            
            var billet = _mapper.Map<BilletViewModel>(await _billetService.CreateBilletAsync(_mapper.Map<BilletModel>(payload)));
            billet.Account = account;

            return billet;
        }

        public async Task<bool> DeleteBilletAsync(long id)
        {
            return await _billetService.DeleteBilletAsync(id);
        }

        public async Task<IEnumerable<BilletViewModel>> GetAllBilletsAsync()
        {
            return _mapper.Map<IEnumerable<BilletViewModel>>(await _billetService.GetAllBilletsAsync());
        }

        public async Task<BilletViewModel> GetBilletByIdAsync(long id)
        {
            return _mapper.Map<BilletViewModel>(await _billetService.GetBilletByIdAsync(id));
        }

        public async Task<bool> UpdateBilletAsync(BilletPayload payload, long id)
        {
            return await _billetService.UpdateBilletAsync(_mapper.Map<BilletModel>(payload), id);
        }
    }
}
