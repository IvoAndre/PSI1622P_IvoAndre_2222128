namespace Projeto2Ano
{
    partial class BancoAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BancoAdmin));
            pDefinicoes = new Panel();
            btnSave = new Button();
            btnDeleteTransaction = new Button();
            btnAlterarPIN = new Button();
            btnDelete = new Button();
            chkShowPIN = new CheckBox();
            lblErro = new Label();
            tbxRepPIN = new TextBox();
            lbltbxRepPIN = new Label();
            tbxPIN = new TextBox();
            lbltbxPIN = new Label();
            dgTransacoes = new DataGridView();
            btnInsertTransaction = new Button();
            btnReturn = new Button();
            cbxContaSel = new ComboBox();
            lblContaSel = new Label();
            lblTitle = new Label();
            pDefinicoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgTransacoes).BeginInit();
            SuspendLayout();
            // 
            // pDefinicoes
            // 
            pDefinicoes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pDefinicoes.BorderStyle = BorderStyle.FixedSingle;
            pDefinicoes.Controls.Add(btnSave);
            pDefinicoes.Controls.Add(btnDeleteTransaction);
            pDefinicoes.Controls.Add(btnAlterarPIN);
            pDefinicoes.Controls.Add(btnDelete);
            pDefinicoes.Controls.Add(chkShowPIN);
            pDefinicoes.Controls.Add(lblErro);
            pDefinicoes.Controls.Add(tbxRepPIN);
            pDefinicoes.Controls.Add(lbltbxRepPIN);
            pDefinicoes.Controls.Add(tbxPIN);
            pDefinicoes.Controls.Add(lbltbxPIN);
            pDefinicoes.Controls.Add(dgTransacoes);
            pDefinicoes.Controls.Add(btnInsertTransaction);
            pDefinicoes.Location = new Point(0, 142);
            pDefinicoes.Margin = new Padding(0);
            pDefinicoes.Name = "pDefinicoes";
            pDefinicoes.Size = new Size(800, 443);
            pDefinicoes.TabIndex = 13;
            pDefinicoes.Visible = false;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Location = new Point(199, -1);
            btnSave.Margin = new Padding(0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(400, 29);
            btnSave.TabIndex = 43;
            btnSave.TabStop = false;
            btnSave.Text = "Guardar Tabela";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDeleteTransaction
            // 
            btnDeleteTransaction.Anchor = AnchorStyles.Top;
            btnDeleteTransaction.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDeleteTransaction.FlatStyle = FlatStyle.Flat;
            btnDeleteTransaction.Location = new Point(599, -1);
            btnDeleteTransaction.Margin = new Padding(0);
            btnDeleteTransaction.Name = "btnDeleteTransaction";
            btnDeleteTransaction.Size = new Size(200, 29);
            btnDeleteTransaction.TabIndex = 44;
            btnDeleteTransaction.TabStop = false;
            btnDeleteTransaction.Text = "Apagar Transação Selecionada";
            btnDeleteTransaction.UseVisualStyleBackColor = true;
            btnDeleteTransaction.Click += btnDeleteTransaction_Click;
            // 
            // btnAlterarPIN
            // 
            btnAlterarPIN.Anchor = AnchorStyles.Bottom;
            btnAlterarPIN.FlatStyle = FlatStyle.Flat;
            btnAlterarPIN.Location = new Point(240, 353);
            btnAlterarPIN.Name = "btnAlterarPIN";
            btnAlterarPIN.Size = new Size(146, 40);
            btnAlterarPIN.TabIndex = 18;
            btnAlterarPIN.TabStop = false;
            btnAlterarPIN.Text = "Alterar PIN";
            btnAlterarPIN.UseVisualStyleBackColor = true;
            btnAlterarPIN.Click += btnAlterarPIN_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(416, 353);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(301, 40);
            btnDelete.TabIndex = 19;
            btnDelete.TabStop = false;
            btnDelete.Text = "Apagar Conta";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // chkShowPIN
            // 
            chkShowPIN.Anchor = AnchorStyles.Bottom;
            chkShowPIN.AutoSize = true;
            chkShowPIN.Location = new Point(27, 392);
            chkShowPIN.Name = "chkShowPIN";
            chkShowPIN.Size = new Size(94, 19);
            chkShowPIN.TabIndex = 39;
            chkShowPIN.Text = "Mostrar PINs";
            chkShowPIN.UseVisualStyleBackColor = true;
            chkShowPIN.CheckedChanged += chkShowPIN_CheckedChanged;
            // 
            // lblErro
            // 
            lblErro.Anchor = AnchorStyles.Bottom;
            lblErro.AutoSize = true;
            lblErro.ForeColor = Color.Red;
            lblErro.Location = new Point(27, 414);
            lblErro.Name = "lblErro";
            lblErro.Size = new Size(31, 15);
            lblErro.TabIndex = 38;
            lblErro.Text = "Erro:";
            lblErro.UseMnemonic = false;
            lblErro.Visible = false;
            // 
            // tbxRepPIN
            // 
            tbxRepPIN.Anchor = AnchorStyles.Bottom;
            tbxRepPIN.Location = new Point(129, 363);
            tbxRepPIN.MaxLength = 4;
            tbxRepPIN.Name = "tbxRepPIN";
            tbxRepPIN.PlaceholderText = "_ _ _ _";
            tbxRepPIN.Size = new Size(94, 23);
            tbxRepPIN.TabIndex = 37;
            tbxRepPIN.TextAlign = HorizontalAlignment.Center;
            tbxRepPIN.UseSystemPasswordChar = true;
            tbxRepPIN.TextChanged += tbxRepPIN_TextChanged;
            // 
            // lbltbxRepPIN
            // 
            lbltbxRepPIN.Anchor = AnchorStyles.Bottom;
            lbltbxRepPIN.AutoSize = true;
            lbltbxRepPIN.Location = new Point(129, 345);
            lbltbxRepPIN.Name = "lbltbxRepPIN";
            lbltbxRepPIN.Size = new Size(71, 15);
            lbltbxRepPIN.TabIndex = 36;
            lbltbxRepPIN.Text = "Repetir PIN*";
            lbltbxRepPIN.Click += lbltbxRepPIN_Click;
            // 
            // tbxPIN
            // 
            tbxPIN.Anchor = AnchorStyles.Bottom;
            tbxPIN.Location = new Point(27, 363);
            tbxPIN.MaxLength = 4;
            tbxPIN.Name = "tbxPIN";
            tbxPIN.PlaceholderText = "_ _ _ _";
            tbxPIN.Size = new Size(94, 23);
            tbxPIN.TabIndex = 35;
            tbxPIN.TextAlign = HorizontalAlignment.Center;
            tbxPIN.UseSystemPasswordChar = true;
            tbxPIN.TextChanged += tbxPIN_TextChanged;
            tbxPIN.KeyPress += tbxPIN_KeyPress;
            // 
            // lbltbxPIN
            // 
            lbltbxPIN.Anchor = AnchorStyles.Bottom;
            lbltbxPIN.AutoSize = true;
            lbltbxPIN.Location = new Point(27, 345);
            lbltbxPIN.Name = "lbltbxPIN";
            lbltbxPIN.Size = new Size(88, 15);
            lbltbxPIN.TabIndex = 34;
            lbltbxPIN.Text = "PIN* (4 Dígitos)";
            lbltbxPIN.TextAlign = ContentAlignment.BottomLeft;
            lbltbxPIN.Click += lbltbxPIN_Click;
            // 
            // dgTransacoes
            // 
            dgTransacoes.AllowUserToAddRows = false;
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
            dgTransacoes.Location = new Point(-1, 28);
            dgTransacoes.Margin = new Padding(0);
            dgTransacoes.Name = "dgTransacoes";
            dgTransacoes.RowHeadersVisible = false;
            dgTransacoes.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgTransacoes.RowTemplate.Height = 25;
            dgTransacoes.Size = new Size(800, 289);
            dgTransacoes.TabIndex = 2;
            dgTransacoes.CellClick += dgTransacoes_CellClick;
            // 
            // btnInsertTransaction
            // 
            btnInsertTransaction.Anchor = AnchorStyles.Top;
            btnInsertTransaction.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnInsertTransaction.FlatStyle = FlatStyle.Flat;
            btnInsertTransaction.Location = new Point(-1, -1);
            btnInsertTransaction.Margin = new Padding(0);
            btnInsertTransaction.Name = "btnInsertTransaction";
            btnInsertTransaction.Size = new Size(200, 29);
            btnInsertTransaction.TabIndex = 45;
            btnInsertTransaction.TabStop = false;
            btnInsertTransaction.Text = "Inserir Transação";
            btnInsertTransaction.UseVisualStyleBackColor = true;
            btnInsertTransaction.Click += btnInsertTransaction_Click;
            // 
            // btnReturn
            // 
            btnReturn.Anchor = AnchorStyles.Top;
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.Location = new Point(417, 59);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(301, 40);
            btnReturn.TabIndex = 17;
            btnReturn.TabStop = false;
            btnReturn.Text = "Voltar";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // cbxContaSel
            // 
            cbxContaSel.Anchor = AnchorStyles.Top;
            cbxContaSel.FormattingEnabled = true;
            cbxContaSel.Location = new Point(190, 69);
            cbxContaSel.Name = "cbxContaSel";
            cbxContaSel.Size = new Size(197, 23);
            cbxContaSel.TabIndex = 16;
            cbxContaSel.TabStop = false;
            cbxContaSel.SelectedIndexChanged += cbxContaSel_SelectedIndexChanged;
            // 
            // lblContaSel
            // 
            lblContaSel.Anchor = AnchorStyles.Top;
            lblContaSel.AutoSize = true;
            lblContaSel.Location = new Point(83, 72);
            lblContaSel.Name = "lblContaSel";
            lblContaSel.Size = new Size(102, 15);
            lblContaSel.TabIndex = 15;
            lblContaSel.Text = "Conta Selcionada:";
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(800, 37);
            lblTitle.TabIndex = 14;
            lblTitle.Text = "Gestão Bancária";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BancoAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 585);
            Controls.Add(btnReturn);
            Controls.Add(cbxContaSel);
            Controls.Add(lblContaSel);
            Controls.Add(lblTitle);
            Controls.Add(pDefinicoes);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(816, 624);
            Name = "BancoAdmin";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Banco Admin";
            pDefinicoes.ResumeLayout(false);
            pDefinicoes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgTransacoes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion
        private Panel pDefinicoes;
        private Button btnReturn;
        private ComboBox cbxContaSel;
        private Label lblContaSel;
        private Label lblTitle;
        private DataGridView dgTransacoes;
        private Button btnAlterarPIN;
        private Button btnDelete;
        private CheckBox chkShowPIN;
        private Label lblErro;
        private TextBox tbxRepPIN;
        private Label lbltbxRepPIN;
        private TextBox tbxPIN;
        private Label lbltbxPIN;
        private Button btnDeleteTransaction;
        private Button btnSave;
        private Button btnInsertTransaction;
    }
}