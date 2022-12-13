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
                new TaxaEntrega(12345678, 10.00m),
                new TaxaEntrega(87654321, 5.00m),
            };
        }

        public TaxaEntrega Obter(int cepEntrega)
        {
            return ListTaxaEntrega.Find(p => p.Cep == cepEntrega);
        }
    }
}
