
using System.Globalization;

namespace LibrarieModele
{
    public class Produs
    {
        public int id { get; set; }
        public string nume { get; set; }
        public double pret { get; set; }

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
        public string Info()
        {
            return $"ID produs: {id}, denumire produs: {nume}, pret: {pret:F2} LEI";
        }
    }
}

     
    
