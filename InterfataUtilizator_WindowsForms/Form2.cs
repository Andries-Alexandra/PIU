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
    public partial class Form2 : Form
    {
        AdministrareClientFisierText adminClient;

        private DataGridView dgvClienti;
        private GroupBox grpIntroducere, grpCautare;
        private Label lblNumeInput, lblEmailInput, lblNrTelInput, lblError, lblCautare;
        private TextBox txtNume, txtEmail, txtNrTel, txtCautare;
        private Button btnAdauga, btnClear, btnRefresh, btnCautare;

        private const int LATIME_TEXTBOX = 200;
        private const int DIMENSIUNE_PAS_Y = 40;
        private const int LIMITA_NUME = 15;
        private const int OFFSET_ETICHETA = 20;
        private const int OFFSET_TEXTBOX = 120;

        public Form2()
        {
            InitializeComponent();
            string numeFisierClient = ConfigurationManager.AppSettings["NumeFisierClient"];
            string locatieFisierSolutieClient = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisierClient = Path.Combine(locatieFisierSolutieClient, numeFisierClient);
            adminClient = new AdministrareClientFisierText(caleCompletaFisierClient);

            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            this.Text = "Gestionare Clienți";
            this.BackColor = Color.LightPink;

            dgvClienti = new DataGridView
            {
                Location = new Point(20, 80),
                Size = new Size(740, 200),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.LavenderBlush,
                BorderStyle = BorderStyle.FixedSingle,
                AllowUserToAddRows = false,
                ReadOnly = true
            };
            dgvClienti.Columns.Add("Nume", "Nume");
            dgvClienti.Columns.Add("Email", "Email");
            dgvClienti.Columns.Add("NrTel", "Nr. Telefon");
            this.Controls.Add(dgvClienti);

            grpCautare = new GroupBox
            {
                Text = "Căutare Clienți",
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
                Text = "Introducere Client Nou",
                Location = new Point(20, 290),
                Size = new Size(740, 250),
                ForeColor = Color.DarkOrchid
            };
            this.Controls.Add(grpIntroducere);

            int startY = 30;
            lblNumeInput = new Label { Text = "Nume:", Left = OFFSET_ETICHETA, Top = startY, ForeColor = Color.DarkOrchid };
            txtNume = new TextBox { Left = OFFSET_TEXTBOX, Top = startY, Width = LATIME_TEXTBOX };
            lblEmailInput = new Label { Text = "Email:", Left = OFFSET_ETICHETA, Top = startY + DIMENSIUNE_PAS_Y, ForeColor = Color.DarkOrchid };
            txtEmail = new TextBox { Left = OFFSET_TEXTBOX, Top = startY + DIMENSIUNE_PAS_Y, Width = LATIME_TEXTBOX };
            lblNrTelInput = new Label { Text = "Nr. Telefon:", Left = OFFSET_ETICHETA, Top = startY + 2 * DIMENSIUNE_PAS_Y, ForeColor = Color.DarkOrchid };
            txtNrTel = new TextBox { Left = OFFSET_TEXTBOX, Top = startY + 2 * DIMENSIUNE_PAS_Y, Width = LATIME_TEXTBOX };
            lblError = new Label { Left = OFFSET_TEXTBOX + LATIME_TEXTBOX + 20, Top = startY, Width = 300, ForeColor = Color.Red, Visible = false };

            btnAdauga = new Button { Text = "Adaugă", Left = OFFSET_TEXTBOX, Top = startY + 3 * DIMENSIUNE_PAS_Y, Width = 100, BackColor = Color.HotPink };
            btnAdauga.Click += BtnAdauga_Click;
            btnClear = new Button { Text = "Șterge Câmpuri", Left = OFFSET_TEXTBOX + 120, Top = startY + 3 * DIMENSIUNE_PAS_Y, Width = 120, BackColor = Color.Plum };
            btnClear.Click += BtnClear_Click;
            btnRefresh = new Button { Text = "Reîmprospătează", Left = OFFSET_TEXTBOX + 260, Top = startY + 3 * DIMENSIUNE_PAS_Y, Width = 120, BackColor = Color.MediumPurple };
            btnRefresh.Click += BtnRefresh_Click;

            grpIntroducere.Controls.AddRange(new Control[] { lblNumeInput, txtNume, lblEmailInput, txtEmail, lblNrTelInput, txtNrTel, btnAdauga, btnClear, btnRefresh, lblError });
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            AfiseazaClienti();
        }

        private void AfiseazaClienti(List<Client> clienti = null)
        {
            if (clienti == null) clienti = adminClient.GetClient();
            dgvClienti.Rows.Clear();
            foreach (Client client in clienti)
            {
                dgvClienti.Rows.Add(client.nume, client.email, client.nrTel);
            }
        }

        private void BtnCautare_Click(object sender, EventArgs e)
        {
            string termenCautare = txtCautare.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(termenCautare))
            {
                AfiseazaClienti();
                return;
            }

            List<Client> clienti = adminClient.GetClient();
            List<Client> rezultate = clienti.FindAll(c =>
                c.nume.ToLower().Contains(termenCautare) ||
                c.email.ToLower().Contains(termenCautare) ||
                c.nrTel.ToLower().Contains(termenCautare));

            AfiseazaClienti(rezultate);
        }

        private void BtnAdauga_Click(object sender, EventArgs e)
        {
            lblNumeInput.ForeColor = lblEmailInput.ForeColor = lblNrTelInput.ForeColor = Color.DarkOrchid;
            lblError.Visible = false;

            string mesajEroare = ValideazaDateClient();
            if (!string.IsNullOrEmpty(mesajEroare))
            {
                AfiseazaEroare(mesajEroare);
                return;
            }

            Client clientNou = new Client(txtNume.Text, txtEmail.Text, txtNrTel.Text);
            adminClient.AddClienti(clientNou);

            txtNume.Clear(); txtEmail.Clear(); txtNrTel.Clear();
            AfiseazaClienti();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtNume.Clear();
            txtEmail.Clear();
            txtNrTel.Clear();
            lblNumeInput.ForeColor = lblEmailInput.ForeColor = lblNrTelInput.ForeColor = Color.DarkOrchid;
            lblError.Visible = false;
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            AfiseazaClienti();
        }

        private string ValideazaDateClient()
        {
            if (string.IsNullOrEmpty(txtNume.Text) || txtNume.Text.Length > LIMITA_NUME)
            {
                lblNumeInput.ForeColor = Color.Red;
                return $"Numele nu poate depăși {LIMITA_NUME} caractere!";
            }
            if (string.IsNullOrEmpty(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                lblEmailInput.ForeColor = Color.Red;
                return "Email-ul trebuie să conțină '@'!";
            }
            if (string.IsNullOrEmpty(txtNrTel.Text) || !long.TryParse(txtNrTel.Text, out _))
            {
                lblNrTelInput.ForeColor = Color.Red;
                return "Numărul de telefon trebuie să fie numeric!";
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