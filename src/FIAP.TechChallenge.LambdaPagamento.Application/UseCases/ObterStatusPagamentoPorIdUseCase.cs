using AutoMapper;
using FIAP.TechChallenge.LambdaPagamento.Application.Models.Response;
using FIAP.TechChallenge.LambdaPagamento.Application.UseCases.Interfaces;
using FIAP.TechChallenge.LambdaPagamento.Domain.Repositories;

namespace FIAP.TechChallenge.LambdaPagamento.Application.UseCases
{
    public class ObterStatusPagamentoPorIdUseCase : IObterStatusPagamentoPorIdUseCase
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IMapper _mapper;

        public ObterStatusPagamentoPorIdUseCase(
            IPagamentoRepository pagamentoRepository, IMapper mapper)
        {
            _pagamentoRepository = pagamentoRepository;
            _mapper = mapper;
        }

        public async Task<PagamentoResponse> Execute(Guid id)
        {
            var result = await _pagamentoRepository.GetById(id);

            return _mapper.Map<PagamentoResponse>(result);
        }

        Task<PagamentoResponse> IUseCaseAsync<Guid, PagamentoResponse>.Execute(Guid request)
        {
            throw new NotImplementedException();
        }
    }
}
