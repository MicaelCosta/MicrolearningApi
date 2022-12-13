namespace MicrolearningApi.Model.Repository
{
    public class TaxaEntrega
    {
        public TaxaEntrega(int cepInicio, int cepFim, decimal percentualTaxa)
        {
            CepInicio = cepInicio;
            CepFim = cepFim;
            Percentualtaxa = percentualTaxa;
        }

        public int CepInicio { get; }
        public int CepFim { get; }
        public decimal Percentualtaxa { get; }
    }
}
