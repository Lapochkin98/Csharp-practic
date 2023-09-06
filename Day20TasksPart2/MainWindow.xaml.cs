using System.Linq;
using System.Text.RegularExpressions;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Day20TasksPart2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int counter = 0;

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(textBox1.Text);
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            counter++;
            label1.Content = counter.ToString();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            int sum = (int.Parse(textBox2.Text) + int.Parse(textBox3.Text));
            label2.Content = sum.ToString();
        }

        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
            this.Background = Brushes.Red;
        }

        private void radioButton2_Checked(object sender, RoutedEventArgs e)
        {
            this.Background = Brushes.Green;
        }

        private void ResizeButton_Click(object sender, RoutedEventArgs e)
        {
            int width, height;
            bool isValidWidth = int.TryParse(widthTextBox.Text, out width);
            bool isValidHeight = int.TryParse(heightTextBox.Text, out height);

            if (isValidWidth && isValidHeight)
            {
                this.Width = width;
                this.Height = height;
            }
            else
            {
                MessageBox.Show("Invalid width or height value. Please enter valid integers.");
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            label10.Content = "Checked";
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            label10.Content = "Unchecked";
        }

        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            string inputString = inputTextBox.Text;

            // Подсчет количества символов
            int characterCount = inputString.Length;
            characterCountLabel.Content = $"Character Count: {characterCount}";

            // Подсчет количества слов
            string[] words = inputString.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int wordCount = words.Length;
            wordCountLabel.Content = $"Word Count: {wordCount}";

            // Подсчет количества цифр
            int digitCount = inputString.Count(char.IsDigit);
            digitCountLabel.Content = $"Digit Count: {digitCount}";

            // Подсчет количества знаков препинания
            int punctuationCount = Regex.Matches(inputString, @"[\p{P}\p{S}]").Count;
            punctuationCountLabel.Content = $"Punctuation Count: {punctuationCount}";
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            string input = inputTextBox.Text;
            string[] numbers = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int[] array = numbers.Select(int.Parse).ToArray();

            if (array.Length > 0)
            {
                int min = array.Min();
                int max = array.Max();
                int sum = min + max;
                resultLabel.Content = $"Sum: {sum}";
            }
            else
            {
                resultLabel.Content = "Please enter a valid array of numbers.";
            }
        }
    }
}