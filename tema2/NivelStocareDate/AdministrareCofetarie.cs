using LibrarieModele;

namespace NivelStocareDate
{
    public class AdministrareCofetarie
    {
        private const int nr_max_produse = 100;
        private const int nr_max_clienti = 100;

        private Produs[] produse;
        private int nrProd;
        private Client[] clienti;
        private int nrClienti;
        public AdministrareCofetarie()
        {
            produse = new Produs[nr_max_produse];
            nrProd = 0;
            clienti = new Client[nr_max_clienti];
            nrClienti = 0;
        }
        public void AddProduse(Produs produs)
        {
            produse[nrProd] = produs;
            nrProd++;
        }
        public void AddClienti(Client client)
        {
            clienti[nrClienti] = client;
            nrClienti++;
        }
        public Produs[] GetProdus(out int nrProd)
        {
            nrProd = this.nrProd;
            return produse;
        }
        public Produs CautaProdusDupaNume(string nume)
        {
            for (int i = 0; i < nrProd; i++)
            {
                if (produse[i].nume.ToLower() == nume.ToLower())
                {
                    return produse[i];
                }
            }
            return null;
        }
        public Client[] GetClient(out int nrClienti)
        {
            nrClienti = this.nrClienti;
            return clienti;
        }
    }
}
