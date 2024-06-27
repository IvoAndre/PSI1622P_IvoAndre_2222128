namespace Projeto2Ano
{
    partial class BancoOpIO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BancoOpIO));
            lblErro = new Label();
            btnReturn = new Button();
            btnOption = new Button();
            lblTitle = new Label();
            lblSaldo = new Label();
            lbltbxQuantia = new Label();
            tbxQuantia = new TextBox();
            SuspendLayout();
            // 
            // lblErro
            // 
            lblErro.AutoSize = true;
            lblErro.ForeColor = Color.Red;
            lblErro.Location = new Point(66, 158);
            lblErro.Name = "lblErro";
            lblErro.Size = new Size(31, 15);
            lblErro.TabIndex = 41;
            lblErro.Text = "Erro:";
            lblErro.UseMnemonic = false;
            lblErro.Visible = false;
            // 
            // btnReturn
            // 
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.Location = new Point(37, 181);
            btnReturn.Margin = new Padding(50000);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(171, 41);
            btnReturn.TabIndex = 39;
            btnReturn.Text = "Cancelar";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // btnOption
            // 
            btnOption.Enabled = false;
            btnOption.FlatStyle = FlatStyle.Flat;
            btnOption.Location = new Point(269, 181);
            btnOption.Margin = new Padding(50000);
            btnOption.Name = "btnOption";
            btnOption.Size = new Size(171, 41);
            btnOption.TabIndex = 38;
            btnOption.Text = "Confirmar";
            btnOption.UseVisualStyleBackColor = true;
            btnOption.Click += btnOption_Click;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(474, 85);
            lblTitle.TabIndex = 40;
            lblTitle.Text = "Title";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSaldo
            // 
            lblSaldo.Dock = DockStyle.Bottom;
            lblSaldo.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblSaldo.Location = new Point(0, 229);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(474, 23);
            lblSaldo.TabIndex = 42;
            lblSaldo.Text = "Saldo Atual: {Program.user.Saldo}";
            // 
            // lbltbxQuantia
            // 
            lbltbxQuantia.Dock = DockStyle.Top;
            lbltbxQuantia.Location = new Point(0, 85);
            lbltbxQuantia.Name = "lbltbxQuantia";
            lbltbxQuantia.Size = new Size(474, 44);
            lbltbxQuantia.TabIndex = 45;
            lbltbxQuantia.Text = "Quantia a Operação*";
            lbltbxQuantia.TextAlign = ContentAlignment.BottomCenter;
            // 
            // tbxQuantia
            // 
            tbxQuantia.Location = new Point(66, 132);
            tbxQuantia.Name = "tbxQuantia";
            tbxQuantia.PlaceholderText = "____ , __";
            tbxQuantia.Size = new Size(342, 23);
            tbxQuantia.TabIndex = 1;
            tbxQuantia.TextAlign = HorizontalAlignment.Center;
            tbxQuantia.TextChanged += tbxQuantia_TextChanged;
            tbxQuantia.KeyPress += tbxQuantia_KeyPress;
            tbxQuantia.ShortcutsEnabled = false;
            // 
            // BancoOpIO
            // 
            AcceptButton = btnOption;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnReturn;
            ClientSize = new Size(474, 252);
            Controls.Add(tbxQuantia);
            Controls.Add(lbltbxQuantia);
            Controls.Add(lblErro);
            Controls.Add(btnOption);
            Controls.Add(lblTitle);
            Controls.Add(btnReturn);
            Controls.Add(lblSaldo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "BancoOpIO";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Banco Transação";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblErro;
        private Button btnReturn;
        private Button btnOption;
        private Label lblTitle;
        private Label lblSaldo;
        private Label lbltbxQuantia;
        private TextBox tbxQuantia;
    }
}