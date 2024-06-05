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
    public partial class BancoAdmin : Form
    {
        public BancoAdmin()
        {
            InitializeComponent();
            Program.DetectTheme(this);
            Program.DetectTheme(pDefinicoes);
            if (Program.db.State != ConnectionState.Open)
            {
                Program.db.Open();
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
