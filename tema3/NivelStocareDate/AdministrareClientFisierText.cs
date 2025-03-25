using LibrarieModele;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelStocareDate
{
    public class AdministrareClientFisierText
    {
        private const int nr_max_clienti = 100;
        private string numeFisierClient;

        public AdministrareClientFisierText(string numeFisierClient)
        {
            this.numeFisierClient = numeFisierClient;

            Stream streamFisierText = File.Open(numeFisierClient, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }
        public void AddClienti(Client client)
        {
            using (StreamWriter streamWriterFisierText=new StreamWriter(numeFisierClient, true))
            {
                streamWriterFisierText.WriteLine(client.ConversieLaSir_PentruFisier());
            }
        }
        public Client[] GetClient(out int nrClienti)
        {
            Client[] clienti = new Client[nr_max_clienti];

            using(StreamReader streamReader = new StreamReader(numeFisierClient))
            {
                string linieFisier;
                nrClienti = 0;

                while((linieFisier=streamReader.ReadLine())!=null)
                {
                    clienti[nrClienti++] = new Client(linieFisier);
                }
            }
            return clienti;
        }
    }
}
