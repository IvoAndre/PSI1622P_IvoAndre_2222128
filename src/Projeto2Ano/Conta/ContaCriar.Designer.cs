namespace Projeto2Ano
{
    partial class ContaCriar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContaCriar));
            lblTitle = new Label();
            btnSair = new Button();
            btnCriar = new Button();
            btnEntrar = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(94, 37);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(196, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Selecione uma opção:";
            // 
            // btnSair
            // 
            btnSair.Anchor = AnchorStyles.None;
            btnSair.FlatStyle = FlatStyle.Flat;
            btnSair.Location = new Point(94, 212);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(196, 41);
            btnSair.TabIndex = 2;
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = true;
            // 
            // btnCriar
            // 
            btnCriar.Anchor = AnchorStyles.None;
            btnCriar.FlatStyle = FlatStyle.Flat;
            btnCriar.Location = new Point(94, 92);
            btnCriar.Margin = new Padding(50000);
            btnCriar.Name = "btnCriar";
            btnCriar.Size = new Size(196, 41);
            btnCriar.TabIndex = 5;
            btnCriar.Text = "Criar Conta";
            btnCriar.UseVisualStyleBackColor = true;
            // 
            // btnEntrar
            // 
            btnEntrar.Anchor = AnchorStyles.None;
            btnEntrar.FlatStyle = FlatStyle.Flat;
            btnEntrar.Location = new Point(94, 151);
            btnEntrar.Margin = new Padding(50000);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(196, 41);
            btnEntrar.TabIndex = 7;
            btnEntrar.Text = "Entrar na Conta";
            btnEntrar.UseVisualStyleBackColor = true;
            // 
            // ContaCriar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(384, 284);
            Controls.Add(btnEntrar);
            Controls.Add(btnCriar);
            Controls.Add(btnSair);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "ContaCriar";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Menu Inicial";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnSair;
        private Button button2;
        private Button btnCriar;
        private Button btnEntrar;
    }
}