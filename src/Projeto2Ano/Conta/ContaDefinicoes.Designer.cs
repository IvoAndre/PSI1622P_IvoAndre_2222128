namespace Projeto2Ano
{
    partial class ContaDefinicoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContaDefinicoes));
            lblTitle = new Label();
            btnReturn = new Button();
            btnDelete = new Button();
            chkShowPass = new CheckBox();
            lblErroUsername = new Label();
            lbltbxRepPass = new Label();
            tbxPass = new TextBox();
            lbltbxPass = new Label();
            tbxUsername = new TextBox();
            lbltbxUsername = new Label();
            tbxName = new TextBox();
            lbltbxName = new Label();
            tbxRepPass = new TextBox();
            btnAlterarName = new Button();
            btnAlterarUsername = new Button();
            btnAlterarPassword = new Button();
            lblErroPass = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(61, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(255, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Definições da Conta";
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(241, 322);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(140, 40);
            btnReturn.TabIndex = 3;
            btnReturn.Text = "Voltar";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(12, 322);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(140, 40);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Apagar Conta";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // chkShowPass
            // 
            chkShowPass.AutoSize = true;
            chkShowPass.Location = new Point(45, 255);
            chkShowPass.Name = "chkShowPass";
            chkShowPass.Size = new Size(147, 19);
            chkShowPass.TabIndex = 25;
            chkShowPass.Text = "Mostrar Palavras-Passe";
            chkShowPass.UseVisualStyleBackColor = true;
            chkShowPass.CheckedChanged += chkShowPass_CheckedChanged;
            // 
            // lblErroUsername
            // 
            lblErroUsername.AutoSize = true;
            lblErroUsername.ForeColor = Color.Red;
            lblErroUsername.Location = new Point(45, 148);
            lblErroUsername.Name = "lblErroUsername";
            lblErroUsername.Size = new Size(31, 15);
            lblErroUsername.TabIndex = 24;
            lblErroUsername.Text = "Erro:";
            lblErroUsername.UseMnemonic = false;
            lblErroUsername.Visible = false;
            // 
            // lbltbxRepPass
            // 
            lbltbxRepPass.AutoSize = true;
            lbltbxRepPass.Location = new Point(45, 208);
            lbltbxRepPass.Name = "lbltbxRepPass";
            lbltbxRepPass.Size = new Size(119, 15);
            lbltbxRepPass.TabIndex = 22;
            lbltbxRepPass.Text = "Repetir Palavra-Passe";
            // 
            // tbxPass
            // 
            tbxPass.Location = new Point(45, 182);
            tbxPass.Name = "tbxPass";
            tbxPass.Size = new Size(193, 23);
            tbxPass.TabIndex = 21;
            tbxPass.UseSystemPasswordChar = true;
            // 
            // lbltbxPass
            // 
            lbltbxPass.AutoSize = true;
            lbltbxPass.Location = new Point(45, 164);
            lbltbxPass.Name = "lbltbxPass";
            lbltbxPass.Size = new Size(79, 15);
            lbltbxPass.TabIndex = 20;
            lbltbxPass.Text = "Palavra-Passe";
            // 
            // tbxUsername
            // 
            tbxUsername.Location = new Point(45, 122);
            tbxUsername.Name = "tbxUsername";
            tbxUsername.Size = new Size(193, 23);
            tbxUsername.TabIndex = 19;
            // 
            // lbltbxUsername
            // 
            lbltbxUsername.AutoSize = true;
            lbltbxUsername.Location = new Point(45, 104);
            lbltbxUsername.Name = "lbltbxUsername";
            lbltbxUsername.Size = new Size(281, 15);
            lbltbxUsername.TabIndex = 18;
            lbltbxUsername.Text = "Nome de Utilizador Atual: {Program.user.Username}";
            // 
            // tbxName
            // 
            tbxName.Location = new Point(45, 78);
            tbxName.Name = "tbxName";
            tbxName.Size = new Size(193, 23);
            tbxName.TabIndex = 17;
            // 
            // lbltbxName
            // 
            lbltbxName.AutoSize = true;
            lbltbxName.Location = new Point(45, 60);
            lbltbxName.Name = "lbltbxName";
            lbltbxName.Size = new Size(191, 15);
            lbltbxName.TabIndex = 16;
            lbltbxName.Text = "Nome Atual: {Program.user.Name}";
            // 
            // tbxRepPass
            // 
            tbxRepPass.Location = new Point(45, 226);
            tbxRepPass.Name = "tbxRepPass";
            tbxRepPass.Size = new Size(193, 23);
            tbxRepPass.TabIndex = 26;
            tbxRepPass.UseSystemPasswordChar = true;
            // 
            // btnAlterarName
            // 
            btnAlterarName.Location = new Point(241, 78);
            btnAlterarName.Name = "btnAlterarName";
            btnAlterarName.Size = new Size(105, 24);
            btnAlterarName.TabIndex = 27;
            btnAlterarName.Text = "Alterar";
            btnAlterarName.UseVisualStyleBackColor = true;
            btnAlterarName.Click += btnAlterarName_Click;
            // 
            // btnAlterarUsername
            // 
            btnAlterarUsername.Location = new Point(241, 122);
            btnAlterarUsername.Name = "btnAlterarUsername";
            btnAlterarUsername.Size = new Size(105, 24);
            btnAlterarUsername.TabIndex = 28;
            btnAlterarUsername.Text = "Alterar";
            btnAlterarUsername.UseVisualStyleBackColor = true;
            btnAlterarUsername.Click += btnAlterarUsername_Click;
            // 
            // btnAlterarPassword
            // 
            btnAlterarPassword.Location = new Point(241, 182);
            btnAlterarPassword.Name = "btnAlterarPassword";
            btnAlterarPassword.Size = new Size(108, 67);
            btnAlterarPassword.TabIndex = 29;
            btnAlterarPassword.Text = "Alterar";
            btnAlterarPassword.UseVisualStyleBackColor = true;
            btnAlterarPassword.Click += btnAlterarPassword_Click;
            // 
            // lblErroPass
            // 
            lblErroPass.AutoSize = true;
            lblErroPass.ForeColor = Color.Red;
            lblErroPass.Location = new Point(45, 277);
            lblErroPass.Name = "lblErroPass";
            lblErroPass.Size = new Size(31, 15);
            lblErroPass.TabIndex = 30;
            lblErroPass.Text = "Erro:";
            lblErroPass.UseMnemonic = false;
            lblErroPass.Visible = false;
            // 
            // ContaDefinicoes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(393, 373);
            ControlBox = false;
            Controls.Add(lblErroPass);
            Controls.Add(btnAlterarPassword);
            Controls.Add(btnAlterarUsername);
            Controls.Add(btnAlterarName);
            Controls.Add(tbxRepPass);
            Controls.Add(chkShowPass);
            Controls.Add(lblErroUsername);
            Controls.Add(lbltbxRepPass);
            Controls.Add(tbxPass);
            Controls.Add(lbltbxPass);
            Controls.Add(tbxUsername);
            Controls.Add(lbltbxUsername);
            Controls.Add(tbxName);
            Controls.Add(lbltbxName);
            Controls.Add(btnDelete);
            Controls.Add(btnReturn);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ContaDefinicoes";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Conta";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnReturn;
        private Button btnDelete;
        private CheckBox chkShowPass;
        private Label lblErroUsername;
        private Label lbltbxRepPass;
        private TextBox tbxPass;
        private Label lbltbxPass;
        private TextBox tbxUsername;
        private Label lbltbxUsername;
        private TextBox tbxName;
        private Label lbltbxName;
        private TextBox tbxRepPass;
        private Button btnAlterarName;
        private Button btnAlterarUsername;
        private Button btnAlterarPassword;
        private Label lblErroPass;
    }
}