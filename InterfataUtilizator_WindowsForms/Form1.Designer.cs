
namespace InterfataUtilizator_WindowsForms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rdbTorturi = new System.Windows.Forms.RadioButton();
            this.rdbPrajituri = new System.Windows.Forms.RadioButton();
            this.rdbBomboane = new System.Windows.Forms.RadioButton();
            this.rdbFursecuri = new System.Windows.Forms.RadioButton();
            this.rdbDiverse = new System.Windows.Forms.RadioButton();
            this.grpCategorie = new System.Windows.Forms.GroupBox();
            this.rdbProduseDePost = new System.Windows.Forms.RadioButton();
            this.dgvProduse = new System.Windows.Forms.DataGridView();
            this.grpCautare = new System.Windows.Forms.GroupBox();
            this.btnCautare = new System.Windows.Forms.Button();
            this.txtCautare = new System.Windows.Forms.TextBox();
            this.lblCautare = new System.Windows.Forms.Label();
            this.grpIntroducere = new System.Windows.Forms.GroupBox();
            this.btnEditare = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdauga = new System.Windows.Forms.Button();
            this.ckbDisponibil = new System.Windows.Forms.CheckBox();
            this.lblError = new System.Windows.Forms.Label();
            this.txtPret = new System.Windows.Forms.TextBox();
            this.lblPretInput = new System.Windows.Forms.Label();
            this.txtNume = new System.Windows.Forms.TextBox();
            this.lblNumeInput = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblIdInput = new System.Windows.Forms.Label();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pret = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categorie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disponibilitate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpCategorie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduse)).BeginInit();
            this.grpCautare.SuspendLayout();
            this.grpIntroducere.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbTorturi
            // 
            this.rdbTorturi.AutoSize = true;
            this.rdbTorturi.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.rdbTorturi.Location = new System.Drawing.Point(10, 30);
            this.rdbTorturi.Margin = new System.Windows.Forms.Padding(4);
            this.rdbTorturi.Name = "rdbTorturi";
            this.rdbTorturi.Size = new System.Drawing.Size(88, 29);
            this.rdbTorturi.TabIndex = 0;
            this.rdbTorturi.TabStop = true;
            this.rdbTorturi.Text = "Torturi";
            this.rdbTorturi.UseVisualStyleBackColor = true;
            // 
            // rdbPrajituri
            // 
            this.rdbPrajituri.AutoSize = true;
            this.rdbPrajituri.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.rdbPrajituri.Location = new System.Drawing.Point(10, 70);
            this.rdbPrajituri.Margin = new System.Windows.Forms.Padding(4);
            this.rdbPrajituri.Name = "rdbPrajituri";
            this.rdbPrajituri.Size = new System.Drawing.Size(100, 29);
            this.rdbPrajituri.TabIndex = 1;
            this.rdbPrajituri.TabStop = true;
            this.rdbPrajituri.Text = "Prăjituri";
            this.rdbPrajituri.UseVisualStyleBackColor = true;
            // 
            // rdbBomboane
            // 
            this.rdbBomboane.AutoSize = true;
            this.rdbBomboane.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.rdbBomboane.Location = new System.Drawing.Point(10, 110);
            this.rdbBomboane.Margin = new System.Windows.Forms.Padding(4);
            this.rdbBomboane.Name = "rdbBomboane";
            this.rdbBomboane.Size = new System.Drawing.Size(124, 29);
            this.rdbBomboane.TabIndex = 2;
            this.rdbBomboane.TabStop = true;
            this.rdbBomboane.Text = "Bomboane";
            this.rdbBomboane.UseVisualStyleBackColor = true;
            // 
            // rdbFursecuri
            // 
            this.rdbFursecuri.AutoSize = true;
            this.rdbFursecuri.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.rdbFursecuri.Location = new System.Drawing.Point(140, 30);
            this.rdbFursecuri.Margin = new System.Windows.Forms.Padding(4);
            this.rdbFursecuri.Name = "rdbFursecuri";
            this.rdbFursecuri.Size = new System.Drawing.Size(110, 29);
            this.rdbFursecuri.TabIndex = 3;
            this.rdbFursecuri.TabStop = true;
            this.rdbFursecuri.Text = "Fursecuri";
            this.rdbFursecuri.UseVisualStyleBackColor = true;
            // 
            // rdbDiverse
            // 
            this.rdbDiverse.AutoSize = true;
            this.rdbDiverse.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.rdbDiverse.Location = new System.Drawing.Point(140, 110);
            this.rdbDiverse.Margin = new System.Windows.Forms.Padding(4);
            this.rdbDiverse.Name = "rdbDiverse";
            this.rdbDiverse.Size = new System.Drawing.Size(95, 29);
            this.rdbDiverse.TabIndex = 5;
            this.rdbDiverse.TabStop = true;
            this.rdbDiverse.Text = "Diverse";
            this.rdbDiverse.UseVisualStyleBackColor = true;
            // 
            // grpCategorie
            // 
            this.grpCategorie.Controls.Add(this.rdbProduseDePost);
            this.grpCategorie.Controls.Add(this.rdbTorturi);
            this.grpCategorie.Controls.Add(this.rdbDiverse);
            this.grpCategorie.Controls.Add(this.rdbPrajituri);
            this.grpCategorie.Controls.Add(this.rdbBomboane);
            this.grpCategorie.Controls.Add(this.rdbFursecuri);
            this.grpCategorie.Location = new System.Drawing.Point(410, 20);
            this.grpCategorie.Margin = new System.Windows.Forms.Padding(4);
            this.grpCategorie.Name = "grpCategorie";
            this.grpCategorie.Padding = new System.Windows.Forms.Padding(4);
            this.grpCategorie.Size = new System.Drawing.Size(320, 150);
            this.grpCategorie.TabIndex = 6;
            this.grpCategorie.TabStop = false;
            this.grpCategorie.Text = "Categorie Produs";
            // 
            // rdbProduseDePost
            // 
            this.rdbProduseDePost.AutoSize = true;
            this.rdbProduseDePost.Location = new System.Drawing.Point(140, 70);
            this.rdbProduseDePost.Name = "rdbProduseDePost";
            this.rdbProduseDePost.Size = new System.Drawing.Size(168, 29);
            this.rdbProduseDePost.TabIndex = 6;
            this.rdbProduseDePost.TabStop = true;
            this.rdbProduseDePost.Text = "Produse de Post";
            this.rdbProduseDePost.UseVisualStyleBackColor = true;
            // 
            // dgvProduse
            // 
            this.dgvProduse.AllowUserToAddRows = false;
            this.dgvProduse.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProduse.BackgroundColor = System.Drawing.Color.LavenderBlush;
            this.dgvProduse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nume,
            this.Pret,
            this.Categorie,
            this.Disponibilitate});
            this.dgvProduse.Location = new System.Drawing.Point(20, 89);
            this.dgvProduse.Name = "dgvProduse";
            this.dgvProduse.ReadOnly = true;
            this.dgvProduse.RowHeadersWidth = 51;
            this.dgvProduse.RowTemplate.Height = 24;
            this.dgvProduse.Size = new System.Drawing.Size(740, 173);
            this.dgvProduse.TabIndex = 7;
            // 
            // grpCautare
            // 
            this.grpCautare.Controls.Add(this.btnCautare);
            this.grpCautare.Controls.Add(this.txtCautare);
            this.grpCautare.Controls.Add(this.lblCautare);
            this.grpCautare.Location = new System.Drawing.Point(20, 20);
            this.grpCautare.Name = "grpCautare";
            this.grpCautare.Size = new System.Drawing.Size(740, 63);
            this.grpCautare.TabIndex = 8;
            this.grpCautare.TabStop = false;
            this.grpCautare.Text = "Căutare Produse";
            // 
            // btnCautare
            // 
            this.btnCautare.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnCautare.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.btnCautare.Location = new System.Drawing.Point(340, 30);
            this.btnCautare.Name = "btnCautare";
            this.btnCautare.Size = new System.Drawing.Size(100, 33);
            this.btnCautare.TabIndex = 2;
            this.btnCautare.Text = "Caută";
            this.btnCautare.UseVisualStyleBackColor = false;
            this.btnCautare.Click += new System.EventHandler(this.BtnCautare_Click);
            // 
            // txtCautare
            // 
            this.txtCautare.BackColor = System.Drawing.Color.LavenderBlush;
            this.txtCautare.Location = new System.Drawing.Point(120, 30);
            this.txtCautare.Name = "txtCautare";
            this.txtCautare.Size = new System.Drawing.Size(200, 32);
            this.txtCautare.TabIndex = 1;
            // 
            // lblCautare
            // 
            this.lblCautare.AutoSize = true;
            this.lblCautare.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.lblCautare.Location = new System.Drawing.Point(20, 30);
            this.lblCautare.Name = "lblCautare";
            this.lblCautare.Size = new System.Drawing.Size(78, 25);
            this.lblCautare.TabIndex = 0;
            this.lblCautare.Text = "Cautare";
            // 
            // grpIntroducere
            // 
            this.grpIntroducere.BackColor = System.Drawing.Color.LightPink;
            this.grpIntroducere.Controls.Add(this.btnEditare);
            this.grpIntroducere.Controls.Add(this.btnRefresh);
            this.grpIntroducere.Controls.Add(this.btnClear);
            this.grpIntroducere.Controls.Add(this.btnAdauga);
            this.grpIntroducere.Controls.Add(this.ckbDisponibil);
            this.grpIntroducere.Controls.Add(this.lblError);
            this.grpIntroducere.Controls.Add(this.txtPret);
            this.grpIntroducere.Controls.Add(this.lblPretInput);
            this.grpIntroducere.Controls.Add(this.txtNume);
            this.grpIntroducere.Controls.Add(this.lblNumeInput);
            this.grpIntroducere.Controls.Add(this.txtId);
            this.grpIntroducere.Controls.Add(this.lblIdInput);
            this.grpIntroducere.Controls.Add(this.grpCategorie);
            this.grpIntroducere.Location = new System.Drawing.Point(20, 310);
            this.grpIntroducere.Name = "grpIntroducere";
            this.grpIntroducere.Size = new System.Drawing.Size(740, 300);
            this.grpIntroducere.TabIndex = 9;
            this.grpIntroducere.TabStop = false;
            this.grpIntroducere.Text = "Introducere Produs Nou";
            // 
            // btnEditare
            // 
            this.btnEditare.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnEditare.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.btnEditare.Location = new System.Drawing.Point(240, 240);
            this.btnEditare.Name = "btnEditare";
            this.btnEditare.Size = new System.Drawing.Size(100, 35);
            this.btnEditare.TabIndex = 19;
            this.btnEditare.Text = "Editare";
            this.btnEditare.UseVisualStyleBackColor = false;
            this.btnEditare.Click += new System.EventHandler(this.BtnEditare_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnRefresh.Location = new System.Drawing.Point(550, 240);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(170, 35);
            this.btnRefresh.TabIndex = 18;
            this.btnRefresh.Text = "Reîmprospătează";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnClear.Location = new System.Drawing.Point(365, 240);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(155, 35);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "Șterge Câmpuri";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnAdauga
            // 
            this.btnAdauga.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnAdauga.Location = new System.Drawing.Point(120, 240);
            this.btnAdauga.Name = "btnAdauga";
            this.btnAdauga.Size = new System.Drawing.Size(100, 35);
            this.btnAdauga.TabIndex = 15;
            this.btnAdauga.Text = "Adaugă";
            this.btnAdauga.UseVisualStyleBackColor = false;
            this.btnAdauga.Click += new System.EventHandler(this.BtnAdauga_Click);
            // 
            // ckbDisponibil
            // 
            this.ckbDisponibil.AutoSize = true;
            this.ckbDisponibil.Location = new System.Drawing.Point(100, 165);
            this.ckbDisponibil.Name = "ckbDisponibil";
            this.ckbDisponibil.Size = new System.Drawing.Size(119, 29);
            this.ckbDisponibil.TabIndex = 14;
            this.ckbDisponibil.Text = "Disponibil";
            this.ckbDisponibil.UseVisualStyleBackColor = true;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.BackColor = System.Drawing.Color.LightPink;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(340, 30);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 25);
            this.lblError.TabIndex = 13;
            this.lblError.Visible = false;
            // 
            // txtPret
            // 
            this.txtPret.Location = new System.Drawing.Point(100, 112);
            this.txtPret.Name = "txtPret";
            this.txtPret.Size = new System.Drawing.Size(200, 32);
            this.txtPret.TabIndex = 12;
            // 
            // lblPretInput
            // 
            this.lblPretInput.AutoSize = true;
            this.lblPretInput.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.lblPretInput.Location = new System.Drawing.Point(20, 110);
            this.lblPretInput.Name = "lblPretInput";
            this.lblPretInput.Size = new System.Drawing.Size(50, 25);
            this.lblPretInput.TabIndex = 11;
            this.lblPretInput.Text = "Preț:";
            // 
            // txtNume
            // 
            this.txtNume.Location = new System.Drawing.Point(100, 72);
            this.txtNume.Name = "txtNume";
            this.txtNume.Size = new System.Drawing.Size(200, 32);
            this.txtNume.TabIndex = 10;
            // 
            // lblNumeInput
            // 
            this.lblNumeInput.AutoSize = true;
            this.lblNumeInput.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.lblNumeInput.Location = new System.Drawing.Point(20, 70);
            this.lblNumeInput.Name = "lblNumeInput";
            this.lblNumeInput.Size = new System.Drawing.Size(67, 25);
            this.lblNumeInput.TabIndex = 9;
            this.lblNumeInput.Text = "Nume:";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(100, 30);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(200, 32);
            this.txtId.TabIndex = 8;
            // 
            // lblIdInput
            // 
            this.lblIdInput.AutoSize = true;
            this.lblIdInput.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.lblIdInput.Location = new System.Drawing.Point(20, 30);
            this.lblIdInput.Name = "lblIdInput";
            this.lblIdInput.Size = new System.Drawing.Size(34, 25);
            this.lblIdInput.TabIndex = 7;
            this.lblIdInput.Text = "ID:";
            // 
            // Id
            // 
            this.Id.HeaderText = "ID";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Nume
            // 
            this.Nume.HeaderText = "Nume";
            this.Nume.MinimumWidth = 6;
            this.Nume.Name = "Nume";
            this.Nume.ReadOnly = true;
            // 
            // Pret
            // 
            this.Pret.HeaderText = "Preț";
            this.Pret.MinimumWidth = 6;
            this.Pret.Name = "Pret";
            this.Pret.ReadOnly = true;
            // 
            // Categorie
            // 
            this.Categorie.HeaderText = "Categorie";
            this.Categorie.MinimumWidth = 6;
            this.Categorie.Name = "Categorie";
            this.Categorie.ReadOnly = true;
            // 
            // Disponibilitate
            // 
            this.Disponibilitate.HeaderText = "Disponibilitate";
            this.Disponibilitate.MinimumWidth = 6;
            this.Disponibilitate.Name = "Disponibilitate";
            this.Disponibilitate.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightPink;
            this.ClientSize = new System.Drawing.Size(856, 709);
            this.Controls.Add(this.grpIntroducere);
            this.Controls.Add(this.grpCautare);
            this.Controls.Add(this.dgvProduse);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.Location = new System.Drawing.Point(30, 400);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Gestionare Produse";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpCategorie.ResumeLayout(false);
            this.grpCategorie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduse)).EndInit();
            this.grpCautare.ResumeLayout(false);
            this.grpCautare.PerformLayout();
            this.grpIntroducere.ResumeLayout(false);
            this.grpIntroducere.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbTorturi;
        private System.Windows.Forms.RadioButton rdbPrajituri;
        private System.Windows.Forms.RadioButton rdbBomboane;
        private System.Windows.Forms.RadioButton rdbFursecuri;
        private System.Windows.Forms.RadioButton rdbDiverse;
        private System.Windows.Forms.GroupBox grpCategorie;
        private System.Windows.Forms.DataGridView dgvProduse;
        private System.Windows.Forms.GroupBox grpCautare;
        private System.Windows.Forms.Label lblCautare;
        private System.Windows.Forms.TextBox txtCautare;
        private System.Windows.Forms.Button btnCautare;
        private System.Windows.Forms.GroupBox grpIntroducere;
        private System.Windows.Forms.Label lblIdInput;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblNumeInput;
        private System.Windows.Forms.TextBox txtNume;
        private System.Windows.Forms.Label lblPretInput;
        private System.Windows.Forms.TextBox txtPret;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.CheckBox ckbDisponibil;
        private System.Windows.Forms.Button btnAdauga;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnEditare;
        private System.Windows.Forms.RadioButton rdbProduseDePost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nume;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pret;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categorie;
        private System.Windows.Forms.DataGridViewTextBoxColumn Disponibilitate;
    }
}

