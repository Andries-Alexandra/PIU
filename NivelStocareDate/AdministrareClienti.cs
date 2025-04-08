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
        private List<Client> clienti;
        private int nrClienti;
        public AdministrareClienti()
        {
            clienti = new List<Client>();
        }
        public void AddClienti(Client client)
        {
            clienti.Add(client);
        }
        public List<Client> GetClient()
        {
            return clienti;
        }
    }
}
