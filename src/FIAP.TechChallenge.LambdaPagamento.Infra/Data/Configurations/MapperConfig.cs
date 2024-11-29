using AutoMapper;
using FIAP.TechChallenge.LambdaPagamento.Application.Models.Request;
using FIAP.TechChallenge.LambdaPagamento.Application.Models.Response;
using FIAP.TechChallenge.LambdaPagamento.Application.Models.Response.MercadoPago;
using FIAP.TechChallenge.LambdaPagamento.Domain.Entities;
using FIAP.TechChallenge.LambdaPagamento.Domain.Entities.Enum;
using FIAP.TechChallenge.LambdaPagamento.Domain.Entities.MercadoPago;

namespace FIAP.TechChallenge.LambdaPagamento.Infra.Data.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            //Request
            CreateMap<PagamentoRequest, Pagamento>().ReverseMap();

            //Response
            CreateMap<PagamentoResponse, Pagamento>().ReverseMap();


            CreateMap<Pagamento, PagamentoResponse>()
                .ForMember(dest => dest.StatusPagamento, opt => opt.MapFrom(src => src.StatusPagamento.GetDescription()))
                .ReverseMap();

            CreateMap<MercadoPagoOrderStatusResponse, MercadoPagoOrderStatus>().ReverseMap();
        }
    }
}
