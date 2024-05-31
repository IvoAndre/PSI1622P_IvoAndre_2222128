using Microsoft.Data.SqlClient;
using System.Data;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

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

            //verificar se a base de dados está disponivel
            try
            {
                db.Open();
            }catch (Exception ex)
            {
                MessageBox.Show($"\nERRO:{ex.Message}","ERRO",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
                    [IBAN]   INT          CONSTRAINT [defo_bank_accounts_IBAN] DEFAULT ((1300000000000000.)) NOT NULL,
                    CONSTRAINT [Pk_bankaccounts_userid] PRIMARY KEY CLUSTERED ([userid] ASC),
                    CONSTRAINT [Fk_bankuid] FOREIGN KEY ([userid]) REFERENCES [dbo].[users] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
                    );

                    IF OBJECT_ID('bank_transactions','U') IS NULL
                    CREATE TABLE [dbo].[bank_transactions] (
                    [id]           INT           IDENTITY (1, 1) NOT NULL,
                    [userid]       INT           NOT NULL,
                    [time]         DATETIME      CONSTRAINT [defo_bank_transactions_time] DEFAULT (getdate()) NOT NULL,
                    [name]         VARCHAR (250) NOT NULL,
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
        
    
    }
}