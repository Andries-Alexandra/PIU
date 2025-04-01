using System;
using System.Configuration;
using LibrarieModele;
using LibrarieModele.Enumerari;
using NivelStocareDate;

namespace EvidentaCofetarie
{
    class Program
    {
        static void Main()
        {

            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            AdministrareProdusFisierText adminProd = new AdministrareProdusFisierText(numeFisier);

            Produs produsNou = CitireProdusTastatura();
            int nrProd = 0;
            Produs[] produse = adminProd.GetProdus(out nrProd);
            AfisareProdus(produse, nrProd);

            int idProd = nrProd + 1;
            produsNou.id = idProd;
            adminProd.AddProduse(produsNou);


            string numeFisierClient = ConfigurationManager.AppSettings["NumeFisierClient"];
            AdministrareClientFisierText adminClient = new AdministrareClientFisierText(numeFisierClient);

            Client clientNou = CitireClientTastatura();
            int nrClienti = 0;
            Client[] clienti = adminClient.GetClient(out nrClienti);
            AfisareClient(clienti,nrClienti);

            adminClient.AddClienti(clientNou);

            /*
            Console.WriteLine("Introduceti numele produsului de cautat:");
            string numeCautat = Console.ReadLine();
            Produs gasit = adminProd.CautaProdusDupaNume(numeCautat);
            if (gasit != null)
            {
                Console.WriteLine("Produs gasit: " + gasit.Info());
            }
            else
            {
                Console.WriteLine("Produsul nu a fost gasit.");
            }
            */

            Console.ReadKey();
        }
        public static Produs CitireProdusTastatura()
        {
            Console.WriteLine("Introduceti numele produsului: ");
            string nume = Console.ReadLine();

            Console.WriteLine("Introduceti pretul produsului: ");
            double pret = double.Parse(Console.ReadLine());

            Produs produs = new Produs(0, nume, pret);

            Console.WriteLine("Alegeti categoria produsului: ");
            Console.WriteLine("1. Torturi \n" +
                "2. Prajituri \n" +
                "3. Bomboane \n" +
                "4. Fursecuri \n" +
                "5. Produse de post \n" +
                "6. Diverse \n");
            int optiune = Convert.ToInt32(Console.ReadLine());
            produs.categorie = (CategorieProdus)optiune;

            return produs;
        }
        public static void AfisareProdus(Produs produs)
        {
            string infoProdus = string.Format("Produs: {1} ID: {0} Pret: {2} Categorie: {3}", 
                produs.id, 
                produs.nume ?? "Necunoscut",
                produs.pret,
                produs.categorie);
            Console.WriteLine(infoProdus);
        }
        public static void AfisareProdus(Produs[] produse, int nrProd)
        {
            //Console.WriteLine("Lista produselor: ");
            for (int i=0; i<nrProd; i++)
            {
                string infoProdus = produse[i].Info();
                Console.WriteLine(infoProdus);
            }
            
        }
        public static Client CitireClientTastatura()
        {
            Console.WriteLine("Introduceti numele complet: ");
            string nume = Console.ReadLine();

            Console.WriteLine("Introduceti adresa de email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Introduceti numarul de telefon: ");
            string nrTel = Console.ReadLine();

            Client client = new Client(nume, email, nrTel);

            Console.WriteLine("Alegeti tipul de client: ");
            Console.WriteLine("1. Standard \n" +
                "2. Premium \n" +
                "3. VIP \n");
            int optiune = Convert.ToInt32(Console.ReadLine());
            client.tip = (TipClient)optiune;

            return client;
        }
        public static void AfisareClient(Client client)
        {
            string infoClient = string.Format("Nume client - {0}, email - {1}, numar de telefon - {2}, tip - {3}", client.nume, client.email, client.nrTel);
            Console.WriteLine(infoClient);
        }
        public static void AfisareClient(Client[] clienti, int nrClienti)
        {
            for (int i = 0; i < nrClienti; i++)
            {
                string infoClient = clienti[i].Info();
                Console.WriteLine(infoClient);
            }
        }
    }
}
