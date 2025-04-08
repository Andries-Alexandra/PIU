using LibrarieModele;
using System;
using System.Collections.Generic;
using System.IO;

namespace NivelStocareDate
{
    public class AdministrareProdusFisierText
    {
        private const int ID_PRIMUL_PRODUS = 1;
        private const int INCREMENT = 1;
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

        public List<Produs> GetProdus()
        {
            List<Produs> produse = new List<Produs>();

            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;

                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    produse.Add(new Produs(linieFisier));
                }
            }
            return produse;
        }

        public Produs GetProduse(int id)
        {
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;

                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    Produs produs = new Produs(linieFisier);
                    if (produs.id == id)
                    {
                        return produs;
                    }
                }
                return null;
            }
        }
    }
}