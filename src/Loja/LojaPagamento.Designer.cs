namespace Projeto2Ano
{
    partial class LojaPagamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LojaPagamento));
            lblTitle = new Label();
            lblTotal = new Label();
            lblSubTitle = new Label();
            btnPayMoney = new Button();
            btnPayBank = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(330, 54);
            lblTitle.TabIndex = 41;
            lblTitle.Text = "Pagamento";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Top;
            lblTotal.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTotal.Location = new Point(0, 54);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(330, 64);
            lblTotal.TabIndex = 46;
            lblTotal.Text = "Total a Pagar:\r\n{total}€";
            lblTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubTitle
            // 
            lblSubTitle.Anchor = AnchorStyles.Top;
            lblSubTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblSubTitle.Location = new Point(0, 118);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(330, 32);
            lblSubTitle.TabIndex = 47;
            lblSubTitle.Text = "Selecione o método de pagamento:";
            lblSubTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnPayMoney
            // 
            btnPayMoney.Anchor = AnchorStyles.Top;
            btnPayMoney.FlatStyle = FlatStyle.Flat;
            btnPayMoney.Location = new Point(67, 233);
            btnPayMoney.Margin = new Padding(50000);
            btnPayMoney.Name = "btnPayMoney";
            btnPayMoney.Size = new Size(196, 41);
            btnPayMoney.TabIndex = 53;
            btnPayMoney.TabStop = false;
            btnPayMoney.Text = "Dinheiro";
            btnPayMoney.UseVisualStyleBackColor = true;
            btnPayMoney.Click += btnPayMoney_Click;
            // 
            // btnPayBank
            // 
            btnPayBank.Anchor = AnchorStyles.Top;
            btnPayBank.FlatStyle = FlatStyle.Flat;
            btnPayBank.Location = new Point(67, 174);
            btnPayBank.Margin = new Padding(50000);
            btnPayBank.Name = "btnPayBank";
            btnPayBank.Size = new Size(196, 41);
            btnPayBank.TabIndex = 52;
            btnPayBank.TabStop = false;
            btnPayBank.Text = "Conta Bancária";
            btnPayBank.UseVisualStyleBackColor = false;
            btnPayBank.Click += btnPayBank_Click;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Location = new Point(67, 293);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(196, 41);
            btnExit.TabIndex = 51;
            btnExit.TabStop = false;
            btnExit.Text = "Voltar";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // LojaPagamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(330, 359);
            ControlBox = false;
            Controls.Add(btnPayMoney);
            Controls.Add(btnPayBank);
            Controls.Add(btnExit);
            Controls.Add(lblSubTitle);
            Controls.Add(lblTotal);
            Controls.Add(lblTitle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LojaPagamento";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Loja Pagamento";
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Label lblTotal;
        private Label lblSubTitle;
        private Button btnPayMoney;
        private Button btnPayBank;
        private Button btnExit;
    }
}