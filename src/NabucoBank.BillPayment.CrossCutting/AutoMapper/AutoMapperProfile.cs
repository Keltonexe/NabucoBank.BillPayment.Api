using AutoMapper;
using NabucoBank.BillPayment.Application.Payloads;
using NabucoBank.BillPayment.Application.ViewModels;
using NabucoBank.BillPayment.Domain.Models;

namespace NabucoBank.BillPayment.CrossCutting.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BilletModel, BilletViewModel>().ForMember(dest => dest.CreatedAt, map => map.MapFrom(src => src.CreatedAt.ToString("dd/MM/yyyy"))).ReverseMap();
            
            CreateMap<BilletPayload, BilletModel>().ReverseMap();
        }
    }
}
