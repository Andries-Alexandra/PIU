using LibrarieModele;
using System.Collections.Generic;

namespace NivelStocareDate
{
    public class AdministrareProduse
    {
        private List<Produs> produse;
        private int nrProd;
        
        public AdministrareProduse()
        {
            produse = new List<Produs>();
        }
        public void AddProduse(Produs produs)
        {
            produse.Add(produs);
        }
        public List<Produs> GetProdus()
        {
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
