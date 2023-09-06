using System;
using System.Linq;
using System.Windows.Forms;

namespace Day15TasksPart2
{
    public partial class Task1 : Form
    {
        public Task1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;

            int characterCount = input.Length;
            int wordCount = input.Split(new[] { ' '}, StringSplitOptions.RemoveEmptyEntries).Length;
            int punctuationCount = input.Count(char.IsPunctuation);
            int digitCount = input.Count(char.IsDigit);

            label5.Text = characterCount.ToString();
            label6.Text = wordCount.ToString();
            label7.Text = punctuationCount.ToString();
            label8.Text = digitCount.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Close();
        }
    }
}