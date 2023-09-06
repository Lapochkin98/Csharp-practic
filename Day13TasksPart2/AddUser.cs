using System;
using System.Windows.Forms;

namespace Day13TasksPart2
{
    
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = (Form1)Application.OpenForms[0];
            form?.NewVehicle(textBox1.Text.ToString(), Double.Parse(textBox2.Text),
                Double.Parse(textBox3.Text));
            form.textBox1.Text += textBox1.Text +" " + textBox2.Text + " "+ textBox3.Text + Environment.NewLine;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = (Form1)Application.OpenForms[0];
            form?.NewVehicle();
            this.Close();
        }
    }
}