using AutoMapper;
using FIAP.TechChallenge.LambdaPagamento.Application.UseCases;
using FIAP.TechChallenge.LambdaPagamento.Application.UseCases.Interfaces;
using FIAP.TechChallenge.LambdaPagamento.Domain.Entities;
using FIAP.TechChallenge.LambdaPagamento.Domain.Repositories;
using FIAP.TechChallenge.LambdaPagamento.Domain.Repositories.MercadoPago;
using FIAP.TechChallenge.LambdaPagamento.Infra.Data.Configurations;
using FIAP.TechChallenge.LambdaPagamento.Infra.Data.Repositories.MercadoPago;
using FIAP.TechChallenge.LambdaPagamento.Tests.Mock;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FIAP.TechChallenge.LambdaPagamento.Tests.UseCases
{
    public class ApplicationTest
    {
        private readonly Mock<ICriarPagamentoUseCase> _criarPagamento;
        private readonly Mock<IPagamentoRepository> _pagamentoRepository;
        private readonly Mock<IMercadoPagoRepository> _mercadoPagoRepository;
        private readonly IMapper _mapper;

        public ApplicationTest()
        {
            _criarPagamento = new Mock<ICriarPagamentoUseCase>();
            _pagamentoRepository = new Mock<IPagamentoRepository>();
            _mercadoPagoRepository = new Mock<IMercadoPagoRepository>();
            _mapper = new MapperConfiguration(c => c.AddProfile<MapperConfig>()).CreateMapper();
        }

        [Fact]
        public async void CriarPagamento_OK_test()
        {
            // Arrange
            var pagamento = PagamentoRequestMock.PagamentoRequestFake();
            var pagamentoFake = PagamentoRequestMock.PagamentoFake();

            _pagamentoRepository.Setup(x => x.Post(It.IsAny<Pagamento>())).Returns(Task.FromResult(pagamentoFake));

            var exec = new CriarPagamentoUseCase(_pagamentoRepository.Object, _mercadoPagoRepository.Object, _mapper);

            // Act
            var result = await exec.Execute(pagamento);

            // Assert
            Assert.NotNull(result);
        }
    }
}
