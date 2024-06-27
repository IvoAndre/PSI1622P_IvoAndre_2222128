namespace Projeto2Ano
{
    partial class BancoPIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BancoPIN));
            btnDelete = new Button();
            chkShowPIN = new CheckBox();
            lblErro = new Label();
            tbxRepPIN = new TextBox();
            lbltbxRepPIN = new Label();
            tbxPIN = new TextBox();
            lbltbxPIN = new Label();
            btnOption = new Button();
            lblTitle = new Label();
            SuspendLayout();
            // 
            // btnDelete
            // 
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(35, 223);
            btnDelete.Margin = new Padding(50000);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(196, 41);
            btnDelete.TabIndex = 34;
            btnDelete.TabStop = false;
            btnDelete.Text = "Apagar Conta";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Visible = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // chkShowPIN
            // 
            chkShowPIN.AutoSize = true;
            chkShowPIN.Location = new Point(35, 113);
            chkShowPIN.Name = "chkShowPIN";
            chkShowPIN.Size = new Size(94, 19);
            chkShowPIN.TabIndex = 33;
            chkShowPIN.Text = "Mostrar PINs";
            chkShowPIN.UseVisualStyleBackColor = true;
            chkShowPIN.CheckedChanged += chkShowPIN_CheckedChanged;
            // 
            // lblErro
            // 
            lblErro.AutoSize = true;
            lblErro.ForeColor = Color.Red;
            lblErro.Location = new Point(35, 135);
            lblErro.Name = "lblErro";
            lblErro.Size = new Size(31, 15);
            lblErro.TabIndex = 32;
            lblErro.Text = "Erro:";
            lblErro.UseMnemonic = false;
            lblErro.Visible = false;
            // 
            // tbxRepPIN
            // 
            tbxRepPIN.Location = new Point(137, 84);
            tbxRepPIN.MaxLength = 4;
            tbxRepPIN.Name = "tbxRepPIN";
            tbxRepPIN.PlaceholderText = "_ _ _ _";
            tbxRepPIN.Size = new Size(94, 23);
            tbxRepPIN.TabIndex = 31;
            tbxRepPIN.TextAlign = HorizontalAlignment.Center;
            tbxRepPIN.UseSystemPasswordChar = true;
            tbxRepPIN.TextChanged += tbxRepPIN_TextChanged;
            tbxRepPIN.KeyPress += tbxPIN_KeyPress;
            tbxRepPIN.ShortcutsEnabled = false;
            // 
            // lbltbxRepPIN
            // 
            lbltbxRepPIN.AutoSize = true;
            lbltbxRepPIN.Location = new Point(137, 66);
            lbltbxRepPIN.Name = "lbltbxRepPIN";
            lbltbxRepPIN.Size = new Size(71, 15);
            lbltbxRepPIN.TabIndex = 30;
            lbltbxRepPIN.Text = "Repetir PIN*";
            lbltbxRepPIN.Click += lbltbxPIN_Click;
            // 
            // tbxPIN
            // 
            tbxPIN.Location = new Point(35, 84);
            tbxPIN.MaxLength = 4;
            tbxPIN.Name = "tbxPIN";
            tbxPIN.PlaceholderText = "_ _ _ _";
            tbxPIN.Size = new Size(94, 23);
            tbxPIN.TabIndex = 29;
            tbxPIN.TextAlign = HorizontalAlignment.Center;
            tbxPIN.UseSystemPasswordChar = true;
            tbxPIN.TextChanged += tbxPIN_TextChanged;
            tbxPIN.KeyPress += tbxPIN_KeyPress;
            tbxPIN.ShortcutsEnabled = false;
            // 
            // lbltbxPIN
            // 
            lbltbxPIN.Location = new Point(35, 51);
            lbltbxPIN.Name = "lbltbxPIN";
            lbltbxPIN.Size = new Size(88, 30);
            lbltbxPIN.TabIndex = 28;
            lbltbxPIN.Text = "PIN* (4 Dígitos)";
            lbltbxPIN.TextAlign = ContentAlignment.BottomLeft;
            lbltbxPIN.Click += lbltbxPIN_Click;
            // 
            // btnOption
            // 
            btnOption.Enabled = false;
            btnOption.FlatStyle = FlatStyle.Flat;
            btnOption.Location = new Point(35, 173);
            btnOption.Margin = new Padding(50000);
            btnOption.Name = "btnOption";
            btnOption.Size = new Size(196, 41);
            btnOption.TabIndex = 27;
            btnOption.Text = "Option";
            btnOption.UseVisualStyleBackColor = true;
            btnOption.Click += btnOption_Click;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(22, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(221, 37);
            lblTitle.TabIndex = 26;
            lblTitle.Text = "Title";
            lblTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // BancoPIN
            // 
            AcceptButton = btnOption;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(264, 277);
            Controls.Add(btnDelete);
            Controls.Add(chkShowPIN);
            Controls.Add(lblErro);
            Controls.Add(tbxRepPIN);
            Controls.Add(lbltbxRepPIN);
            Controls.Add(tbxPIN);
            Controls.Add(lbltbxPIN);
            Controls.Add(btnOption);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BancoPIN";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Banco";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDelete;
        private CheckBox chkShowPIN;
        private Label lblErro;
        private TextBox tbxRepPIN;
        private Label lbltbxRepPIN;
        private TextBox tbxPIN;
        private Label lbltbxPIN;
        private Button btnOption;
        private Label lblTitle;
    }
}