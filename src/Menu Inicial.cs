using System.Data;

namespace Projeto2Ano
{
    public partial class MenuInicial : Form
    {
        private const string AdminCode = "ADMIN";//"WWSSADADBA"; 
        private int currentKeyIndex = 0;


        public MenuInicial()
        {
            InitializeComponent();
            Program.DetectTheme(this);
            if (Program.db.State != ConnectionState.Open)
            {
                Program.db.Open();
            }
            VUsers();


            Program.adminMode = false;
            KeyPress += MenuInicial_KeyPress; 
        }
        private void AdminMode()
        {
                        
            Program.user.ID = -1;
            Program.user.Username = "Admin";
            Program.user.Name = "Administrador";
            Program.adminMode = true;
            Hide();
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            menuPrincipal.Closed += (s, args) => 
            {
                Program.DetectTheme(this);
                Program.adminMode = false;
                Show(); 
                
            };
            menuPrincipal.ShowDialog();
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
                    AdminMode();
                    //lblTitle.Text = "Parabéns!";
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
            Hide();
            Definicoes definicoes = new Definicoes();
            definicoes.Closed += (s, args) =>
            {
                Program.DetectTheme(this);
                Show();
            };
            definicoes.ShowDialog();
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            Hide();
            ContaCriar contaCriar = new ContaCriar();
            contaCriar.Closed += (s, args) =>
            {
                Program.DetectTheme(this);
                VUsers();
                Show();
            };
            contaCriar.ShowDialog();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Hide();
            ContaEntrar contaEntrar = new ContaEntrar();
            contaEntrar.Closed += (s, args) => 
            {
                Program.DetectTheme(this);
                VUsers();
                Show();
            };
            contaEntrar.ShowDialog();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void VUsers()
        {
            if (Program.VerifyUsers())
            {
                btnEntrar.Enabled = true;
                lblTitle.Text = "Selecione uma opção:";
            }
            else
            {
                btnEntrar.Enabled = false;
                lblTitle.Text = "Crie uma conta:";
            }
        }


        
    }
}