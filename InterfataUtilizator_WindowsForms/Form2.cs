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

        private Label lblNumeHeader, lblEmailHeader, lblNrTelHeader;
        private Label lblNumeInput, lblEmailInput, lblNrTelInput, lblError;
        private TextBox txtNume, txtEmail, txtNrTel;
        private Button btnAdauga;

        private Label[,] lblsClienti;

        private const int LATIME_CONTROL = 150;
        private const int LATIME_TEXTBOX = 200;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 160;
        private const int LIMITA_NUME = 15;
        private const int OFFSET_ETICHETA = 10; 
        private const int OFFSET_TEXTBOX = 120; 

        public Form2()
        {
            InitializeComponent();
            string numeFisierClient = ConfigurationManager.AppSettings["NumeFisierClient"];
            string locatieFisierSolutieClient = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisierClient = Path.Combine(locatieFisierSolutieClient, numeFisierClient);
            adminClient = new AdministrareClientFisierText(caleCompletaFisierClient);

            this.Size = new Size(800, 400); 
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.DeepPink;
            this.Text = "Informatii clienti";

            lblNumeHeader = new Label { Width = LATIME_CONTROL, Text = "Nume", Left = DIMENSIUNE_PAS_X, ForeColor = Color.DarkMagenta };
            lblEmailHeader = new Label { Width = LATIME_CONTROL, Text = "Email", Left = 2 * DIMENSIUNE_PAS_X, ForeColor = Color.DarkMagenta };
            lblNrTelHeader = new Label { Width = LATIME_CONTROL, Text = "NrTel", Left = 3 * DIMENSIUNE_PAS_X, ForeColor = Color.DarkMagenta };
            this.Controls.AddRange(new[] { lblNumeHeader, lblEmailHeader, lblNrTelHeader });

            int startY = 150;
            lblNumeInput = new Label { Text = "Nume:", Left = OFFSET_ETICHETA, Top = startY, ForeColor = Color.DarkMagenta };
            txtNume = new TextBox { Left = OFFSET_TEXTBOX, Top = startY, Width = LATIME_TEXTBOX };
            lblEmailInput = new Label { Text = "Email:", Left = OFFSET_ETICHETA, Top = startY + DIMENSIUNE_PAS_Y, ForeColor = Color.DarkMagenta };
            txtEmail = new TextBox { Left = OFFSET_TEXTBOX, Top = startY + DIMENSIUNE_PAS_Y, Width = LATIME_TEXTBOX };
            lblNrTelInput = new Label { Text = "NrTel:", Left = OFFSET_ETICHETA, Top = startY + 2 * DIMENSIUNE_PAS_Y, ForeColor = Color.DarkMagenta };
            txtNrTel = new TextBox { Left = OFFSET_TEXTBOX, Top = startY + 2 * DIMENSIUNE_PAS_Y, Width = LATIME_TEXTBOX };
            lblError = new Label { Left = OFFSET_TEXTBOX + LATIME_TEXTBOX + 20, Top = startY, Width = 300, ForeColor = Color.Red, Visible = false };

            btnAdauga = new Button { Text = "Adaugă", Left = OFFSET_TEXTBOX, Top = startY + 3 * DIMENSIUNE_PAS_Y, Width = 100 };
            btnAdauga.Click += BtnAdauga_Click;

            this.Controls.AddRange(new Control[] { lblNumeInput, txtNume, lblEmailInput, txtEmail, lblNrTelInput, txtNrTel, btnAdauga, lblError });
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            AfiseazaClienti();
        }

        private void AfiseazaClienti()
        {
            if (lblsClienti != null)
                foreach (var lbl in lblsClienti) this.Controls.Remove(lbl);

            List<Client> clienti = adminClient.GetClient();
            lblsClienti = new Label[clienti.Count, 3];

            for (int i = 0; i < clienti.Count; i++)
            {
                lblsClienti[i, 0] = new Label { Width = LATIME_CONTROL, Text = clienti[i].nume, Left = DIMENSIUNE_PAS_X, Top = (i + 1) * DIMENSIUNE_PAS_Y };
                lblsClienti[i, 1] = new Label { Width = LATIME_CONTROL, Text = clienti[i].email, Left = 2 * DIMENSIUNE_PAS_X, Top = (i + 1) * DIMENSIUNE_PAS_Y };
                lblsClienti[i, 2] = new Label { Width = LATIME_CONTROL, Text = clienti[i].nrTel, Left = 3 * DIMENSIUNE_PAS_X, Top = (i + 1) * DIMENSIUNE_PAS_Y };
                this.Controls.AddRange(new[] { lblsClienti[i, 0], lblsClienti[i, 1], lblsClienti[i, 2] });
            }
        }

        private void BtnAdauga_Click(object sender, EventArgs e)
        {
            lblNumeInput.ForeColor = lblEmailInput.ForeColor = lblNrTelInput.ForeColor = Color.DarkMagenta;
            lblError.Visible = false;

            int codEroare = ValideazaDateClient();
            if (codEroare != 0)
            {
                AfiseazaEroare(codEroare);
                return;
            }

            Client clientNou = new Client(txtNume.Text, txtEmail.Text, txtNrTel.Text);
            adminClient.AddClienti(clientNou);

            txtNume.Clear(); txtEmail.Clear(); txtNrTel.Clear();
            AfiseazaClienti();
        }

        private int ValideazaDateClient()
        {
            if (string.IsNullOrEmpty(txtNume.Text) || txtNume.Text.Length > LIMITA_NUME) return 1;
            if (string.IsNullOrEmpty(txtEmail.Text) || !txtEmail.Text.Contains("@")) return 2;
            if (string.IsNullOrEmpty(txtNrTel.Text) || !long.TryParse(txtNrTel.Text, out _)) return 3;
            return 0;
        }

        private void AfiseazaEroare(int codEroare)
        {
            lblError.Visible = true;
            switch (codEroare)
            {
                case 1:
                    lblNumeInput.ForeColor = Color.Red;
                    lblError.Text = $"Numele nu poate depăși {LIMITA_NUME} caractere!";
                    break;
                case 2:
                    lblEmailInput.ForeColor = Color.Red;
                    lblError.Text = "Email-ul trebuie să conțină '@'!";
                    break;
                case 3:
                    lblNrTelInput.ForeColor = Color.Red;
                    lblError.Text = "Numărul de telefon trebuie să fie numeric!";
                    break;
            }
        }
    }
}