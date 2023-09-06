using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Day18TasksPart3.Entities
{
   
    public class MenuItem<T>
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public string Type { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        // ReSharper disable once MemberCanBePrivate.Global
        public string Name { get; set; }
        // ReSharper disable once MemberCanBePrivate.Global
        public T Quantity { get; set; }
        // ReSharper disable once MemberCanBePrivate.Global
        public string PhotoPath { get; set; }

        // ReSharper disable once MemberCanBeProtected.Global
        public MenuItem(string type, string name, T quantity, string photoPath)
        {
            Type = type;
            Name = name;
            Quantity = quantity;
            PhotoPath = photoPath;
        }
        

        public decimal GetPrice()
        {
            switch (Type)
            {
                case "Суп":
                    return Convert.ToDecimal(Quantity) * 0.01m;
                case "Салат":
                    return Convert.ToDecimal(Quantity) * 0.025m;
                case "Десерт":
                    return Convert.ToDecimal(Quantity) * 0.05m;
                default:
                    throw new ArgumentException($"Invalid type: {Type}");
            }
        }

        public bool HasPhoto()
        {
            return File.Exists(PhotoPath);
        }
    }

    public class Soup : MenuItem<double>
    {
        public Soup(string name, double quantity, string photoPath) : base("Суп", name, quantity, photoPath) { }
    }

    public class Salad : MenuItem<double>
    {
        public Salad(string name, double quantity, string photoPath) : base("Салат", name, quantity, photoPath) { }
    }

    public class Dessert : MenuItem<int>
    {
        public Dessert(string name, int quantity, string photoPath) : base("Десерт", name, quantity, photoPath) { }
    }

    static class MenuViewer
    {
        public static void DisplayMenuItem<T>(T item, TextBox nameBox, TextBox typeBox, TextBox quantityBox, TextBox priceBox, PictureBox photoBox) where T: Form1.MenuItem
        {
            nameBox.Text = item.Name;
            typeBox.Text = item.Type;
            quantityBox.Text = item.Quantity.ToString(CultureInfo.InvariantCulture);
            priceBox.Text = item.GetPrice().ToString("C");

            if (File.Exists(item.PhotoPath))
            {
                photoBox.ImageLocation = item.PhotoPath;
            }
            else
            {
                photoBox.Image = null;
            }
        }
    }
}