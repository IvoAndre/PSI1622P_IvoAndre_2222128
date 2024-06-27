using Microsoft.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace Projeto2Ano
{
    /// <summary>
    /// Classe de Criptografia
    /// </summary>
    public class Crypt
    {
        /// <summary>
        /// Faz o hash do input e devolve o hash em base64
        /// </summary>
        /// <param name="input">string a fazer hash</param>
        /// <returns>hash do input em base64</returns>
        public static string Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
        /// <summary>
        /// Verifica se o hash do input corresponde ao hash guardado
        /// </summary>
        /// <param name="input">String a verificar</param>
        /// <param name="hash">Hash obtido da base de dados</param>
        /// <returns>True se corresponder, False se não corresponder</returns>
        public static bool Verify(string input, string hash)
        {
            string inputHash = Hash(input);
            return inputHash == hash;
        }
    }

    /// <summary>
    /// Struct utilizado para guardar as informações do utilizador com sessão iniciada
    /// </summary>
    public struct User
    {
        /// <summary>
        /// ID do utilizador atual
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Nome do utilizador atual
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Nome de utilizador do utilizador atual
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Saldo da conta bancária do utilizador atual, se esta existir
        /// </summary>
        public string Saldo { get; set; }
    }

    /// <summary>
    /// Struct utilizado para guardar as informações necessárias para o funcionamento dos forms Loja
    /// </summary>
    public struct Loja
    {
        /// <summary>
        /// Este dicionário guarda as quantidades dos produtos no carrinho <br/><idcategoria,<idproduto,quantidade>>
        /// </summary>
        public Dictionary<int, Dictionary<int, int>> ProductQuantity;
        /// <summary>
        /// Preço total
        /// </summary>
        public double totalPrice; 
        /// <summary>
        /// Quantia paga em "Dinheiro"
        /// </summary>
        public double paidQuantityMoney; 
        /// <summary>
        /// Quantia paga pela conta bancária
        /// </summary>
        public double paidQuantityBank;
    }

    static class Program
    {
        /// <summary>
        /// <inheritdoc cref="User"/>
        /// </summary>
        public static User user = new();

        /// <summary>
        /// <inheritdoc cref="Loja"/>
        /// </summary>
        public static Loja loja = new();
        
        /// <summary>
        /// True se o utilizador atual é administrador<br/>False se o utilizador atual não é administrador
        /// </summary>
        public static bool adminMode = false;

        //Cores de tema padrão
        public static Color backcolor = Color.White;
        public static Color forecolor = Color.Black;
        public static Color altBackcolor = Color.LightGray;

        //Diretórios usados para guardar as configs e o tema selecionado
        public const string configFolder = "config";
        public const string themeFilePath = configFolder + @"\theme";

        //Componentes para manipulação de dados da base de dados usados por todo o programa
        //SqlConnection
        private static string _connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=Projeto_2_Ano;Trusted_Connection=True;TrustServerCertificate=True";
        public static SqlConnection db = new SqlConnection(_connectionString);
        //DataReader
        public static SqlDataReader dr;
        //DataTable
        public static DataTable dt;
        //DataAdapter
        public static SqlDataAdapter da;



        
        [STAThread]
        static void Main()
        {
            //Criar Base de dados se não existir
            CreateDatabase();
            CreateTables();
            CreateTrigger();
            InsertProducts();

            //Verificar se a base de dados está disponivel
            try
            {
                db.Open();
            } catch (Exception ex)
            {
                MessageBox.Show($"\nERRO:{ex.Message}", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            if (db.State == System.Data.ConnectionState.Open)
            {
                db.Close();
            }

            //Aplicar tema guardado se existir
            if (File.Exists(themeFilePath))
            {
                switch (File.ReadAllText(themeFilePath))
                {
                    case "Claro":
                        backcolor = Color.White;
                        altBackcolor = Color.LightGray;
                        forecolor = Color.Black;
                        break;
                    case "Escuro":
                        backcolor = Color.FromArgb(255, 33, 34, 33);
                        altBackcolor = Color.FromArgb(255, 38, 39, 38);
                        forecolor = Color.White;
                        break;
                }

            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MenuInicial());
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// FUNÇÕES ESPECÍFICAS                                                                                       ///
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// BANCO ///
        /////////////

        ///<summary>
        ///Obter o saldo bancário de determnado utilizador
        ///</summary>
        ///<param name="userid">ID de utilizador a obter o saldo</param>
        public static void GetSaldo(int userid)
        {
            string Saldo = "";

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = db;
                cmd.CommandText = "SELECT saldo FROM [bank_accounts] WHERE userid = @userid";
                cmd.Parameters.AddWithValue("@userid", userid);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Saldo = dr["saldo"].ToString();
                        }
                    }
                }
            }
            user.Saldo = string.Format("{0:N2}", Saldo);
        }

        /// <summary>
        /// Adição de fundos com registo da transação
        /// </summary>
        /// <param name="userId">ID do utilizador a adicionar fundos</param>
        /// <param name="description">Descritivo da transação</param>
        /// <param name="amount">Quantia a adicionar</param>
        /// <returns></returns>
        public static DialogResult AdicionarFundos(int userId, string description, double amount)
        {
            if (amount > 0)
            {
                try
                {

                    using (SqlCommand command = new SqlCommand("SELECT saldo FROM bank_accounts WHERE userid = @userid", Program.db))
                    {
                        command.Parameters.AddWithValue("@userid", userId);
                        double currentBalance = 0;

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    currentBalance = (double)dr["saldo"];
                                }
                            }
                        }


                        double newBalance = currentBalance + amount;


                        using (SqlCommand transactionCommand = new SqlCommand("INSERT INTO bank_transactions (userid, description, variation, finalbalance) VALUES (@userid, @description, @amount, @newbalance)", Program.db))
                        {
                            transactionCommand.Parameters.AddWithValue("@userid", userId);
                            transactionCommand.Parameters.AddWithValue("@description", description);
                            transactionCommand.Parameters.AddWithValue("@amount", amount);
                            transactionCommand.Parameters.AddWithValue("@newbalance", newBalance);
                            transactionCommand.ExecuteNonQuery();
                        }


                        Program.user.Saldo = string.Format("{0:N2}", newBalance);
                        return DialogResult.OK;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao depositar dinheiro: {ex.Message}");
                }
            }
            return DialogResult.Abort;
        }

        /// <summary>
        /// Remoção de fundos com registo de transação
        /// </summary>
        /// <param name="userId">ID do utilizador a remover fundos</param>
        /// <param name="description">Descritivo da transação</param>
        /// <param name="amount">Quantia a remover</param>
        /// <param name="canGoNegative">true se o saldo final pode ser negativo, false se não.</param>
        /// <returns>DialogResult.OK se a transação for concluída com sucesso, 
        /// <br/> DialogResult.Abort em caso de erro e 
        /// <br/> caso (canGoNegative = false) e o utilizador não tenha fundos suficientes.</returns>
        public static DialogResult RemoverFundos(int userId, string description, double amount, bool canGoNegative)
        {
            if (amount > 0)
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("SELECT saldo FROM bank_accounts WHERE userid = @userid", Program.db))
                    {
                        command.Parameters.AddWithValue("@userid", userId);
                        double currentBalance = 0;

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    currentBalance = (double)dr["saldo"];
                                }
                            }
                        }

                        if (currentBalance < amount && !canGoNegative)
                        {
                            throw new InvalidOperationException("Fundos insuficientes.");
                        }

                        double newBalance = currentBalance - amount;

                        using (SqlCommand transactionCommand = new SqlCommand("INSERT INTO bank_transactions (userid, description, variation, finalbalance) VALUES (@userid, @description, -@amount, @newbalance)", Program.db))
                        {
                            transactionCommand.Parameters.AddWithValue("@userid", userId);
                            transactionCommand.Parameters.AddWithValue("@description", description);
                            transactionCommand.Parameters.AddWithValue("@amount", amount);
                            transactionCommand.Parameters.AddWithValue("@newbalance", newBalance);
                            transactionCommand.ExecuteNonQuery();
                        }

                        Program.user.Saldo = string.Format("{0:N2}", newBalance);
                        return DialogResult.OK;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    return DialogResult.Abort;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao retirar dinheiro: {ex.Message}");
                }
            }
            return DialogResult.Abort;

        }

        /// <summary>
        /// Formata os IBANs para legibilidade
        /// </summary>
        /// <param name="iban">IBAN a formatar</param>
        /// <returns>IBAN formatado com espaços</returns>
        public static string FormatIBAN(string iban)
        {
            iban = iban.Replace(" ", "");
            var parts = Enumerable.Range(0, iban.Length / 4).Select(i => iban.Substring(i * 4, 4)).ToList();
            if (iban.Length % 4 != 0)
            {
                parts.Add(iban.Substring(iban.Length - (iban.Length % 4)));
            }
            return string.Join(" ", parts);
        }

        ////////////
        /// LOJA ///
        ////////////

        /// <summary>
        /// Atualiza o preço total do carrinho do utilizador
        /// </summary>
        /// <returns>Valor total em double</returns>
        public static double UpdateTotal()
        {
            loja.totalPrice = 0.0;
            foreach (var category in Program.loja.ProductQuantity)
            {
                foreach (var product in category.Value)
                {
                    using (SqlCommand command = new SqlCommand("SELECT price FROM shop_products WHERE idprod = @ProductId", Program.db))
                    {
                        command.Parameters.AddWithValue("@CategoryId", category.Key);
                        command.Parameters.AddWithValue("@ProductId", product.Key);

                        using (Program.dr = command.ExecuteReader())
                        {
                            if (Program.dr.HasRows)
                            {
                                while (Program.dr.Read())
                                {
                                    loja.totalPrice += product.Value * (double)Program.dr["price"];
                                }
                            }
                        }

                    }
                }
            }
            loja.totalPrice -= loja.paidQuantityMoney + loja.paidQuantityBank;
            return loja.totalPrice;
        }











        //////////
        // Tema //
        //////////

        
        //Esta função é utilizada no construtor de todos os forms do programa
        /// <summary>
        /// Atualiza o tema do form indicado
        /// </summary>
        /// <param name="form">Form para atualizar o Tema</param>
        public static void DetectTheme(Form form)
        {
            form.BackColor = backcolor;
            form.ForeColor = forecolor;

            UpdateControlColors(form.Controls);
            form.Refresh();
        }

        /// <summary>
        /// Função de suporte para a função <see cref="DetectTheme(Form)"/>
        /// </summary>
        /// <param name="controls"></param>
        private static void UpdateControlColors(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                control.BackColor = backcolor;
                control.ForeColor = forecolor;

                
                if (control is Panel panel)
                {
                    UpdateControlColors(panel.Controls);
                    panel.Refresh();
                }
                else if (control is FlowLayoutPanel flp)
                {
                    UpdateControlColors(flp.Controls);
                    flp.Refresh();
                }
                else if (control is DataGridView dgv)
                {
                    dgv.BackgroundColor = backcolor;
                    dgv.ForeColor = forecolor;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = backcolor;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = forecolor;
                    dgv.RowsDefaultCellStyle.BackColor = backcolor;
                    dgv.RowsDefaultCellStyle.ForeColor = forecolor;
                    dgv.AlternatingRowsDefaultCellStyle.BackColor = altBackcolor;
                    dgv.AlternatingRowsDefaultCellStyle.ForeColor = forecolor;
                    dgv.Refresh();
                }
            }
        }
        /////////////
        // Utility //
        /////////////
        
        
        /// <summary>
        /// Mostra a string Erro no LblErro indicado a vermelho
        /// </summary>
        /// <param name="LblErro">Label para mostrar o erro</param>
        /// <param name="Erro">Descrição do Erro</param>
        public static void DisplaylblError(Control LblErro, string Erro)
        {
            LblErro.ForeColor = Color.Red;
            LblErro.Visible = true;
            LblErro.Text = Erro;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Verifications

        /// <summary>
        /// Verifica se o nome de utilizador indicado é único (se não existe na base de dados)
        /// </summary>
        /// <param name="username">Nome de utilizador a verificar</param>
        /// <returns>True se único, False se não</returns>
        public static bool IsUsernameUnique(string username)
        {
            if (username == "Admin")
                return false;


            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = Program.db;
                cmd.CommandText = "SELECT username FROM [users] WHERE username COLLATE Latin1_General_BIN = @username";
                cmd.Parameters.AddWithValue("@username", username);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Verifica se existem utilizadores na base de dados
        /// </summary>
        /// <returns>True se existirem, False se não</returns>
        public static bool VerifyUsers()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = Program.db;
                cmd.CommandText = "SELECT username FROM [users]";

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

        }

        /// <summary>
        /// Verifica se o utilizador atual tem uma conta bancária, usa <see cref="User.ID"/>
        /// </summary>
        /// <returns>True se tiver, False se não</returns>
        public static bool VerifyBankAccount()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = Program.db;
                cmd.CommandText = "SELECT userid FROM [bank_accounts] WHERE userid = @userid";
                cmd.Parameters.AddWithValue("@userid", user.ID);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        /////////////////
        //Base de Dados//
        /////////////////
        
        /// <summary>
        /// Cria a base de dados necessária para o funcionamento do programa<br/>
        /// Base de dados: Projeto_2_Ano
        /// </summary>
        private static void CreateDatabase()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Trusted_Connection=True;TrustServerCertificate=True;Integrated Security=True"))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("IF DB_ID('Projeto_2_Ano') IS NULL CREATE DATABASE Projeto_2_Ano", connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao criar base de dados: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Cria as tabelas necessárias para o funcionamento do programa<br/><br/>
        /// Tabelas:<br/>
        /// [dbo].[users] armazena o id, nome, password (em hash) e username dos utilizadores<br/>
        /// [dbo].[bank_accounts] armazena o userid, pin (em hash), saldo e IBAN das contas bancárias. userid corresponde ao id da tabela [dbo].[users]<br/>
        /// [dbo].[bank_transactions] armazena o id, userid, time, description, variation, finalbalance para cada transação das contas bancárias<br/>
        /// [dbo].[shop_categories] armazena o id e o name das categorias da loja<br/>
        /// [dbo].[shop_products] armazena o idprod, idcat, catpos, name, description, stock, price e imagepath dos produtos da loja, cat id corresponde ao id da tabela [dbo].[shop_categories]<br/>
        /// </summary>
        private static void CreateTables()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string createTableQuery = @"
                    IF OBJECT_ID('users', 'U') IS NULL
                    CREATE TABLE [dbo].[users] (
                    [id]       INT           IDENTITY (1, 1) NOT NULL,
                    [name]     VARCHAR (100) NOT NULL,
                    [password] VARCHAR (64)  NOT NULL,
                    [username] VARCHAR (100) NOT NULL,
                    CONSTRAINT [Pk_users_id] PRIMARY KEY CLUSTERED ([id] ASC)
                    );
                        
                    IF OBJECT_ID('bank_accounts','U') IS NULL
                    CREATE TABLE [dbo].[bank_accounts] (
                    [userid] INT          NOT NULL,
                    [pin]    VARCHAR (64) NOT NULL,
                    [saldo]  FLOAT (53)   CONSTRAINT [defo_bank_accounts_saldo] DEFAULT ((0.00)) NOT NULL,
                    [IBAN]   VARCHAR (25) CONSTRAINT [defo_bank_accounts_IBAN] NOT NULL,
                    CONSTRAINT [Pk_bankaccounts_userid] PRIMARY KEY CLUSTERED ([userid] ASC),
                    CONSTRAINT [Fk_bankuid] FOREIGN KEY ([userid]) REFERENCES [dbo].[users] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
                    );

                    IF OBJECT_ID('bank_transactions','U') IS NULL
                    CREATE TABLE [dbo].[bank_transactions] (
                    [id]           INT           IDENTITY (1, 1) NOT NULL,
                    [userid]       INT           NOT NULL,
                    [time]         DATETIME      CONSTRAINT [defo_bank_transactions_time] DEFAULT (getdate()) NOT NULL,
                    [description]         VARCHAR (250) NOT NULL,
                    [variation]    FLOAT (53)    NOT NULL,
                    [finalbalance] FLOAT (53)    CONSTRAINT [defo_bank_transactions_finalbalance] DEFAULT (0) NOT NULL,
                    CONSTRAINT [Pk_banktransactions_id] PRIMARY KEY CLUSTERED ([id] ASC),
                    CONSTRAINT [FK_banktransuid] FOREIGN KEY ([userid]) REFERENCES [dbo].[bank_accounts] ([userid]) ON DELETE CASCADE ON UPDATE CASCADE
                    );

                    IF OBJECT_ID('shop_categories','U') IS NULL
                    CREATE TABLE [dbo].[shop_categories] (
                        [name] VARCHAR (100) NOT NULL,
                        [id]   INT           IDENTITY (1, 1) NOT NULL,
                        CONSTRAINT [Pk_shop_categories_id] PRIMARY KEY CLUSTERED ([id] ASC)
                    );

                    IF OBJECT_ID('shop_products','U') IS NULL
                    CREATE TABLE [dbo].[shop_products] (
                        [idprod]      INT           IDENTITY (1, 1) NOT NULL,
                        [idcat]       INT           NOT NULL,
                        [catpos]      INT           NOT NULL,
                        [name]        VARCHAR (100) NOT NULL,
                        [description] VARCHAR (500) NULL,
                        [stock]       INT           NOT NULL,
                        [price]       FLOAT (53)    NOT NULL,
                        [imagepath]  VARCHAR(255)  CONSTRAINT [defo_shop_products_imagepath] NOT NULL DEFAULT 'config\noimage.png',
                        CONSTRAINT [Pk_produtos_idpr] PRIMARY KEY CLUSTERED ([idprod] ASC),
                        CONSTRAINT [fk_idcat] FOREIGN KEY ([idcat]) REFERENCES [dbo].[shop_categories] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
                    );
                    ";
                    using (SqlCommand command = new SqlCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro a criar tabelas: {ex.Message}");
                }
            }
        }
        /// <summary>
        /// Cria os triggers necessários para o funcionamento do programa<br/><br/>
        /// Triggers:<br/>
        /// trg_maintain_finalbalance na tabela [dbo].[bank_transactions] para atualizar o finalbalance de todas as transações por utilizador em caso de insert, update ou delete.
        /// trg_OrderProductsByCategory na tabela [dbo].[shop_products] para ordenar os produtos por ordem alfabética do nome por categoria
        /// </summary>
        private static void CreateTrigger()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    var createTriggerQuery = @"
                    IF NOT EXISTS (SELECT * FROM sys.triggers WHERE name = 'trg_maintain_finalbalance')
                    BEGIN
                        EXEC ('CREATE TRIGGER trg_maintain_finalbalance
                        ON [dbo].[bank_transactions]
                        AFTER INSERT, UPDATE, DELETE
                        AS
                        BEGIN
                            SET NOCOUNT ON;

                            DECLARE @userid INT;

                            -- Determine affected user ID
                            IF EXISTS (SELECT 1 FROM inserted) 
                                SET @userid = (SELECT TOP 1 userid FROM inserted);
                            ELSE 
                                SET @userid = (SELECT TOP 1 userid FROM deleted);

                            -- Update finalbalance for all transactions of the affected userid
                            WITH cte AS (
                                SELECT 
                                    id,
                                    userid,
                                    variation,
                                    SUM(variation) OVER (PARTITION BY userid ORDER BY [time], id ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS running_total
                                FROM 
                                    [dbo].[bank_transactions]
                                WHERE 
                                    userid = @userid
                            )
                            UPDATE bt
                            SET bt.finalbalance = ROUND(cte.running_total, 2)
                            FROM 
                                [dbo].[bank_transactions] bt
                            JOIN 
                                cte ON bt.id = cte.id;

                            -- Update saldo in bank_accounts table
                            UPDATE ba
                            SET ba.saldo = (
                                SELECT ROUND(ISNULL(SUM(variation), 0), 2)
                                FROM [dbo].[bank_transactions]
                                WHERE userid = @userid
                            )
                            FROM [dbo].[bank_accounts] ba
                            WHERE ba.userid = @userid;
                        END');
                    END;
                    ";
                    using (SqlCommand command = new SqlCommand(createTriggerQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro a criar trigger: {ex.Message}");
                }
            }
            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    var createTriggerQuery = @"
                    IF NOT EXISTS (SELECT * FROM sys.triggers WHERE name = 'trg_OrderProductsByCategory')
                    BEGIN
                        EXEC ('CREATE TRIGGER trg_OrderProductsByCategory
                    ON shop_products
                    AFTER INSERT, UPDATE, DELETE
                    AS
                    BEGIN
                        SET NOCOUNT ON;

                        ;WITH AffectedCategories AS (
                            SELECT DISTINCT idcat
                            FROM inserted
                            UNION
                            SELECT DISTINCT idcat
                            FROM deleted
                        ),

                        CTE AS (
                            SELECT 
                                sp.idprod, 
                                sp.idcat,
                                ROW_NUMBER() OVER (PARTITION BY sp.idcat ORDER BY sp.name) AS RowNum
                            FROM 
                                shop_products sp
                            INNER JOIN 
                                AffectedCategories ac ON sp.idcat = ac.idcat
                        )
    
                        UPDATE sp
                        SET sp.catpos = cte.RowNum
                        FROM shop_products sp
                        INNER JOIN CTE ON sp.idprod = CTE.idprod;
                    END');
                    END;
                    ";
                    using (SqlCommand command = new SqlCommand(createTriggerQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro a criar trigger: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Insere as categorias e os produtos padrão caso não existam categorias nem produtos na base de dados
        /// </summary>
        private static void InsertProducts()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    var insertDataQuery = @"
            IF NOT EXISTS (SELECT 1 FROM [dbo].[shop_categories]) 
                AND NOT EXISTS (SELECT 1 FROM [dbo].[shop_products])
            BEGIN
                INSERT INTO [dbo].[shop_categories] ([name])
                VALUES
                    ('Tecnologia'),
                    ('Alimentos'),
                    ('Bebidas'),
                    ('Lazer'),
                    ('Produtos Automóveis');
            
                INSERT INTO [dbo].[shop_products] ([idcat], [catpos], [name], [description], [stock], [price], [imagepath])
                VALUES
                    (1, 1, 'Calculadora gráfica Texas Instruments TI-82 STAT', 'Calculadora gráfica avançada TI-82 STAT.', 20, 189.99, 'config\\loja\\default\\texascalc.png'),
                    (1, 2, 'Cartão presente Microsoft Azure 1 Mês', 'Cartão presente para 1 mês de serviços Microsoft Azure.', 10, 69.99, 'config\\loja\\default\\azuregiftcard.png'),
                    (1, 3, 'Smartphone SAMSUNG Galaxy S24 Ultra 256GB', 'Smartphone topo de gama Samsung Galaxy S24 Ultra com 256GB de armazenamento.', 15, 1299.99, 'config\\loja\\default\\s24.png'),
                    (1, 4, 'MacBook Pro M4 16 Polegadas 48GB RAM 1TB', 'MacBook Pro de 16 polegadas com 48GB de RAM e 1TB de armazenamento.', 5, 5899.99, 'config\\loja\\default\\macbook.png'),
                    (1, 5, 'TV LG OLED83G45LW (OLED - 83'' - 210 cm - 4K Ultra HD)', 'Televisão LG OLED de 83 polegadas com resolução 4K Ultra HD.', 10, 5699.99, 'config\\loja\\default\\lgtvhd.png'),
                    (1, 6, 'Aspirador Robô IROBOT Roomba Combo J9+ 2-em-1', 'Aspirador robô IROBOT Roomba Combo J9+ com função 2-em-1.', 25, 999.99, 'config\\loja\\default\\irobot.png'),

                    (2, 1, 'Carne de Javali 1kg', 'Carne de javali de alta qualidade, 1 kg.', 30, 25.50, 'config\\loja\\default\\carnejavali.png'),
                    (2, 2, 'Leite Mário Edição Limitada', 'Leite especial em edição limitada.', 100, 12.99, 'config\\loja\\default\\mariomilk.png'),
                    (2, 3, 'Croquetes de Carne', 'Deliciosos croquetes de carne.', 200, 3.99, 'config\\loja\\default\\croquetes.png'),
                    (2, 4, 'Bacalhau Desfiado Congelado', 'Bacalhau desfiado e congelado, pronto a cozinhar.', 150, 9.49, 'config\\loja\\default\\bacalhau.png'),
                    (2, 5, 'Manga Palmer Maturada 1kg', 'Mangas Palmer maturadas, 1 kg.', 100, 2.99, 'config\\loja\\default\\manga.png'),
                    (2, 6, 'Pimento Vermelho 500g', 'Pimentos vermelhos frescos, 500 g.', 200, 1.89, 'config\\loja\\default\\pimentos.png'),

                    (3, 1, 'Cerveja com Álcool Super Bock Mini Pack 30', 'Pack de 30 unidades de cerveja Super Bock Mini.', 120, 13.85, 'config\\loja\\default\\super.png'),
                    (3, 2, 'Compal Laranja do Algarve 1L', 'Sumo de laranja natural do Algarve, 1 litro.', 300, 1.99, 'config\\loja\\default\\compal.png'),
                    (3, 3, 'Coca-Cola Pack 4x1L', 'Pack de 4 garrafas de 1 litro de Coca-Cola.', 150, 5.49, 'config\\loja\\default\\cocacola.png'),
                    (3, 4, 'Ice Tea Limão Lipton 2x2L', 'Pack de 2 garrafas de 2 litros de Ice Tea Limão Lipton.', 100, 4.20, 'config\\loja\\default\\icetea.png'),
                    (3, 5, 'Água sem Gás Luso 6x1,5L', 'Pack de 6 garrafas de 1,5 litros de água sem gás Luso.', 200, 3.89, 'config\\loja\\default\\luso.png'),
                    (3, 6, 'Só Pias Vinho Tinto 5L', 'Garrafão de 5 litros de vinho tinto Só Pias.', 50, 9.39, 'config\\loja\\default\\sopias.png'),

                    (4, 1, 'Livro de Poemas de Antero de Quental', 'Livro com uma coleção de poemas de Antero de Quental.', 50, 22.40, 'config\\loja\\default\\anteroquental.png'),
                    (4, 2, 'Pacote de Férias no Dubai', 'Pacote de férias completo para o Dubai.', 5, 889.75, 'config\\loja\\default\\feriasdubai.png'),
                    (4, 3, 'Isto é Matemática Blu-ray Edição Limitada', 'Edição limitada do Blu-ray ""Isto é Matemática"".', 30, 19.99, 'config\\loja\\default\\istoematematica.png'),
                    (4, 4, 'Bola Anti-Stress Newtoniana', 'Bola anti-stress de design newtoniano.', 100, 1.99, 'config\\loja\\default\\bolastressnewtoniana.png'),
                    (4, 5, 'Cigarro Marlboro Gold 10 unidades', 'Pacote de cigarros Marlboro Gold, 10 unidades.', 200, 7.90, 'config\\loja\\default\\marlboro.png'),
                    (4, 6, 'Helldivers 2', 'Jogo de ação cooperativa ""Helldivers 2"".', 50, 39.99, 'config\\loja\\default\\helldivers2.png'),

                    (5, 1, 'Lâmpadas NORAUTO Clássico W5W 2un', 'Par de lâmpadas clássicas para automóveis, modelo W5W.', 100, 4.99, 'config\\loja\\default\\lampadascarro.png'),
                    (5, 2, 'Bateria VARTA E44 Silver Dynamic 77 Ah - 780 A', 'Bateria automóvel de alta performance, 77 Ah e 780 A.', 50, 139.00, 'config\\loja\\default\\bateriacarro.png'),
                    (5, 3, 'Escova limpa-vidros NORAUTO Performance 165 650mm', 'Escova limpa-vidros de alta performance, 650mm.', 75, 15.99, 'config\\loja\\default\\escovalimpavidros.png'),
                    (5, 4, 'Óleo de Motor SHELL HELIX HX8 5W30 ECT 5L', 'Óleo de motor de qualidade superior, 5W30 ECT, 5 litros.', 40, 39.99, 'config\\loja\\default\\oleomotor.png'),
                    (5, 5, 'Colete de segurança amarelo adulto', 'Colete de segurança amarelo para adultos, obrigatório em veículos.', 200, 3.99, 'config\\loja\\default\\coleteseg.png'),
                    (5, 6, 'Pack 4 Pneus Multi-usos', 'Conjunto de 4 pneus multi-usos para diversos tipos de terreno.', 20, 499.99, 'config\\loja\\default\\4pneus.png');
            END;
            ";
                    using (SqlCommand command = new SqlCommand(insertDataQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao inserir produtos: {ex.Message}");
                }
            }
        }


    }

}