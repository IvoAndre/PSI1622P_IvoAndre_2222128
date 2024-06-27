namespace Projeto2Ano
{
    partial class BancoTransferencia
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BancoTransferencia));
            btnReturn = new Button();
            btnOption = new Button();
            lblTitle = new Label();
            lblSaldo = new Label();
            lbltbxQuantia = new Label();
            tbxQuantia = new TextBox();
            tbxIBAN = new TextBox();
            lbltbxIBAN = new Label();
            dgTransferencias = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgTransferencias).BeginInit();
            SuspendLayout();
            // 
            // btnReturn
            // 
            btnReturn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.Location = new Point(28, 342);
            btnReturn.Margin = new Padding(50000);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(171, 41);
            btnReturn.TabIndex = 5;
            btnReturn.Text = "Cancelar";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // btnOption
            // 
            btnOption.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOption.Enabled = false;
            btnOption.FlatStyle = FlatStyle.Flat;
            btnOption.Location = new Point(432, 342);
            btnOption.Margin = new Padding(50000);
            btnOption.Name = "btnOption";
            btnOption.Size = new Size(171, 41);
            btnOption.TabIndex = 4;
            btnOption.Text = "Confirmar";
            btnOption.UseVisualStyleBackColor = true;
            btnOption.Click += btnOption_Click;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(0, 0);
            lblTitle.MinimumSize = new Size(623, 40);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(623, 40);
            lblTitle.TabIndex = 40;
            lblTitle.Text = "Efetuar Transferência";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSaldo
            // 
            lblSaldo.Dock = DockStyle.Bottom;
            lblSaldo.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblSaldo.Location = new Point(0, 388);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(623, 23);
            lblSaldo.TabIndex = 42;
            lblSaldo.Text = "Saldo Atual: {Program.user.Saldo}";
            // 
            // lbltbxQuantia
            // 
            lbltbxQuantia.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lbltbxQuantia.Location = new Point(432, 275);
            lbltbxQuantia.Name = "lbltbxQuantia";
            lbltbxQuantia.Size = new Size(171, 21);
            lbltbxQuantia.TabIndex = 45;
            lbltbxQuantia.Text = "Quantia a Tranferir*:";
            lbltbxQuantia.TextAlign = ContentAlignment.BottomLeft;
            // 
            // tbxQuantia
            // 
            tbxQuantia.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tbxQuantia.Location = new Point(432, 299);
            tbxQuantia.Name = "tbxQuantia";
            tbxQuantia.PlaceholderText = "____ , __";
            tbxQuantia.Size = new Size(171, 23);
            tbxQuantia.TabIndex = 3;
            tbxQuantia.TextChanged += tbxQuantia_TextChanged;
            tbxQuantia.KeyPress += tbxQuantia_KeyPress;
            tbxQuantia.ShortcutsEnabled = false;
            // 
            // tbxIBAN
            // 
            tbxIBAN.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbxIBAN.Location = new Point(28, 299);
            tbxIBAN.MaxLength = 26;
            tbxIBAN.Name = "tbxIBAN";
            tbxIBAN.PlaceholderText = "____ ____ ____ ____ ___ _";
            tbxIBAN.Size = new Size(398, 23);
            tbxIBAN.TabIndex = 2;
            tbxIBAN.TextChanged += tbxIBAN_TextChanged;
            // 
            // lbltbxIBAN
            // 
            lbltbxIBAN.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbltbxIBAN.Location = new Point(28, 275);
            lbltbxIBAN.Name = "lbltbxIBAN";
            lbltbxIBAN.Size = new Size(398, 21);
            lbltbxIBAN.TabIndex = 47;
            lbltbxIBAN.Text = "IBAN destinatário*:";
            lbltbxIBAN.TextAlign = ContentAlignment.BottomLeft;
            // 
            // dgTransferencias
            // 
            dgTransferencias.AllowUserToAddRows = false;
            dgTransferencias.AllowUserToDeleteRows = false;
            dgTransferencias.AllowUserToResizeRows = false;
            dgTransferencias.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgTransferencias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgTransferencias.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgTransferencias.BackgroundColor = SystemColors.Control;
            dgTransferencias.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgTransferencias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgTransferencias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgTransferencias.DefaultCellStyle = dataGridViewCellStyle2;
            dgTransferencias.GridColor = SystemColors.ActiveBorder;
            dgTransferencias.Location = new Point(0, 40);
            dgTransferencias.Name = "dgTransferencias";
            dgTransferencias.ReadOnly = true;
            dgTransferencias.RowHeadersVisible = false;
            dgTransferencias.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgTransferencias.RowTemplate.Height = 25;
            dgTransferencias.Size = new Size(623, 232);
            dgTransferencias.TabIndex = 1;
            // 
            // BancoTransferencia
            // 
            AcceptButton = btnOption;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnReturn;
            ClientSize = new Size(623, 411);
            Controls.Add(dgTransferencias);
            Controls.Add(tbxIBAN);
            Controls.Add(lbltbxIBAN);
            Controls.Add(tbxQuantia);
            Controls.Add(lbltbxQuantia);
            Controls.Add(btnOption);
            Controls.Add(lblTitle);
            Controls.Add(btnReturn);
            Controls.Add(lblSaldo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "BancoTransferencia";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Banco Transferência";
            ((System.ComponentModel.ISupportInitialize)dgTransferencias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnReturn;
        private Button btnOption;
        private Label lblTitle;
        private Label lblSaldo;
        private Label lbltbxQuantia;
        private TextBox tbxQuantia;
        private TextBox tbxIBAN;
        private Label lbltbxIBAN;
        private DataGridView dgTransferencias;
    }
}