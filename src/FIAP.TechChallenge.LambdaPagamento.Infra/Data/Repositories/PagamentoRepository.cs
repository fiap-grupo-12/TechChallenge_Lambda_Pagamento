using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using FIAP.TechChallenge.LambdaPagamento.Domain.Entities;
using FIAP.TechChallenge.LambdaPagamento.Domain.Entities.Enum;
using FIAP.TechChallenge.LambdaPagamento.Domain.Repositories;

namespace FIAP.TechChallenge.LambdaPagamento.Infra.Data.Repositories
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly IDynamoDBContext _context;

        public PagamentoRepository(IDynamoDBContext context)
        {
            _context = context;
        }

        public async Task<Pagamento> Post(Pagamento pagamento)
        {
            try
            {
                await _context.SaveAsync(pagamento);

                return pagamento;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao cadastrar pedido. {ex.Message}", ex);
            }
        }

        public async Task<Pagamento> GetById(Guid Id)
        {
            try
            {
                return await _context.LoadAsync<Pagamento>(Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar pedido {Id}. {ex}");
            }
        }

        
    }
}
