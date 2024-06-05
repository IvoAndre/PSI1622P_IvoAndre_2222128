namespace Projeto2Ano
{
    partial class BancoAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BancoAdmin));
            btnReturn = new Button();
            cbxContaSel = new ComboBox();
            lblContaSel = new Label();
            lblTitle = new Label();
            pDefinicoes = new Panel();
            SuspendLayout();
            // 
            // btnReturn
            // 
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.Location = new Point(414, 71);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(301, 40);
            btnReturn.TabIndex = 12;
            btnReturn.TabStop = false;
            btnReturn.Text = "Voltar";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // cbxContaSel
            // 
            cbxContaSel.FormattingEnabled = true;
            cbxContaSel.Location = new Point(187, 81);
            cbxContaSel.Name = "cbxContaSel";
            cbxContaSel.Size = new Size(197, 23);
            cbxContaSel.TabIndex = 11;
            cbxContaSel.TabStop = false;
            // 
            // lblContaSel
            // 
            lblContaSel.AutoSize = true;
            lblContaSel.Location = new Point(80, 84);
            lblContaSel.Name = "lblContaSel";
            lblContaSel.Size = new Size(102, 15);
            lblContaSel.TabIndex = 10;
            lblContaSel.Text = "Conta Selcionada:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(287, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(207, 37);
            lblTitle.TabIndex = 9;
            lblTitle.Text = "Gestão Bancária";
            // 
            // pDefinicoes
            // 
            pDefinicoes.BorderStyle = BorderStyle.FixedSingle;
            pDefinicoes.Dock = DockStyle.Bottom;
            pDefinicoes.Location = new Point(0, 150);
            pDefinicoes.Margin = new Padding(0);
            pDefinicoes.Name = "pDefinicoes";
            pDefinicoes.Size = new Size(800, 300);
            pDefinicoes.TabIndex = 13;
            pDefinicoes.Visible = false;
            // 
            // BancoAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pDefinicoes);
            Controls.Add(btnReturn);
            Controls.Add(cbxContaSel);
            Controls.Add(lblContaSel);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "BancoAdmin";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Banco Admin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnReturn;
        private ComboBox cbxContaSel;
        private Label lblContaSel;
        private Label lblTitle;
        private Panel pDefinicoes;
    }
}