using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using AutoMapper;
using FIAP.TechChallenge.LambdaPagamento.Application.UseCases;
using FIAP.TechChallenge.LambdaPagamento.Application.UseCases.Interfaces;
using FIAP.TechChallenge.LambdaPagamento.Application.UseCases.Interfaces.MercadoPago;
using FIAP.TechChallenge.LambdaPagamento.Application.UseCases.MercadoPago;
using FIAP.TechChallenge.LambdaPagamento.Domain.Repositories;
using FIAP.TechChallenge.LambdaPagamento.Domain.Repositories.MercadoPago;
using FIAP.TechChallenge.LambdaPagamento.Infra.Data.Configurations;
using FIAP.TechChallenge.LambdaPagamento.Infra.Data.Repositories;
using FIAP.TechChallenge.LambdaPagamento.Infra.Data.Repositories.MercadoPago;
using System.Diagnostics.CodeAnalysis;

namespace FIAP.TechChallenge.LambdaPagamento.API.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static void AddProjectDependencies(this IServiceCollection services)
        {
            
            //AWS
            services.AddAWSService<IAmazonDynamoDB>();
            services.AddTransient<IDynamoDBContext, DynamoDBContext>();

            //AutoMapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperConfig());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            //Repository
            services.AddTransient<IPagamentoRepository, PagamentoRepository>();
            services.AddTransient<IMercadoPagoRepository, MercadoPagoRepository>();

            //UseCase
            services.AddTransient<ICriarPagamentoUseCase, CriarPagamentoUseCase>();
            services.AddTransient<IObterStatusPagamentoPorIdUseCase, ObterStatusPagamentoPorIdUseCase>();
            services.AddTransient<IMercadoPagoObterStatusPagamentoUseCase, MercadoPagoObterStatusPagamentoUseCase>();
            services.AddTransient<IMercadoPagoObterQrCodeUseCase, MercadoPagoObterQrCodeUseCase>();

        }
    }
}
