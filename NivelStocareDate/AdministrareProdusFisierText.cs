using LibrarieModele;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelStocareDate
{
    public class AdministrareProdusFisierText
    {
        private const int nr_max_produse = 100;
        private string numeFisier;

        public AdministrareProdusFisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;

            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }
        public void AddProduse(Produs produs)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true)) 
            {
                streamWriterFisierText.WriteLine(produs.ConversieLaSir_PentruFisier());
            }
        }
        public Produs[] GetProdus(out int nrProd)
        {
            Produs[] produse = new Produs[nr_max_produse];

            using(StreamReader streamReader=new StreamReader(numeFisier))
            {
                string linieFisier;
                nrProd = 0;

                while((linieFisier=streamReader.ReadLine())!=null)
                {
                    produse[nrProd++] = new Produs(linieFisier);
                }
            }
            return produse;
        }
    }
}
