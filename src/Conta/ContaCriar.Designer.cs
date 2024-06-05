namespace Projeto2Ano
{
    partial class ContaCriar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContaCriar));
            lblTitle = new Label();
            btnCriar = new Button();
            lbltbxName = new Label();
            tbxName = new TextBox();
            tbxUsername = new TextBox();
            lbltbxUsername = new Label();
            tbxPass = new TextBox();
            lbltbxPass = new Label();
            tbxRepPass = new TextBox();
            lbltbxRepPass = new Label();
            lblErro = new Label();
            chkShowPass = new CheckBox();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(79, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(221, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Criação de Conta";
            // 
            // btnCriar
            // 
            btnCriar.Enabled = false;
            btnCriar.FlatStyle = FlatStyle.Flat;
            btnCriar.Location = new Point(92, 306);
            btnCriar.Margin = new Padding(50000);
            btnCriar.Name = "btnCriar";
            btnCriar.Size = new Size(196, 41);
            btnCriar.TabIndex = 5;
            btnCriar.Text = "Criar Conta";
            btnCriar.UseVisualStyleBackColor = true;
            btnCriar.Click += btnCriar_Click;
            // 
            // lbltbxName
            // 
            lbltbxName.AutoSize = true;
            lbltbxName.Location = new Point(79, 67);
            lbltbxName.Name = "lbltbxName";
            lbltbxName.Size = new Size(45, 15);
            lbltbxName.TabIndex = 6;
            lbltbxName.Text = "Nome*";
            lbltbxName.Click += lbltbxName_Click;
            // 
            // tbxName
            // 
            tbxName.Location = new Point(79, 85);
            tbxName.Name = "tbxName";
            tbxName.Size = new Size(221, 23);
            tbxName.TabIndex = 7;
            tbxName.TextChanged += tbxName_TextChanged;
            // 
            // tbxUsername
            // 
            tbxUsername.Location = new Point(79, 133);
            tbxUsername.Name = "tbxUsername";
            tbxUsername.Size = new Size(221, 23);
            tbxUsername.TabIndex = 9;
            tbxUsername.TextChanged += tbxUsername_TextChanged;
            // 
            // lbltbxUsername
            // 
            lbltbxUsername.AutoSize = true;
            lbltbxUsername.Location = new Point(79, 115);
            lbltbxUsername.Name = "lbltbxUsername";
            lbltbxUsername.Size = new Size(114, 15);
            lbltbxUsername.TabIndex = 8;
            lbltbxUsername.Text = "Nome de Utilizador*";
            lbltbxUsername.Click += lbltbxUsername_Click;
            // 
            // tbxPass
            // 
            tbxPass.Location = new Point(79, 189);
            tbxPass.Name = "tbxPass";
            tbxPass.Size = new Size(221, 23);
            tbxPass.TabIndex = 11;
            tbxPass.UseSystemPasswordChar = true;
            tbxPass.TextChanged += tbxPass_TextChanged;
            // 
            // lbltbxPass
            // 
            lbltbxPass.AutoSize = true;
            lbltbxPass.Location = new Point(79, 171);
            lbltbxPass.Name = "lbltbxPass";
            lbltbxPass.Size = new Size(84, 15);
            lbltbxPass.TabIndex = 10;
            lbltbxPass.Text = "Palavra-Passe*";
            lbltbxPass.Click += lbltbxPass_Click;
            // 
            // tbxRepPass
            // 
            tbxRepPass.Location = new Point(79, 244);
            tbxRepPass.Name = "tbxRepPass";
            tbxRepPass.Size = new Size(221, 23);
            tbxRepPass.TabIndex = 13;
            tbxRepPass.UseSystemPasswordChar = true;
            tbxRepPass.TextChanged += tbxRepPass_TextChanged;
            // 
            // lbltbxRepPass
            // 
            lbltbxRepPass.AutoSize = true;
            lbltbxRepPass.Location = new Point(79, 226);
            lbltbxRepPass.Name = "lbltbxRepPass";
            lbltbxRepPass.Size = new Size(124, 15);
            lbltbxRepPass.TabIndex = 12;
            lbltbxRepPass.Text = "Repetir Palavra-Passe*";
            lbltbxRepPass.Click += lbltbxRepPass_Click;
            // 
            // lblErro
            // 
            lblErro.AutoSize = true;
            lblErro.ForeColor = Color.Red;
            lblErro.Location = new Point(25, 353);
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
            chkShowPass.Location = new Point(79, 273);
            chkShowPass.Name = "chkShowPass";
            chkShowPass.Size = new Size(147, 19);
            chkShowPass.TabIndex = 15;
            chkShowPass.Text = "Mostrar Palavras-Passe";
            chkShowPass.UseVisualStyleBackColor = true;
            chkShowPass.CheckedChanged += chkShowPass_CheckedChanged;
            // 
            // ContaCriar
            // 
            AcceptButton = btnCriar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(384, 386);
            Controls.Add(chkShowPass);
            Controls.Add(lblErro);
            Controls.Add(tbxRepPass);
            Controls.Add(lbltbxRepPass);
            Controls.Add(tbxPass);
            Controls.Add(lbltbxPass);
            Controls.Add(tbxUsername);
            Controls.Add(lbltbxUsername);
            Controls.Add(tbxName);
            Controls.Add(lbltbxName);
            Controls.Add(btnCriar);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ContaCriar";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Conta";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnCriar;
        private Label lbltbxName;
        private TextBox tbxName;
        private TextBox tbxUsername;
        private Label lbltbxUsername;
        private TextBox tbxPass;
        private Label lbltbxPass;
        private TextBox tbxRepPass;
        private Label lbltbxRepPass;
        private Label lblErro;
        private CheckBox chkShowPass;
    }
}