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

        private DataGridView dgvProduse;
        private GroupBox grpIntroducere, grpCautare;
        private Label lblIdInput, lblNumeInput, lblPretInput, lblError, lblCautare;
        private TextBox txtId, txtNume, txtPret, txtCautare;
        private Button btnAdauga, btnClear, btnRefresh, btnCautare;

        private const int LATIME_TEXTBOX = 200;
        private const int DIMENSIUNE_PAS_Y = 40;
        private const int LIMITA_NUME = 15;
        private const int OFFSET_ETICHETA = 20;
        private const int OFFSET_TEXTBOX = 120;

        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);

            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = Path.Combine(locatieFisierSolutie, numeFisier);
            adminProd = new AdministrareProdusFisierText(caleCompletaFisier);

            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            this.Text = "Gestionare Produse";
            this.BackColor = Color.LightPink;

            dgvProduse = new DataGridView
            {
                Location = new Point(20, 80),
                Size = new Size(740, 200),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.LavenderBlush,
                BorderStyle = BorderStyle.FixedSingle,
                AllowUserToAddRows = false,
                ReadOnly = true
            };
            dgvProduse.Columns.Add("Id", "ID");
            dgvProduse.Columns.Add("Nume", "Nume");
            dgvProduse.Columns.Add("Pret", "Preț");
            this.Controls.Add(dgvProduse);

            grpCautare = new GroupBox
            {
                Text = "Căutare Produse",
                Location = new Point(20, 20),
                Size = new Size(740, 50),
                ForeColor = Color.DarkOrchid
            };
            lblCautare = new Label { Text = "Caută:", Left = OFFSET_ETICHETA, Top = 20, ForeColor = Color.DarkOrchid };
            txtCautare = new TextBox { Left = OFFSET_TEXTBOX, Top = 20, Width = LATIME_TEXTBOX };
            btnCautare = new Button { Text = "Caută", Left = OFFSET_TEXTBOX + LATIME_TEXTBOX + 20, Top = 20, Width = 100, BackColor = Color.Orchid };
            btnCautare.Click += BtnCautare_Click;
            grpCautare.Controls.AddRange(new Control[] { lblCautare, txtCautare, btnCautare });
            this.Controls.Add(grpCautare);

            grpIntroducere = new GroupBox
            {
                Text = "Introducere Produs Nou",
                Location = new Point(20, 290),
                Size = new Size(740, 250),
                ForeColor = Color.DarkOrchid
            };
            this.Controls.Add(grpIntroducere);

            int startY = 30;
            lblIdInput = new Label { Text = "ID:", Left = OFFSET_ETICHETA, Top = startY, ForeColor = Color.DarkOrchid };
            txtId = new TextBox { Left = OFFSET_TEXTBOX, Top = startY, Width = LATIME_TEXTBOX };
            lblNumeInput = new Label { Text = "Nume:", Left = OFFSET_ETICHETA, Top = startY + DIMENSIUNE_PAS_Y, ForeColor = Color.DarkOrchid };
            txtNume = new TextBox { Left = OFFSET_TEXTBOX, Top = startY + DIMENSIUNE_PAS_Y, Width = LATIME_TEXTBOX };
            lblPretInput = new Label { Text = "Preț:", Left = OFFSET_ETICHETA, Top = startY + 2 * DIMENSIUNE_PAS_Y, ForeColor = Color.DarkOrchid };
            txtPret = new TextBox { Left = OFFSET_TEXTBOX, Top = startY + 2 * DIMENSIUNE_PAS_Y, Width = LATIME_TEXTBOX };
            lblError = new Label { Left = OFFSET_TEXTBOX + LATIME_TEXTBOX + 20, Top = startY, Width = 300, ForeColor = Color.Red, Visible = false };

            btnAdauga = new Button { Text = "Adaugă", Left = OFFSET_TEXTBOX, Top = startY + 3 * DIMENSIUNE_PAS_Y, Width = 100, BackColor = Color.HotPink };
            btnAdauga.Click += BtnAdauga_Click;
            btnClear = new Button { Text = "Șterge Câmpuri", Left = OFFSET_TEXTBOX + 120, Top = startY + 3 * DIMENSIUNE_PAS_Y, Width = 120, BackColor = Color.Plum };
            btnClear.Click += BtnClear_Click;
            btnRefresh = new Button { Text = "Reîmprospătează", Left = OFFSET_TEXTBOX + 260, Top = startY + 3 * DIMENSIUNE_PAS_Y, Width = 120, BackColor = Color.MediumPurple };
            btnRefresh.Click += BtnRefresh_Click;

            grpIntroducere.Controls.AddRange(new Control[] { lblIdInput, txtId, lblNumeInput, txtNume, lblPretInput, txtPret, btnAdauga, btnClear, btnRefresh, lblError });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AfiseazaProduse();
        }

        private void AfiseazaProduse(List<Produs> produse = null)
        {
            if (produse == null) produse = adminProd.GetProdus();
            dgvProduse.Rows.Clear();
            foreach (Produs produs in produse)
            {
                dgvProduse.Rows.Add(produs.id, produs.nume, produs.pret.ToString("F2"));
            }
        }

        private void BtnCautare_Click(object sender, EventArgs e)
        {
            string termenCautare = txtCautare.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(termenCautare))
            {
                AfiseazaProduse();
                return;
            }

            List<Produs> produse = adminProd.GetProdus();
            List<Produs> rezultate = produse.FindAll(p =>
                p.nume.ToLower().Contains(termenCautare) ||
                p.id.ToString().Contains(termenCautare) ||
                p.pret.ToString().Contains(termenCautare));

            AfiseazaProduse(rezultate);
        }

        private void BtnAdauga_Click(object sender, EventArgs e)
        {
            lblIdInput.ForeColor = lblNumeInput.ForeColor = lblPretInput.ForeColor = Color.DarkOrchid;
            lblError.Visible = false;

            string mesajEroare = ValideazaDateProdus();
            if (!string.IsNullOrEmpty(mesajEroare))
            {
                AfiseazaEroare(mesajEroare);
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

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtNume.Clear();
            txtPret.Clear();
            lblIdInput.ForeColor = lblNumeInput.ForeColor = lblPretInput.ForeColor = Color.DarkOrchid;
            lblError.Visible = false;
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            AfiseazaProduse();
        }

        private string ValideazaDateProdus()
        {
            if (string.IsNullOrEmpty(txtId.Text) || !int.TryParse(txtId.Text, out _))
            {
                lblIdInput.ForeColor = Color.Red;
                return "ID-ul trebuie să fie un număr valid!";
            }
            if (string.IsNullOrEmpty(txtNume.Text) || txtNume.Text.Length > LIMITA_NUME)
            {
                lblNumeInput.ForeColor = Color.Red;
                return $"Numele nu poate depăși {LIMITA_NUME} caractere!";
            }
            if (string.IsNullOrEmpty(txtPret.Text) || !double.TryParse(txtPret.Text, out double pret) || pret <= 0)
            {
                lblPretInput.ForeColor = Color.Red;
                return "Prețul trebuie să fie un număr pozitiv!";
            }
            return "";
        }

        private void AfiseazaEroare(string mesajEroare)
        {
            lblError.Text = mesajEroare;
            lblError.Visible = true;
        }
    }
}