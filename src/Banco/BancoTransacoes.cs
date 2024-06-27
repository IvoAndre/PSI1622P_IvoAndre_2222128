using Microsoft.Data.SqlClient;
using System.Data;

namespace Projeto2Ano
{
    /// <summary>
    /// Este form mostra ao utilizador o histórico de transações da conta bancária do utilizador
    /// </summary>
    public partial class BancoTransacoes : Form
    {
        public BancoTransacoes()
        {
            InitializeComponent();
            Program.DetectTheme(this);
            Program.GetSaldo(Program.user.ID);
            lblSaldo.Text = $"Saldo Atual: {Program.user.Saldo}€";

            if (Program.db.State != ConnectionState.Open)
            {
                Program.db.Open();
            }

            string query = @"
                SELECT 
                    time AS 'Data e Hora', 
                    description AS 'Descritivo', 
                    variation AS 'Variação', 
                    finalbalance AS 'Saldo Final'
                FROM bank_transactions
                WHERE userid = @userid
                ORDER BY time ASC";

            using (SqlCommand cmd = new SqlCommand(query, Program.db))
            {
                cmd.Parameters.AddWithValue("@userid", Program.user.ID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgTransacoes.DataSource = dt;
            }

            dgTransacoes.Columns["Data e Hora"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgTransacoes.Columns["Descritivo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgTransacoes.Columns["Variação"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgTransacoes.Columns["Saldo Final"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        /// <summary>
        /// Formata as células da <see cref="dgTransacoes"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgTransacoes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && (dgTransacoes.Columns[e.ColumnIndex].Name == "Variação" || dgTransacoes.Columns[e.ColumnIndex].Name == "Saldo Final"))
            {
                if (e.Value != null && double.TryParse(e.Value.ToString(), out double value))
                {
                    // Formatação do valor com duas casas decimais e o símbolo de euro
                    string formattedValue = $"{Math.Abs(value):F2} €";

                    // Adicionar o símbolo correto dependendo do valor
                    if (value > 0 && dgTransacoes.Columns[e.ColumnIndex].Name == "Variação")
                        formattedValue = "+" + formattedValue;
                    else if (value < 0 && dgTransacoes.Columns[e.ColumnIndex].Name == "Variação")
                        formattedValue = "-" + formattedValue;
                    else
                        formattedValue = " " + formattedValue;

                    // Definir a cor do texto
                    if (value > 0)
                        dgTransacoes.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Green; // Verde para valores positivos
                    else if (value < 0)
                        dgTransacoes.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red; // Vermelho para valores negativos
                    else
                        dgTransacoes.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Program.forecolor; // Preto para zero

                    e.Value = formattedValue;
                    e.FormattingApplied = true;
                }
            }
        }

        /// <summary>
        /// Fecha o Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}



