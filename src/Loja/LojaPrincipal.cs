using Microsoft.Data.SqlClient;
using System.Data;

namespace Projeto2Ano
{
    /// <summary>
    /// Este form é o menu principal da loja aqui aparecem os produtos para o utilizador os adicionar ao carrinho
    /// </summary>
    public partial class LojaPrincipal : Form
    {
        /// <summary>
        /// Mantém-se true se o form carregar corretamente, caso contrário um erro é mostrado
        /// </summary>
        bool CouldLoad = true;

        public LojaPrincipal()
        {
            InitializeComponent();
            Program.DetectTheme(this);

            if (Program.db.State != ConnectionState.Open)
            {
                Program.db.Open();
            }

            Program.loja.paidQuantityBank = 0;
            Program.loja.paidQuantityMoney = 0;

            if (GetNumberOfCategories() == 0)
            {
                MessageBox.Show("Erro: Nenhuma categoria foi encontrada.\nPede ajuda ao administrador.", "Erro Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Abort;
                Close();
                return;
            }
            
            Program.loja.ProductQuantity = new Dictionary<int, Dictionary<int, int>>();
            LoadCategories();
            cbxCatSel.SelectedIndex = 0;

            if (cbxCatSel.Items.Count == 0)
            {
                MessageBox.Show("Erro: Nenhuma categoria com produtos foi encontrada.\nPede ajuda ao administrador.", "Erro Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Abort;
                Close();
                return;
            }
        }

        /// <summary>
        /// Verifica se o form carregou corretamente, se não é fechado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LojaPrincipal_Load(object sender, EventArgs e)
        {
            if (!CouldLoad)
            {
                Close();
            }
        }

        /// <summary>
        /// Abre <see cref="LojaCarrinho"></see>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCart_Click(object sender, EventArgs e)
        {
            LojaCarrinho lojaCarrinho = new LojaCarrinho();
            lojaCarrinho.ShowDialog();
            if (lojaCarrinho.DialogResult != DialogResult.OK)
            {
                LoadProducts(cbxCatSel.SelectedIndex);
                Show();
            }
            else
            {
                Close();
            }
        }
        /// <summary>
        /// Fecha o Form, se o utilizador tiver itens no seu carrinho é mostrado um aviso.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (Program.loja.ProductQuantity.Any(outerKvp => outerKvp.Value.Any(innerKvp => innerKvp.Value >0 ))) 
            {
                DialogResult result = MessageBox.Show("Tem a certeza que pretende sair da Loja?\nO seu carrinho não ficará salvo!", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Close();
                }
            }
            else
            {
                Close();
            }
            
        }
        /// <summary>
        /// Carrega as categorias da loja guardadas na base de dados na combobox <see cref="cbxCatSel"/>
        /// </summary>
        private void LoadCategories()
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SELECT c.id, c.name FROM shop_categories c WHERE EXISTS (SELECT 1 FROM shop_products p WHERE p.idcat = c.id)", Program.db))
                {
                    using (Program.dr = command.ExecuteReader())
                    {
                        cbxCatSel.Items.Add(new ComboBoxItem("Nenhuma Categoria Selecionada", 0));
                        while (Program.dr.Read())
                        {
                            cbxCatSel.Items.Add(new ComboBoxItem(Program.dr["name"].ToString(), (int)Program.dr["id"]));
                        }
                    }
                }

                if (cbxCatSel.Items.Count == 0)
                {
                    MessageBox.Show("Erro: Nenhuma categoria com produtos foi encontrada.\nPede ajuda ao administrador.", "Erro Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.Abort;
                    CouldLoad = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro a carregar categorias: " + ex.Message);
                DialogResult = DialogResult.Abort;
                CouldLoad = false;
            }
        }
        /// <summary>
        /// Carrega os produtos da categoria selecionada na <see cref="cbxCatSel"/> em panels usando <see cref="AddProductToFlowLayout(int, string, string, double, int, string, int, int)"/> no <see cref="flpProductsList"/>
        /// </summary>
        /// <param name="categoryId"></param>
        private void LoadProducts(int categoryId)
        {
            flpProductsList.Controls.Clear();

            try
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM shop_products WHERE idcat = @CategoryId", Program.db))
                {
                    command.Parameters.AddWithValue("@CategoryId", categoryId);
                    using (Program.dr = command.ExecuteReader())
                    {
                        int productPosition = 0;
                        while (Program.dr.Read())
                        {
                            AddProductToFlowLayout(
                                (int)Program.dr["idprod"],
                                Program.dr["name"].ToString(),
                                Program.dr["description"].ToString(),
                                (double)Program.dr["price"],
                                (int)Program.dr["stock"],
                                Program.dr["imagepath"].ToString(),
                                categoryId,
                                productPosition
                            );
                            productPosition++;
                        }
                    }
                }
                Program.DetectTheme(this);
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar produtos: " + ex.Message);
            }
        }

        /// <summary>
        /// Obtém o número de categorias existentes na base de dados
        /// </summary>
        /// <returns>O número de categorias existentes na base de dados</returns>
        private int GetNumberOfCategories()
        {
            int numberOfCategories = 0;

            try
            {
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM shop_categories WHERE EXISTS (SELECT 1 FROM shop_products WHERE shop_products.idcat = shop_categories.id)", Program.db))
                {
                    numberOfCategories = (int)command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao obter o número de categorias: " + ex.Message);
            }

            return numberOfCategories;
        }

        /// <summary>
        /// Adiciona um productPanel a <see cref="flpProductsList"/>
        /// </summary>
        /// <param name="productId">ID do Produto</param>
        /// <param name="name">Nome do Produto</param>
        /// <param name="description">Descrição do Produto</param>
        /// <param name="price">Preço do Produto</param>
        /// <param name="stock">Stock do Produto</param>
        /// <param name="imagePath">Caminho da Imagem do Produto</param>
        /// <param name="categoryId">ID da Categoria</param>
        /// <param name="productPosition">Posição do Produto</param>
        private void AddProductToFlowLayout(int productId,string name, string description, double price, int stock, string imagePath, int categoryId, int productPosition)
        {
            Panel productPanel = new Panel
            {
                Width = 760,
                Height = 200,
                Padding = new Padding(0,10,0,10),
                Margin = new Padding(10),
                BorderStyle = BorderStyle.None,
            };

            PictureBox pictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(120, 180), //Ratio 2:3
                ImageLocation = imagePath,
                Location = new Point(0, 0)
            };
            productPanel.Controls.Add(pictureBox);

            Label labelName = new Label
            {
                Text = name,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(125, 10),
                AutoSize = true
            };
            productPanel.Controls.Add(labelName);

            Label labelDescription = new Label
            {
                Text = description.Length > 150 ? description.Substring(0, 150) + "..." : description,
                Font = new Font("Segoe UI", 10),
                Location = new Point(130, 30),
                Size = new Size(500, 80),
                AutoEllipsis = true
            };
            productPanel.Controls.Add(labelDescription);

            if (labelDescription.Text.Contains("..."))
            {
                LinkLabel linkShowMore = new LinkLabel
                {
                    Text = "Mostrar Mais...",
                    Font = new Font("Segoe UI", 10, FontStyle.Underline),
                    Location = new Point(130, 110)
                };
                linkShowMore.Click += (sender, e) => MessageBox.Show(description,"Descrição de " + name);
                productPanel.Controls.Add(linkShowMore);
            }


            Label labelPrice = new Label
            {
                Text = price.ToString("0.00") + "€",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                Location = new Point(130, 130),
                AutoSize = true
            };
            productPanel.Controls.Add(labelPrice);

            NumericUpDown numericUpDownQuantity = new NumericUpDown
            {
                Maximum = stock,
                Minimum = 0,
                Increment = 1,
                Tag = new Tuple<int, int>(categoryId, productId),
                Location = new Point(690, 130),
                DecimalPlaces = 0,
                Font = new Font("Segoe UI",15, FontStyle.Bold),
                Width = 60,
                Value = Program.loja.ProductQuantity.ContainsKey(categoryId) &&
                        Program.loja.ProductQuantity[categoryId].ContainsKey(productId) ?
                        Program.loja.ProductQuantity[categoryId][productId] : 0
            };
            numericUpDownQuantity.ValueChanged += numericUpDown_ValueChanged;
            productPanel.Controls.Add(numericUpDownQuantity);


            Label labelStock = new Label
            {
                Text = "Quantidade Disponível: " + stock,
                Font = new Font("Segoe UI", 10),
                Location = new Point(130, 170),
                AutoSize = true
            };
            productPanel.Controls.Add(labelStock);

            flpProductsList.Controls.Add(productPanel);
        }

        /// <summary>
        /// Altera os produtos mostrados conforme a seleção na <see cref="cbxCatSel"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxCatSel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCatSel.SelectedIndex != 0)
            {
                int categoryId = ((ComboBoxItem)cbxCatSel.SelectedItem).Value;
                LoadProducts(categoryId);
            }
            else
            {
                flpProductsList.Controls.Clear();
            }
        }

        /// <summary>
        /// Lida com os controlos numericUpDown dos produtos para guardar a quantidade escolhida dos produtos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (sender is NumericUpDown numericUpDown && numericUpDown.Tag is Tuple<int, int> identifiers)
            {
                int categoryId = identifiers.Item1;
                int productPosition = identifiers.Item2;

                if (!Program.loja.ProductQuantity.ContainsKey(categoryId))
                {
                    Program.loja.ProductQuantity[categoryId] = new Dictionary<int, int>();
                }

                if(numericUpDown.Value != 0 && numericUpDown.Value != null)
                Program.loja.ProductQuantity[categoryId][productPosition] = (int)numericUpDown.Value;
                else
                    Program.loja.ProductQuantity[categoryId].Remove(productPosition);

                if (Program.loja.ProductQuantity[categoryId].Count == 0)
                    Program.loja.ProductQuantity.Remove(categoryId);
            }

            int prodCount = 0;
            foreach (var category in Program.loja.ProductQuantity)
            {
                prodCount += Program.loja.ProductQuantity[category.Key].Count;
            }
                btnCart.Text = $"Carrinho ({prodCount})";
        }

        
    }


    /// <summary>
    /// É a classe usada para os itens da <see cref="LojaPrincipal.cbxCatSel"/>
    /// </summary>
    public class ComboBoxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public ComboBoxItem(string text, int value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
