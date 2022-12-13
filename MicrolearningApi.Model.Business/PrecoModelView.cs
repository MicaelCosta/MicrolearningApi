namespace MicrolearningApi.Model.Business
{
    public class PrecoModelView
    {
        public int CodigoProduto { get; set; }
        public string NomeProduto { get; set; }
        public decimal ValorProduto { get; set; }
        public decimal PrecoTotal { get; set; }
        public decimal ValorEntrega { get; set; }
    }
}
