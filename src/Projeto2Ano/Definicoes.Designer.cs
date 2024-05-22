namespace Projeto2Ano
{
    partial class Definicoes
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
            lblTitle = new Label();
            gbxAparencia = new GroupBox();
            lblTheme = new Label();
            cbxTheme = new ComboBox();
            btnConfirmar = new Button();
            gbxAparencia.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(95, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(140, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Definições";
            // 
            // gbxAparencia
            // 
            gbxAparencia.Controls.Add(lblTheme);
            gbxAparencia.Controls.Add(cbxTheme);
            gbxAparencia.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            gbxAparencia.Location = new Point(-1, 49);
            gbxAparencia.Name = "gbxAparencia";
            gbxAparencia.Size = new Size(333, 100);
            gbxAparencia.TabIndex = 2;
            gbxAparencia.TabStop = false;
            gbxAparencia.Text = "Aparência";
            // 
            // lblTheme
            // 
            lblTheme.AutoSize = true;
            lblTheme.Location = new Point(30, 46);
            lblTheme.Name = "lblTheme";
            lblTheme.Size = new Size(60, 25);
            lblTheme.TabIndex = 1;
            lblTheme.Text = "Tema:";
            // 
            // cbxTheme
            // 
            cbxTheme.FormattingEnabled = true;
            cbxTheme.Items.AddRange(new object[] { "Claro", "Escuro" });
            cbxTheme.Location = new Point(96, 43);
            cbxTheme.Name = "cbxTheme";
            cbxTheme.Size = new Size(140, 33);
            cbxTheme.TabIndex = 0;
            cbxTheme.TabStop = false;
            cbxTheme.Text = "Claro";
            cbxTheme.SelectedIndexChanged += cbxTheme_SelectedIndexChanged;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(95, 212);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(140, 39);
            btnConfirmar.TabIndex = 3;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // Definicoes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(331, 263);
            Controls.Add(btnConfirmar);
            Controls.Add(gbxAparencia);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Definicoes";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Definicoes";
            TopMost = true;
            gbxAparencia.ResumeLayout(false);
            gbxAparencia.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private GroupBox gbxAparencia;
        private Button btnConfirmar;
        private Label lblTheme;
        private ComboBox cbxTheme;
    }
}