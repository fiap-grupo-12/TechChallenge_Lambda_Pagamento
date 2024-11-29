using Amazon.Lambda.Annotations;
using FIAP.TechChallenge.LambdaPagamento.API.Extensions;
using FIAP.TechChallenge.LambdaPagamento.Domain.Entities.MercadoPago;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace FIAP.TechChallenge.LambdaPagamento.API
{
    [ExcludeFromCodeCoverage]
    [LambdaStartup]
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = WebApplication.CreateBuilder();

            IConfiguration configuration = builder.Configuration;
            services.Configure<MercadoPagoSettings>(configuration.GetSection("myConfiguration"));

            services.AddProjectDependencies();

            services.AddCors();
            services.AddControllers();
        }
    }
}
