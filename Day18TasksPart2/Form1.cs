using System;
using System.Windows.Forms;
using Day18TasksPart2.Entities;

namespace Day18TasksPart2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ControlArray<Button> buttons = new ControlArray<Button>(5, 50, 30);
            buttons.DisplayOnForm(this, 20, 20, 10);

            ControlArray<CheckBox> checkboxes = new ControlArray<CheckBox>(10, 100, 20);
            checkboxes.DisplayOnForm(this, 20, 80, 5);
        }
    }
}