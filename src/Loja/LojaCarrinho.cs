using Microsoft.Data.SqlClient;
using System.Data;

namespace Projeto2Ano
{
    public partial class LojaCarrinho : Form
    {
        public LojaCarrinho()
        {
            InitializeComponent();
            Program.DetectTheme(this);
            if (Program.db.State != ConnectionState.Open)
            {
                Program.db.Open();
            }
            LoadCartItems();
            lblTotal.Text = "Total: " + Program.UpdateTotal().ToString("0.00") + "€";
        }

        private void LoadCartItems()
        {
            if(Program.UpdateTotal() == 0)
            {
                btnCheckout.Enabled = false;
            }
            else
            {
                btnCheckout.Enabled = true;
            }


            Program.loja.ProductQuantity = OrderProductsById(Program.loja.ProductQuantity);

            flowLayoutPanelCart.Controls.Clear();

            Panel infoPanel = new Panel
            {
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                Width = flowLayoutPanelCart.Width - 30,
                Height = 75,
                Margin = new Padding(10, 0, 0, 0),
                BorderStyle = BorderStyle.None
            };

            Label infoLabelPictureBox = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 15, FontStyle.Bold),
                Size = new Size(50, 75), //Ratio 2:3
                Location = new Point(0, 0)
            };
            infoPanel.Controls.Add(infoLabelPictureBox);

            Label infoLabelName = new Label
            {
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                Text = "Nome do Produto",
                Font = new Font("Segoe UI", 15, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(infoLabelPictureBox.Width + 10, 0),
                Size = new Size(infoPanel.Width / 3, 75),
                MinimumSize = new Size(100, 75)
            };
            infoPanel.Controls.Add(infoLabelName);

            Label infoLabelQuantity = new Label
            {
                Text = "Qtd.",
                Font = new Font("Segoe UI", 15, FontStyle.Bold),
                Size = new Size(60, 75),
                MinimumSize = new Size(100, 75),
                Location = new Point(infoLabelPictureBox.Width + 10 + infoLabelName.Width + 20, 0),
                TextAlign = ContentAlignment.MiddleLeft,
            };
            infoPanel.Controls.Add(infoLabelQuantity);

            Label infoLabelPrice = new Label
            {
                Text = "€/un",
                Font = new Font("Segoe UI", 15, FontStyle.Bold),
                AutoSize = true,
                MinimumSize = new Size(100, 75),
                Location = new Point(infoLabelPictureBox.Width + 10 + infoLabelName.Width + 10 + infoLabelQuantity.Width + 10, 0),
                TextAlign = ContentAlignment.MiddleLeft,
            };
            infoPanel.Controls.Add(infoLabelPrice);


            Label infoLabelTotal = new Label
            {
                Text = "Total",
                Font = new Font("Segoe UI", 15, FontStyle.Bold),
                Location = new Point(infoLabelPictureBox.Width + 10 + infoLabelName.Width + 10 + infoLabelQuantity.Width + 10 + infoLabelPrice.Width + 10, 0),
                MinimumSize = new Size(100, 75),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleLeft
            };
            infoPanel.Controls.Add(infoLabelTotal);
            flowLayoutPanelCart.Controls.Add(infoPanel);

            foreach (var category in Program.loja.ProductQuantity)
            {
                int categoryId = category.Key;

                using (SqlCommand command = new SqlCommand("SELECT name FROM shop_categories WHERE id = @CategoryId", Program.db))
                {
                    command.Parameters.AddWithValue("@CategoryId", categoryId);
                    string categoryName = (string)command.ExecuteScalar();

                    Label lblCategory = new Label
                    {
                        Text = categoryName,
                        Font = new Font("Segoe UI", 20, FontStyle.Bold),
                        Size = new Size(flowLayoutPanelCart.Width - 100, 50),
                        Margin = new Padding(5, 10, 0, 0)
                    };
                    flowLayoutPanelCart.Controls.Add(lblCategory);
                }

                foreach (var product in category.Value)
                {
                    int productId = product.Key;
                    int quantity = product.Value;

                    if (quantity > 0)
                    {
                        using (SqlCommand command = new SqlCommand("SELECT name, price, imagepath, stock FROM shop_products WHERE idprod = @ProductId", Program.db))
                        {
                            command.Parameters.AddWithValue("@ProductId", productId);

                            using (Program.dr = command.ExecuteReader())
                            {
                                if (Program.dr.HasRows)
                                {
                                    while (Program.dr.Read())
                                    {
                                        string productName = Program.dr["name"].ToString();
                                        double price = (double)Program.dr["price"];
                                        string imagePath = Program.dr["imagepath"].ToString();
                                        int stock = (int)Program.dr["stock"];


                                        Panel productPanel = new Panel
                                        {
                                            Anchor = AnchorStyles.Left | AnchorStyles.Right,
                                            Width = flowLayoutPanelCart.Width - 30,
                                            Height = 75,
                                            Margin = new Padding(10, 0, 0, 0),
                                            BorderStyle = BorderStyle.None
                                        };

                                        PictureBox pictureBox = new PictureBox
                                        {
                                            SizeMode = PictureBoxSizeMode.Zoom,
                                            Size = new Size(50, 75), //Ratio 2:3
                                            ImageLocation = imagePath,
                                            Location = new Point(0, 0)
                                        };
                                        productPanel.Controls.Add(pictureBox);

                                        Label labelName = new Label
                                        {
                                            Anchor = AnchorStyles.Left | AnchorStyles.Right,
                                            Text = productName,
                                            Font = new Font("Segoe UI", 14, FontStyle.Bold),
                                            TextAlign = ContentAlignment.MiddleLeft,
                                            Location = new Point(pictureBox.Width + 10, 0),
                                            Size = new Size(productPanel.Width / 3, 75),
                                            MinimumSize = new Size(100, 75)
                                        };
                                        productPanel.Controls.Add(labelName);

                                        NumericUpDown numericUpDownQuantity = new NumericUpDown
                                        {
                                            Maximum = stock,
                                            Minimum = 1,
                                            Tag = new Tuple<int, int>(categoryId, productId),
                                            DecimalPlaces = 0,
                                            Font = new Font("Segoe UI", 15, FontStyle.Bold),
                                            Value = product.Value,
                                            Increment = 1,
                                            Location = new Point(pictureBox.Width + 10 + labelName.Width + 20, 20),
                                            Width = 60


                                        };
                                        numericUpDownQuantity.ValueChanged += numericUpDownQuantity_ValueChanged;
                                        productPanel.Controls.Add(numericUpDownQuantity);

                                        Label labelPrice = new Label
                                        {
                                            Text = price.ToString("0.00") + "€",
                                            Font = new Font("Segoe UI", 15, FontStyle.Bold),
                                            AutoSize = true,
                                            MinimumSize = new Size(100, 75),
                                            Location = new Point(pictureBox.Width + 10 + labelName.Width + 20 + numericUpDownQuantity.Width + 10, 0),
                                            TextAlign = ContentAlignment.MiddleCenter,
                                        };
                                        productPanel.Controls.Add(labelPrice);


                                        Label lblTotal = new Label
                                        {
                                            Text = (quantity * price).ToString("0.00") + "€",
                                            Font = new Font("Segoe UI", 15, FontStyle.Bold),
                                            Location = new Point(pictureBox.Width + 10 + labelName.Width + 20 + numericUpDownQuantity.Width + 10 + labelPrice.Width + 10, 0),
                                            MinimumSize = new Size(100, 75),
                                            AutoSize = true,
                                            TextAlign = ContentAlignment.MiddleCenter
                                        };
                                        productPanel.Controls.Add(lblTotal);

                                        Button btnRemove = new Button
                                        {
                                            Text = "X",
                                            Font = new Font("Segoe UI", 20, FontStyle.Bold),
                                            Location = new Point(pictureBox.Width + 10 + labelName.Width + 20 + numericUpDownQuantity.Width + 10 + labelPrice.Width + 10 + lblTotal.Width + 10, 25 / 2),
                                            Size = new Size(50, 50),
                                            Tag = new Tuple<int, int>(categoryId, productId),
                                            TextAlign = ContentAlignment.MiddleCenter

                                        };
                                        btnRemove.Click += btnRemove_Click;
                                        productPanel.Controls.Add(btnRemove);
                                        flowLayoutPanelCart.Controls.Add(productPanel);

                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        private void numericUpDownQuantity_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = sender as NumericUpDown;
            if (numericUpDown != null && numericUpDown.Tag is Tuple<int, int> identifiers)
            {
                int categoryId = identifiers.Item1;
                int productId = identifiers.Item2;

                Program.loja.ProductQuantity[categoryId][productId] = (int)numericUpDown.Value;

                Panel productPanel = numericUpDown.Parent as Panel;
                if (productPanel != null)
                {
                    using (SqlCommand command = new SqlCommand("SELECT price FROM shop_products WHERE idprod = @ProductId", Program.db))
                    {
                        command.Parameters.AddWithValue("@CategoryId", categoryId);
                        command.Parameters.AddWithValue("@ProductId", productId);
                        double price = (double)command.ExecuteScalar();

                        Label lblTotal = productPanel.Controls.OfType<Label>().Last();
                        lblTotal.Text = ((int)numericUpDown.Value * price).ToString("0.00") + "€";
                    }
                }

                lblTotal.Text = "Total: " + Program.UpdateTotal().ToString("0.00") + "€";
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Button btnRemove = sender as Button;
            if (btnRemove != null && btnRemove.Tag is Tuple<int, int> identifiers)
            {
                int categoryId = identifiers.Item1;
                int productId = identifiers.Item2;

                Program.loja.ProductQuantity[categoryId].Remove(productId);
                if (Program.loja.ProductQuantity[categoryId].Count == 0)
                {
                    Program.loja.ProductQuantity.Remove(categoryId);
                }

                LoadCartItems();
                lblTotal.Text = "Total: " + Program.UpdateTotal().ToString("0.00") + "€";
            }
        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }


        private static Dictionary<int, Dictionary<int, int>> OrderProductsById(Dictionary<int, Dictionary<int, int>> productQuantity)
        {
            Dictionary<int, Dictionary<int, int>> orderedProductQuantity = new Dictionary<int, Dictionary<int, int>>();

            foreach (var category in productQuantity)
            {
                int categoryId = category.Key;
                Dictionary<int, int> orderedProducts = category.Value.OrderBy(p => p.Key)
                                                                    .ToDictionary(p => p.Key, p => p.Value);
                orderedProductQuantity[categoryId] = orderedProducts;
            }

            return orderedProductQuantity;
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            LojaPagamento lojaPagamento = new LojaPagamento();
            lojaPagamento.ShowDialog();

            if (lojaPagamento.DialogResult == DialogResult.OK)
            {
                foreach (var category in Program.loja.ProductQuantity)
                {
                    foreach (var product in category.Value)
                    {
                        int productId = product.Key;
                        int quantity = product.Value;

                        UpdateStockInDatabase(productId, quantity);
                    }
                }

                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void UpdateStockInDatabase(int productId, int quantity)
        {
            string sqlUpdate = "UPDATE shop_products SET stock = stock - @Quantity WHERE idprod = @ProductId";

            using (SqlCommand command = new SqlCommand(sqlUpdate, Program.db))
            {
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@ProductId", productId);
                command.ExecuteNonQuery();
            }
        }

    }
}
