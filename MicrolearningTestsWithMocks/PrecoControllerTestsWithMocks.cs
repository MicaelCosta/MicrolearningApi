using MicrolearningApi.Business;
using MicrolearningApi.Controllers;
using MicrolearningApi.Model.Business;
using MicrolearningApi.Model.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MicrolearningTestsWithMocks
{
    public class PrecoControllerTestsWithMocks
    {
        [Fact]
        [Trait("Controller", "Preco")]
        public void DeveriaRetornarErroSeNaoEncontrarOProduto()
        {
            //Arrange
            var prodMock = new Mock<IProdutoRepository>();
            prodMock.Setup(m => m.Obter(It.IsAny<int>())).Returns((Produto)null);

            var taxaMock = new Mock<ITaxaEntregaRepository>();

            var precoBusiness = new PrecoBusiness(prodMock.Object, taxaMock.Object);
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
            var prodMock = new Mock<IProdutoRepository>();
            prodMock.Setup(m => m.Obter(It.IsAny<int>())).Returns(new Produto(33, "Produto Mock", 1022.33m, false));

            var taxaMock = new Mock<ITaxaEntregaRepository>();

            var precoBusiness = new PrecoBusiness(prodMock.Object, taxaMock.Object);
            var precoCtrl = new PrecoController(precoBusiness);

            //Act
            var res = precoCtrl.ObterPreco(33, 75021010);
            var objRes = (PrecoModelView)((OkObjectResult)res).Value;

            //Assert
            Assert.Equal(0, objRes.ValorEntrega);
            Assert.Equal(1022.33m, objRes.PrecoTotal);
            Assert.Equal(1022.33m, objRes.ValorProduto);
        }

        [Fact]
        [Trait("Controller", "Preco")]
        public void DeveriaRetornarValorEntregaEPrecoTotalIgualASomaDoProdutoEEntrega()
        {
            //Arrange
            var prodMock = new Mock<IProdutoRepository>();
            prodMock.Setup(m => m.Obter(It.IsAny<int>())).Returns(new Produto(1, "Produto Mock", 7044.75m, true));

            var taxaMock = new Mock<ITaxaEntregaRepository>();
            taxaMock.Setup(m => m.Obter(It.IsAny<int>())).Returns(new TaxaEntrega(1, 1, 0.03m));

            var precoBusiness = new PrecoBusiness(prodMock.Object, taxaMock.Object);
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
