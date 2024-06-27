namespace Projeto2Ano
{
    partial class MenuInicial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuInicial));
            lblTitle = new Label();
            btnSair = new Button();
            menuStrip1 = new MenuStrip();
            menuDefinicoes = new ToolStripMenuItem();
            btnCriar = new Button();
            btnEntrar = new Button();
            pictureBox1 = new PictureBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            lblTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(0, 165);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(384, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Selecione uma opção:";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSair
            // 
            btnSair.Anchor = AnchorStyles.None;
            btnSair.FlatStyle = FlatStyle.Flat;
            btnSair.Location = new Point(94, 340);
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
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuDefinicoes });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.Size = new Size(384, 24);
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
            // btnCriar
            // 
            btnCriar.Anchor = AnchorStyles.None;
            btnCriar.FlatStyle = FlatStyle.Flat;
            btnCriar.Location = new Point(94, 220);
            btnCriar.Margin = new Padding(50000);
            btnCriar.Name = "btnCriar";
            btnCriar.Size = new Size(196, 41);
            btnCriar.TabIndex = 5;
            btnCriar.TabStop = false;
            btnCriar.Text = "Criar Conta";
            btnCriar.UseVisualStyleBackColor = false;
            btnCriar.Click += btnCriar_Click;
            // 
            // btnEntrar
            // 
            btnEntrar.Anchor = AnchorStyles.None;
            btnEntrar.FlatStyle = FlatStyle.Flat;
            btnEntrar.Location = new Point(94, 279);
            btnEntrar.Margin = new Padding(50000);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(196, 41);
            btnEntrar.TabIndex = 7;
            btnEntrar.TabStop = false;
            btnEntrar.Text = "Entrar na Conta";
            btnEntrar.UseVisualStyleBackColor = true;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(384, 137);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // MenuInicial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(384, 422);
            Controls.Add(pictureBox1);
            Controls.Add(btnEntrar);
            Controls.Add(btnCriar);
            Controls.Add(btnSair);
            Controls.Add(lblTitle);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "MenuInicial";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu Inicial";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
            KeyPress += MenuInicial_KeyPress;
        }

        #endregion

        private Label lblTitle;
        private Button btnSair;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuDefinicoes;
        private Button btnCriar;
        private Button btnEntrar;
        private PictureBox pictureBox1;
    }
}