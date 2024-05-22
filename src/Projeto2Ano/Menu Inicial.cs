namespace Projeto2Ano
{
    public partial class MenuInicial : Form
    {
        private const string AdminCode = "WWSSADADBA"; // Konami code sequence
        private int currentKeyIndex = 0; // Index to keep track of the current key in the Konami code sequence


        public MenuInicial()
        {
            InitializeComponent();
            Program.DetectTheme(this);

            KeyPreview = true;
            KeyPress += MenuInicial_KeyPress;
        }

        private void MenuInicial_KeyPress(object sender, KeyPressEventArgs e)
        {


            char pressedKeyUpper = char.ToUpper(e.KeyChar);
            char adminCode = AdminCode[currentKeyIndex];


            if (pressedKeyUpper == adminCode)
            {
                currentKeyIndex++;

                if (currentKeyIndex == AdminCode.Length)
                {
                    lblTitle.Text = "Parabéns!";
                    currentKeyIndex = 0; 
                }
                else
                {
                    //lblTitle.Text = $"Pressed Key: {e.KeyChar}";
                }
            }
            else
            {
                currentKeyIndex = 0;
                //lblTitle.Text = $"Pressed Key: {e.KeyChar}";
            }
        }



        private void menuDefinicoes_Click(object sender, EventArgs e)
        {
            Definicoes definicoes = new Definicoes();
            definicoes.Closed += (s, args) =>
            {
                Program.DetectTheme(this);
                
                Focus();
            };
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