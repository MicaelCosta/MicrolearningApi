using MicrolearningApi.Model.Business;
using MicrolearningApi.Model.Repository;

namespace MicrolearningApi.Business
{
    public class PrecoBusiness : IPrecoBusiness
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ITaxaEntregaRepository _taxaEntregaRepository;

        public PrecoBusiness(IProdutoRepository produtoRepository,
                             ITaxaEntregaRepository taxaEntregaRepository)
        {
            _produtoRepository = produtoRepository;
            _taxaEntregaRepository = taxaEntregaRepository;
        }

        public PrecoModelView ObterPreco(int codigoProduto, int cepEntrega)
        {
            var prod = _produtoRepository.Obter(codigoProduto);

            if (prod is null) return null;

            var preco = Map(prod);

            if (prod.TemTaxaEntrega)
            {
                var taxa = _taxaEntregaRepository.Obter(cepEntrega);
                if(taxa != null)
                {
                    preco.ValorEntrega = Math.Round(prod.Preco * taxa.Percentualtaxa, 2);
                    preco.PrecoTotal = Math.Round(preco.ValorProduto + preco.ValorEntrega, 2);
                }
            }

            return preco;
        }

        private PrecoModelView Map(Produto prod)
        {
            return new PrecoModelView
            {
                CodigoProduto = prod.Codigo,
                NomeProduto = prod.Nome,
                ValorProduto = prod.Preco,
                PrecoTotal = prod.Preco,
            };
        }
    }
}
