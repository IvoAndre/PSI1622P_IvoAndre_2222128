namespace Projeto2Ano
{
    partial class LojaAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LojaAdmin));
            pDefinicoes = new Panel();
            btnSave = new Button();
            btnDeleteProduct = new Button();
            btnInsertProduct = new Button();
            dgProdutos = new DataGridView();
            btnDelete = new Button();
            btnReturn = new Button();
            cbxCatSel = new ComboBox();
            lblCatSel = new Label();
            lblTitle = new Label();
            lblNewCat = new Label();
            tbxNewCat = new TextBox();
            btnCreateCat = new Button();
            tbxAltCatName = new TextBox();
            lblAltCatName = new Label();
            btnAltCatName = new Button();
            lblNewCatErro = new Label();
            lblAltCatNameErro = new Label();
            pDefinicoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgProdutos).BeginInit();
            SuspendLayout();
            // 
            // pDefinicoes
            // 
            pDefinicoes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pDefinicoes.BorderStyle = BorderStyle.FixedSingle;
            pDefinicoes.Controls.Add(btnSave);
            pDefinicoes.Controls.Add(btnDeleteProduct);
            pDefinicoes.Controls.Add(btnInsertProduct);
            pDefinicoes.Controls.Add(dgProdutos);
            pDefinicoes.Location = new Point(0, 184);
            pDefinicoes.Margin = new Padding(0);
            pDefinicoes.Name = "pDefinicoes";
            pDefinicoes.Size = new Size(800, 401);
            pDefinicoes.TabIndex = 13;
            pDefinicoes.Visible = false;
            pDefinicoes.SizeChanged += pDefinicoes_SizeChanged;
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
            // btnDeleteProduct
            // 
            btnDeleteProduct.Anchor = AnchorStyles.Top;
            btnDeleteProduct.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDeleteProduct.FlatStyle = FlatStyle.Flat;
            btnDeleteProduct.Location = new Point(599, -1);
            btnDeleteProduct.Margin = new Padding(0);
            btnDeleteProduct.Name = "btnDeleteProduct";
            btnDeleteProduct.Size = new Size(200, 29);
            btnDeleteProduct.TabIndex = 44;
            btnDeleteProduct.TabStop = false;
            btnDeleteProduct.Text = "Apagar Produto Selecionado";
            btnDeleteProduct.UseVisualStyleBackColor = true;
            btnDeleteProduct.Click += btnDeleteProduct_Click;
            // 
            // btnInsertProduct
            // 
            btnInsertProduct.Anchor = AnchorStyles.Top;
            btnInsertProduct.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnInsertProduct.FlatStyle = FlatStyle.Flat;
            btnInsertProduct.Location = new Point(-1, -1);
            btnInsertProduct.Margin = new Padding(0);
            btnInsertProduct.Name = "btnInsertProduct";
            btnInsertProduct.Size = new Size(200, 29);
            btnInsertProduct.TabIndex = 45;
            btnInsertProduct.TabStop = false;
            btnInsertProduct.Text = "Inserir Produto";
            btnInsertProduct.UseVisualStyleBackColor = true;
            btnInsertProduct.Click += btnInsertProduct_Click;
            // 
            // dgProdutos
            // 
            dgProdutos.AllowUserToAddRows = false;
            dgProdutos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgProdutos.BackgroundColor = SystemColors.Control;
            dgProdutos.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgProdutos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgProdutos.DefaultCellStyle = dataGridViewCellStyle2;
            dgProdutos.GridColor = SystemColors.ActiveBorder;
            dgProdutos.Location = new Point(-1, 28);
            dgProdutos.Margin = new Padding(0);
            dgProdutos.MinimumSize = new Size(800, 371);
            dgProdutos.Name = "dgProdutos";
            dgProdutos.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgProdutos.RowTemplate.Height = 25;
            dgProdutos.RowTemplate.Resizable = DataGridViewTriState.True;
            dgProdutos.ScrollBars = ScrollBars.Vertical;
            dgProdutos.Size = new Size(800, 371);
            dgProdutos.TabIndex = 2;
            dgProdutos.CellClick += dgProdutos_CellClick;
            dgProdutos.CellPainting += dgProdutos_CellPainting;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top;
            btnDelete.Enabled = false;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(607, 119);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(135, 40);
            btnDelete.TabIndex = 19;
            btnDelete.TabStop = false;
            btnDelete.Text = "Apagar Categoria";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnReturn
            // 
            btnReturn.Anchor = AnchorStyles.Top;
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.Location = new Point(607, 59);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(135, 40);
            btnReturn.TabIndex = 17;
            btnReturn.TabStop = false;
            btnReturn.Text = "Voltar";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // cbxCatSel
            // 
            cbxCatSel.Anchor = AnchorStyles.Top;
            cbxCatSel.FormattingEnabled = true;
            cbxCatSel.Location = new Point(200, 104);
            cbxCatSel.Name = "cbxCatSel";
            cbxCatSel.Size = new Size(240, 23);
            cbxCatSel.TabIndex = 16;
            cbxCatSel.TabStop = false;
            cbxCatSel.SelectedIndexChanged += cbxCatSel_SelectedIndexChanged;
            // 
            // lblCatSel
            // 
            lblCatSel.Anchor = AnchorStyles.Top;
            lblCatSel.AutoSize = true;
            lblCatSel.Location = new Point(73, 107);
            lblCatSel.Name = "lblCatSel";
            lblCatSel.Size = new Size(121, 15);
            lblCatSel.TabIndex = 15;
            lblCatSel.Text = "Categoria Selcionada:";
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(800, 37);
            lblTitle.TabIndex = 14;
            lblTitle.Text = "Gestão da Loja";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNewCat
            // 
            lblNewCat.Anchor = AnchorStyles.Top;
            lblNewCat.AutoSize = true;
            lblNewCat.Location = new Point(102, 62);
            lblNewCat.Name = "lblNewCat";
            lblNewCat.Size = new Size(92, 15);
            lblNewCat.TabIndex = 39;
            lblNewCat.Text = "Nova Categoria:";
            lblNewCat.Click += lblNewCat_Click;
            // 
            // tbxNewCat
            // 
            tbxNewCat.Anchor = AnchorStyles.Top;
            tbxNewCat.Location = new Point(200, 59);
            tbxNewCat.Name = "tbxNewCat";
            tbxNewCat.Size = new Size(240, 23);
            tbxNewCat.TabIndex = 40;
            tbxNewCat.TextChanged += tbxNewCat_TextChanged;
            // 
            // btnCreateCat
            // 
            btnCreateCat.Anchor = AnchorStyles.Top;
            btnCreateCat.Enabled = false;
            btnCreateCat.FlatStyle = FlatStyle.Flat;
            btnCreateCat.Location = new Point(459, 59);
            btnCreateCat.Name = "btnCreateCat";
            btnCreateCat.Size = new Size(134, 40);
            btnCreateCat.TabIndex = 41;
            btnCreateCat.TabStop = false;
            btnCreateCat.Text = "Criar Categoria";
            btnCreateCat.UseVisualStyleBackColor = true;
            btnCreateCat.Click += btnCreateCat_Click;
            // 
            // tbxAltCatName
            // 
            tbxAltCatName.Anchor = AnchorStyles.Top;
            tbxAltCatName.Location = new Point(200, 136);
            tbxAltCatName.Name = "tbxAltCatName";
            tbxAltCatName.Size = new Size(240, 23);
            tbxAltCatName.TabIndex = 43;
            tbxAltCatName.TextChanged += tbxAltCatName_TextChanged;
            // 
            // lblAltCatName
            // 
            lblAltCatName.Anchor = AnchorStyles.Top;
            lblAltCatName.AutoSize = true;
            lblAltCatName.Location = new Point(49, 139);
            lblAltCatName.Name = "lblAltCatName";
            lblAltCatName.Size = new Size(145, 15);
            lblAltCatName.TabIndex = 42;
            lblAltCatName.Text = "Novo Nome da Categoria:";
            // 
            // btnAltCatName
            // 
            btnAltCatName.Anchor = AnchorStyles.Top;
            btnAltCatName.Enabled = false;
            btnAltCatName.FlatStyle = FlatStyle.Flat;
            btnAltCatName.Location = new Point(459, 119);
            btnAltCatName.Name = "btnAltCatName";
            btnAltCatName.Size = new Size(134, 40);
            btnAltCatName.TabIndex = 44;
            btnAltCatName.TabStop = false;
            btnAltCatName.Text = "Alterar Nome da Categoria";
            btnAltCatName.UseVisualStyleBackColor = true;
            btnAltCatName.Click += btnAltCatName_Click;
            // 
            // lblNewCatErro
            // 
            lblNewCatErro.AutoSize = true;
            lblNewCatErro.ForeColor = Color.Red;
            lblNewCatErro.Location = new Point(49, 84);
            lblNewCatErro.Name = "lblNewCatErro";
            lblNewCatErro.Size = new Size(31, 15);
            lblNewCatErro.TabIndex = 55;
            lblNewCatErro.Text = "Erro:";
            lblNewCatErro.UseMnemonic = false;
            lblNewCatErro.Visible = false;
            // 
            // lblAltCatNameErro
            // 
            lblAltCatNameErro.AutoSize = true;
            lblAltCatNameErro.ForeColor = Color.Red;
            lblAltCatNameErro.Location = new Point(49, 162);
            lblAltCatNameErro.Name = "lblAltCatNameErro";
            lblAltCatNameErro.Size = new Size(31, 15);
            lblAltCatNameErro.TabIndex = 55;
            lblAltCatNameErro.Text = "Erro:";
            lblAltCatNameErro.UseMnemonic = false;
            lblAltCatNameErro.Visible = false;
            // 
            // LojaAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 585);
            Controls.Add(lblAltCatNameErro);
            Controls.Add(lblNewCatErro);
            Controls.Add(btnAltCatName);
            Controls.Add(tbxAltCatName);
            Controls.Add(lblAltCatName);
            Controls.Add(btnCreateCat);
            Controls.Add(tbxNewCat);
            Controls.Add(lblNewCat);
            Controls.Add(btnReturn);
            Controls.Add(cbxCatSel);
            Controls.Add(btnDelete);
            Controls.Add(lblCatSel);
            Controls.Add(lblTitle);
            Controls.Add(pDefinicoes);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(814, 617);
            Name = "LojaAdmin";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Loja Admin";
            pDefinicoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgProdutos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion
        private Panel pDefinicoes;
        private Button btnReturn;
        private ComboBox cbxCatSel;
        private Label lblCatSel;
        private Label lblTitle;
        private DataGridView dgProdutos;
        private Button btnDelete;
        private Button btnDeleteProduct;
        private Button btnSave;
        private Button btnInsertProduct;
        private Label lblNewCat;
        private TextBox tbxNewCat;
        private Button btnCreateCat;
        private TextBox tbxAltCatName;
        private Label lblAltCatName;
        private Button btnAltCatName;
        private Label lblNewCatErro;
        private Label lblAltCatNameErro;
    }
}