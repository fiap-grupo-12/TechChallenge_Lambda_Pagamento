using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using AutoMapper;
using FIAP.TechChallenge.LambdaPagamento.Application.UseCases;
using FIAP.TechChallenge.LambdaPagamento.Application.UseCases.Interfaces;
using FIAP.TechChallenge.LambdaPagamento.Domain.Repositories;
using FIAP.TechChallenge.LambdaPagamento.Infra.Data.Configurations;
using FIAP.TechChallenge.LambdaPagamento.Infra.Data.Repositories;
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

            //UseCase
            services.AddTransient<ICriarPagamentoUseCase, CriarPagamentoUseCase>();
            services.AddTransient<IObterStatusPagamentoPorIdUseCase, ObterStatusPagamentoPorIdUseCase>();
        }
    }
}
