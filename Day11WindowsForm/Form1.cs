using System;
using System.Windows.Forms;

namespace Day11WindowsForm
{
    public partial class Form1 : Form
    {
        delegate void Func();

        private void ChangeColor()
        {
            ColorDialog colorDialog1 = new ColorDialog();
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // установка цвета формы
            this.BackColor = colorDialog1.Color;
        }

        private void ChangeHeader()
        {
            this.Text = textBox1.Text;
        }

        private void StartLoad()
        {
            timer1.Interval = 1000; // 500 миллисекунд
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
        }

        private void NormalSize()
        {
            this.WindowState = FormWindowState.Normal;
            this.Height = 489;
            this.Width = 344;
        }

        private void FullScreenSize()
        {
            this.WindowState = FormWindowState.Maximized;
        }
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Func func = null;
            
            if(textBox1.Text != null)
                func += ChangeHeader;
            if(checkBox1.Checked)
                func += this.ChangeColor;
            if(radioButton1.Checked)
                func += this.NormalSize;
            else if(radioButton2.Checked)
                func += this.FullScreenSize;
            if (checkBox2.Checked)
                func += this.StartLoad;
            else
                timer1.Enabled = false;
            if (func != null) func.Invoke();
            func = null;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
        }
    }
}