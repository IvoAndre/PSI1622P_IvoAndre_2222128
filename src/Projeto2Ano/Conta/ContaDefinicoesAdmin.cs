using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Projeto2Ano.Conta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto2Ano
{
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
            cbxContaSel.DisplayMember = "username";
            cbxContaSel.ValueMember = "username";
            cbxContaSel.DataSource = Program.dt;
        }

        private void cbxContaSel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxContaSel.SelectedIndex != -1)
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

        private void DisplaylblError(Control lblErro, string Erro)
        {
            lblErro.ForeColor = Color.Red;
            lblErro.Visible = true;
            lblErro.Text = Erro;
        }

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
                    DisplaylblError(lblErroUsername, "Este nome de utilizador já está a ser utilizado.");
                }
            }
        }

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
                    DisplaylblError(lblErroPass, "As Palavras-passe não coincidem.");
                }
            }
        }
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


        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }


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

       
    }
}
