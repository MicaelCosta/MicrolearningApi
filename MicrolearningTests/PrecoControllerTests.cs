using MicrolearningApi.Business;
using MicrolearningApi.Controllers;
using MicrolearningApi.Model.Business;
using MicrolearningTests.Mocks;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MicrolearningTests
{
    public class PrecoControllerTests
    {
        #region Exemplo Setup

        //private readonly PrecoController _precoController;
        //public PrecoControllerTests()
        //{
        //    var precoBusiness = new PrecoBusiness(new ProdutoRepositoryFake(), new TaxaEntregaRepositoryFake());
        //    _precoController = new PrecoController(precoBusiness);
        //}

        #endregion

        [Fact]
        [Trait("Controller", "Preco")]
        public void DeveriaRetornarErroSeNaoEncontrarOProduto()
        {
            //Arrange
            var prodMock = new ProdutoRepositoryFake();
            var precoBusiness = new PrecoBusiness(prodMock, null);
            var precoCtrl = new PrecoController(precoBusiness);

            //Act
            var res = precoCtrl.ObterPreco(0, 111111);

            //Assert
            Assert.Equal(404, ((NotFoundObjectResult)res).StatusCode);
        }

        [Fact]
        [Trait("Controller", "Preco")]
        public void DeveriaRetornarPrecoTotalIgualAValorProduto()
        {
            //Arrange
            var prodMock = new ProdutoRepositoryFake();
            var taxaMock = new TaxaEntregaRepositoryFake();
            var precoBusiness = new PrecoBusiness(prodMock, taxaMock);
            var precoCtrl = new PrecoController(precoBusiness);

            //Act
            var res = precoCtrl.ObterPreco(2, 75021010);
            var objRes = (PrecoModelView)((OkObjectResult)res).Value;

            //Assert
            Assert.Equal(0, objRes.ValorEntrega);
            Assert.Equal(4976m, objRes.PrecoTotal);
            Assert.Equal(4976m, objRes.ValorProduto);
        }

        [Fact]
        [Trait("Controller", "Preco")]
        public void DeveriaRetornarValorEntregaEPrecoTotalIgualASomaDoProdutoEEntrega()
        {
            //Arrange
            var prodMock = new ProdutoRepositoryFake();
            var taxaMock = new TaxaEntregaRepositoryFake();
            var precoBusiness = new PrecoBusiness(prodMock, taxaMock);
            var precoCtrl = new PrecoController(precoBusiness);

            //Act
            var res = precoCtrl.ObterPreco(1, 75021010);
            var objRes = (PrecoModelView)((OkObjectResult)res).Value;

            //Assert
            Assert.Equal(211.34m, objRes.ValorEntrega);
            Assert.Equal(7044.75m, objRes.ValorProduto);
            Assert.Equal(7256.09m, objRes.PrecoTotal);
        }
    }
}
