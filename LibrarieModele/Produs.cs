
using System;
using LibrarieModele.Enumerari;
using System.Globalization;

namespace LibrarieModele
{
    public class Produs
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ',';

        private const int ID = 0;
        private const int NUME = 1;
        private const int PRET = 2;
        private const int CATEGORIE = 3;
        
        public int id { get; set; }
        public string nume { get; set; }
        public double pret { get; set; }
        public CategorieProdus categorie { get; set; }


        public Produs()
        {
            id = 0;
            nume = string.Empty;
            pret = 0;
        }

        public Produs(int id, string nume, double pret)
        {
            this.id = id;
            this.nume = nume;
            this.pret = pret;
        }
        public Produs(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            this.id = Convert.ToInt32(dateFisier[ID]);
            this.nume = dateFisier[NUME];
            this.pret = Convert.ToInt32(dateFisier[PRET]);
            this.categorie = (CategorieProdus)Enum.Parse(typeof(CategorieProdus), dateFisier[CATEGORIE]);
        }
        public string Info()
        {
            return $"ID produs: {id}, denumire produs: {nume}, pret: {pret:F2} LEI, Categorie: {categorie}";
        }
        public string ConversieLaSir_PentruFisier()
        {
            string obiectProdusPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}",
                SEPARATOR_PRINCIPAL_FISIER,
                id.ToString(),
                (nume ?? "necunoscut"),
                pret.ToString(),
                categorie);
            return obiectProdusPentruFisier;
        }
    }
}

     
    
