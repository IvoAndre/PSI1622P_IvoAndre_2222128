using Microsoft.Data.SqlClient;
using System.Data;

namespace Projeto2Ano
{
    public partial class ContaCriar : Form
    {
        
        public ContaCriar()
        {
            InitializeComponent();
            Program.DetectTheme(this);
            lblErro.ForeColor = Color.Red;

            if (Program.db.State != ConnectionState.Open)
            {
                Program.db.Open();
            }

            KeyDown += ContaCriar_KeyDown;
        }

        private void ContaCriar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btnCriar.Enabled)
                {
                    btnCriar.Select();
                }
                e.Handled = true;
            }
        }

        

        private void DisplaylblError(string Erro)
        {
            lblErro.Visible = true;
            lblErro.Text = Erro;
        }
        private void VerifyTxtbxs()
        {
            if (tbxName.Text.Length == 0 || tbxUsername.Text.Length == 0 || tbxPass.Text.Length == 0 || tbxRepPass.Text.Length == 0)
            {
                btnCriar.Enabled = false;
                DisplaylblError("Tem de preencher todos os campos obrigatórios. (*)");
            }
            else if (!Program.IsUsernameUnique(tbxUsername.Text))
            {
                btnCriar.Enabled = false;
                DisplaylblError("Este Nome de Utilizador já está a ser utilizado!");
            }
            else if (tbxPass.Text != tbxRepPass.Text)
            {
                btnCriar.Enabled = false;
                DisplaylblError("As palavras-passe devem ser iguais.");
            }
            else
            {
                lblErro.Visible = false;
                btnCriar.Enabled = true;
            }
        }

        //lblFocustbx
        private void lbltbxName_Click(object sender, EventArgs e)
        {
            tbxName.Focus();
        }

        private void lbltbxUsername_Click(object sender, EventArgs e)
        {
            tbxUsername.Focus();
        }

        private void lbltbxPass_Click(object sender, EventArgs e)
        {
            tbxPass.Focus();
        }

        private void lbltbxRepPass_Click(object sender, EventArgs e)
        {
            tbxRepPass.Focus();
        }

        //verifytxbxs when textchanges
        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            VerifyTxtbxs();
        }

        private void tbxUsername_TextChanged(object sender, EventArgs e)
        {
            VerifyTxtbxs();
        }

        private void tbxPass_TextChanged(object sender, EventArgs e)
        {
            VerifyTxtbxs();
        }

        private void tbxRepPass_TextChanged(object sender, EventArgs e)
        {
            VerifyTxtbxs();
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = Program.db;

                cmdInsert.CommandText = "INSERT INTO users (name,username,password) VALUES (@name,@username,@password)";

                cmdInsert.Parameters.Add("@name", SqlDbType.VarChar).Value = tbxName.Text;
                cmdInsert.Parameters.Add("@username", SqlDbType.VarChar).Value = tbxUsername.Text;
                cmdInsert.Parameters.Add("@password", SqlDbType.VarChar).Value = Crypt.Hash(tbxPass.Text);


                cmdInsert.ExecuteNonQuery();

                MessageBox.Show("Conta criada com sucesso!\nInicie a sessão para entrar no programa.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally 
            { 
                Close();
            }

        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if(chkShowPass.Checked)
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
    }
}