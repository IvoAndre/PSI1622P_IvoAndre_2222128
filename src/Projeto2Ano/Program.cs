using Microsoft.Data.SqlClient;
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
        public string Name { get; set; }
        public string Username { get; set; }
    }


    static class Program
    {
        public static Color backcolor = Color.White;

        public static Color forecolor = Color.Black;

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



        //Base de Dados

        private static string _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Projeto_2_Ano;Trusted_Connection=True;TrustServerCertificate=True";

        public static SqlConnection db = new SqlConnection(_connectionString);

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            try
            {
                db.Open();
            }catch (Exception ex)
            {
                MessageBox.Show($"\nERRO:{ex.Message}","ERRO",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                if (db.State == System.Data.ConnectionState.Open)
                {
                    db.Close();

                    // To customize application configuration such as set high DPI settings or default font,
                    // see https://aka.ms/applicationconfiguration.
                    ApplicationConfiguration.Initialize();
                    Application.Run(new MenuInicial());
                }
            }
        

            
        }
    }
}