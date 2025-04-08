using System;
using System.Windows.Forms;

namespace InterfataUtilizator_WindowsForms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Creează și afișează Form1
            Form1 form1 = new Form1();
            form1.Show();

            // Creează și afișează Form2
            Form2 form2 = new Form2();
            form2.Show();

            // Rulează aplicația
            Application.Run();
        }
    }
}