using System;
using System.Globalization;
using System.Windows.Forms;

namespace Day15TasksPart2
{
    public partial class Task2 : Form
    {
        public Task2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double sqr = 1;
            double g = 1;
            if (radioButton1.Checked)
                sqr = 5;
            if (radioButton2.Checked)
                sqr = 10;
            if (radioButton3.Checked)
                g = 0.1;
            if (radioButton4.Checked)
                g = 0.15;
            double length = double.Parse(textBox1.Text);
            double width = double.Parse(textBox3.Text);
            double height = double.Parse(textBox2.Text);
            
            double floorArea = length * width;
            double wallArea = 2 * height * (length + width);
            label7.Text = (Math.Ceiling(wallArea / sqr)).ToString(CultureInfo.InvariantCulture); // assuming wallpaper rolls are 5 sq.m
            double paintWeight = floorArea * g; // assuming paint consumption of 100 g per sq.m of floor
            label8.Text =  (Math.Ceiling(paintWeight / 1.8)).ToString(CultureInfo.InvariantCulture); // assuming paint cans weigh 1.8 kg
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Close();
        }
    }
}