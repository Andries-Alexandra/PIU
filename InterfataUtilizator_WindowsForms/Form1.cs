using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using LibrarieModele;
using NivelStocareDate;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Form1 : Form
    {
        AdministrareProdusFisierText adminProd;

        private Label lblIdHeader, lblNumeHeader, lblPretHeader;
        private Label lblIdInput, lblNumeInput, lblPretInput, lblError;
        private TextBox txtId, txtNume, txtPret;
        private Button btnAdauga;

        private Label[,] lblsProduse;

        private const int LATIME_CONTROL = 150;
        private const int LATIME_TEXTBOX = 200;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 160;
        private const int LIMITA_NUME = 15;
        private const int OFFSET_ETICHETA = 10; 
        private const int OFFSET_TEXTBOX = 120; 

        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);

            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = Path.Combine(locatieFisierSolutie, numeFisier);
            adminProd = new AdministrareProdusFisierText(caleCompletaFisier);

            this.Size = new Size(800, 400); 
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.DeepPink;
            this.Text = "Informatii produse";

            lblIdHeader = new Label { Width = LATIME_CONTROL, Text = "ID", Left = DIMENSIUNE_PAS_X, ForeColor = Color.DarkMagenta };
            lblNumeHeader = new Label { Width = LATIME_CONTROL, Text = "Nume", Left = 2 * DIMENSIUNE_PAS_X, ForeColor = Color.DarkMagenta };
            lblPretHeader = new Label { Width = LATIME_CONTROL, Text = "Pret", Left = 3 * DIMENSIUNE_PAS_X, ForeColor = Color.DarkMagenta };
            this.Controls.AddRange(new[] { lblIdHeader, lblNumeHeader, lblPretHeader });

            int startY = 150;
            lblIdInput = new Label { Text = "ID:", Left = OFFSET_ETICHETA, Top = startY, ForeColor = Color.DarkMagenta };
            txtId = new TextBox { Left = OFFSET_TEXTBOX, Top = startY, Width = LATIME_TEXTBOX };
            lblNumeInput = new Label { Text = "Nume:", Left = OFFSET_ETICHETA, Top = startY + DIMENSIUNE_PAS_Y, ForeColor = Color.DarkMagenta };
            txtNume = new TextBox { Left = OFFSET_TEXTBOX, Top = startY + DIMENSIUNE_PAS_Y, Width = LATIME_TEXTBOX };
            lblPretInput = new Label { Text = "Pret:", Left = OFFSET_ETICHETA, Top = startY + 2 * DIMENSIUNE_PAS_Y, ForeColor = Color.DarkMagenta };
            txtPret = new TextBox { Left = OFFSET_TEXTBOX, Top = startY + 2 * DIMENSIUNE_PAS_Y, Width = LATIME_TEXTBOX };
            lblError = new Label { Left = OFFSET_TEXTBOX + LATIME_TEXTBOX + 20, Top = startY, Width = 300, ForeColor = Color.Red, Visible = false };

            btnAdauga = new Button { Text = "Adaugă", Left = OFFSET_TEXTBOX, Top = startY + 3 * DIMENSIUNE_PAS_Y, Width = 100 };
            btnAdauga.Click += BtnAdauga_Click;

            this.Controls.AddRange(new Control[] { lblIdInput, txtId, lblNumeInput, txtNume, lblPretInput, txtPret, btnAdauga, lblError });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AfiseazaProduse();
        }

        private void AfiseazaProduse()
        {
            if (lblsProduse != null)
                foreach (var lbl in lblsProduse) this.Controls.Remove(lbl);

            List<Produs> produse = adminProd.GetProdus();
            lblsProduse = new Label[produse.Count, 3];

            for (int i = 0; i < produse.Count; i++)
            {
                lblsProduse[i, 0] = new Label { Width = LATIME_CONTROL, Text = produse[i].id.ToString(), Left = DIMENSIUNE_PAS_X, Top = (i + 1) * DIMENSIUNE_PAS_Y };
                lblsProduse[i, 1] = new Label { Width = LATIME_CONTROL, Text = produse[i].nume, Left = 2 * DIMENSIUNE_PAS_X, Top = (i + 1) * DIMENSIUNE_PAS_Y };
                lblsProduse[i, 2] = new Label { Width = LATIME_CONTROL, Text = produse[i].pret.ToString("F2"), Left = 3 * DIMENSIUNE_PAS_X, Top = (i + 1) * DIMENSIUNE_PAS_Y };
                this.Controls.AddRange(new[] { lblsProduse[i, 0], lblsProduse[i, 1], lblsProduse[i, 2] });
            }
        }

        private void BtnAdauga_Click(object sender, EventArgs e)
        {
            lblIdInput.ForeColor = lblNumeInput.ForeColor = lblPretInput.ForeColor = Color.DarkMagenta;
            lblError.Visible = false;

            int codEroare = ValideazaDateProdus();
            if (codEroare != 0)
            {
                AfiseazaEroare(codEroare);
                return;
            }

            int id = int.Parse(txtId.Text);
            string nume = txtNume.Text;
            double pret = double.Parse(txtPret.Text);
            Produs produsNou = new Produs(id, nume, pret);
            adminProd.AddProduse(produsNou);

            txtId.Clear(); txtNume.Clear(); txtPret.Clear();
            AfiseazaProduse();
        }

        private int ValideazaDateProdus()
        {
            if (string.IsNullOrEmpty(txtId.Text) || !int.TryParse(txtId.Text, out _)) return 1;
            if (string.IsNullOrEmpty(txtNume.Text) || txtNume.Text.Length > LIMITA_NUME) return 2;
            if (string.IsNullOrEmpty(txtPret.Text) || !double.TryParse(txtPret.Text, out double pret) || pret <= 0) return 3;
            return 0;
        }

        private void AfiseazaEroare(int codEroare)
        {
            lblError.Visible = true;
            switch (codEroare)
            {
                case 1:
                    lblIdInput.ForeColor = Color.Red;
                    lblError.Text = "ID-ul trebuie să fie un număr valid!";
                    break;
                case 2:
                    lblNumeInput.ForeColor = Color.Red;
                    lblError.Text = $"Numele nu poate depăși {LIMITA_NUME} caractere!";
                    break;
                case 3:
                    lblPretInput.ForeColor = Color.Red;
                    lblError.Text = "Prețul trebuie să fie un număr pozitiv!";
                    break;
            }
        }
    }
}