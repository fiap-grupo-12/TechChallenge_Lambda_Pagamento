using Amazon.Lambda.Annotations;
using Amazon.Lambda.Annotations.APIGateway;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using FIAP.TechChallenge.LambdaPagamento.Application.Models.Request;
using FIAP.TechChallenge.LambdaPagamento.Application.Models.Response;
using FIAP.TechChallenge.LambdaPagamento.Application.Models.Response.MercadoPago;
using FIAP.TechChallenge.LambdaPagamento.Application.UseCases.Interfaces;
using FIAP.TechChallenge.LambdaPagamento.Application.UseCases.Interfaces.MercadoPago;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using FromBodyAttribute = Amazon.Lambda.Annotations.APIGateway.FromBodyAttribute;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace FIAP.TechChallenge.LambdaPagamento.API;

[ExcludeFromCodeCoverage]
public class Function
{
    private readonly ICriarPagamentoUseCase _criarPagamento;
    private readonly IObterStatusPagamentoPorIdUseCase _obterStatusPagamentoPorId;
    private readonly IMercadoPagoObterStatusPagamentoUseCase _obterStatusPagamentoMercadoPago;

    public Function(IObterStatusPagamentoPorIdUseCase obterStatusPagamentoPorIdUseCase, IMercadoPagoObterStatusPagamentoUseCase mercadoPagoObterStatusPagamentoUseCase)
    {
        _obterStatusPagamentoPorId = obterStatusPagamentoPorIdUseCase;
        _obterStatusPagamentoMercadoPago = mercadoPagoObterStatusPagamentoUseCase;
    }

    [LambdaFunction(ResourceName = "Handler")]
    public async Task<APIGatewayProxyResponse> Handler(APIGatewayProxyRequest request, ILambdaContext context)
    {
        bool methodOk = false;
        List<object> parameters = new List<object>();

        LambdaHttpMethod httpMethod = Enum.Parse<LambdaHttpMethod>(request.HttpMethod, true);
        try
        {
            foreach (var method in this.GetType().GetMethods().Where(x => x.Name != "Handler"))
            {
                foreach (var attributes in method.CustomAttributes.Where(x => x.ConstructorArguments.Count > 1))
                {
                    int methodType = (int)attributes.ConstructorArguments.FirstOrDefault(x => x.ArgumentType.Name == "LambdaHttpMethod").Value;
                    var pathType = attributes.ConstructorArguments.FirstOrDefault(x => x.ArgumentType.Name == "String").Value.ToString();

                    methodOk = httpMethod == (LambdaHttpMethod)methodType && string.Equals(pathType, request.Resource, StringComparison.CurrentCultureIgnoreCase);
                }
                if (methodOk)
                {
                    foreach (var parameter in method.GetParameters())
                        if (parameter.CustomAttributes.Count() > 0)
                            parameters.Add(Newtonsoft.Json.JsonConvert.DeserializeObject(request.Body, Type.GetType(parameter.ParameterType.AssemblyQualifiedName)));
                        else
                            foreach (var stringParameters in request.PathParameters.Where(x => x.Key == parameter.Name))
                                parameters.Add(stringParameters.Value);

                    var resultAsync = method.Invoke(this, [.. parameters]);

                    if (resultAsync is Task task)
                    {
                        await task;
                        var resultProperty = task.GetType().GetProperty("Result");

                        return new APIGatewayProxyResponse
                        {
                            StatusCode = 200,
                            Body = Newtonsoft.Json.JsonConvert.SerializeObject(resultProperty?.GetValue(task)),
                            Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
                        };
                    }
                }
            }
        }
        catch (Exception ex)
        {
            return new APIGatewayProxyResponse
            {
                StatusCode = 400,
                Body = ex.Message + ex.ToString(),
                Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
            };
        }
        return null;
    }

    [HttpApi(LambdaHttpMethod.Post, "/Pagamento")]
    public async Task<PagamentoResponse> CriarPagamento([FromBody] PagamentoRequest request)
        => await _criarPagamento.Execute(request);

    [HttpApi(LambdaHttpMethod.Get, "/Pagamento/{id}")]
    public async Task<PagamentoResponse> ObterPedidoPorId(string id)
        => await _obterStatusPagamentoPorId.Execute(Guid.Parse(id));

    [HttpApi(LambdaHttpMethod.Post, "/Webhook/Pagamento")]
    public async Task<MercadoPagoOrderStatusResponse> ObterStatusPagamentoMercadopago([FromQuery] long id, [FromQuery] string topic)
        => await _obterStatusPagamentoMercadoPago.Execute(id);
}
