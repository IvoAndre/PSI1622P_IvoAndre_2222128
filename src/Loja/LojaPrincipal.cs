using Microsoft.Data.SqlClient;
using System.Data;

namespace Projeto2Ano
{
    public partial class LojaPrincipal : Form
    {
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
            Program.loja.numberOfCategories = GetNumberOfCategories();
            if (Program.loja.numberOfCategories == 0)
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

        private void LojaPrincipal_Load(object sender, EventArgs e)
        {
            if (!CouldLoad)
            {
                Close();
            }
        }

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

        private void AddProductToFlowLayout(int productId,string name, string description, double price, int stock, string imagePath, int categoryId, int productPosition)
        {
            Panel productPanel = new Panel
            {
                Width = 360,
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
                Size = new Size(230, 80),
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
                Location = new Point(300, 130),
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
