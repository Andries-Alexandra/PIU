using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using LibrarieModele;
using NivelStocareDate;
using LibrarieModele.Enumerari;
using System.Linq;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Form2 : Form
    {
        AdministrareClientFisierText adminClient;

        public Form2()
        {
            InitializeComponent();
      
            string numeFisier = ConfigurationManager.AppSettings["NumeFisierClienti"];
            string locatieFisier = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = Path.Combine(locatieFisier, numeFisier);
            adminClient = new AdministrareClientFisierText(caleCompletaFisier);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            AfiseazaClienti();
            dgvClienti.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClienti.SelectionChanged += DgvClienti_SelectionChanged;
        }

        private void AfiseazaClienti(List<Client> clienti = null)
        {
            if (clienti == null) clienti = adminClient.GetClienti();
            dgvClienti.Rows.Clear();
            foreach (Client client in clienti)
            {
                string newsletterText = client.abonatNewsletter ? "Da" : "Nu";
                string fidelText = client.clientFidel ? "Da" : "Nu";
                
                dgvClienti.Rows.Add(client.email, client.nrTel, client.nume, client.tip.ToString(), newsletterText, fidelText);
            }
        }

        private void BtnCautare_Click(object sender, EventArgs e)
        {
            string termen = txtCautare.Text.ToLower();
            if (string.IsNullOrEmpty(termen))
            {
                AfiseazaClienti();
                return;
            }

            List<Client> clienti = adminClient.GetClienti();
            List<Client> rezultate = new List<Client>();
            foreach (Client c in clienti)
            {
                string newsletterText = c.abonatNewsletter ? "da" : "nu";
                string fidelText = c.clientFidel ? "da" : "nu";
                if (c.nume.ToLower().Contains(termen) ||
                    c.email.ToLower().Contains(termen) ||
                    c.nrTel.ToLower().Contains(termen) ||
                    c.tip.ToString().ToLower().Contains(termen) ||
                    newsletterText.Contains(termen) ||
                    fidelText.Contains(termen))
                {
                    rezultate.Add(c);
                }
            }

            AfiseazaClienti(rezultate);
        }

        private void BtnAdauga_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            if (string.IsNullOrEmpty(txtNrTel.Text) || string.IsNullOrEmpty(txtNume.Text) || string.IsNullOrEmpty(txtEmail.Text))
            {
                lblError.Text = "Toate câmpurile trebuie completate!";
                lblError.Visible = true;
                return;
            }

            string nrTel = txtNrTel.Text;
            string nume = txtNume.Text;
            string email = txtEmail.Text;
            TipClient tip = GetTipClientSelectat();
            bool abonatNewsletter = ckbNewsletter.Checked;
            bool clientFidel = ckbClientFidel.Checked;

            Client clientNou = new Client(nrTel, nume, email, abonatNewsletter, clientFidel)
            {
                tip = tip
            };
            adminClient.AddClient(clientNou);

            ResetareControale();
            AfiseazaClienti();
        }

        // Editează un client existent
        private void BtnEditare_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            if (string.IsNullOrEmpty(txtNrTel.Text) || string.IsNullOrEmpty(txtNume.Text) || string.IsNullOrEmpty(txtEmail.Text))
            {
                lblError.Text = "Toate câmpurile trebuie completate!";
                lblError.Visible = true;
                return;
            }

            if (dgvClienti.SelectedRows.Count == 0)
            {
                lblError.Text = "Selectați un client pentru editare!";
                lblError.Visible = true;
                return;
            }

            string nrTelVechi = dgvClienti.SelectedRows[0].Cells["NrTel"].Value.ToString();
            string nrTelNou = txtNrTel.Text;
            string nume = txtNume.Text;
            string email = txtEmail.Text;
            TipClient tip = GetTipClientSelectat();
            bool abonatNewsletter = ckbNewsletter.Checked;
            bool clientFidel = ckbClientFidel.Checked;

            var clienti = adminClient.GetClienti();
            var client = clienti.Find(c => c.nrTel == nrTelVechi);
            if (client != null)
            {
                client.nrTel = nrTelNou;
                client.nume = nume;
                client.email = email;
                client.tip = tip;
                client.abonatNewsletter = abonatNewsletter;
                client.clientFidel = clientFidel;

                string caleFisier = adminClient.GetType().GetField("numeFisier", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(adminClient).ToString();
                File.WriteAllLines(caleFisier, clienti.Select(c => c.ConversieLaSir_PentruFisier()));
            }

            ResetareControale();
            AfiseazaClienti();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ResetareControale();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            AfiseazaClienti();
        }

        private void DgvClienti_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClienti.SelectedRows.Count == 0) return;

            var randSelectat = dgvClienti.SelectedRows[0];
            txtNume.Text = randSelectat.Cells["Nume"].Value?.ToString() ?? "";
            txtEmail.Text = randSelectat.Cells["Email"].Value?.ToString() ?? "";
            txtNrTel.Text = randSelectat.Cells["NrTel"].Value?.ToString() ?? "";

            string tipText = randSelectat.Cells["Tip"].Value?.ToString() ?? "Standard";
            if (tipText == "Premium") rdbPremium.Checked = true;
            else if (tipText == "VIP") rdbVIP.Checked = true;
            else rdbStandard.Checked = true;

            string newsletterText = randSelectat.Cells["Newsletter"].Value?.ToString() ?? "Nu";
            ckbNewsletter.Checked = newsletterText == "Da";
            string fidelText = randSelectat.Cells["Fidel"].Value?.ToString() ?? "Nu";
            ckbClientFidel.Checked = fidelText == "Da";
        }

        private TipClient GetTipClientSelectat()
        {
            if (rdbStandard.Checked) return TipClient.Standard;
            if (rdbPremium.Checked) return TipClient.Premium;
            if (rdbVIP.Checked) return TipClient.VIP;
            return TipClient.Standard; 
        }

        private void ResetareControale()
        {
            txtNrTel.Clear();
            txtNume.Clear();
            txtEmail.Clear();
            rdbStandard.Checked = true;
            rdbPremium.Checked = false;
            rdbVIP.Checked = false;
            ckbNewsletter.Checked = true;
            ckbClientFidel.Checked = false;
            lblError.Visible = false;
        }
    }
}