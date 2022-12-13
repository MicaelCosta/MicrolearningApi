namespace MicrolearningApi.Model.Repository
{
    public class Produto
    {
        public Produto(int codigo, string nome, decimal preco, bool temTaxaEntrega)
        {
            Codigo = codigo;
            Nome = nome;
            Preco = preco;
            TemTaxaEntrega = temTaxaEntrega;
        }

        public int Codigo { get; }

        public string Nome { get; }

        public decimal Preco { get; }

        public bool TemTaxaEntrega { get; }
    }
}
