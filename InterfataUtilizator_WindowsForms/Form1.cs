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
    public partial class Form1 : Form
    {
        AdministrareProdusFisierText adminProd;
        private string caleFisier;
        private const int LIMITA_NUME = 15;

        public Form1()
        {
            InitializeComponent();
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            caleFisier = Path.Combine(locatieFisierSolutie, numeFisier);
            adminProd = new AdministrareProdusFisierText(caleFisier);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AfiseazaProduse();
            dgvProduse.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProduse.SelectionChanged += DgvProduse_SelectionChanged;
        }

        private void AfiseazaProduse(List<Produs> produse = null)
        {
            if (produse == null) produse = adminProd.GetProdus();
            dgvProduse.Rows.Clear();
            foreach (Produs produs in produse)
            {
                string disponibilitateText = produs.disponibil ? "Disponibil" : "Indisponibil";
                dgvProduse.Rows.Add(produs.id, produs.nume, produs.pret.ToString("F2"), produs.categorie.ToString(), disponibilitateText);
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
            {
                string disponibilitateText = p.disponibil ? "disponibil" : "indisponibil";
                return p.nume.ToLower().Contains(termenCautare) ||
                       p.id.ToString().Contains(termenCautare) ||
                       p.pret.ToString().Contains(termenCautare) ||
                       p.categorie.ToString().ToLower().Contains(termenCautare) ||
                       disponibilitateText.ToLower().Contains(termenCautare);
            });

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
            CategorieProdus categorie = GetCategorieSelectata();
            bool disponibil = ckbDisponibil.Checked;

            Produs produsNou = new Produs(id, nume, pret, disponibil)
            {
                categorie = categorie
            };
            adminProd.AddProduse(produsNou);

            ResetareControale();
            AfiseazaProduse();
        }

        private void BtnEditare_Click(object sender, EventArgs e)
        {
            lblIdInput.ForeColor = lblNumeInput.ForeColor = lblPretInput.ForeColor = Color.DarkOrchid;
            lblError.Visible = false;

            if (dgvProduse.SelectedRows.Count == 0)
            {
                AfiseazaEroare("Selectați un produs pentru editare!");
                return;
            }

            string mesajEroare = ValideazaDateProdus(true);
            if (!string.IsNullOrEmpty(mesajEroare))
            {
                AfiseazaEroare(mesajEroare);
                return;
            }

            int idVechi = int.Parse(dgvProduse.SelectedRows[0].Cells["Id"].Value.ToString());
            int idNou = int.Parse(txtId.Text);
            string nume = txtNume.Text;
            double pret = double.Parse(txtPret.Text);
            CategorieProdus categorie = GetCategorieSelectata();
            bool disponibil = ckbDisponibil.Checked;

            var produse = adminProd.GetProdus();
            var produs = produse.Find(p => p.id == idVechi);
            if (produs != null)
            {
                produs.id = idNou;
                produs.nume = nume;
                produs.pret = pret;
                produs.categorie = categorie;
                produs.disponibil = disponibil;

                File.WriteAllLines(caleFisier, produse.Select(p => p.ConversieLaSir_PentruFisier()));
            }

            ResetareControale();
            AfiseazaProduse();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ResetareControale();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            AfiseazaProduse();
        }

        private void DgvProduse_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProduse.SelectedRows.Count == 0) return;

            var row = dgvProduse.SelectedRows[0];
            int id = int.Parse(row.Cells["Id"].Value.ToString());
            var produs = adminProd.GetProduse(id);
            if (produs != null)
            {
                txtId.Text = produs.id.ToString();
                txtNume.Text = produs.nume;
                txtPret.Text = produs.pret.ToString("F2");
                ckbDisponibil.Checked = produs.disponibil;
                switch (produs.categorie)
                {
                    case CategorieProdus.Torturi: rdbTorturi.Checked = true; break;
                    case CategorieProdus.Prajituri: rdbPrajituri.Checked = true; break;
                    case CategorieProdus.Bomboane: rdbBomboane.Checked = true; break;
                    case CategorieProdus.Fursecuri: rdbFursecuri.Checked = true; break;
                    case CategorieProdus.ProduseDePost: rdbProduseDePost.Checked = true; break;
                    case CategorieProdus.Diverse: rdbDiverse.Checked = true; break;
                }
            }
        }

        private string ValideazaDateProdus(bool esteEditare = false)
        {
            if (string.IsNullOrEmpty(txtId.Text) || !int.TryParse(txtId.Text, out int id))
            {
                lblIdInput.ForeColor = Color.Red;
                return "ID-ul trebuie să fie un număr valid!";
            }

            var produse = adminProd.GetProdus();
            int idVechi = esteEditare && dgvProduse.SelectedRows.Count > 0 ? int.Parse(dgvProduse.SelectedRows[0].Cells["Id"].Value.ToString()) : -1;
            if (!esteEditare && produse.Any(p => p.id == id))
            {
                lblIdInput.ForeColor = Color.Red;
                return "ID-ul există deja!";
            }
            else if (esteEditare && id != idVechi && produse.Any(p => p.id == id))
            {
                lblIdInput.ForeColor = Color.Red;
                return "ID-ul modificat există deja!";
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

        private CategorieProdus GetCategorieSelectata()
        {
            if (rdbTorturi.Checked) return CategorieProdus.Torturi;
            if (rdbPrajituri.Checked) return CategorieProdus.Prajituri;
            if (rdbBomboane.Checked) return CategorieProdus.Bomboane;
            if (rdbFursecuri.Checked) return CategorieProdus.Fursecuri;
            if (rdbProduseDePost.Checked) return CategorieProdus.ProduseDePost;
            if (rdbDiverse.Checked) return CategorieProdus.Diverse;
            return CategorieProdus.Diverse;
        }

        private void ResetareControale()
        {
            txtId.Clear();
            txtNume.Clear();
            txtPret.Clear();
            rdbTorturi.Checked = true;
            rdbPrajituri.Checked = false;
            rdbBomboane.Checked = false;
            rdbFursecuri.Checked = false;
            rdbProduseDePost.Checked = false;
            rdbDiverse.Checked = false;
            ckbDisponibil.Checked = true;
            lblIdInput.ForeColor = lblNumeInput.ForeColor = lblPretInput.ForeColor = Color.DarkOrchid;
            lblError.Visible = false;
        }
    }
}