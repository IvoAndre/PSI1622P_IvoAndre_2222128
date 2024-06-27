using Microsoft.Data.SqlClient;
using System.Data;

namespace Projeto2Ano
{
    /// <summary>
    /// Este form é exclusivo ao administrador e permite-o ver e alterar os valores das categorias e dos produtos da loja
    /// </summary>
    public partial class LojaAdmin : Form
    {
        private DataTable dtProdutos;

        public LojaAdmin()
        {
            InitializeComponent();
            Program.DetectTheme(this);
            if (Program.db.State != ConnectionState.Open)
            {
                Program.db.Open();
            }

            LoadCategories();
        }
        /// <summary>
        /// Carrega as categorias na <see cref="cbxCatSel"/>
        /// </summary>
        private void LoadCategories()
        {
            Program.dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    cmd.Connection = Program.db;
                    cmd.CommandText = "SELECT name, id FROM [shop_categories]";
                    Program.da = new SqlDataAdapter(cmd);
                    Program.da.Fill(Program.dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            DataRow newRow = Program.dt.NewRow();
            newRow["name"] = "Nenhuma Categoria Selecionada";
            Program.dt.Rows.InsertAt(newRow, 0);

            cbxCatSel.DisplayMember = "name";
            cbxCatSel.ValueMember = "id";
            cbxCatSel.DataSource = Program.dt;
            cbxCatSel.SelectedIndex = 0;
        }
        /// <summary>
        /// Carregas os produtos da categoria selecionada na <see cref="dgProdutos"/>
        /// </summary>
        /// <param name="catId"></param>
        private void LoadProducts(int catId)
        {
            dtProdutos = new DataTable();
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    cmd.Connection = Program.db;
                    cmd.CommandText = @"
                    SELECT 
                        imagepath AS 'Caminho da Imagem',
                        idprod AS 'ID Produto',
                        idcat AS 'ID Categoria',
                        catpos AS 'Posição Categoria', 
                        name AS 'Nome do Produto', 
                        description AS 'Descrição', 
                        stock AS 'Stock',
                        price AS 'Preço'
                    FROM shop_products
                    WHERE idcat = @idcat
                    ORDER BY catpos ASC";
                    cmd.Parameters.AddWithValue("@idcat", catId);
                    Program.da = new SqlDataAdapter(cmd);
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(Program.da);
                    Program.da.Fill(dtProdutos);

                    if (!dtProdutos.Columns.Contains("Imagem"))
                    {
                        DataColumn imageColumn = new DataColumn("Imagem", typeof(Image));
                        dtProdutos.Columns.Add(imageColumn);
                    }

                    foreach (DataRow row in dtProdutos.Rows)
                    {
                        string imagePath = Convert.ToString(row["Caminho da Imagem"]);
                        if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                        {
                            row["Imagem"] = Image.FromFile(imagePath);
                        }
                        else
                        {
                            row["Imagem"] = Image.FromFile("config\\noimage.png");
                        }
                    }


                    dgProdutos.DataSource = dtProdutos;
                    dgProdutos.Columns["Imagem"].DisplayIndex = 0;
                    dgProdutos.Columns["Caminho da Imagem"].Visible = false;
                    dgProdutos.Columns["ID Produto"].Visible = false;
                    dgProdutos.Columns["ID Categoria"].Visible = false;
                    dgProdutos.Columns["Posição Categoria"].Visible = false;
                    ((DataGridViewTextBoxColumn)dgProdutos.Columns["Nome do Produto"]).MaxInputLength = 100;
                    ((DataGridViewTextBoxColumn)dgProdutos.Columns["Descrição"]).MaxInputLength = 500;
                    dgProdutos.MinimumSize = new Size(pDefinicoes.Width, pDefinicoes.Height - btnSave.Height);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Mostra <see cref="pDefinicoes"/> e chama <see cref="LoadCategories"/> se for selecionada uma categoria 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxCatSel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCatSel.SelectedIndex > 0)
            {
                int catId = Convert.ToInt32(cbxCatSel.SelectedValue);
                LoadProducts(catId);
                pDefinicoes.Visible = true;
                tbxAltCatName.Clear();
                tbxAltCatName.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                dgProdutos.DataSource = null;
                pDefinicoes.Visible = false;
                tbxAltCatName.Clear();
                tbxAltCatName.Enabled = false;
                btnDelete.Enabled = false;
            }
        }
        /// <summary>
        /// Guarda as alterações efetuadas em <see cref="dgProdutos"/> na base de dados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            ContaConfirmarMessageBox confirmar = new ContaConfirmarMessageBox();
            confirmar.Closed += (s, args) => Show();
            confirmar.ShowDialog();
            if (confirmar.DialogResult == DialogResult.Continue)
            {
                try
                {
                    Program.da.Update(dtProdutos);
                    MessageBox.Show("Produtos atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    int catId = Convert.ToInt32(cbxCatSel.SelectedValue);
                    LoadProducts(catId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Apaga o produto selecionado na <see cref="dgProdutos"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgProdutos.SelectedRows)
            {
                dgProdutos.Rows.Remove(row);
            }
        }
        /// <summary>
        /// Insere um novo produto na <see cref="dgProdutos"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsertProduct_Click(object sender, EventArgs e)
        {
            if (cbxCatSel.SelectedIndex > 0)
            {
                DataRow newRow = dtProdutos.NewRow();
                newRow["ID Categoria"] = Convert.ToInt32(cbxCatSel.SelectedValue);
                newRow["Posição Categoria"] = 0;
                newRow["Imagem"] = Image.FromFile("config\\noimage.png");
                dtProdutos.Rows.Add(newRow);
            }
        }
        /// <summary>
        /// Apaga a categoria selecionada em <see cref="cbxCatSel"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cbxCatSel.SelectedIndex > 0)
            {
                ContaConfirmarMessageBox confirmar = new ContaConfirmarMessageBox();
                confirmar.Closed += (s, args) => Show();
                confirmar.ShowDialog();
                if (confirmar.DialogResult == DialogResult.Continue)
                {
                    int catId = Convert.ToInt32(cbxCatSel.SelectedValue);

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        try
                        {
                            cmd.Connection = Program.db;
                            cmd.CommandText = "DELETE FROM [shop_categories] WHERE id = @catid";
                            cmd.Parameters.AddWithValue("@catid", catId);
                            cmd.ExecuteNonQuery();
                            LoadCategories();
                            dgProdutos.DataSource = null;
                            MessageBox.Show("Categoria apagada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        
        /// <summary>
        /// Verifica se já existe uma categoria com o nome inserido se sim mostra um aviso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxNewCat_TextChanged(object sender, EventArgs e)
        {
            if (tbxNewCat.Text.Length == 0)
            {
                btnCreateCat.Enabled = false;
            }
            else if (tbxNewCat.Text.Length != 0)
            {
                btnCreateCat.Enabled = false;

                using (SqlCommand cmd = new SqlCommand("SELECT name FROM [shop_categories] WHERE name = @name", Program.db))
                {
                    cmd.Parameters.AddWithValue("@name", tbxNewCat.Text);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            Program.DisplaylblError(lblNewCatErro, "Já existe uma categoria com esta designação!");
                            btnCreateCat.Enabled = false;
                        }
                        else
                        {
                            btnCreateCat.Enabled = true;
                            lblNewCatErro.Visible = false;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Altera o foco para a textbox referente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblNewCat_Click(object sender, EventArgs e)
        {
            tbxNewCat.Focus();
        }
        /// <summary>
        /// Cria a categoria com o nome inserido em <see cref="tbxNewCat"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateCat_Click(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO [shop_categories] (name) VALUES (@name)", Program.db))
            {
                cmd.Parameters.AddWithValue("@name", tbxNewCat.Text.Trim());
                cmd.ExecuteNonQuery();

                MessageBox.Show("Categoria criada com sucesso!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategories();
            }
        }
        /// <summary>
        /// Seleciona a linha toda ao clicar numa célula e abre o diálogo de seleção de imagem caso uma célula de imagem seja clicada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgProdutos.Rows[e.RowIndex].Selected = true;
            }
            if (e.ColumnIndex == dgProdutos.Columns["Imagem"].Index && e.RowIndex >= 0)
            {

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Ficheiros de Imagem (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            string fileName = openFileDialog.FileName;
                            string fileExtension = Path.GetExtension(fileName);
                            int productId = Convert.ToInt32(dgProdutos.Rows[e.RowIndex].Cells["ID Produto"].Value);
                            string directoryPath = @"config\loja";


                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }

                            string imagePath = Path.Combine(directoryPath, $"Image{productId}{fileExtension}");
                            File.Copy(fileName, imagePath, true);


                            dgProdutos.Rows[e.RowIndex].Cells["Caminho da Imagem"].Value = imagePath;
                            dtProdutos.Rows[e.RowIndex]["Imagem"] = Image.FromFile(imagePath);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Guarde a tabela antes de inserir uma imagem nos produtos novos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Mostra as imagens corretamente na <see cref="dgProdutos"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgProdutos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dgProdutos.Columns["Imagem"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                Image img = (Image)e.Value;
                if (img != null)
                {
                    Rectangle rect = e.CellBounds;
                    float aspectRatio = (float)img.Width / img.Height;
                    int imgHeight = rect.Height - 4;
                    int imgWidth = (int)(imgHeight * aspectRatio);
                    int posX = rect.X + (rect.Width - imgWidth) / 2;
                    int posY = rect.Y + 2;
                    e.Graphics.DrawImage(img, new Rectangle(posX, posY, imgWidth, imgHeight));
                }
                e.Handled = true;
            }
        }
        /// <summary>
        /// Altera o tamanho de <see cref="dgProdutos"/> conforme o tamanho de <see cref="pDefinicoes"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pDefinicoes_SizeChanged(object sender, EventArgs e)
        {
            dgProdutos.MinimumSize = new Size(pDefinicoes.Width, pDefinicoes.Height - btnSave.Height);
        }
        /// <summary>
        /// Altera o nome da categoria selecionada em <see cref="cbxCatSel"/> com o nome inserido em <see cref="tbxAltCatName"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAltCatName_Click(object sender, EventArgs e)
        {
            bool catExists = false;
            using (SqlCommand cmd = new SqlCommand("SELECT name FROM [shop_categories] WHERE name = @name", Program.db))
            {
                cmd.Parameters.AddWithValue("@name", cbxCatSel.Text);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        catExists = true;
                    }
                }
            }
            if (catExists)
            {
                using (SqlCommand cmdUpdate = new SqlCommand("UPDATE [shop_categories] SET name = @newname WHERE name = @name", Program.db))
                {
                    cmdUpdate.Parameters.AddWithValue("@name", cbxCatSel.Text);
                    cmdUpdate.Parameters.AddWithValue("@newname", tbxAltCatName.Text);
                    cmdUpdate.ExecuteNonQuery();

                    MessageBox.Show("Nome da categoria alterado com sucesso!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategories();
                }
            }


        }
        /// <summary>
        /// Verifica se já existe uma categoria com o nome inserido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxAltCatName_TextChanged(object sender, EventArgs e)
        {
            if (tbxAltCatName.Text.Length == 0)
            {
                btnAltCatName.Enabled = false;
            }
            else if (tbxAltCatName.Text.Length != 0)
            {
                btnAltCatName.Visible = true;
                btnAltCatName.Enabled = false;

                using (SqlCommand cmd = new SqlCommand("SELECT name FROM [shop_categories] WHERE name = @name", Program.db))
                {
                    cmd.Parameters.AddWithValue("@name", tbxAltCatName.Text);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            Program.DisplaylblError(lblAltCatNameErro, "Já existe uma categoria com esta designação!");
                            btnAltCatName.Enabled = false;
                        }
                        else
                        {
                            btnAltCatName.Enabled = true;
                            lblAltCatNameErro.Visible = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Fecha o Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
