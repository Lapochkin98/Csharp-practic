using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Day22TasksPart1
{
    //Classes
   
    public partial class Form1 : Form
    {
        private List<Question> questions;
        private int currentQuestionIndex;
        private int correctAnswers;
        private string studentName;
        private string studentClass;
        private List<TestResult> testResults;
        private string databaseFile = "test.db"; // Имя файла базы данных SQLite
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
            // Создание базы данных и таблицы результатов, если они не существуют
            CreateDatabase();

            // Загрузка вопросов из базы данных
            LoadQuestions();
     
            // Перемешивание вопросов
            ShuffleQuestions();

            // Инициализация переменных
            currentQuestionIndex = 0;
            correctAnswers = 0;

            // Отображение первого вопроса
            ShowQuestion();
            grpRegistration.Visible = true;  
        }
        
        //Functions
        private void CreateDatabase()
        {
            if (!File.Exists(databaseFile))
            {
                SQLiteConnection.CreateFile(databaseFile);

                using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + databaseFile))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"CREATE TABLE Results (Name TEXT, Grade TEXT, Date DATETIME)";
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
        private void LoadQuestions()
        {
            questions = new List<Question>();

            using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + databaseFile))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = "SELECT * FROM Questions";
                    SQLiteDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Question question = new Question
                        {
                            Text = reader["Question"].ToString(),
                            Answers = new List<string>
                            {
                                reader["AnswerA"].ToString(),
                                reader["AnswerB"].ToString(),
                                reader["AnswerC"].ToString(),
                                reader["AnswerD"].ToString()
                            },
                            CorrectAnswerIndex = int.Parse(reader["CorrectAnswerIndex"].ToString())
                        };

                        questions.Add(question);
                    }
                }
            }
        }
        private void ShuffleQuestions()
        {
            Random random = new Random();
            questions = questions.OrderBy(q => random.Next()).ToList();
        }

        private void ShowQuestion()
        {
            if (currentQuestionIndex < 10)
            {
                Question question = questions[currentQuestionIndex];

                lblQuestion.Text = question.Text;
                rbtnA.Text = question.Answers[0];
                rbtnB.Text = question.Answers[1];
                rbtnC.Text = question.Answers[2];
                rbtnD.Text = question.Answers[3];

                lblQuestionNumber.Text = $@"Вопрос № {currentQuestionIndex + 1} из 10";
            }
            else
            {
                FinishTest();
            }
        }

        private void CheckAnswer()
        {
            Question question = questions[currentQuestionIndex];
            int selectedAnswerIndex = GetSelectedAnswerIndex();

            if (selectedAnswerIndex == question.CorrectAnswerIndex)
            {
                correctAnswers++;
            }
        }

        private int GetSelectedAnswerIndex()
        {
            if (rbtnA.Checked)
                return 0;
            else if (rbtnB.Checked)
                return 1;
            else if (rbtnC.Checked)
                return 2;
            else if (rbtnD.Checked)
                return 3;
            else
                return -1;
        }

        private void FinishTest()
        {
            string grade = GetGrade();

            // Отображение результатов
            MessageBox.Show($@"Тестирование завершено.
            Количество верных ответов: {correctAnswers}/ 10
            Оценка: {grade}");

            // Запись результатов в базу данных
            TestResult result = new TestResult
            {
                Name = studentName,
                Grade = grade,
                Class = studentClass,
                Date = DateTime.Now
            };

            SaveResult(result);

            // Сброс переменных
            currentQuestionIndex = 0;
            correctAnswers = 0;

            // Очистка выбранного варианта ответа
            rbtnA.Checked = false;
            rbtnB.Checked = false;
            rbtnC.Checked = false;
            rbtnD.Checked = false;

            // Отображение первого вопроса
            ShowQuestion();
        }

        private string GetGrade()
        {
            double percentage = (double)correctAnswers / 10 * 100;

            if (percentage >= 90)
                return "Отлично";
            else if (percentage >= 80)
                return "Хорошо";
            else if (percentage >= 70)
                return "Удовлетворительно";
            else
                return "Неудовлетворительно";
        }

        private void SaveResult(TestResult result)
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + databaseFile))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = "INSERT INTO Results (Name, Class, Grade, Date) VALUES (@Name, @Class, @Grade, @Date)";
                    command.Parameters.AddWithValue("@Name", result.Name);
                    command.Parameters.AddWithValue("@Grade", result.Grade);
                    command.Parameters.AddWithValue("@Class", result.Class);
                    command.Parameters.AddWithValue("@Date", result.Date);
                    command.ExecuteNonQuery();
                }
            }
        }


        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            AddQuestionForm addQuestionForm = new AddQuestionForm(databaseFile);
            addQuestionForm.QuestionAdded += AddQuestionForm_QuestionAdded;
            addQuestionForm.ShowDialog();
        }

        private void AddQuestionForm_QuestionAdded(object sender, EventArgs e)
        {
            LoadQuestions();
        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
        
        }

        private void grpRegistration_Enter(object sender, EventArgs e)
        {

        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtClass.Text))
            {
                studentName = txtName.Text;
                studentClass = txtClass.Text;

                // Очистка поля ввода имени и класса
                txtName.Text = string.Empty;
                txtClass.Text = string.Empty;

                // Активация элементов управления для тестирования
                grpRegistration.Visible = false;
                grpQuestions.Visible = true;
            }
            else
            {
                MessageBox.Show(@"Введите имя и класс учащегося.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rbtnA.Checked || rbtnB.Checked || rbtnC.Checked || rbtnD.Checked)
            {
                CheckAnswer();

                // Сброс выбранного варианта ответа
                rbtnA.Checked = false;
                rbtnB.Checked = false;
                rbtnC.Checked = false;
                rbtnD.Checked = false;

                currentQuestionIndex++;
                ShowQuestion();
            }
            else
            {
                MessageBox.Show(@"Выберите вариант ответа.");
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewResultsForm viewResultsForm = new ViewResultsForm(databaseFile);
            viewResultsForm.ShowDialog();
        }

        private void btnStartTest_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtClass.Text))
            {
                studentName = txtName.Text;
                studentClass = txtClass.Text;

                // Очистка поля ввода имени и класса
                txtName.Text = string.Empty;
                txtClass.Text = string.Empty;

                // Активация элементов управления для тестирования
                grpRegistration.Visible = false;
                grpQuestions.Visible = true;
            }
            else
            {
                MessageBox.Show("Введите имя и класс учащегося.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (rbtnA.Checked || rbtnB.Checked || rbtnC.Checked || rbtnD.Checked)
            {
                CheckAnswer();

                // Сброс выбранного варианта ответа
                rbtnA.Checked = false;
                rbtnB.Checked = false;
                rbtnC.Checked = false;
                rbtnD.Checked = false;

                currentQuestionIndex++;
                ShowQuestion();
            }
            else
            {
                MessageBox.Show(@"Выберите вариант ответа.");
            }
        }

        private void addQuestionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddQuestionForm addQuestionForm = new AddQuestionForm(databaseFile);
            addQuestionForm.QuestionAdded += AddQuestionForm_QuestionAdded;
            addQuestionForm.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ViewResultsForm viewResultsForm = new ViewResultsForm(databaseFile);
            viewResultsForm.ShowDialog();
        }
    }
    public class Question
    {
        public string Text { get; set; }
        public List<string> Answers { get; set; }
        public int CorrectAnswerIndex { get; set; }
    }
    public class TestResult
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public string Grade { get; set; }
        public DateTime Date { get; set; }
    }

}