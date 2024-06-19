namespace Projeto2Ano
{
    partial class LojaCarrinho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LojaCarrinho));
            flowLayoutPanelCart = new FlowLayoutPanel();
            btnBack = new Button();
            lblTotal = new Label();
            btnCheckout = new Button();
            SuspendLayout();
            // 
            // flowLayoutPanelCart
            // 
            flowLayoutPanelCart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            flowLayoutPanelCart.AutoScroll = true;
            flowLayoutPanelCart.Location = new Point(0, 0);
            flowLayoutPanelCart.Name = "flowLayoutPanelCart";
            flowLayoutPanelCart.Size = new Size(700, 400);
            flowLayoutPanelCart.TabIndex = 0;
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBack.Location = new Point(718, 12);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(170, 30);
            btnBack.TabIndex = 1;
            btnBack.Text = "Voltar";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotal.Location = new Point(718, 270);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(170, 85);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "Total: 0.00€";
            lblTotal.TextAlign = ContentAlignment.BottomRight;
            // 
            // btnCheckout
            // 
            btnCheckout.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCheckout.Location = new Point(718, 358);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(170, 30);
            btnCheckout.TabIndex = 3;
            btnCheckout.Text = "Pagamento";
            btnCheckout.UseVisualStyleBackColor = true;
            btnCheckout.Click += btnCheckout_Click;
            // 
            // LojaCarrinho
            // 
            ClientSize = new Size(900, 400);
            Controls.Add(btnCheckout);
            Controls.Add(lblTotal);
            Controls.Add(btnBack);
            Controls.Add(flowLayoutPanelCart);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(916, 99999);
            MinimumSize = new Size(916, 439);
            Name = "LojaCarrinho";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Carrinho";
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanelCart;
        private Button btnBack;
        private Label lblTotal;
        private Button btnCheckout;
    }
}