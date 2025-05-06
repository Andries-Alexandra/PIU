using System;
using System.Collections.Generic;
using System.IO;
using LibrarieModele;

namespace NivelStocareDate
{
    public class AdministrareClientFisierText
    {
        private string numeFisier;

        public AdministrareClientFisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            using (StreamWriter sw = new StreamWriter(numeFisier, true)) { }
        }

        public void AddClient(Client client)
        {
            using (StreamWriter sw = new StreamWriter(numeFisier, true))
            {
                sw.WriteLine(client.ConversieLaSir_PentruFisier());
            }
        }

        public List<Client> GetClienti()
        {
            List<Client> clienti = new List<Client>();
            List<string> liniiNoi = new List<string>();

            // Citim toate liniile din fișier
            string[] linii = File.ReadAllLines(numeFisier);
            bool necesitaActualizare = false;

            foreach (string linie in linii)
            {
                if (string.IsNullOrWhiteSpace(linie)) continue;

                Client client = new Client(linie);
                clienti.Add(client);

                // Verificăm dacă linia are formatul vechi (5 elemente)
                string[] dateFisier = linie.Split(',');
                if (dateFisier.Length == 5)
                {
                    // Linia este în format vechi, o convertim
                    necesitaActualizare = true;
                }
                // Adăugăm linia în formatul nou
                liniiNoi.Add(client.ConversieLaSir_PentruFisier());
            }

            // Dacă am găsit linii în format vechi, rescriem fișierul
            if (necesitaActualizare)
            {
                File.WriteAllLines(numeFisier, liniiNoi);
            }

            return clienti;
        }

        public Client GetClienti(string nrTel)
        {
            using (StreamReader sr = new StreamReader(numeFisier))
            {
                string linie;
                while ((linie = sr.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(linie))
                    {
                        Client client = new Client(linie);
                        if (client.nrTel == nrTel)
                        {
                            return client;
                        }
                    }
                }
            }
            return null;
        }
    }
}