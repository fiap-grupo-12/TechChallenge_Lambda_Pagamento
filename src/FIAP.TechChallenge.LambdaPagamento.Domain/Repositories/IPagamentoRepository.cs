using FIAP.TechChallenge.LambdaPagamento.Domain.Entities;

namespace FIAP.TechChallenge.LambdaPagamento.Domain.Repositories
{
    public interface IPagamentoRepository
    {
        Task<Pagamento> Post(Pagamento pagamento);
        Task Update(Pagamento pagamento, Guid Id);
        Task<Pagamento> GetById(Guid id);
    }
}
