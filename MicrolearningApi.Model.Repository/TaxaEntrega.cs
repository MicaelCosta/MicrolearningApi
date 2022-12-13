namespace MicrolearningApi.Model.Repository
{
    public class TaxaEntrega
    {
        public TaxaEntrega(int cep, decimal percentualTaxa)
        {
            Cep = cep;
            Percentualtaxa = percentualTaxa;
        }

        public int Cep { get; }
        public decimal Percentualtaxa { get; }
    }
}
