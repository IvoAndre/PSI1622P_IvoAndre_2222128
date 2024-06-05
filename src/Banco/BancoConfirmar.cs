using Microsoft.Data.SqlClient;
using Projeto2Ano.Conta;
using System;
using System.Data;
using System.Text;

namespace Projeto2Ano
{
    public partial class BancoConfirmar : Form
    {
        bool IsEnterOp = false;
        public BancoConfirmar(bool isEnterOp)
        {
            InitializeComponent();
            Program.DetectTheme(this);
            lblErro.ForeColor = Color.Red;
            IsEnterOp = isEnterOp;
            if (IsEnterOp)
            {
                lblTitle.Text = "Entrar na Conta";
                btnOption.Text = "Entrar";
                btnReturn.Text = "Voltar";
            }
            else
            {
                lblTitle.Text = "Confirmar Operação";
                btnOption.Text = "Confirmar";
                btnReturn.Text = "Cancelar";
            }
            if (Program.db.State != ConnectionState.Open)
            {
                Program.db.Open();
            }

        }






        private void VerifyTxtbxs()
        {
            if (tbxPIN.Text.Length != 4)
            {
                btnOption.Enabled = false;
                Program.DisplaylblError(lblErro, "Tem de preencher todos os \ncampos obrigatórios. (*)");
            }
            else
            {
                lblErro.Visible = false;
                btnOption.Enabled = true;
            }
        }

        //tbxPINlogic

        private void lbltbxPIN_Click(object sender, EventArgs e)
        {
            tbxPIN.Focus();
        }

        private void tbxPIN_TextChanged(object sender, EventArgs e)
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


        private void btnReturn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void btnOption_Click(object sender, EventArgs e)
        {
            string hash = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Program.db;
                cmd.CommandText = "SELECT pin FROM [bank_accounts] WHERE userid = @userid";
                cmd.Parameters.AddWithValue("@userid", Program.user.ID);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            hash = dr["pin"].ToString();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (Crypt.Verify(tbxPIN.Text, hash))
                {
                    if (IsEnterOp)
                    {
                        DialogResult = DialogResult.Continue;
                        Hide();
                        BancoPrincipal bancoPrincipal = new BancoPrincipal();
                        bancoPrincipal.Closed += (s, args) => Close();
                        bancoPrincipal.ShowDialog();
                    }
                    else
                    {
                        DialogResult = DialogResult.Continue;
                        Close();
                    }
                }
                else
                {
                    Program.DisplaylblError(lblErro, "O PIN está incorreto.");
                }
                    
            }
        }


        private void chkShowPIN_CheckedChanged(object sender, EventArgs e)
        {
            tbxPIN.UseSystemPasswordChar = !chkShowPIN.Checked;
        }

        
    }
}