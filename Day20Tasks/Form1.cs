using System;
using System.Windows.Forms;

namespace Day20Tasks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool _clampedMouse = true;
        private int _rightClickCount;
        private int _leftClickCount;
        

        private void Form1_Enter(object sender, EventArgs e)
        {
            
        }

        private void button1_Enter(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            label3.Text = @"You on picture box";
        }

        private void label1_Enter(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            label3.Text = @"You on form";
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            label3.Text = @"You on button";
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label3.Text = @"You on label";
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            label3.Text = @"You on text box";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = $@"x: {MousePosition.X}  y: {MousePosition.Y}";
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = $@"x: {MousePosition.X}  y: {MousePosition.Y}";
            label5.Text = !_clampedMouse ? $@"x: {MousePosition.X}  y: {MousePosition.Y}" : @"Null";
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = $@"x: {MousePosition.X}  y: {MousePosition.Y}";
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = $@"x: {MousePosition.X}  y: {MousePosition.Y}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            _clampedMouse = false;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            _clampedMouse = true;
        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button is MouseButtons.Right)
                _rightClickCount++;
            if (e.Button is MouseButtons.Left)
                _leftClickCount++;
            label7.Text = $@"Right clicks: {_rightClickCount}";
            label6.Text = $@"Left clicks: {_leftClickCount}";

            button2.Location = e.Location;
            button2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game form = new Game();
            form.Show();
            this.Hide();
        }
    }
}