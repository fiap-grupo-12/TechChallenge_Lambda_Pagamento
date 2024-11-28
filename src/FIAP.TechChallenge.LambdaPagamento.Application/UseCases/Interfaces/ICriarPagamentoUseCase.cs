using FIAP.TechChallenge.LambdaPagamento.Application.Models.Request;
using FIAP.TechChallenge.LambdaPagamento.Application.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP.TechChallenge.LambdaPagamento.Application.UseCases.Interfaces
{
    public interface ICriarPagamentoUseCase : IUseCaseAsync<PagamentoRequest, PagamentoResponse>
    {
    }
}
