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
    public partial class BancoInicial : Form
    {
        private bool HasAccount = false;
        public BancoInicial()
        {
            InitializeComponent();
            Program.DetectTheme(this);
            if (Program.db.State != ConnectionState.Open)
            {
                Program.db.Open();
            }


            BtnTexts();

        }

        private void BtnTexts()
        {
            if (Program.adminMode)
            {
                btnContinue.Text = "Gerir Contas";
            }
            else
            {
                HasAccount = Program.VerifyBankAccount();
                if (HasAccount)
                {
                    btnContinue.Text = "Entrar na Conta";
                }
                else
                {
                    btnContinue.Text = "Criar Conta";
                }
            }
            Refresh();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (Program.adminMode)
            {
                Hide();
                BancoAdmin bancoAdmin = new BancoAdmin();
                bancoAdmin.Closed += (s, args) => Show();
                bancoAdmin.ShowDialog();
            }
            else
            {
                if (HasAccount)
                {
                    Hide();
                    BancoConfirmar bancoEntrar = new BancoConfirmar(true);
                    bancoEntrar.Closed += (s, args) => {
                        BtnTexts();
                        Show(); 
                    };
                    bancoEntrar.ShowDialog();
                }
                else
                {
                    Hide();
                    BancoPIN bancoCriar = new BancoPIN(true);
                    bancoCriar.Closed += (s, args) => {
                        BtnTexts();
                        
                        Show(); 
                    };
                    bancoCriar.ShowDialog();
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
