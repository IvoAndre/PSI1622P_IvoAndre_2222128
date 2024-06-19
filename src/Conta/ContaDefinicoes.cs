using Microsoft.Data.SqlClient;
using System.Data;

namespace Projeto2Ano
{
    public partial class ContaDefinicoes : Form
    {
        private bool PasswordAltered = false;
        public ContaDefinicoes()
        {
            InitializeComponent();
            Program.DetectTheme(this);

            if (Program.adminMode)
            {
                Hide();
                ContaDefinicoesAdmin contaDefinicoesAdmin = new ContaDefinicoesAdmin();
                contaDefinicoesAdmin.Closed += (s, args) => Show();
                contaDefinicoesAdmin.ShowDialog();
            }


            lbltbxName.Text = $"Nome Atual: {Program.user.Name}";
            lbltbxUsername.Text = $"Nome de Utilizador Atual: {Program.user.Username}";

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
                    Program.user.Name = tbxName.Text;
                    MessageBox.Show("Nome alterado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lbltbxName.Text = $"Nome Atual: {Program.user.Name}";
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
                        Program.user.Username = tbxUsername.Text;
                        MessageBox.Show("Nome de utilizador alterado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lbltbxUsername.Text = $"Nome de Utilizador Atual: {Program.user.Username}";
                        Refresh();
                    }
                }
                else
                {
                    Program.DisplaylblError(lblErroUsername, "Este nome de utilizador já está a ser utilizado.");
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
                        PasswordAltered = true;
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
                    cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = Program.user.Username;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Conta apagada com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.Abort;
                    Close();
                    
                }
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (PasswordAltered)
            {
                MessageBox.Show("Você vai ter que iniciar a sessão novamente pois alterou a palavra-passe.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.Abort;
            }
            else 
            {
                DialogResult = DialogResult.OK;
            }
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
                    cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = Program.user.Username;
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
