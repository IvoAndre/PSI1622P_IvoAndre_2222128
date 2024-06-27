namespace Projeto2Ano
{
    partial class LojaPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LojaPrincipal));
            flpProductsList = new FlowLayoutPanel();
            btnExit = new Button();
            cbxCatSel = new ComboBox();
            lblCatCbx = new Label();
            btnCart = new Button();
            SuspendLayout();
            // 
            // flpProductsList
            // 
            flpProductsList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpProductsList.AutoScroll = true;
            flpProductsList.Location = new Point(0, 90);
            flpProductsList.Margin = new Padding(0);
            flpProductsList.Name = "flpProductsList";
            flpProductsList.Size = new Size(800, 500);
            flpProductsList.TabIndex = 0;
            // 
            // btnExit
            // 
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Location = new Point(9, 24);
            btnExit.Margin = new Padding(0);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 41);
            btnExit.TabIndex = 45;
            btnExit.Text = "Sair";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // cbxCatSel
            // 
            cbxCatSel.Anchor = AnchorStyles.Top;
            cbxCatSel.FormattingEnabled = true;
            cbxCatSel.Location = new Point(319, 34);
            cbxCatSel.Name = "cbxCatSel";
            cbxCatSel.Size = new Size(240, 23);
            cbxCatSel.TabIndex = 51;
            cbxCatSel.TabStop = false;
            cbxCatSel.SelectedIndexChanged += cbxCatSel_SelectedIndexChanged;
            // 
            // lblCatCbx
            // 
            lblCatCbx.Anchor = AnchorStyles.Top;
            lblCatCbx.AutoEllipsis = true;
            lblCatCbx.AutoSize = true;
            lblCatCbx.Location = new Point(192, 37);
            lblCatCbx.Name = "lblCatCbx";
            lblCatCbx.Size = new Size(121, 15);
            lblCatCbx.TabIndex = 50;
            lblCatCbx.Text = "Categoria Selcionada:";
            // 
            // btnCart
            // 
            btnCart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCart.FlatStyle = FlatStyle.Flat;
            btnCart.Location = new Point(651, 24);
            btnCart.Margin = new Padding(0);
            btnCart.Name = "btnCart";
            btnCart.Size = new Size(140, 41);
            btnCart.TabIndex = 52;
            btnCart.Text = "Carrinho (0)";
            btnCart.UseVisualStyleBackColor = true;
            btnCart.Click += btnCart_Click;
            // 
            // LojaPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 590);
            Controls.Add(btnCart);
            Controls.Add(cbxCatSel);
            Controls.Add(lblCatCbx);
            Controls.Add(btnExit);
            Controls.Add(flpProductsList);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(816, 629);
            Name = "LojaPrincipal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Loja";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flpProductsList;
        private Button btnExit;
        private ComboBox cbxCatSel;
        private Label lblCatCbx;
        private Button btnCart;
    }
}