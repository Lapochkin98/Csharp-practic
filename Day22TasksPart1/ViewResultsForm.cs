using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Day22TasksPart1
{
    public partial class ViewResultsForm : Form
    {
        private string databaseFile;

        public ViewResultsForm(string dbFile)
        {
            InitializeComponent();
            databaseFile = dbFile;
        }

        private void ViewResultsForm_Load(object sender, EventArgs e)
        {
            LoadResults();
        }
        private void LoadResults()
        {
            List<TestResult> results = new List<TestResult>();

            using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + databaseFile))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = "SELECT * FROM Results ORDER BY Date DESC";
                    SQLiteDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        TestResult result = new TestResult
                        {
                            Name = reader["Name"].ToString(),
                            Class = reader["Class"].ToString(),
                            Grade = reader["Grade"].ToString(),
                            Date = DateTime.Parse(reader["Date"].ToString())
                        };

                        results.Add(result);
                    }
                }
            }

            dgvResults.DataSource = results;
        }
    }
}
