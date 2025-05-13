namespace InterfataUtilizator_WindowsForms
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvClienti = new System.Windows.Forms.DataGridView();
            this.grpCautare = new System.Windows.Forms.GroupBox();
            this.lblCautare = new System.Windows.Forms.Label();
            this.txtCautare = new System.Windows.Forms.TextBox();
            this.btnCautare = new System.Windows.Forms.Button();
            this.grpIntroducere = new System.Windows.Forms.GroupBox();
            this.ckbClientFidel = new System.Windows.Forms.CheckBox();
            this.ckbNewsletter = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnEditare = new System.Windows.Forms.Button();
            this.btnAdauga = new System.Windows.Forms.Button();
            this.grpTipClient = new System.Windows.Forms.GroupBox();
            this.rdbVIP = new System.Windows.Forms.RadioButton();
            this.rdbPremium = new System.Windows.Forms.RadioButton();
            this.rdbStandard = new System.Windows.Forms.RadioButton();
            this.lblError = new System.Windows.Forms.Label();
            this.txtNrTel = new System.Windows.Forms.TextBox();
            this.lblNrTelInput = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmailInput = new System.Windows.Forms.Label();
            this.txtNume = new System.Windows.Forms.TextBox();
            this.lblNumeInput = new System.Windows.Forms.Label();
            this.Nume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NrTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Newsletter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fidel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClienti)).BeginInit();
            this.grpIntroducere.SuspendLayout();
            this.grpTipClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvClienti
            // 
            this.dgvClienti.AllowUserToAddRows = false;
            this.dgvClienti.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClienti.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dgvClienti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClienti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nume,
            this.Email,
            this.NrTel,
            this.Tip,
            this.Newsletter,
            this.Fidel});
            this.dgvClienti.Location = new System.Drawing.Point(20, 80);
            this.dgvClienti.Name = "dgvClienti";
            this.dgvClienti.ReadOnly = true;
            this.dgvClienti.RowHeadersWidth = 51;
            this.dgvClienti.RowTemplate.Height = 24;
            this.dgvClienti.Size = new System.Drawing.Size(794, 200);
            this.dgvClienti.TabIndex = 0;
            // 
            // grpCautare
            // 
            this.grpCautare.BackColor = System.Drawing.Color.Thistle;
            this.grpCautare.ForeColor = System.Drawing.Color.Indigo;
            this.grpCautare.Location = new System.Drawing.Point(20, 20);
            this.grpCautare.Name = "grpCautare";
            this.grpCautare.Size = new System.Drawing.Size(740, 20);
            this.grpCautare.TabIndex = 1;
            this.grpCautare.TabStop = false;
            this.grpCautare.Text = "Căutare Clienți";
            // 
            // lblCautare
            // 
            this.lblCautare.AutoSize = true;
            this.lblCautare.Location = new System.Drawing.Point(30, 43);
            this.lblCautare.Name = "lblCautare";
            this.lblCautare.Size = new System.Drawing.Size(65, 25);
            this.lblCautare.TabIndex = 2;
            this.lblCautare.Text = "Caută:";
            // 
            // txtCautare
            // 
            this.txtCautare.Location = new System.Drawing.Point(120, 45);
            this.txtCautare.Name = "txtCautare";
            this.txtCautare.Size = new System.Drawing.Size(200, 32);
            this.txtCautare.TabIndex = 3;
            // 
            // btnCautare
            // 
            this.btnCautare.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnCautare.ForeColor = System.Drawing.Color.Indigo;
            this.btnCautare.Location = new System.Drawing.Point(338, 43);
            this.btnCautare.Name = "btnCautare";
            this.btnCautare.Size = new System.Drawing.Size(100, 35);
            this.btnCautare.TabIndex = 4;
            this.btnCautare.Text = "Caută";
            this.btnCautare.UseVisualStyleBackColor = false;
            this.btnCautare.Click += new System.EventHandler(this.BtnCautare_Click);
            // 
            // grpIntroducere
            // 
            this.grpIntroducere.Controls.Add(this.ckbClientFidel);
            this.grpIntroducere.Controls.Add(this.ckbNewsletter);
            this.grpIntroducere.Controls.Add(this.btnRefresh);
            this.grpIntroducere.Controls.Add(this.btnClear);
            this.grpIntroducere.Controls.Add(this.btnEditare);
            this.grpIntroducere.Controls.Add(this.btnAdauga);
            this.grpIntroducere.Controls.Add(this.grpTipClient);
            this.grpIntroducere.Controls.Add(this.lblError);
            this.grpIntroducere.Controls.Add(this.txtNrTel);
            this.grpIntroducere.Controls.Add(this.lblNrTelInput);
            this.grpIntroducere.Controls.Add(this.txtEmail);
            this.grpIntroducere.Controls.Add(this.lblEmailInput);
            this.grpIntroducere.Controls.Add(this.txtNume);
            this.grpIntroducere.Controls.Add(this.lblNumeInput);
            this.grpIntroducere.ForeColor = System.Drawing.Color.Indigo;
            this.grpIntroducere.Location = new System.Drawing.Point(20, 290);
            this.grpIntroducere.Name = "grpIntroducere";
            this.grpIntroducere.Size = new System.Drawing.Size(740, 300);
            this.grpIntroducere.TabIndex = 5;
            this.grpIntroducere.TabStop = false;
            this.grpIntroducere.Text = "Introducere Client Nou";
            // 
            // ckbClientFidel
            // 
            this.ckbClientFidel.AutoSize = true;
            this.ckbClientFidel.Location = new System.Drawing.Point(410, 155);
            this.ckbClientFidel.Name = "ckbClientFidel";
            this.ckbClientFidel.Size = new System.Drawing.Size(125, 29);
            this.ckbClientFidel.TabIndex = 14;
            this.ckbClientFidel.Text = "Client fidel";
            this.ckbClientFidel.UseVisualStyleBackColor = true;
            // 
            // ckbNewsletter
            // 
            this.ckbNewsletter.AutoSize = true;
            this.ckbNewsletter.Location = new System.Drawing.Point(410, 120);
            this.ckbNewsletter.Name = "ckbNewsletter";
            this.ckbNewsletter.Size = new System.Drawing.Size(207, 29);
            this.ckbNewsletter.TabIndex = 13;
            this.ckbNewsletter.Text = "Abonat la newsletter";
            this.ckbNewsletter.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnRefresh.Location = new System.Drawing.Point(482, 240);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(165, 35);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "Reîmprospătează";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnClear.Location = new System.Drawing.Point(360, 240);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 35);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Șterge Câmpuri";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnEditare
            // 
            this.btnEditare.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnEditare.Location = new System.Drawing.Point(240, 240);
            this.btnEditare.Name = "btnEditare";
            this.btnEditare.Size = new System.Drawing.Size(100, 35);
            this.btnEditare.TabIndex = 10;
            this.btnEditare.Text = "Editare";
            this.btnEditare.UseVisualStyleBackColor = false;
            this.btnEditare.Click += new System.EventHandler(this.BtnEditare_Click);
            // 
            // btnAdauga
            // 
            this.btnAdauga.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnAdauga.Location = new System.Drawing.Point(120, 240);
            this.btnAdauga.Name = "btnAdauga";
            this.btnAdauga.Size = new System.Drawing.Size(100, 35);
            this.btnAdauga.TabIndex = 9;
            this.btnAdauga.Text = "Adaugă";
            this.btnAdauga.UseVisualStyleBackColor = false;
            this.btnAdauga.Click += new System.EventHandler(this.BtnAdauga_Click);
            // 
            // grpTipClient
            // 
            this.grpTipClient.Controls.Add(this.rdbVIP);
            this.grpTipClient.Controls.Add(this.rdbPremium);
            this.grpTipClient.Controls.Add(this.rdbStandard);
            this.grpTipClient.Location = new System.Drawing.Point(400, 35);
            this.grpTipClient.Name = "grpTipClient";
            this.grpTipClient.Size = new System.Drawing.Size(315, 70);
            this.grpTipClient.TabIndex = 7;
            this.grpTipClient.TabStop = false;
            this.grpTipClient.Text = "Tip Client";
            // 
            // rdbVIP
            // 
            this.rdbVIP.AutoSize = true;
            this.rdbVIP.Location = new System.Drawing.Point(230, 30);
            this.rdbVIP.Name = "rdbVIP";
            this.rdbVIP.Size = new System.Drawing.Size(61, 29);
            this.rdbVIP.TabIndex = 2;
            this.rdbVIP.TabStop = true;
            this.rdbVIP.Text = "VIP";
            this.rdbVIP.UseVisualStyleBackColor = true;
            // 
            // rdbPremium
            // 
            this.rdbPremium.AutoSize = true;
            this.rdbPremium.Location = new System.Drawing.Point(120, 30);
            this.rdbPremium.Name = "rdbPremium";
            this.rdbPremium.Size = new System.Drawing.Size(109, 29);
            this.rdbPremium.TabIndex = 1;
            this.rdbPremium.TabStop = true;
            this.rdbPremium.Text = "Premium";
            this.rdbPremium.UseVisualStyleBackColor = true;
            // 
            // rdbStandard
            // 
            this.rdbStandard.AutoSize = true;
            this.rdbStandard.Location = new System.Drawing.Point(10, 30);
            this.rdbStandard.Name = "rdbStandard";
            this.rdbStandard.Size = new System.Drawing.Size(108, 29);
            this.rdbStandard.TabIndex = 0;
            this.rdbStandard.TabStop = true;
            this.rdbStandard.Text = "Standard";
            this.rdbStandard.UseVisualStyleBackColor = true;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(63, 193);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 25);
            this.lblError.TabIndex = 6;
            this.lblError.Visible = false;
            // 
            // txtNrTel
            // 
            this.txtNrTel.Location = new System.Drawing.Point(140, 150);
            this.txtNrTel.Name = "txtNrTel";
            this.txtNrTel.Size = new System.Drawing.Size(200, 32);
            this.txtNrTel.TabIndex = 5;
            // 
            // lblNrTelInput
            // 
            this.lblNrTelInput.AutoSize = true;
            this.lblNrTelInput.Location = new System.Drawing.Point(20, 150);
            this.lblNrTelInput.Name = "lblNrTelInput";
            this.lblNrTelInput.Size = new System.Drawing.Size(62, 25);
            this.lblNrTelInput.TabIndex = 4;
            this.lblNrTelInput.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(140, 110);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 32);
            this.txtEmail.TabIndex = 3;
            // 
            // lblEmailInput
            // 
            this.lblEmailInput.AutoSize = true;
            this.lblEmailInput.Location = new System.Drawing.Point(20, 110);
            this.lblEmailInput.Name = "lblEmailInput";
            this.lblEmailInput.Size = new System.Drawing.Size(67, 25);
            this.lblEmailInput.TabIndex = 2;
            this.lblEmailInput.Text = "Nume:";
            // 
            // txtNume
            // 
            this.txtNume.Location = new System.Drawing.Point(140, 67);
            this.txtNume.Name = "txtNume";
            this.txtNume.Size = new System.Drawing.Size(200, 32);
            this.txtNume.TabIndex = 1;
            // 
            // lblNumeInput
            // 
            this.lblNumeInput.AutoSize = true;
            this.lblNumeInput.Location = new System.Drawing.Point(20, 70);
            this.lblNumeInput.Name = "lblNumeInput";
            this.lblNumeInput.Size = new System.Drawing.Size(105, 25);
            this.lblNumeInput.TabIndex = 0;
            this.lblNumeInput.Text = "Nr. telefon:";
            // 
            // Nume
            // 
            this.Nume.HeaderText = "Nr. telefon";
            this.Nume.MinimumWidth = 6;
            this.Nume.Name = "Nume";
            this.Nume.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.HeaderText = "Nume";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // NrTel
            // 
            this.NrTel.HeaderText = "Email";
            this.NrTel.MinimumWidth = 6;
            this.NrTel.Name = "NrTel";
            this.NrTel.ReadOnly = true;
            // 
            // Tip
            // 
            this.Tip.HeaderText = "Tip Client";
            this.Tip.MinimumWidth = 6;
            this.Tip.Name = "Tip";
            this.Tip.ReadOnly = true;
            // 
            // Newsletter
            // 
            this.Newsletter.HeaderText = "Newsletter";
            this.Newsletter.MinimumWidth = 6;
            this.Newsletter.Name = "Newsletter";
            this.Newsletter.ReadOnly = true;
            // 
            // Fidel
            // 
            this.Fidel.HeaderText = "Client Fidel";
            this.Fidel.MinimumWidth = 6;
            this.Fidel.Name = "Fidel";
            this.Fidel.ReadOnly = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(822, 645);
            this.Controls.Add(this.grpIntroducere);
            this.Controls.Add(this.btnCautare);
            this.Controls.Add(this.txtCautare);
            this.Controls.Add(this.lblCautare);
            this.Controls.Add(this.grpCautare);
            this.Controls.Add(this.dgvClienti);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form2";
            this.Text = "Gestionare Clienți";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClienti)).EndInit();
            this.grpIntroducere.ResumeLayout(false);
            this.grpIntroducere.PerformLayout();
            this.grpTipClient.ResumeLayout(false);
            this.grpTipClient.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClienti;
        private System.Windows.Forms.GroupBox grpCautare;
        private System.Windows.Forms.Label lblCautare;
        private System.Windows.Forms.TextBox txtCautare;
        private System.Windows.Forms.Button btnCautare;
        private System.Windows.Forms.GroupBox grpIntroducere;
        private System.Windows.Forms.Label lblNumeInput;
        private System.Windows.Forms.TextBox txtNume;
        private System.Windows.Forms.Label lblEmailInput;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblNrTelInput;
        private System.Windows.Forms.TextBox txtNrTel;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.GroupBox grpTipClient;
        private System.Windows.Forms.RadioButton rdbStandard;
        private System.Windows.Forms.RadioButton rdbVIP;
        private System.Windows.Forms.RadioButton rdbPremium;
        private System.Windows.Forms.Button btnAdauga;
        private System.Windows.Forms.Button btnEditare;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.CheckBox ckbClientFidel;
        private System.Windows.Forms.CheckBox ckbNewsletter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nume;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn NrTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Newsletter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fidel;
    }
}