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
    public partial class AddQuestionForm : Form
    {
        private string databaseFile;

        public event EventHandler QuestionAdded;

        public AddQuestionForm(string dbFile)
        {
            InitializeComponent();
            databaseFile = dbFile;
        }

        private void AddQuestionForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQuestion.Text) &&
                !string.IsNullOrEmpty(txtAnswerA.Text) &&
                !string.IsNullOrEmpty(txtAnswerB.Text) &&
                !string.IsNullOrEmpty(txtAnswerC.Text) &&
                !string.IsNullOrEmpty(txtAnswerD.Text) &&
                cbCorrectAnswer.SelectedIndex != -1)
            {
                using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + databaseFile))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "INSERT INTO Questions (Question, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswerIndex) VALUES (@Question, @AnswerA, @AnswerB, @AnswerC, @AnswerD, @CorrectAnswerIndex)";
                        command.Parameters.AddWithValue("@Question", txtQuestion.Text);
                        command.Parameters.AddWithValue("@AnswerA", txtAnswerA.Text);
                        command.Parameters.AddWithValue("@AnswerB", txtAnswerB.Text);
                        command.Parameters.AddWithValue("@AnswerC", txtAnswerC.Text);
                        command.Parameters.AddWithValue("@AnswerD", txtAnswerD.Text);
                        command.Parameters.AddWithValue("@CorrectAnswerIndex", cbCorrectAnswer.SelectedIndex);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Вопрос успешно добавлен.");

                QuestionAdded?.Invoke(this, EventArgs.Empty);

                // Очистка полей ввода
                txtQuestion.Text = string.Empty;
                txtAnswerA.Text = string.Empty;
                txtAnswerB.Text = string.Empty;
                txtAnswerC.Text = string.Empty;
                txtAnswerD.Text = string.Empty;
                cbCorrectAnswer.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Заполните все поля.");
            }
        }
    }
}
