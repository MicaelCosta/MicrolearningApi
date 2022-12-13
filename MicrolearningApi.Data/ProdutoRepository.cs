using MicrolearningApi.Model.Repository;

namespace MicrolearningApi.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private List<Produto> ListProduto { get; set; }

        public ProdutoRepository()
        {
            ListProduto = new List<Produto>()
            {
                new Produto(1, "TV 75 polegadas", 7044.75m, true),
                new Produto(2, "Celular super novo", 4976.00m, false),
                new Produto(3, "Notebook superfino", 6777.99m, true),
                new Produto(3, "Roteador wifi", 133.29m, true),
            };
        }

        public Produto Obter(int codigo)
        {
            return ListProduto.Find(p => p.Codigo == codigo);
        }
    }
}
