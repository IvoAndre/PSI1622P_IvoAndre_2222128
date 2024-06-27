namespace Projeto2Ano
{
    partial class ContaConfirmarMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContaConfirmarMessageBox));
            chkShowPass = new CheckBox();
            lblErro = new Label();
            btnConfirm = new Button();
            tbxPass = new TextBox();
            lblTitle = new Label();
            btnCancel = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // chkShowPass
            // 
            chkShowPass.AutoSize = true;
            chkShowPass.Location = new Point(118, 75);
            chkShowPass.Name = "chkShowPass";
            chkShowPass.Size = new Size(142, 19);
            chkShowPass.TabIndex = 20;
            chkShowPass.Text = "Mostrar Palavra-Passe";
            chkShowPass.UseVisualStyleBackColor = true;
            chkShowPass.CheckedChanged += chkShowPass_CheckedChanged;
            // 
            // lblErro
            // 
            lblErro.AutoSize = true;
            lblErro.ForeColor = Color.Red;
            lblErro.Location = new Point(118, 97);
            lblErro.Name = "lblErro";
            lblErro.Size = new Size(31, 15);
            lblErro.TabIndex = 19;
            lblErro.Text = "Erro:";
            lblErro.UseMnemonic = false;
            lblErro.Visible = false;
            // 
            // btnConfirm
            // 
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Location = new Point(210, 134);
            btnConfirm.Margin = new Padding(50000);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(160, 23);
            btnConfirm.TabIndex = 16;
            btnConfirm.Text = "Confirmar";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // tbxPass
            // 
            tbxPass.Location = new Point(118, 46);
            tbxPass.Name = "tbxPass";
            tbxPass.Size = new Size(225, 23);
            tbxPass.TabIndex = 0;
            tbxPass.UseSystemPasswordChar = true;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(118, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(225, 34);
            lblTitle.TabIndex = 23;
            lblTitle.Text = "Esta operação requer confirmação, \r\ninsira a sua palavra-passe:";
            // 
            // btnCancel
            // 
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(12, 134);
            btnCancel.Margin = new Padding(50000);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(160, 23);
            btnCancel.TabIndex = 24;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 103);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 25;
            pictureBox1.TabStop = false;
            // 
            // ContaConfirmarMessageBox
            // 
            AcceptButton = btnConfirm;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(382, 167);
            Controls.Add(pictureBox1);
            Controls.Add(btnCancel);
            Controls.Add(lblTitle);
            Controls.Add(tbxPass);
            Controls.Add(chkShowPass);
            Controls.Add(lblErro);
            Controls.Add(btnConfirm);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ContaConfirmarMessageBox";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Confirmação";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox chkShowPass;
        private Label lblErro;
        private Button btnConfirm;
        private TextBox tbxPass;
        private Label lblTitle;
        private Button btnCancel;
        private PictureBox pictureBox1;
    }
}