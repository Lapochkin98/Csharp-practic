 using System;
 using System.Drawing;
 using System.Globalization;
 using System.IO;
 using System.Windows.Forms;

namespace Day17Tasks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Date.Text = DateTime.Now.ToString("dd.MM");
            Day.Text = DateTime.Now.DayOfWeek.ToString();
            string fileName = Date.Text + ".txt";
            if (File.Exists(fileName))
            {
                string[] text = File.ReadAllLines(fileName);
                for (int i = 1; i < text.Length; i++)
                {
                    if (text[i] != "true" && text[i] != "false")
                    {
                        checkedListBox.Items.Add(text[i]);
                        if (text[i - 1] == "true")
                            checkedListBox.SetItemChecked(checkedListBox.Items.Count - 1, true);
                    }
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string fileName = Date.Text + ".txt";
            
            Date.Text = dateTimePicker.Value.ToString("dd.MM");
            Day.Text = dateTimePicker.Value.DayOfWeek.ToString();
            if (File.Exists((fileName)))
            {
                var text = File.ReadAllLines(fileName);
                for (int i = 0; i < checkedListBox.Items.Count; i++)
                {
                    if (checkedListBox.GetItemChecked(i))
                    {
                        text[i] = text[i].Split('|')[0] + "|+";
                    }
                    else
                        text[i] = text[i].Split('|')[0] + "|-";
                    File.WriteAllLines(fileName, text);
                }   
            }
            fileName = Date.Text + ".txt";
            
            checkedListBox.Items.Clear();
            if (File.Exists(fileName))
            {
                var text = File.ReadAllLines(fileName);
                for (int i = 0; i < text.Length; i++)
                {
                    checkedListBox.Items.Add(text[i].Split('|')[0]);
                    if (text[i].Split('|')[1] == "+")
                        checkedListBox.SetItemChecked(i, true);
                }
                File.WriteAllLines(fileName, text);
            }
        }

        private void perDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindFilesByWeek(CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(dateTimePicker.Value, CalendarWeekRule.FirstDay, DayOfWeek.Sunday));
        }

        private void FindFilesByMonth(int desiredMonth)
        {
            string folderPath = @"D:\College Labs\MyLabs\C#works\Practic\day.1\ConsoleApplication1\Day17Tasks\bin\Debug";
            string[] fileNames = Directory.GetFiles(folderPath, "*.txt");

            foreach (string fileName in fileNames)
            {
                string[] parts = Path.GetFileNameWithoutExtension(fileName).Split('.');
                if (parts.Length == 2)
                {
                    if (int.TryParse(parts[0], out _) && int.TryParse(parts[1], out var month) && month == desiredMonth)
                    {
                        string[] text = File.ReadAllLines(fileName);
                        foreach (var t in text)
                        {
                            if (t.Split('|')[1] == "-" )
                                checkedListBox.Items.Add(t.Split('|')[0]);
                        }
                        // здесь можно добавить свой код для обработки найденных файлов
                    }
                }
            }
        }
        
        private void FindFilesByWeek(int desiredWeek)
        {
            string folderPath = @"D:\College Labs\MyLabs\C#works\Practic\day.1\ConsoleApplication1\Day17Tasks\bin\Debug";
            string[] fileNames = Directory.GetFiles(folderPath, "*.txt");

            foreach (string fileName in fileNames)
            {
                string[] parts = Path.GetFileNameWithoutExtension(fileName).Split('.');
                if (parts.Length == 2)
                {
                    if (int.TryParse(parts[0], out var day) && int.TryParse(parts[1], out var month))
                    {
                        var date = new DateTime(DateTime.Today.Year, month, day);
                        var week = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                        if (week == desiredWeek)
                        {
                            string[] text = File.ReadAllLines(fileName);
                            foreach (var t in text)
                            {
                                if (t.Split('|')[1] == "-")
                                {
                                    checkedListBox.Items.Add(t.Split('|')[0]);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void perMonthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindFilesByMonth(dateTimePicker.Value.Month);
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewNote newNote = new NewNote();
            newNote.Show();
            Hide();
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkedListBox.Items.Clear();
            string fileName = Date.Text + ".txt";
            if (File.Exists(fileName))
            {
                string[] text = File.ReadAllLines(fileName);
                for (int i = 1; i < text.Length; i++)
                {
                    if (text[i] != "true" && text[i] != "false" || text[i] != "" || text[i] != " ")
                    {
                        if (text[i - 1] == "false")
                            checkedListBox.Items.Add(text[i]);
                    }
                }
            }
        }

        private void changeFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Создаем диалог для выбора шрифта
            FontDialog fontDialog = new FontDialog();

            // Отображаем диалог и если пользователь выбрал шрифт
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                // Меняем шрифт для всех элементов на форме
                this.Font = fontDialog.Font;
            }
        }

        private void changeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
            }
        }

        private void changeImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = @"Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.BackgroundImage = Image.FromFile(openFileDialog.FileName);
            }
        }
    }
}