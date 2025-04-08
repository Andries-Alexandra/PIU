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
        private const int ID_PRIMUL_CLIENT = 1;
        private const int INCREMENT = 1;
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
        public List<Client> GetClient()
        {
            List<Client> clienti = new List<Client>();

            using(StreamReader streamReader = new StreamReader(numeFisierClient))
            {
                string linieFisier;

                while((linieFisier=streamReader.ReadLine())!=null)
                {
                    clienti.Add(new Client(linieFisier));
                }
            }
            return clienti;
        }
    }
}
