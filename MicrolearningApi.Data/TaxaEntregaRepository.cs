using MicrolearningApi.Model.Repository;

namespace MicrolearningApi.Data.Repository
{
    public class TaxaEntregaRepository : ITaxaEntregaRepository
    {
        private List<TaxaEntrega> ListTaxaEntrega { get; set; }

        public TaxaEntregaRepository()
        {
            ListTaxaEntrega = new List<TaxaEntrega>()
            {
                new TaxaEntrega(1, 9999999, 0.05m),
                new TaxaEntrega(10000000, 39999999, 0.07m),
                new TaxaEntrega(40000000, 69999999, 0.02m),
                new TaxaEntrega(70000000, 99999999, 0.03m),
            };
        }

        public TaxaEntrega Obter(int cepEntrega)
        {
            return ListTaxaEntrega.Find(p => p.CepInicio <= cepEntrega && p.CepFim >= cepEntrega);
        }
    }
}
