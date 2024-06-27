namespace Projeto2Ano
{
    partial class LojaPagamentoDinheiro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LojaPagamentoDinheiro));
            btnReturn = new Button();
            btnOption = new Button();
            lblTitle = new Label();
            lbltbxQuantia = new Label();
            tbxQuantia = new TextBox();
            SuspendLayout();
            // 
            // btnReturn
            // 
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.Location = new Point(53, 302);
            btnReturn.Margin = new Padding(71429, 83333, 71429, 83333);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(244, 68);
            btnReturn.TabIndex = 39;
            btnReturn.Text = "Cancelar";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // btnOption
            // 
            btnOption.FlatStyle = FlatStyle.Flat;
            btnOption.Location = new Point(384, 302);
            btnOption.Margin = new Padding(71429, 83333, 71429, 83333);
            btnOption.Name = "btnOption";
            btnOption.Size = new Size(244, 68);
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
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(677, 142);
            lblTitle.TabIndex = 40;
            lblTitle.Text = "Pagamento";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbltbxQuantia
            // 
            lbltbxQuantia.Dock = DockStyle.Top;
            lbltbxQuantia.Location = new Point(0, 142);
            lbltbxQuantia.Margin = new Padding(4, 0, 4, 0);
            lbltbxQuantia.Name = "lbltbxQuantia";
            lbltbxQuantia.Size = new Size(677, 67);
            lbltbxQuantia.TabIndex = 45;
            lbltbxQuantia.Text = "Quantia a Pagar*:\r\n(Clique em Confirmar sem inserir um valor para pagar a quantia total.)";
            lbltbxQuantia.TextAlign = ContentAlignment.BottomCenter;
            // 
            // tbxQuantia
            // 
            tbxQuantia.Location = new Point(94, 240);
            tbxQuantia.Margin = new Padding(4, 5, 4, 5);
            tbxQuantia.Name = "tbxQuantia";
            tbxQuantia.PlaceholderText = "____ , __";
            tbxQuantia.Size = new Size(487, 31);
            tbxQuantia.TabIndex = 1;
            tbxQuantia.TextAlign = HorizontalAlignment.Center;
            tbxQuantia.TextChanged += tbxQuantia_TextChanged;
            tbxQuantia.KeyPress += tbxQuantia_KeyPress;
            tbxQuantia.ShortcutsEnabled = false;
            // 
            // LojaPagamentoDinheiro
            // 
            AcceptButton = btnOption;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnReturn;
            ClientSize = new Size(677, 420);
            Controls.Add(tbxQuantia);
            Controls.Add(lbltbxQuantia);
            Controls.Add(btnOption);
            Controls.Add(lblTitle);
            Controls.Add(btnReturn);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "LojaPagamentoDinheiro";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Loja Pagamento em Dinheiro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnReturn;
        private Button btnOption;
        private Label lblTitle;
        private Label lbltbxQuantia;
        private TextBox tbxQuantia;
    }
}