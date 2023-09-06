using System;
using System.Windows.Forms;

namespace Day20Tasks
{
    public partial class Game : Form
    {
        int _scoreCount;
        int _time;
        public Game()
        {
            InitializeComponent();
            timer1.Start();
            timer1.Interval = 1000;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            button1.Location = new System.Drawing.Point(random.Next(0, 635), random.Next(0, 477));
            _time++;
            label3.Text = _time.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _scoreCount++;
            label2.Text = _scoreCount.ToString();
            if (_scoreCount % 5 == 0)
                timer1.Interval -= 100;
        }

        private void Game_MouseClick(object sender, MouseEventArgs e)
        {
            _scoreCount--;
            label2.Text = _scoreCount.ToString();
            if (_scoreCount == 0)
            {
                MessageBox.Show(@"Game over");
                timer1.Enabled = false;
                Form form = Application.OpenForms[0];
                form.Show();
                this.Close();
            }
        }
    }
}