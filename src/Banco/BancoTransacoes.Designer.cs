namespace Projeto2Ano
{
    partial class BancoTransacoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BancoTransacoes));
            lblTitle = new Label();
            lblSaldo = new Label();
            dgTransacoes = new DataGridView();
            btnReturn = new Button();
            ((System.ComponentModel.ISupportInitialize)dgTransacoes).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(834, 40);
            lblTitle.TabIndex = 40;
            lblTitle.Text = "Histórico de Transações";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSaldo
            // 
            lblSaldo.Dock = DockStyle.Bottom;
            lblSaldo.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblSaldo.Location = new Point(0, 388);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(834, 23);
            lblSaldo.TabIndex = 42;
            lblSaldo.Text = "Saldo Atual: {Program.user.Saldo}";
            // 
            // dgTransacoes
            // 
            dgTransacoes.AllowUserToAddRows = false;
            dgTransacoes.AllowUserToDeleteRows = false;
            dgTransacoes.AllowUserToResizeRows = false;
            dgTransacoes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgTransacoes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgTransacoes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgTransacoes.BackgroundColor = SystemColors.Control;
            dgTransacoes.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgTransacoes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgTransacoes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgTransacoes.DefaultCellStyle = dataGridViewCellStyle2;
            dgTransacoes.GridColor = SystemColors.ActiveBorder;
            dgTransacoes.Location = new Point(0, 40);
            dgTransacoes.Name = "dgTransacoes";
            dgTransacoes.ReadOnly = true;
            dgTransacoes.RowHeadersVisible = false;
            dgTransacoes.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgTransacoes.RowTemplate.Height = 25;
            dgTransacoes.Size = new Size(834, 287);
            dgTransacoes.TabIndex = 1;
            dgTransacoes.CellFormatting += dgTransacoes_CellFormatting;
            // 
            // btnReturn
            // 
            btnReturn.Anchor = AnchorStyles.Bottom;
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.Location = new Point(332, 343);
            btnReturn.Margin = new Padding(0);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(171, 41);
            btnReturn.TabIndex = 44;
            btnReturn.Text = "Voltar";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // BancoTransacoes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(834, 411);
            Controls.Add(btnReturn);
            Controls.Add(dgTransacoes);
            Controls.Add(lblTitle);
            Controls.Add(lblSaldo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(850, 450);
            Name = "BancoTransacoes";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Banco Transações";
            ((System.ComponentModel.ISupportInitialize)dgTransacoes).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label lblTitle;
        private Label lblSaldo;
        private DataGridView dgTransacoes;
        private Button btnReturn;
    }
}