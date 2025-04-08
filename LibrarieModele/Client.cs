using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Client
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ',';

        private const int NUME = 0;
        private const int EMAIL = 1;
        private const int NRTEL = 2;
        private const int TIP = 3;

        public string nume { get; set; }
        public string email { get; set; }
        public string nrTel { get; set; }
        public TipClient tip { get; set; }
    
        public Client()
        {
            nume = string.Empty;
            email = string.Empty;
            nrTel = string.Empty;
        }
        public Client(string nume, string email, string nrTel)
        {
            this.nume = nume;
            this.email = email;
            this.nrTel = nrTel;
        }
        public Client(string linieFisier)
        {
            string[] dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            this.nume = dateFisier[NUME];
            this.email = dateFisier[EMAIL];
            this.nrTel = dateFisier[NRTEL];
            this.tip = (TipClient)Enum.Parse(typeof(TipClient), dateFisier[TIP]);

        }
        public string Info()
        {
            return $"Nume client: {nume}, email: {email}, numar de telefon: {nrTel}, tip: {tip}";
        }
        public string ConversieLaSir_PentruFisier()
        {
            string obiectClientPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}",
                SEPARATOR_PRINCIPAL_FISIER,
                (nume ?? "necunoscut"),
                (email ?? "necunoscut"),
                (nrTel ?? "necunoscut"),
                tip);
            return obiectClientPentruFisier;
        }
    }
}
