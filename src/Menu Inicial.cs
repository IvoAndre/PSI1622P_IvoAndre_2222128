using System.Data;

namespace Projeto2Ano
{
    /// <summary>
    /// Menu Inicial do Programa: Este é o primeiro menu que o utilizador vê, nele o utilizador pode criar uma conta, entrar numa conta ou sair do programa. O modo de administrador é acedido ao premir uma sequência de teclas.
    /// </summary>
    public partial class MenuInicial : Form
    {
        /// <summary>
        /// Sequência de teclas para ativar o modo de administrador
        /// </summary>
        private const string AdminCode = "WWSSADADBA";
        /// <summary>
        /// Indica a posição em que o utilizador está na sequência do <see cref="AdminCode"/>
        /// </summary>
        private int currentKeyIndex = 0;


        public MenuInicial()
        {
            InitializeComponent();
            Program.DetectTheme(this);
            if (Program.db.State != ConnectionState.Open)
            {
                Program.db.Open();
            }
            VerifyUsers();
            Program.adminMode = false;
        }

        /// <summary>
        /// Ativa o modo de administrador, define o utilizador atual como Admin e abre o <see cref="MenuPrincipal"/>
        /// </summary>
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

        /// <summary>
        /// Recebe as teclas premidas pelo o utilizador e verifica se corresponde a <see cref=" AdminCode"/> 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    //lblTitle.Text = "Parabéns!"; debug
                    currentKeyIndex = 0; 
                }
                else
                {
                    //lblTitle.Text = $"Pressed Key: {e.KeyChar}"; debug
                }
            }
            else
            {
                currentKeyIndex = 0;
                //lblTitle.Text = $"Pressed Key: {e.KeyChar}"; debug
            }
        }


        /// <summary>
        /// Abre <see cref="Definicoes"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Abre <see cref="ContaCriar"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCriar_Click(object sender, EventArgs e)
        {
            Hide();
            ContaCriar contaCriar = new ContaCriar();
            contaCriar.Closed += (s, args) =>
            {
                Program.DetectTheme(this);
                VerifyUsers();
                Show();
            };
            contaCriar.ShowDialog();
        }
        /// <summary>
        /// Abre <see cref="ContaEntrar"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Hide();
            ContaEntrar contaEntrar = new ContaEntrar();
            contaEntrar.Closed += (s, args) => 
            {
                Program.DetectTheme(this);
                VerifyUsers();
                Show();
            };
            contaEntrar.ShowDialog();
        }

        /// <summary>
        /// Fecha o Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Ativa/Desativa o <see cref="btnEntrar"/> e altera o texto de <see cref="lblTitle"/> conforme o retorno do <see cref="Program.VerifyUsers"/>
        /// </summary>
        private void VerifyUsers()
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