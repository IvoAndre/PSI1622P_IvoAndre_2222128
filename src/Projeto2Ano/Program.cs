using Microsoft.Data.SqlClient;

namespace Projeto2Ano
{
    internal static class Program
    {
        

        private static string _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=demosnet_2222128;Trusted_Connection=True;TrustServerCertificate=True";


        private static SqlConnection db = new SqlConnection(_connectionString);

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
                MessageBox.Show($"\nERRO:{ex.Message}","ERRO",MessageBoxButtons.OK);
            }
            finally
            {
                if (db.State == System.Data.ConnectionState.Open)
                {
                    db.Close();
                }
            }
        

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MenuInicial());
        }
    }
}