using Projeto2Ano;
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
    public partial class BancoPrincipal : Form
    {
        public BancoPrincipal()
        {
            InitializeComponent();
            Program.DetectTheme(this);
            lblTitle.Text = $"Bem Vindo {Program.user.Name}\nSelecione uma operação:\n";
            if (Program.db.State != ConnectionState.Open)
            {
                Program.db.Open();
            }


        }

        

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            Hide();
            BancoOpIO bancoOpIO = new BancoOpIO(true);
            bancoOpIO.Closed += (s, args) => Show();
            bancoOpIO.ShowDialog();
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            Hide();
            BancoOpIO bancoOpIO = new BancoOpIO(false);
            bancoOpIO.Closed += (s, args) => Show();
            bancoOpIO.ShowDialog();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {

        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {

        }

        private void btnAlterarPin_Click(object sender, EventArgs e)
        {
            Hide();
            BancoPIN bancoPIN = new BancoPIN(false);
            bancoPIN.ShowDialog();
            if(bancoPIN.DialogResult == DialogResult.Abort) 
            {
                Close();
            }
            else
            {
                Show();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
