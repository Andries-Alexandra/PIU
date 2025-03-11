using System;
using LibrarieModele;
using NivelStocareDate;

namespace tema1
{
    class Program
    {
        static void Main()
        {

            Produs produsNou = new Produs();
            produsNou = CitireProdusTastatura();
            AfisareProdus(produsNou);

            AdministrareCofetarie adminProd = new AdministrareCofetarie();
            int nrProd = 0;
            Produs[] produse = adminProd.GetProdus(out nrProd);
            AfisareProdus(produse, nrProd);

           // Client clientNou = new Client();
            //clientNou = CitireClientTastatura();
           // AfisareClient(clientNou);

            int idProd = nrProd + 1;
            produsNou.id = idProd;
            adminProd.AddProduse(produsNou);

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


            Console.ReadKey();
        }
        public static Produs CitireProdusTastatura()
        {
            Console.WriteLine("Introduceti numele produsului: ");
            string nume = Console.ReadLine();

            Console.WriteLine("Introduceti pretul produsului: ");
            double pret = double.Parse(Console.ReadLine());

            Produs produs = new Produs(0, nume, pret);

            return produs;
        }
        public static void AfisareProdus(Produs produs)
        {
            string infoProdus = string.Format("Produsul {1} cu ID-ul {0} are pretul {2}", produs.id, produs.nume, produs.pret);
            Console.WriteLine(infoProdus);
        }
        public static void AfisareProdus(Produs[] produse, int nrProd)
        {
            Console.WriteLine("Lista produselor: ");
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

            return client;
        }
        public static void AfisareClient(Client client)
        {
            string infoClient = string.Format("Nume client - {0}, email - {1}, numar de telefon - {2}", client.nume, client.email, client.nrTel);
            Console.WriteLine(infoClient);
        }
    }
}
