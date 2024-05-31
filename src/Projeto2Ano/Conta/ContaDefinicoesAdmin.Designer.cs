namespace Projeto2Ano
{
    partial class ContaDefinicoesAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContaDefinicoesAdmin));
            lblTitle = new Label();
            pDefinicoes = new Panel();
            lblErroPass = new Label();
            tbxName = new TextBox();
            btnAlterarPassword = new Button();
            btnDelete = new Button();
            btnAlterarUsername = new Button();
            lbltbxName = new Label();
            btnAlterarName = new Button();
            lbltbxUsername = new Label();
            tbxRepPass = new TextBox();
            tbxUsername = new TextBox();
            chkShowPass = new CheckBox();
            lbltbxPass = new Label();
            lblErroUsername = new Label();
            tbxPass = new TextBox();
            lbltbxRepPass = new Label();
            lblContaSel = new Label();
            cbxContaSel = new ComboBox();
            btnReturn = new Button();
            pDefinicoes.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(270, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(226, 37);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Gestão de Contas";
            // 
            // pDefinicoes
            // 
            pDefinicoes.BorderStyle = BorderStyle.FixedSingle;
            pDefinicoes.Controls.Add(lblErroPass);
            pDefinicoes.Controls.Add(tbxName);
            pDefinicoes.Controls.Add(btnAlterarPassword);
            pDefinicoes.Controls.Add(btnDelete);
            pDefinicoes.Controls.Add(btnAlterarUsername);
            pDefinicoes.Controls.Add(lbltbxName);
            pDefinicoes.Controls.Add(btnAlterarName);
            pDefinicoes.Controls.Add(lbltbxUsername);
            pDefinicoes.Controls.Add(tbxRepPass);
            pDefinicoes.Controls.Add(tbxUsername);
            pDefinicoes.Controls.Add(chkShowPass);
            pDefinicoes.Controls.Add(lbltbxPass);
            pDefinicoes.Controls.Add(lblErroUsername);
            pDefinicoes.Controls.Add(tbxPass);
            pDefinicoes.Controls.Add(lbltbxRepPass);
            pDefinicoes.Dock = DockStyle.Bottom;
            pDefinicoes.Location = new Point(0, 136);
            pDefinicoes.Margin = new Padding(0);
            pDefinicoes.Name = "pDefinicoes";
            pDefinicoes.Size = new Size(778, 253);
            pDefinicoes.TabIndex = 2;
            pDefinicoes.Visible = false;
            // 
            // lblErroPass
            // 
            lblErroPass.AutoSize = true;
            lblErroPass.ForeColor = Color.Red;
            lblErroPass.Location = new Point(62, 209);
            lblErroPass.Name = "lblErroPass";
            lblErroPass.Size = new Size(31, 15);
            lblErroPass.TabIndex = 60;
            lblErroPass.Text = "Erro:";
            lblErroPass.UseMnemonic = false;
            lblErroPass.Visible = false;
            // 
            // tbxName
            // 
            tbxName.Location = new Point(62, 43);
            tbxName.Name = "tbxName";
            tbxName.Size = new Size(193, 23);
            tbxName.TabIndex = 48;
            // 
            // btnAlterarPassword
            // 
            btnAlterarPassword.Location = new Point(258, 114);
            btnAlterarPassword.Name = "btnAlterarPassword";
            btnAlterarPassword.Size = new Size(108, 67);
            btnAlterarPassword.TabIndex = 59;
            btnAlterarPassword.Text = "Alterar";
            btnAlterarPassword.UseVisualStyleBackColor = true;
            btnAlterarPassword.Click += btnAlterarPassword_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(396, 127);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(301, 41);
            btnDelete.TabIndex = 46;
            btnDelete.Text = "Apagar Conta";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAlterarUsername
            // 
            btnAlterarUsername.Location = new Point(592, 43);
            btnAlterarUsername.Name = "btnAlterarUsername";
            btnAlterarUsername.Size = new Size(105, 24);
            btnAlterarUsername.TabIndex = 58;
            btnAlterarUsername.Text = "Alterar";
            btnAlterarUsername.UseVisualStyleBackColor = true;
            btnAlterarUsername.Click += btnAlterarUsername_Click;
            // 
            // lbltbxName
            // 
            lbltbxName.AutoSize = true;
            lbltbxName.Location = new Point(62, 25);
            lbltbxName.Name = "lbltbxName";
            lbltbxName.Size = new Size(115, 15);
            lbltbxName.TabIndex = 47;
            lbltbxName.Text = "Nome Atual: {name}";
            // 
            // btnAlterarName
            // 
            btnAlterarName.Location = new Point(258, 43);
            btnAlterarName.Name = "btnAlterarName";
            btnAlterarName.Size = new Size(105, 24);
            btnAlterarName.TabIndex = 57;
            btnAlterarName.Text = "Alterar";
            btnAlterarName.UseVisualStyleBackColor = true;
            btnAlterarName.Click += btnAlterarName_Click;
            // 
            // lbltbxUsername
            // 
            lbltbxUsername.AutoSize = true;
            lbltbxUsername.Location = new Point(396, 25);
            lbltbxUsername.Name = "lbltbxUsername";
            lbltbxUsername.Size = new Size(206, 15);
            lbltbxUsername.TabIndex = 49;
            lbltbxUsername.Text = "Nome de Utilizador Atual: {username}";
            // 
            // tbxRepPass
            // 
            tbxRepPass.Location = new Point(62, 158);
            tbxRepPass.Name = "tbxRepPass";
            tbxRepPass.Size = new Size(193, 23);
            tbxRepPass.TabIndex = 56;
            tbxRepPass.UseSystemPasswordChar = true;
            // 
            // tbxUsername
            // 
            tbxUsername.Location = new Point(396, 43);
            tbxUsername.Name = "tbxUsername";
            tbxUsername.Size = new Size(193, 23);
            tbxUsername.TabIndex = 50;
            // 
            // chkShowPass
            // 
            chkShowPass.AutoSize = true;
            chkShowPass.Location = new Point(62, 187);
            chkShowPass.Name = "chkShowPass";
            chkShowPass.Size = new Size(147, 19);
            chkShowPass.TabIndex = 55;
            chkShowPass.Text = "Mostrar Palavras-Passe";
            chkShowPass.UseVisualStyleBackColor = true;
            chkShowPass.CheckedChanged += chkShowPass_CheckedChanged;
            // 
            // lbltbxPass
            // 
            lbltbxPass.AutoSize = true;
            lbltbxPass.Location = new Point(62, 96);
            lbltbxPass.Name = "lbltbxPass";
            lbltbxPass.Size = new Size(79, 15);
            lbltbxPass.TabIndex = 51;
            lbltbxPass.Text = "Palavra-Passe";
            // 
            // lblErroUsername
            // 
            lblErroUsername.AutoSize = true;
            lblErroUsername.ForeColor = Color.Red;
            lblErroUsername.Location = new Point(396, 69);
            lblErroUsername.Name = "lblErroUsername";
            lblErroUsername.Size = new Size(31, 15);
            lblErroUsername.TabIndex = 54;
            lblErroUsername.Text = "Erro:";
            lblErroUsername.UseMnemonic = false;
            lblErroUsername.Visible = false;
            // 
            // tbxPass
            // 
            tbxPass.Location = new Point(62, 114);
            tbxPass.Name = "tbxPass";
            tbxPass.Size = new Size(193, 23);
            tbxPass.TabIndex = 52;
            tbxPass.UseSystemPasswordChar = true;
            // 
            // lbltbxRepPass
            // 
            lbltbxRepPass.AutoSize = true;
            lbltbxRepPass.Location = new Point(62, 140);
            lbltbxRepPass.Name = "lbltbxRepPass";
            lbltbxRepPass.Size = new Size(119, 15);
            lbltbxRepPass.TabIndex = 53;
            lbltbxRepPass.Text = "Repetir Palavra-Passe";
            // 
            // lblContaSel
            // 
            lblContaSel.AutoSize = true;
            lblContaSel.Location = new Point(63, 73);
            lblContaSel.Name = "lblContaSel";
            lblContaSel.Size = new Size(102, 15);
            lblContaSel.TabIndex = 3;
            lblContaSel.Text = "Conta Selcionada:";
            // 
            // cbxContaSel
            // 
            cbxContaSel.FormattingEnabled = true;
            cbxContaSel.Location = new Point(170, 70);
            cbxContaSel.Name = "cbxContaSel";
            cbxContaSel.Size = new Size(197, 23);
            cbxContaSel.TabIndex = 4;
            cbxContaSel.SelectedIndexChanged += cbxContaSel_SelectedIndexChanged;
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(397, 60);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(301, 40);
            btnReturn.TabIndex = 5;
            btnReturn.Text = "Voltar";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // ContaDefinicoesAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(778, 389);
            Controls.Add(btnReturn);
            Controls.Add(cbxContaSel);
            Controls.Add(lblContaSel);
            Controls.Add(pDefinicoes);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            Name = "ContaDefinicoesAdmin";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Conta Admin";
            pDefinicoes.ResumeLayout(false);
            pDefinicoes.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Panel pDefinicoes;
        private Label lblContaSel;
        private ComboBox cbxContaSel;
        private Label lblErroPass;
        private TextBox tbxName;
        private Button btnAlterarPassword;
        private Button btnDelete;
        private Button btnAlterarUsername;
        private Label lbltbxName;
        private Button btnAlterarName;
        private Label lbltbxUsername;
        private TextBox tbxRepPass;
        private TextBox tbxUsername;
        private CheckBox chkShowPass;
        private Label lbltbxPass;
        private Label lblErroUsername;
        private TextBox tbxPass;
        private Label lbltbxRepPass;
        private Button btnReturn;
    }
}