using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Day18TasksPart3.Entities;
using Newtonsoft.Json.Linq;

namespace Day18TasksPart3
{
    
    
    
    public partial class Form1 : Form
    {
        public class MenuItem
        {
            public string Type { get; set; }
            public string Name { get; set; }
            public double Quantity { get; set; }
            public string PhotoPath { get; set; }

            protected MenuItem(string type, string name, double quantity, string photoPath)
            {
                Type = type;
                Name = name;
                Quantity = quantity;
                PhotoPath = photoPath;
            }

            public double GetPrice()
            {
                switch (Type)
                {
                    case "Суп":
                        return Quantity * 0.01;
                    case "Салат":
                        return Quantity * 0.025;
                    case "Десерт":
                        return Quantity * 0.05;
                    default:
                        throw new ArgumentException($"Invalid type: {Type}");
                }
            }
        }

        class Soup : MenuItem
        {
            public Soup(string name, double quantity, string photoPath) : base("Суп", name, quantity, photoPath) { }
        }

        class Salad : MenuItem
        {
            public Salad(string name, double quantity, string photoPath) : base("Салат", name, quantity, photoPath) { }
        }

        class Dessert : MenuItem
        {
            public Dessert(string name, double quantity, string photoPath) : base("Десерт", name, quantity, photoPath) { }
        }

        readonly List<MenuItem> _menuItems = new List<MenuItem>
        {
            new Soup("Грибной", 300, "photos/soup_mushroom.jpg"),
            new Soup("Борщ", 250, "photos/soup_borsch.jpg"),
            new Salad("Цезарь", 150, "photos/salad_caesar.jpg") 
        };
        int _currentItemIndex;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MenuViewer.DisplayMenuItem(_menuItems[_currentItemIndex], nameBox, typeBox, quantityBox, priceBox, photoBox);
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            if (_currentItemIndex > 0)
            {
                _currentItemIndex--;
                MenuViewer.DisplayMenuItem(_menuItems[_currentItemIndex], nameBox, typeBox, quantityBox, priceBox, photoBox);
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (_currentItemIndex < _menuItems.Count - 1)
            {
                _currentItemIndex++;
                MenuViewer.DisplayMenuItem(_menuItems[_currentItemIndex], nameBox, typeBox, quantityBox, priceBox, photoBox);
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Очистить список перед загрузкой данных
            _menuItems.Clear();

            // Прочитать все строки из файла
            string filePath = "settings.json";
            string jsonData = File.ReadAllText(filePath);

            // Разобрать данные из файла и создать объекты блюд на основе этих данных
            JArray jsonArray = JArray.Parse(jsonData);
            foreach (var jToken in jsonArray)
            {
                var itemObject = (JObject)jToken;
                string type = (string)itemObject["type"];
                string name = (string)itemObject["name"];
                int quantity = (int)itemObject["quantity"];
                string photoPath = (string)itemObject["photoPath"];

                MenuItem item;
                if (type == "суп")
                {
                    item = new Soup(name, quantity, photoPath);
                }
                else if (type == "салат")
                {
                    item = new Salad(name, quantity, photoPath);
                }
                else if (type == "десерт")
                {
                    item = new Dessert(name, quantity, photoPath);
                }
                else
                {
                    // Если тип блюда неизвестен, пропустить строку
                    continue;
                }

                // Добавить объект блюда в список
                _menuItems.Add(item);
            }
        }
    }
}