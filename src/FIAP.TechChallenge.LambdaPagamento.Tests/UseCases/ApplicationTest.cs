using AutoMapper;
using FIAP.TechChallenge.LambdaPagamento.Application.UseCases;
using FIAP.TechChallenge.LambdaPagamento.Application.UseCases.Interfaces;
using FIAP.TechChallenge.LambdaPagamento.Application.UseCases.Interfaces.MercadoPago;
using FIAP.TechChallenge.LambdaPagamento.Application.UseCases.MercadoPago;
using FIAP.TechChallenge.LambdaPagamento.Domain.Entities;
using FIAP.TechChallenge.LambdaPagamento.Domain.Repositories;
using FIAP.TechChallenge.LambdaPagamento.Domain.Repositories.Mensageria;
using FIAP.TechChallenge.LambdaPagamento.Domain.Repositories.MercadoPago;
using FIAP.TechChallenge.LambdaPagamento.Infra.Data.Configurations;
using FIAP.TechChallenge.LambdaPagamento.Infra.Data.Repositories.Mensageria;
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
        private readonly Mock<IObterStatusPagamentoPorIdUseCase> _obterPagamento;
        private readonly Mock<ICriarPagamentoUseCase> _criarPagamento;
        private readonly Mock<IPagamentoRepository> _pagamentoRepository;
        private readonly Mock<IMercadoPagoRepository> _mercadoPagoRepository;
        private readonly Mock<IMercadoPagoObterQrCodeUseCase> _mercadoPagoObterQrCode;
        private readonly Mock<IMercadoPagoObterStatusPagamentoUseCase> _mercadoPagoObterStatusPagamento;
        private readonly Mock<IMensageriaAtualizaPagamento> _mensageriaAtualizaPagamento;
        private readonly IMapper _mapper;

        public ApplicationTest()
        {
            _obterPagamento = new Mock<IObterStatusPagamentoPorIdUseCase>();
            _criarPagamento = new Mock<ICriarPagamentoUseCase>();
            _pagamentoRepository = new Mock<IPagamentoRepository>();
            _mercadoPagoRepository = new Mock<IMercadoPagoRepository>();
            _mercadoPagoObterQrCode = new Mock<IMercadoPagoObterQrCodeUseCase>();
            _mercadoPagoObterStatusPagamento = new Mock<IMercadoPagoObterStatusPagamentoUseCase>();
            _mensageriaAtualizaPagamento = new Mock<IMensageriaAtualizaPagamento>();
            _mapper = new MapperConfiguration(c => c.AddProfile<MapperConfig>()).CreateMapper();
        }

        [Fact]
        public async void ObterStatusPagamentoPorIdUseCase_OK_Test()
        {
            // Arrange
            var pagamentoFake = PagamentoRequestMock.PagamentoFake();

            _pagamentoRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(Task.FromResult(pagamentoFake));

            var exec = new ObterStatusPagamentoPorIdUseCase(_pagamentoRepository.Object, _mapper);

            // Act
            var result = await exec.Execute(pagamentoFake.Id);

            // Assert
            Assert.NotNull(result);
        }


        [Fact]
        public async void CriarPagamento_OK_Test()
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
