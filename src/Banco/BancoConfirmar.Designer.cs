namespace Projeto2Ano
{
    partial class BancoConfirmar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BancoConfirmar));
            btnReturn = new Button();
            btnOption = new Button();
            lblTitle = new Label();
            chkShowPIN = new CheckBox();
            lblErro = new Label();
            tbxPIN = new TextBox();
            lbltbxPIN = new Label();
            SuspendLayout();
            // 
            // btnReturn
            // 
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.Location = new Point(22, 173);
            btnReturn.Margin = new Padding(50000);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(104, 41);
            btnReturn.TabIndex = 4;
            btnReturn.Text = "Return";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // btnOption
            // 
            btnOption.Enabled = false;
            btnOption.FlatStyle = FlatStyle.Flat;
            btnOption.Location = new Point(140, 173);
            btnOption.Margin = new Padding(50000);
            btnOption.Name = "btnOption";
            btnOption.Size = new Size(103, 41);
            btnOption.TabIndex = 3;
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
            // chkShowPIN
            // 
            chkShowPIN.AutoSize = true;
            chkShowPIN.Location = new Point(86, 113);
            chkShowPIN.Name = "chkShowPIN";
            chkShowPIN.Size = new Size(89, 19);
            chkShowPIN.TabIndex = 2;
            chkShowPIN.Text = "Mostrar PIN";
            chkShowPIN.UseVisualStyleBackColor = true;
            chkShowPIN.CheckedChanged += chkShowPIN_CheckedChanged;
            // 
            // lblErro
            // 
            lblErro.AutoSize = true;
            lblErro.ForeColor = Color.Red;
            lblErro.Location = new Point(22, 134);
            lblErro.Name = "lblErro";
            lblErro.Size = new Size(31, 15);
            lblErro.TabIndex = 37;
            lblErro.Text = "Erro:";
            lblErro.UseMnemonic = false;
            lblErro.Visible = false;
            // 
            // tbxPIN
            // 
            tbxPIN.Location = new Point(86, 84);
            tbxPIN.MaxLength = 4;
            tbxPIN.Name = "tbxPIN";
            tbxPIN.PlaceholderText = "_ _ _ _";
            tbxPIN.Size = new Size(94, 23);
            tbxPIN.TabIndex = 1;
            tbxPIN.TextAlign = HorizontalAlignment.Center;
            tbxPIN.UseSystemPasswordChar = true;
            tbxPIN.TextChanged += tbxPIN_TextChanged;
            tbxPIN.KeyPress += tbxPIN_KeyPress;
            tbxPIN.ShortcutsEnabled = false;
            // 
            // lbltbxPIN
            // 
            lbltbxPIN.Location = new Point(86, 60);
            lbltbxPIN.Name = "lbltbxPIN";
            lbltbxPIN.Size = new Size(94, 21);
            lbltbxPIN.TabIndex = 35;
            lbltbxPIN.Text = "PIN*";
            lbltbxPIN.TextAlign = ContentAlignment.BottomCenter;
            lbltbxPIN.Click += lbltbxPIN_Click;
            // 
            // BancoConfirmar
            // 
            AcceptButton = btnOption;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            CancelButton = btnReturn;
            ClientSize = new Size(264, 232);
            Controls.Add(chkShowPIN);
            Controls.Add(lblErro);
            Controls.Add(tbxPIN);
            Controls.Add(lbltbxPIN);
            Controls.Add(btnReturn);
            Controls.Add(btnOption);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BancoConfirmar";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Banco";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnReturn;
        private Button btnOption;
        private Label lblTitle;
        private CheckBox chkShowPIN;
        private Label lblErro;
        private TextBox tbxPIN;
        private Label lbltbxPIN;
    }
}