using Microsoft.Data.SqlClient;
using System.Data;

namespace Projeto2Ano
{
    /// <summary>
    /// Este form é exclusivo ao administrador e permite alterar os dados das contas dos utilizadores
    /// </summary>
    public partial class ContaDefinicoesAdmin : Form
    {
        private string username;
        private string name;
        public ContaDefinicoesAdmin()
        {
            InitializeComponent();
            Program.DetectTheme(this);
            if (Program.db.State != ConnectionState.Open)
            {
                Program.db.Open();
            }
            LoadUsernames();
        }
        /// <summary>
        /// Carrega os nomes de utilizador na <see cref="cbxContaSel"/>
        /// </summary>
        private void LoadUsernames()
        {
            Program.dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    cmd.Connection = Program.db;
                    cmd.CommandText = "SELECT username FROM [users]";
                    Program.da = new SqlDataAdapter(cmd);
                    Program.da.Fill(Program.dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            DataRow newRow = Program.dt.NewRow();
            newRow["username"] = "Nenhuma Conta Selecionada";
            Program.dt.Rows.InsertAt(newRow, 0); 


            cbxContaSel.DisplayMember = "username";
            cbxContaSel.ValueMember = "username";
            cbxContaSel.DataSource = Program.dt;
            cbxContaSel.SelectedIndex = 0;
        }
        /// <summary>
        /// Mostra os dados da conta selecionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxContaSel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxContaSel.SelectedIndex == -1 || cbxContaSel.SelectedValue.ToString() == "Nenhuma Conta Selecionada")
            {
                lbltbxName.Text = "Nome Atual: {name}"; 
                lbltbxUsername.Text = "Nome de Utilizador Atual: {username}"; 
                pDefinicoes.Visible = false; 
            }
            else
            {
                username = cbxContaSel.Text;

                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Program.db;
                    cmd.CommandText = "SELECT * FROM users WHERE username COLLATE Latin1_General_BIN = @username";
                    cmd.Parameters.AddWithValue("@username", username);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                name = dr["Name"].ToString();
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                lbltbxName.Text = $"Nome Atual: {name}";
                lbltbxUsername.Text = $"Nome de Utilizador Atual: {username}";
                pDefinicoes.Visible = true;

            }
        }


        /// <summary>
        /// Altera o nome da conta selecionada em <see cref="cbxContaSel"/> com o nome inserido em <see cref="tbxName"/> após confirmação em <see cref="ContaConfirmarMessageBox"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAlterarName_Click(object sender, EventArgs e)
        {
            if (tbxName.Text.Length != 0)
            {
                ContaConfirmarMessageBox confirmar = new ContaConfirmarMessageBox();
                confirmar.Closed += (s, args) => Show();
                confirmar.ShowDialog();
                if (confirmar.DialogResult == DialogResult.Continue)
                {
                    UpdateDatabaseValue("name", tbxName.Text);
                    name = tbxName.Text;
                    MessageBox.Show("Nome alterado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lbltbxName.Text = $"Nome Atual: {name}";
                    Refresh();
                }
            }
        }
        /// <summary>
        /// Altera o nome de utilizador da conta selecionada em <see cref="cbxContaSel"/> com o nome de utilizador inserido em <see cref="tbxUsername"/> após confirmação em <see cref="ContaConfirmarMessageBox"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAlterarUsername_Click(object sender, EventArgs e)
        {
            if (tbxUsername.Text.Length != 0)
            {

                if (Program.IsUsernameUnique(tbxUsername.Text))
                {
                    ContaConfirmarMessageBox confirmar = new ContaConfirmarMessageBox();
                    confirmar.Closed += (s, args) => Show();
                    confirmar.ShowDialog();
                    if (confirmar.DialogResult == DialogResult.Continue)
                    {
                        UpdateDatabaseValue("username", tbxUsername.Text);
                        username = tbxUsername.Text;
                        MessageBox.Show("Nome de utilizador alterado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lbltbxUsername.Text = $"Nome de Utilizador Atual: {username}";
                        LoadUsernames();
                        Refresh();
                    }
                }
                else
                {
                    Program.DisplaylblError(lblErroUsername, "Este nome de utilizador já está a ser utilizado.");
                }
            }
        }
        /// <summary>
        /// Altera a palavra-passe da conta selecionada em <see cref="cbxContaSel"/> com a palavra-passe inserida em <see cref="tbxPass"/> após confirmação em <see cref="ContaConfirmarMessageBox"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAlterarPassword_Click(object sender, EventArgs e)
        {
            if (tbxPass.Text.Length != 0 && tbxRepPass.Text.Length != 0)
            {
                if (tbxPass.Text == tbxRepPass.Text)
                {
                    ContaConfirmarMessageBox confirmar = new ContaConfirmarMessageBox();
                    confirmar.Closed += (s, args) => Show();
                    confirmar.ShowDialog();
                    if (confirmar.DialogResult == DialogResult.Continue)
                    {
                        UpdateDatabaseValue("password", Crypt.Hash(tbxPass.Text));
                        MessageBox.Show("Palavra-passe alterada com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    Program.DisplaylblError(lblErroPass, "As Palavras-passe não coincidem.");
                }
            }
        }
        /// <summary>
        /// Alterna a visibilidade das palavras-passe das <see cref="tbxPass"/> e <see cref="tbxRepPass"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass.Checked)
            {
                tbxPass.UseSystemPasswordChar = false;
                tbxRepPass.UseSystemPasswordChar = false;
            }
            else
            {
                tbxPass.UseSystemPasswordChar = true;
                tbxRepPass.UseSystemPasswordChar = true;
            }
        }

        /// <summary>
        /// Apaga a conta selecionada em <see cref="cbxContaSel"/> após confirmação em <see cref="ContaConfirmarMessageBox"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            ContaConfirmarMessageBox confirmar = new ContaConfirmarMessageBox();
            confirmar.Closed += (s, args) => Show();
            confirmar.ShowDialog();
            if (confirmar.DialogResult == DialogResult.Continue)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Program.db;
                    cmd.CommandText = "DELETE FROM users WHERE username COLLATE Latin1_General_BIN = @username";
                    cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Conta apagada com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Refresh();
                    if (Program.VerifyUsers())
                    {
                        LoadUsernames();
                    }
                    else
                    {
                        Close();
                    }

                }
            }
        }
        /// <summary>
        /// Altera o valor indicado com o novo valor
        /// </summary>
        /// <param name="valueName">Valor a alterar</param>
        /// <param name="value">Novo Valor</param>
        private void UpdateDatabaseValue(string valueName, string value)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Program.db;

                    cmd.CommandText = $"UPDATE users SET {valueName}=@value WHERE username COLLATE Latin1_General_BIN = @username";
                    cmd.Parameters.Add("@value", SqlDbType.VarChar).Value = value;
                    cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
