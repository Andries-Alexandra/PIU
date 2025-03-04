
using System.Globalization;

namespace tema1
{
    public class Produs
    {
        int id;
        string nume;
        double pret;

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
            return $"ID produs: {id}, denumire produs: {nume}, pret: {pret}";
        }
    }
}

     
    
