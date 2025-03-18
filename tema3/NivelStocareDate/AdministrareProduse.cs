using LibrarieModele;

namespace NivelStocareDate
{
    public class AdministrareProduse
    {
        private const int nr_max_produse = 100;
        
        private Produs[] produse;
        private int nrProd;
        
        public AdministrareProduse()
        {
            produse = new Produs[nr_max_produse];
            nrProd = 0;
        }
        public void AddProduse(Produs produs)
        {
            produse[nrProd] = produs;
            nrProd++;
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
        
    }
    
}
