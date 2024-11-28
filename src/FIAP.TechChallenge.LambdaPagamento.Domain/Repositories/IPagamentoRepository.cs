using FIAP.TechChallenge.LambdaPagamento.Domain.Entities;

namespace FIAP.TechChallenge.LambdaPagamento.Domain.Repositories
{
    public interface IPagamentoRepository
    {
        Task<Pagamento> Post(Pagamento pagamento);
        Task<Pagamento> GetById(Guid id);
    }
}
