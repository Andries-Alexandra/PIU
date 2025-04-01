using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;
using NivelStocareDate;
using System.IO;
using System.Windows.Forms;
using System.Configuration;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Form1 : Form
    {
        AdministrareProdusFisierText adminProd;

        private Label lblId;
        private Label lblNume;
        private Label lblPret;

        private Label[] lblsId;
        private Label[] lblsNume;
        private Label[] lblsPret;

        private const int LATIME_CONTROL = 100;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 120;

        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);

            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
           

            adminProd = new AdministrareProdusFisierText(numeFisier);
            int nrProd = 0;
            Produs[] produse = adminProd.GetProdus(out nrProd);

            this.Size = new Size(500, 200);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Arial", 12, FontStyle.Bold);
            this.ForeColor = Color.Pink;
            this.Text = "Afisare produse";

            //label pt 'ID'
            lblId = new Label();
            lblId.Width = LATIME_CONTROL;
            lblId.Text = "ID";
            lblId.Left = DIMENSIUNE_PAS_X;
            lblId.ForeColor = Color.Black;
            this.Controls.Add(lblId);

            //label pt 'Nume'
            lblNume = new Label();
            lblNume.Width = LATIME_CONTROL;
            lblNume.Text = "Nume";
            lblNume.Left = 2 * DIMENSIUNE_PAS_X;
            lblNume.ForeColor = Color.Black;
            this.Controls.Add(lblNume);

            //label pt 'Pret'
            lblPret = new Label();
            lblPret.Width = LATIME_CONTROL;
            lblPret.Text = "Pret";
            lblPret.Left = 3 * DIMENSIUNE_PAS_X;
            lblPret.ForeColor = Color.Black;
            this.Controls.Add(lblPret);
        }

        private void AfiseazaProduse()
        {
            Produs[] produse = adminProd.GetProdus(out int nrProd);

            lblsId = new Label[nrProd];
            lblsNume = new Label[nrProd];
            lblsPret = new Label[nrProd];

            int i = 0;
            foreach (Produs produs in produse)
            {
                if (produse[i] != null)
                {
                    lblsId[i] = new Label();
                    lblsId[i].Width = LATIME_CONTROL;
                    lblsId[i].Text = produse[i].id.ToString();
                    lblsId[i].Left = DIMENSIUNE_PAS_X;
                    lblsId[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                    this.Controls.Add(lblsId[i]);

                    lblsNume[i] = new Label();
                    lblsNume[i].Width = LATIME_CONTROL;
                    lblsNume[i].Text = produse[i].nume;
                    lblsNume[i].Left = 2 * DIMENSIUNE_PAS_X;
                    lblsNume[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                    this.Controls.Add(lblsNume[i]);

                    lblsPret[i] = new Label();
                    lblsPret[i].Width = LATIME_CONTROL;
                    lblsPret[i].Text = produse[i].pret.ToString("F2");
                    lblsPret[i].Left = 3 * DIMENSIUNE_PAS_X;
                    lblsPret[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                    this.Controls.Add(lblsPret[i]);
                }
            }
        }
            private void Form1_Load(object sender, EventArgs e)
            {
            AfiseazaProduse();
            }
         
    }
}
