namespace Projeto2Ano
{
    partial class ContaEntrar
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContaEntrar));
            lblTitle = new Label();
            btnEntrar = new Button();
            tbxUsername = new TextBox();
            lbltbxUsername = new Label();
            tbxPass = new TextBox();
            lbltbxPass = new Label();
            lblErro = new Label();
            chkShowPass = new CheckBox();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(102, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(175, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Iniciar Sessão";
            // 
            // btnEntrar
            // 
            btnEntrar.Enabled = false;
            btnEntrar.FlatStyle = FlatStyle.Flat;
            btnEntrar.Location = new Point(92, 191);
            btnEntrar.Margin = new Padding(50000);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(196, 41);
            btnEntrar.TabIndex = 5;
            btnEntrar.Text = "Iniciar Sessão";
            btnEntrar.UseVisualStyleBackColor = true;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // tbxUsername
            // 
            tbxUsername.Location = new Point(79, 79);
            tbxUsername.Name = "tbxUsername";
            tbxUsername.Size = new Size(221, 23);
            tbxUsername.TabIndex = 9;
            tbxUsername.TextChanged += tbxUsername_TextChanged;
            // 
            // lbltbxUsername
            // 
            lbltbxUsername.AutoSize = true;
            lbltbxUsername.Location = new Point(79, 61);
            lbltbxUsername.Name = "lbltbxUsername";
            lbltbxUsername.Size = new Size(114, 15);
            lbltbxUsername.TabIndex = 8;
            lbltbxUsername.Text = "Nome de Utilizador*";
            lbltbxUsername.Click += lbltbxUsername_Click;
            // 
            // tbxPass
            // 
            tbxPass.Location = new Point(79, 135);
            tbxPass.Name = "tbxPass";
            tbxPass.Size = new Size(221, 23);
            tbxPass.TabIndex = 11;
            tbxPass.UseSystemPasswordChar = true;
            tbxPass.TextChanged += tbxPass_TextChanged;
            // 
            // lbltbxPass
            // 
            lbltbxPass.AutoSize = true;
            lbltbxPass.Location = new Point(79, 117);
            lbltbxPass.Name = "lbltbxPass";
            lbltbxPass.Size = new Size(84, 15);
            lbltbxPass.TabIndex = 10;
            lbltbxPass.Text = "Palavra-Passe*";
            lbltbxPass.Click += lbltbxPass_Click;
            // 
            // lblErro
            // 
            lblErro.AutoSize = true;
            lblErro.ForeColor = Color.Red;
            lblErro.Location = new Point(26, 237);
            lblErro.Name = "lblErro";
            lblErro.Size = new Size(31, 15);
            lblErro.TabIndex = 14;
            lblErro.Text = "Erro:";
            lblErro.UseMnemonic = false;
            lblErro.Visible = false;
            // 
            // chkShowPass
            // 
            chkShowPass.AutoSize = true;
            chkShowPass.Location = new Point(79, 164);
            chkShowPass.Name = "chkShowPass";
            chkShowPass.Size = new Size(147, 19);
            chkShowPass.TabIndex = 15;
            chkShowPass.Text = "Mostrar Palavras-Passe";
            chkShowPass.UseVisualStyleBackColor = true;
            chkShowPass.CheckedChanged += chkShowPass_CheckedChanged;
            // 
            // ContaEntrar
            // 
            AcceptButton = btnEntrar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(384, 279);
            Controls.Add(chkShowPass);
            Controls.Add(lblErro);
            Controls.Add(tbxPass);
            Controls.Add(lbltbxPass);
            Controls.Add(tbxUsername);
            Controls.Add(lbltbxUsername);
            Controls.Add(btnEntrar);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ContaEntrar";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Conta";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnEntrar;
        private TextBox tbxUsername;
        private Label lbltbxUsername;
        private TextBox tbxPass;
        private Label lbltbxPass;
        private Label lblErro;
        private CheckBox chkShowPass;
    }
}