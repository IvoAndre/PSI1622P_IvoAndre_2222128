using Microsoft.Data.SqlClient;
using System.Data;

namespace Projeto2Ano
{
    public partial class BancoPIN : Form
    {
        bool IsNew = false;
        public BancoPIN(bool isNew)
        {
            InitializeComponent();
            Program.DetectTheme(this);
            IsNew = isNew;
            if (IsNew)
            {
                lblTitle.Text = "Criação de Conta";
                btnOption.Text = "Criar Conta";
            }
            else
            {
                lblTitle.Text = "Alterar PIN";
                btnOption.Text = "Confirmar";
                lbltbxPIN.Text = "Novo PIN* \n(4 Dígitos)";
                btnDelete.Visible = true;
            }
            if (Program.db.State != ConnectionState.Open)
            {
                Program.db.Open();
            }

        }






        private void VerifyTxtbxs()
        {
            if (tbxPIN.Text.Length != 4 || tbxRepPIN.Text.Length != 4)
            {
                btnOption.Enabled = false;
                Program.DisplaylblError(lblErro, "Tem de preencher todos os \ncampos obrigatórios. (*)");
            }
            else if (tbxPIN.Text != tbxRepPIN.Text)
            {
                btnOption.Enabled = false;
                Program.DisplaylblError(lblErro, "Os PINs devem ser iguais.");
            }
            else
            {
                lblErro.Visible = false;
                btnOption.Enabled = true;
            }
        }

        //lblFocustbx

        private void lbltbxPIN_Click(object sender, EventArgs e)
        {
            tbxPIN.Focus();
        }

        private void lbltbxRepPIN_Click(object sender, EventArgs e)
        {
            tbxRepPIN.Focus();
        }

        //verifytxbxs when textchanges

        private void tbxPIN_TextChanged(object sender, EventArgs e)
        {
            VerifyTxtbxs();
        }

        private void tbxRepPIN_TextChanged(object sender, EventArgs e)
        {
            VerifyTxtbxs();
        }

        private void tbxPIN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnOption_Click(object sender, EventArgs e)
        {
            if (IsNew)
            {
                try
                {
                    SqlCommand cmdInsert = new SqlCommand();
                    cmdInsert.Connection = Program.db;

                    cmdInsert.CommandText = "INSERT INTO [bank_accounts] (userid,pin,saldo,IBAN) VALUES (@userid,@pin,@saldo,@IBAN)";

                    cmdInsert.Parameters.Add("@userid", SqlDbType.Int).Value = Program.user.ID;
                    cmdInsert.Parameters.Add("@pin", SqlDbType.VarChar).Value = Crypt.Hash(tbxPIN.Text);
                    cmdInsert.Parameters.Add("@saldo", SqlDbType.Float).Value = 0;
                    cmdInsert.Parameters.Add("@IBAN", SqlDbType.VarChar).Value = GenerateUniqueIban();


                    cmdInsert.ExecuteNonQuery();

                    MessageBox.Show("Conta criada com sucesso!\nInicie a sessão para entrar na conta.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);


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
            else
            {
                BancoConfirmar confirmar = new BancoConfirmar(false);
                confirmar.Closed += (s, args) => Show();
                confirmar.ShowDialog();
                if (confirmar.DialogResult == DialogResult.Continue)
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = Program.db;

                            cmd.CommandText = $"UPDATE [bank_accounts] SET PIN=@value WHERE userid = @userid";
                            cmd.Parameters.Add("@value", SqlDbType.VarChar).Value = Crypt.Hash(tbxPIN.Text);
                            cmd.Parameters.Add("@userid", SqlDbType.Int).Value = Program.user.ID;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    MessageBox.Show("PIN alterado com sucesso!\nPor favor volte a iniciar sessão.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.Abort;
                    Close();
                }
            }
        }

        private void chkShowPIN_CheckedChanged(object sender, EventArgs e)
        {
            tbxPIN.UseSystemPasswordChar = !chkShowPIN.Checked;
            tbxRepPIN.UseSystemPasswordChar = !chkShowPIN.Checked;
        }

        private static string GenerateUniqueIban()
        {
            string iban;
            do
            {
                string IBANstart = "PT5013694200";
                Random random = new Random();
                string accountNumber = random.Next(100000000, 1000000000).ToString();
                iban = IBANstart + accountNumber;
            } while (!IsIBANUnique(iban));
            return iban;
        }

        private static bool IsIBANUnique(string IBAN)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = Program.db;
                cmd.CommandText = "SELECT IBAN FROM [bank_accounts] WHERE IBAN = @IBAN";
                cmd.Parameters.AddWithValue("@IBAN", IBAN);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
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
                    cmd.CommandText = "DELETE FROM [bank_accounts] WHERE userid = @userid";
                    cmd.Parameters.Add("@userid", SqlDbType.VarChar).Value = Program.user.ID;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Conta apagada com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.Abort;
                    Close();

                }
            }
        }

        
    }
}