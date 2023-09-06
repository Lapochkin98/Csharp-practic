using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Day17Tasks
{
    public partial class NewNote : Form
    {
        public NewNote()
        {
            InitializeComponent();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Date.Text = dateTimePicker.Value.ToString("dd.MM");
            Day.Text = dateTimePicker.Value.DayOfWeek.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                string fileName = Date.Text + ".txt";
                File.AppendAllLines(fileName, richTextBox1.Lines.Select(line => line + "|-"));
                MessageBox.Show(@"File was saved");
            }
            else
            {
                MessageBox.Show(@"Error: can't create empty note");
            }
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = Application.OpenForms[0] as Form1;
            form?.Show();
            Hide();
        }

        private void NewNote_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}