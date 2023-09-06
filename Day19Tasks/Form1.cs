using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Day19Tasks
{
    public partial class Form1 : Form
    {
        private Dictionary<string, string> _enRuDict;
        private Dictionary<string, string> _ruEnDict;
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void engRusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var enRuJson = File.ReadAllText(@"D:\College Labs\MyLabs\C#works\Practic\day.1\ConsoleApplication1\Day19Tasks\Data\EnRuDict.json");
            _enRuDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(enRuJson);

            var ruEnJson = File.ReadAllText(@"D:\College Labs\MyLabs\C#works\Practic\day.1\ConsoleApplication1\Day19Tasks\Data\RuEnDict.json");
            _ruEnDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(ruEnJson);
            
            var inputWord = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(inputWord))
            {
                MessageBox.Show(@"Please enter a word to translate");
                return;
            }
            var translation = TranslateWord(inputWord, _enRuDict);
            textBox2.Text = translation;
        }
        
        private string TranslateWord(string word, Dictionary<string, string> dictionary)
        {
            return dictionary.TryGetValue(word.ToLower(), out var translation) ? translation : $"Translation for '{word}' not found";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var enRuJson = File.ReadAllText(@"D:\College Labs\MyLabs\C#works\Practic\day.1\ConsoleApplication1\Day19Tasks\Data\EnRuDict.json");
            _enRuDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(enRuJson);

            var ruEnJson = File.ReadAllText(@"D:\College Labs\MyLabs\C#works\Practic\day.1\ConsoleApplication1\Day19Tasks\Data\RuEnDict.json");
            _ruEnDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(ruEnJson);
        }

        private void rusEngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var enRuJson = File.ReadAllText(@"D:\College Labs\MyLabs\C#works\Practic\day.1\ConsoleApplication1\Day19Tasks\Data\EnRuDict.json");
            _enRuDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(enRuJson);

            var ruEnJson = File.ReadAllText(@"D:\College Labs\MyLabs\C#works\Practic\day.1\ConsoleApplication1\Day19Tasks\Data\RuEnDict.json");
            _ruEnDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(ruEnJson);
            
            var inputWord = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(inputWord))
            {
                MessageBox.Show(@"Please enter a word to translate");
                return;
            }
            var translation = TranslateWord(inputWord, _ruEnDict);
            textBox1.Text = translation;
        }

        private void dictionaryEnlargerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DictionaryEnlarger form = new DictionaryEnlarger();
            form.Show();
            Hide();
        }
    }
}