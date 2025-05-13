using System;

namespace LibrarieModele
{
    public class Client
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ',';
        private const int NUME = 0;
        private const int EMAIL = 1;
        private const int NR_TEL = 2;
        private const int TIP = 3;
        private const int ABONAT_NEWSLETTER = 4;
        private const int CLIENT_FIDEL = 5;

        public string nume { get; set; }
        public string email { get; set; }
        public string nrTel { get; set; }
        public TipClient tip { get; set; }
        public bool abonatNewsletter { get; set; }
        public bool clientFidel { get; set; }

        public Client(string nume, string email, string nrTel, bool abonatNewsletter, bool clientFidel)
        {
            this.nume = nume;
            this.email = email;
            this.nrTel = nrTel;
            this.abonatNewsletter = abonatNewsletter;
            this.clientFidel = clientFidel;
        }

        public Client(string linieFisier)
        {
            string[] dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            this.nume = dateFisier[NUME];
            this.email = dateFisier[EMAIL];
            this.nrTel = dateFisier[NR_TEL];
            this.tip = (TipClient)Enum.Parse(typeof(TipClient), dateFisier[TIP]);

            if (dateFisier.Length > ABONAT_NEWSLETTER)
            {
                this.abonatNewsletter = bool.Parse(dateFisier[ABONAT_NEWSLETTER]);
                this.clientFidel = bool.Parse(dateFisier[CLIENT_FIDEL]);
            }
            else
            {
                this.abonatNewsletter = true;
                this.clientFidel = false;
            }
        }

        public string ConversieLaSir_PentruFisier()
        {
            return $"{nume},{email},{nrTel},{tip},{abonatNewsletter},{clientFidel}";
        }
    }
}