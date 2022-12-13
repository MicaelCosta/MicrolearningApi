namespace MicrolearningApi.Model.Business
{
    public interface IPrecoBusiness
    {
        PrecoModelView ObterPreco(int codigoProduto, int cepEntrega);
    }
}
