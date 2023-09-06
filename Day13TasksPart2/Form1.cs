using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Day13TasksPart2
{
    [Serializable()]
    public class Vehicle
    {
        public string Name { get; }
        public double Distance { get; }
        public double CostPerKm { get; }

        public Vehicle(string name, double distance, double costPerKm)
        {
            Name = name;
            Distance = distance;
            CostPerKm = costPerKm;
        }

        internal Vehicle()
        {
            Name = "";
            Distance = 0;
            CostPerKm = 0;
        }
        public virtual double CalculateCost() => CostPerKm*Distance;
    }
    public partial class Form1 : Form
    {
        private List<Vehicle> _vehicles = new List<Vehicle>();
        public Form1()
        {
            InitializeComponent();
            
            // var bindingList = new BindingList<Vehicle>(Vehicles);
            // var bindingSource = new BindingSource();
            // bindingSource.DataSource = bindingList;
            // dataGridView1.DataSource = bindingSource;
        }

        public void NewVehicle(string n, double d, double c)
        {
            var newVehicle = new Vehicle(n,d,c);
            _vehicles.Add(newVehicle);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _vehicles;
        }
        
        public void NewVehicle()
        {
            var newVehicle = new Vehicle();
            _vehicles.Add(newVehicle);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _vehicles;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            _vehicles.Clear();
            textBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("vehicles.bin", FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, _vehicles);
            }

            MessageBox.Show(@"Succes");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.FormClosed += NotifyAboutClosedChildForm;
            addUser.Show();
        }
        
        private void NotifyAboutClosedChildForm(object sender, FormClosedEventArgs args)
        {
            dataGridView1.Text += _vehicles;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // dataGridView1.ColumnCount = 3;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("vehicles.bin", FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                _vehicles = (List<Vehicle>)formatter.Deserialize(fs);
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _vehicles;
        }
    }
}