using FIAP.TechChallenge.LambdaPagamento.Application.Models.Response;

namespace FIAP.TechChallenge.LambdaPagamento.Application.UseCases.Interfaces
{
    public interface IObterStatusPagamentoPorIdUseCase : IUseCaseAsync<Guid, PagamentoResponse>
    {
    }
}
