using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Client
    {
        public string nume { get; set; }
        public string email { get; set; }
        public string nrTel { get; set; }
            
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
        public string Info()
        {
            return $"Nume client: {nume}, email: {email}, numar de telefon: {nrTel}";
        }
    }
}
