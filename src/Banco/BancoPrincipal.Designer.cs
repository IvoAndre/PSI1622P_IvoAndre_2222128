namespace Projeto2Ano
{
    partial class BancoPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BancoPrincipal));
            btnSair = new Button();
            lblTitle = new Label();
            pictureBox1 = new PictureBox();
            lblBanco = new Label();
            btnDeposit = new Button();
            btnTransfer = new Button();
            btnTransactions = new Button();
            btnWithdraw = new Button();
            btnAlterarPin = new Button();
            lblSaldo = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnSair
            // 
            btnSair.FlatStyle = FlatStyle.Flat;
            btnSair.Location = new Point(318, 378);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(243, 41);
            btnSair.TabIndex = 9;
            btnSair.TabStop = false;
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = true;
            btnSair.Click += btnSair_Click;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(0, 177);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(594, 64);
            lblTitle.TabIndex = 8;
            lblTitle.Text = "Bem Vindo {Program.User.Name}\r\nSelecione uma operação:";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(594, 137);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // lblBanco
            // 
            lblBanco.BackColor = Color.Transparent;
            lblBanco.FlatStyle = FlatStyle.Flat;
            lblBanco.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblBanco.Location = new Point(0, 140);
            lblBanco.Name = "lblBanco";
            lblBanco.Size = new Size(594, 37);
            lblBanco.TabIndex = 14;
            lblBanco.Text = "Banco";
            lblBanco.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnDeposit
            // 
            btnDeposit.FlatStyle = FlatStyle.Flat;
            btnDeposit.Location = new Point(31, 251);
            btnDeposit.Margin = new Padding(50000);
            btnDeposit.Name = "btnDeposit";
            btnDeposit.Size = new Size(243, 41);
            btnDeposit.TabIndex = 15;
            btnDeposit.TabStop = false;
            btnDeposit.Text = "Efetuar Depósito";
            btnDeposit.UseVisualStyleBackColor = true;
            btnDeposit.Click += btnDeposit_Click;
            // 
            // btnTransfer
            // 
            btnTransfer.FlatStyle = FlatStyle.Flat;
            btnTransfer.Location = new Point(31, 300);
            btnTransfer.Margin = new Padding(50000);
            btnTransfer.Name = "btnTransfer";
            btnTransfer.Size = new Size(243, 41);
            btnTransfer.TabIndex = 17;
            btnTransfer.TabStop = false;
            btnTransfer.Text = "Efetuar Transferência";
            btnTransfer.UseVisualStyleBackColor = true;
            btnTransfer.Click += btnTransfer_Click;
            // 
            // btnTransactions
            // 
            btnTransactions.FlatStyle = FlatStyle.Flat;
            btnTransactions.Location = new Point(318, 300);
            btnTransactions.Margin = new Padding(50000);
            btnTransactions.Name = "btnTransactions";
            btnTransactions.Size = new Size(243, 41);
            btnTransactions.TabIndex = 18;
            btnTransactions.TabStop = false;
            btnTransactions.Text = "Consultar Transações";
            btnTransactions.UseVisualStyleBackColor = true;
            btnTransactions.Click += btnTransactions_Click;
            // 
            // btnWithdraw
            // 
            btnWithdraw.FlatStyle = FlatStyle.Flat;
            btnWithdraw.Location = new Point(318, 251);
            btnWithdraw.Margin = new Padding(50000);
            btnWithdraw.Name = "btnWithdraw";
            btnWithdraw.Size = new Size(243, 41);
            btnWithdraw.TabIndex = 19;
            btnWithdraw.TabStop = false;
            btnWithdraw.Text = "Efetuar Levantamento";
            btnWithdraw.UseVisualStyleBackColor = true;
            btnWithdraw.Click += btnWithdraw_Click;
            // 
            // btnAlterarPin
            // 
            btnAlterarPin.FlatStyle = FlatStyle.Flat;
            btnAlterarPin.Location = new Point(31, 378);
            btnAlterarPin.Margin = new Padding(50000);
            btnAlterarPin.Name = "btnAlterarPin";
            btnAlterarPin.Size = new Size(243, 41);
            btnAlterarPin.TabIndex = 20;
            btnAlterarPin.TabStop = false;
            btnAlterarPin.Text = "Alterar PIN";
            btnAlterarPin.UseVisualStyleBackColor = true;
            btnAlterarPin.Click += btnAlterarPin_Click;
            // 
            // lblSaldo
            // 
            lblSaldo.Dock = DockStyle.Bottom;
            lblSaldo.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblSaldo.Location = new Point(0, 430);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(594, 23);
            lblSaldo.TabIndex = 43;
            lblSaldo.Text = "Saldo Atual: {Program.user.Saldo}";
            // 
            // BancoPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnSair;
            ClientSize = new Size(594, 453);
            Controls.Add(lblSaldo);
            Controls.Add(btnAlterarPin);
            Controls.Add(btnWithdraw);
            Controls.Add(btnTransactions);
            Controls.Add(btnTransfer);
            Controls.Add(btnDeposit);
            Controls.Add(lblBanco);
            Controls.Add(pictureBox1);
            Controls.Add(btnSair);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            Name = "BancoPrincipal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Banco";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnSair;
        private Label lblTitle;
        private PictureBox pictureBox1;
        private Label lblBanco;
        private Button btnDeposit;
        private Button btnTransfer;
        private Button btnTransactions;
        private Button btnWithdraw;
        private Button btnAlterarPin;
        private Label lblSaldo;
    }
}