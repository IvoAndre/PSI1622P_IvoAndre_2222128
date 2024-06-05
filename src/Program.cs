using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Projeto2Ano
{
    public class Crypt
    {
        //Fazer o hash do input e devolver uma string em base64
        public static string Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
        //Verificar se o hash do input corresponde ao hash guardado
        public static bool Verify(string input, string hash)
        {
            string inputHash = Hash(input);
            return inputHash == hash;
        }
    }

    public struct User
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public double Saldo { get; set; }
    }
    

    static class Program
    {
        public static User user = new();
        public static bool adminMode = false;

        //Theme Colors
        public static Color backcolor = Color.White;
        public static Color forecolor = Color.Black;

        //File Paths
        public const string configFolder = "config";

        public const string themeFilePath = configFolder + @"\theme";
        
        //SqlConnection
        private static string _connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=Projeto_2_Ano;Trusted_Connection=True;TrustServerCertificate=True";
        public static SqlConnection db = new SqlConnection(_connectionString);

        //DataReader
        public static SqlDataReader dr;
        //DataTable
        public static DataTable dt;
        //DataAdapter
        public static SqlDataAdapter da;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Criar Base de dados se nao existir
            CreateDatabase();
            CreateTables();
            CreateTrigger();

            //verificar se a base de dados está disponivel
            try
            {
                db.Open();
            }catch (Exception ex)
            {
                MessageBox.Show($"\nERRO:{ex.Message}","ERRO",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Application.Exit();
            }

            if (db.State == System.Data.ConnectionState.Open)
            {
                db.Close();
            }

            //aplicar tema se existir
            if (File.Exists(themeFilePath))
            {
                switch (File.ReadAllText(themeFilePath))
                {
                    case "Claro":
                        backcolor = Color.White;
                        forecolor = Color.Black;
                        break;
                    case "Escuro":
                        backcolor = Color.FromArgb(255,33,34,33);
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
        
        public static void GetSaldo(int userid)
        {
            double Saldo = 0;

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = Program.db;
                cmd.CommandText = "SELECT saldo FROM [bank_accounts] WHERE userid = @userid";
                cmd.Parameters.AddWithValue("@userid", userid);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Saldo = (double)dr["saldo"];
                        }
                    }
                }
            }

            user.Saldo = Saldo;
        }

        public static DialogResult AdicionarFundos(int userId, string description, double amount)
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

                    
                    Program.user.Saldo = newBalance;
                    return DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao depositar dinheiro: {ex.Message}");
            }
            return DialogResult.Abort;
        }

        public static DialogResult RemoverFundos(int userId, string description, double amount, bool canGoNegative)
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

                    // Check if the withdrawal would result in a negative balance
                    if (currentBalance < amount && !canGoNegative)
                    {
                        throw new InvalidOperationException("Fundos insuficientes.");
                    }

                    // Calculate new balance
                    double newBalance = currentBalance - amount;

                    // Insert transaction
                    using (SqlCommand transactionCommand = new SqlCommand("INSERT INTO bank_transactions (userid, description, variation, finalbalance) VALUES (@userid, @description, -@amount, @newbalance)", Program.db))
                    {
                        transactionCommand.Parameters.AddWithValue("@userid", userId);
                        transactionCommand.Parameters.AddWithValue("@description", description);
                        transactionCommand.Parameters.AddWithValue("@amount", amount);
                        transactionCommand.Parameters.AddWithValue("@newbalance", newBalance);
                        transactionCommand.ExecuteNonQuery();
                    }

                    // Update account balance
                    Program.user.Saldo = newBalance;
                    return DialogResult.OK;
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao retirar dinheiro: {ex.Message}");
            }
            return DialogResult.Abort;
        }


















        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Theme
        public static void DetectTheme(Form form)
        {
            form.BackColor = backcolor;
            form.ForeColor = forecolor;

            foreach (Control control in form.Controls)
            {
                control.BackColor = backcolor;
                control.ForeColor = forecolor;
            }
            form.Refresh();
        }

        public static void DetectTheme(Panel panel)
        {
            panel.BackColor = backcolor;
            panel.ForeColor = forecolor;

            foreach (Control control in panel.Controls)
            {
                control.BackColor = backcolor;
                control.ForeColor = forecolor;
            }
            panel.Refresh();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Utility

        public static void DisplaylblError(Control LblErro, string Erro)
        {
            LblErro.ForeColor = Color.Red;
            LblErro.Visible = true;
            LblErro.Text = Erro;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Verifications
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

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Base de Dados
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
                    [finalbalance] FLOAT (53)    NOT NULL,
                    CONSTRAINT [Pk_banktransactions_id] PRIMARY KEY CLUSTERED ([id] ASC),
                    CONSTRAINT [FK_banktransuid] FOREIGN KEY ([userid]) REFERENCES [dbo].[bank_accounts] ([userid]) ON DELETE CASCADE ON UPDATE CASCADE
                    );

                    IF OBJECT_ID('shop_categories','U') IS NULL
                    CREATE TABLE [dbo].[shop_categories] (
                        [name] VARCHAR (100) NOT NULL,
                        [id]   INT           NOT NULL,
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
                            SET bt.finalbalance = cte.running_total
                            FROM 
                                [dbo].[bank_transactions] bt
                            JOIN 
                                cte ON bt.id = cte.id;

                            -- Update saldo in bank_accounts table
                            UPDATE ba
                            SET ba.saldo = (
                                SELECT ISNULL(SUM(variation), 0)
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
        }
    }
}