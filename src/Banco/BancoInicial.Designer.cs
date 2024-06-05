namespace Projeto2Ano
{
    partial class BancoInicial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BancoInicial));
            btnContinue = new Button();
            btnSair = new Button();
            lblTitle = new Label();
            pictureBox1 = new PictureBox();
            lblBanco = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnContinue
            // 
            btnContinue.Anchor = AnchorStyles.None;
            btnContinue.FlatStyle = FlatStyle.Flat;
            btnContinue.Location = new Point(45, 230);
            btnContinue.Margin = new Padding(50000);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(196, 41);
            btnContinue.TabIndex = 11;
            btnContinue.TabStop = false;
            btnContinue.Text = "Opçao";
            btnContinue.UseVisualStyleBackColor = true;
            btnContinue.Click += btnContinue_Click;
            // 
            // btnSair
            // 
            btnSair.Anchor = AnchorStyles.None;
            btnSair.FlatStyle = FlatStyle.Flat;
            btnSair.Location = new Point(45, 291);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(196, 41);
            btnSair.TabIndex = 9;
            btnSair.TabStop = false;
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = true;
            btnSair.Click += btnSair_Click;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(45, 188);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(196, 25);
            lblTitle.TabIndex = 8;
            lblTitle.Text = "Selecione uma opção:";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(285, 137);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // lblBanco
            // 
            lblBanco.AutoSize = true;
            lblBanco.BackColor = Color.Transparent;
            lblBanco.FlatStyle = FlatStyle.Flat;
            lblBanco.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblBanco.Location = new Point(96, 140);
            lblBanco.Name = "lblBanco";
            lblBanco.Size = new Size(95, 37);
            lblBanco.TabIndex = 14;
            lblBanco.Text = "Banco";
            // 
            // BancoInicial
            // 
            AcceptButton = btnContinue;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnSair;
            ClientSize = new Size(285, 355);
            Controls.Add(lblBanco);
            Controls.Add(pictureBox1);
            Controls.Add(btnContinue);
            Controls.Add(btnSair);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            Name = "BancoInicial";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Banco";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnContinue;
        private Button btnSair;
        private Label lblTitle;
        private PictureBox pictureBox1;
        private Label lblBanco;
    }
}