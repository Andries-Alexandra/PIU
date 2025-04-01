using System;
using LibrarieModele;
using NivelStocareDate;
using System.Configuration;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Form2 : Form
    {
        AdministrareClientFisierText adminClient;

        private Label lblNume;
        private Label lblEmail;
        private Label lblNrTel;

        private Label[] lblsNume;
        private Label[] lblsEmail;
        private Label[] lblsNrTel;

        private const int LATIME_CONTROL = 100;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 120;

        public Form2()
        {
            InitializeComponent();
            string numeFisierClient = ConfigurationManager.AppSettings["NumeFisierClient"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisierClient = locatieFisierSolutie + "\\" + numeFisierClient;
            adminClient = new AdministrareClientFisierText(caleCompletaFisierClient);
            int nrClienti = 0;
            Client[] clienti = adminClient.GetClient(out nrClienti);

            this.Size = new Size(500, 200);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.DarkMagenta;
            this.Text = "Informatii clienti";

            //label pt 'Nume'
            lblNume = new Label();
            lblNume.Width = LATIME_CONTROL;
            lblNume.Text = "Nume";
            lblNume.Left = DIMENSIUNE_PAS_X;
            lblNume.ForeColor = Color.DarkMagenta;
            this.Controls.Add(lblNume);

            //label pt 'Email'
            lblEmail = new Label();
            lblEmail.Width = LATIME_CONTROL;
            lblEmail.Text = "Email";
            lblEmail.Left = 2 * DIMENSIUNE_PAS_X;
            lblEmail.ForeColor = Color.DarkMagenta;
            this.Controls.Add(lblEmail);

            //label pt 'NrTel'
            lblNrTel = new Label();
            lblNrTel.Width = LATIME_CONTROL;
            lblNrTel.Text = "NrTel";
            lblNrTel.Left = 3 * DIMENSIUNE_PAS_X;
            lblNrTel.ForeColor = Color.DarkMagenta;
            this.Controls.Add(lblNrTel);
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            AfiseazaClienti();
        }
        private void AfiseazaClienti()
        {
            int nrClienti = 0;
            Client[] clienti = adminClient.GetClient(out nrClienti);
            lblsNume = new Label[nrClienti];
            lblsEmail = new Label[nrClienti];
            lblsNrTel = new Label[nrClienti];
            for (int i = 0; i < nrClienti; i++)
            {
                lblsNume[i] = new Label();
                lblsNume[i].Width = LATIME_CONTROL;
                lblsNume[i].Text = clienti[i].nume;
                lblsNume[i].Left = DIMENSIUNE_PAS_X;
                lblsNume[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                lblsNume[i].ForeColor = Color.DarkMagenta;
                this.Controls.Add(lblsNume[i]);
                lblsEmail[i] = new Label();
                lblsEmail[i].Width = LATIME_CONTROL;
                lblsEmail[i].Text = clienti[i].email;
                lblsEmail[i].Left = 2 * DIMENSIUNE_PAS_X;
                lblsEmail[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                lblsEmail[i].ForeColor = Color.DarkMagenta;
                this.Controls.Add(lblsEmail[i]);
                lblsNrTel[i] = new Label();
                lblsNrTel[i].Width = LATIME_CONTROL;
                lblsNrTel[i].Text = clienti[i].nrTel;
                lblsNrTel[i].Left = 3 * DIMENSIUNE_PAS_X;
                lblsNrTel[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                lblsNrTel[i].ForeColor = Color.DarkMagenta;
                this.Controls.Add(lblsNrTel[i]);
                i++;
            }
        }
    }
}
