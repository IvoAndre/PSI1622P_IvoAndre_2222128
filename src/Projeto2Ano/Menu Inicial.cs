namespace Projeto2Ano
{
    public partial class MenuInicial : Form
    {
        public MenuInicial()
        {
            InitializeComponent();
            BackColor = Program.backcolor;
            ForeColor = Program.forecolor;
        }

        private void menuDefinicoes_Click(object sender, EventArgs e)
        {
            Definicoes definicoes = new Definicoes();
            definicoes.Closed += (s, args) => Focus();
            definicoes.ShowDialog();
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            Hide();
            ContaCriar contaCriar = new ContaCriar();
            contaCriar.Closed += (s, args) => Show();
            contaCriar.ShowDialog();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Hide();
            /*Form1 form1 = new Form1();
            form1.Closed += (s, args) => Show();
            form1.ShowDialog();*/
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}