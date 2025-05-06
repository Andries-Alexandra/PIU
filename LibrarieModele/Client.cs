using System;

namespace LibrarieModele
{
    public class Client
    {
        public string nrTel { get; set; }
        public string nume { get; set; }
        public string email { get; set; }
        public TipClient tip { get; set; }
        public bool abonatNewsletter { get; set; }
        public bool clientFidel { get; set; }

        public Client(string nrTel, string nume, string email, bool abonatNewsletter, bool clientFidel)
        {
            this.nrTel = nrTel;
            this.nume = nume;
            this.email = email;
            this.abonatNewsletter = abonatNewsletter;
            this.clientFidel = clientFidel;
        }

        // Constructor pentru citirea din fișier
        public Client(string linieFisier)
        {
            string[] dateFisier = linieFisier.Split(',');
            this.nrTel = dateFisier[0];
            this.nume = dateFisier[1];
            this.email = dateFisier[2];
            this.tip = (TipClient)Enum.Parse(typeof(TipClient), dateFisier[3]);

            // Verificăm lungimea array-ului pentru a gestiona formatul vechi
            if (dateFisier.Length > 4)
            {
                // Format vechi (cu tipComanda) sau format nou (cu abonatNewsletter și clientFidel)
                if (dateFisier.Length == 5)
                {
                    // Format vechi: nrTel,nume,email,tip,tipComanda
                    // Setăm valori implicite
                    this.abonatNewsletter = true; // Implicit, clientul este abonat
                    this.clientFidel = false;     // Implicit, nu este client fidel
                }
                else if (dateFisier.Length >= 6)
                {
                    // Format nou: nrTel,nume,email,tip,abonatNewsletter,clientFidel
                    this.abonatNewsletter = bool.Parse(dateFisier[4]);
                    this.clientFidel = bool.Parse(dateFisier[5]);
                }
            }
            else
            {
                // Dacă linia este incompletă, setăm valori implicite
                this.abonatNewsletter = true;
                this.clientFidel = false;
            }
        }

        // Conversie pentru salvarea în fișier
        public string ConversieLaSir_PentruFisier()
        {
            return $"{nrTel},{nume},{email},{tip},{abonatNewsletter},{clientFidel}";
        }
    }
}