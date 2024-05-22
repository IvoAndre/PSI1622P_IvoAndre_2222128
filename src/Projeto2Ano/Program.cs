using Microsoft.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace Projeto2Ano
{
    
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