using Amazon.Lambda.Annotations;
using FIAP.TechChallenge.LambdaPagamento.API.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace FIAP.TechChallenge.LambdaPagamento.API
{
    [ExcludeFromCodeCoverage]
    [LambdaStartup]
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddProjectDependencies();

            services.AddCors();
            services.AddControllers();
        }
    }
}
