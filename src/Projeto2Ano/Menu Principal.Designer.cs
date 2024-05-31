namespace Projeto2Ano
{
    partial class MenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            btnSair = new Button();
            menuStrip1 = new MenuStrip();
            menuDefinicoes = new ToolStripMenuItem();
            contaToolStripMenuItem = new ToolStripMenuItem();
            btnShop = new Button();
            btnBank = new Button();
            lblTitle = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnSair
            // 
            btnSair.FlatStyle = FlatStyle.Flat;
            btnSair.Location = new Point(441, 457);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(196, 41);
            btnSair.TabIndex = 2;
            btnSair.TabStop = false;
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = true;
            btnSair.Click += btnSair_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuDefinicoes, contaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.Size = new Size(1083, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuDefinicoes
            // 
            menuDefinicoes.Name = "menuDefinicoes";
            menuDefinicoes.Size = new Size(74, 20);
            menuDefinicoes.Text = "Definições";
            menuDefinicoes.Click += menuDefinicoes_Click;
            // 
            // contaToolStripMenuItem
            // 
            contaToolStripMenuItem.Name = "contaToolStripMenuItem";
            contaToolStripMenuItem.Size = new Size(51, 20);
            contaToolStripMenuItem.Text = "Conta";
            contaToolStripMenuItem.Click += menuConta_Click;
            // 
            // btnShop
            // 
            btnShop.BackgroundImage = (Image)resources.GetObject("btnShop.BackgroundImage");
            btnShop.BackgroundImageLayout = ImageLayout.Zoom;
            btnShop.Cursor = Cursors.Hand;
            btnShop.FlatAppearance.BorderSize = 0;
            btnShop.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnShop.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnShop.FlatStyle = FlatStyle.Flat;
            btnShop.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnShop.Location = new Point(690, 134);
            btnShop.Margin = new Padding(50000);
            btnShop.Name = "btnShop";
            btnShop.Size = new Size(300, 300);
            btnShop.TabIndex = 5;
            btnShop.TabStop = false;
            btnShop.Text = "Loja";
            btnShop.TextAlign = ContentAlignment.BottomCenter;
            btnShop.UseVisualStyleBackColor = false;
            btnShop.Click += btnShop_Click;
            // 
            // btnBank
            // 
            btnBank.BackgroundImage = (Image)resources.GetObject("btnBank.BackgroundImage");
            btnBank.BackgroundImageLayout = ImageLayout.Zoom;
            btnBank.Cursor = Cursors.Hand;
            btnBank.FlatAppearance.BorderSize = 0;
            btnBank.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnBank.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnBank.FlatStyle = FlatStyle.Flat;
            btnBank.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnBank.Location = new Point(91, 134);
            btnBank.Margin = new Padding(0);
            btnBank.Name = "btnBank";
            btnBank.Size = new Size(300, 300);
            btnBank.TabIndex = 7;
            btnBank.TabStop = false;
            btnBank.Text = "Banco";
            btnBank.TextAlign = ContentAlignment.BottomCenter;
            btnBank.UseVisualStyleBackColor = true;
            btnBank.Click += btnBank_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(396, 42);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(288, 50);
            lblTitle.TabIndex = 8;
            lblTitle.Text = "Bem Vindo {Program.user.Name}\r\nSelecione um local:\r\n";
            lblTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1083, 510);
            Controls.Add(lblTitle);
            Controls.Add(btnBank);
            Controls.Add(btnShop);
            Controls.Add(btnSair);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "MenuPrincipal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Menu Principal";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnSair;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuDefinicoes;
        private Button btnShop;
        private Button btnBank;
        private ToolStripMenuItem contaToolStripMenuItem;
        private Label lblTitle;
    }
}