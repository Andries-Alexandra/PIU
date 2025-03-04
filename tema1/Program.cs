using System;

namespace tema1
{
    class Program
    {
        static void Main()
        {
            var p = new Produs();
            var c = new Client();
            string s = p.Info();
            
            Console.WriteLine(s);
            Console.WriteLine(c.Info());

            Produs p1 = new Produs(1234, "Ecler", 20.5);
            string s1 = p1.Info();
            Client c1 = new Client("Ion Popescu", "ionpopescu1@gmail.com", "0754399567");
            
            Console.WriteLine(s1);
            Console.WriteLine(c1.Info());

            Console.ReadKey();
        }
    }
}
