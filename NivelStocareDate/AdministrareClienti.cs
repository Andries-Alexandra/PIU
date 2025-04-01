using LibrarieModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NivelStocareDate
{
    public class AdministrareClienti
    {
        private const int nr_max_clienti = 100;

        private Client[] clienti;
        private int nrClienti;
        public AdministrareClienti()
        {
            clienti = new Client[nr_max_clienti];
            nrClienti = 0;
        }
        public void AddClienti(Client client)
        {
            clienti[nrClienti] = client;
            nrClienti++;
        }
        public Client[] GetClient(out int nrClienti)
        {
            nrClienti = this.nrClienti;
            return clienti;
        }
    }
}
