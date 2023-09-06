using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Day19Tasks
{
    public partial class DictionaryEnlarger : Form
    {
        
        private void SerializeAndSaveTranslation(string word, string translation, string fileName)
        {
            Dictionary<string, string> translations;

            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                translations = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }

            translations[word] = translation;

            string output = JsonConvert.SerializeObject(translations);

            using (StreamWriter w = new StreamWriter(fileName))
            {
                w.Write(output);
            }
        }
        
        public class Translation : Dictionary<string, string>
        {
        }
        
        Dictionary<string, string> _enRuDictionary = new Dictionary<string, string>();
        Dictionary<string, string> _ruEnDictionary = new Dictionary<string, string>();
        
        public DictionaryEnlarger()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms[0];
            form.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            string word = textBox1.Text.Trim().ToLower();
            string translation = textBox2.Text.Trim().ToLower();
            
            if (!_enRuDictionary.ContainsKey(word))
            {
                // Если слово отсутствует в словаре, добавляем новую пару слов
                _enRuDictionary.Add(word, translation);
            }
            else
            {
                // Если слово уже есть в словаре, проверяем, что новый вариант перевода еще не содержится в списке значений
                if (!_enRuDictionary[word].Contains(translation))
                {
                    // Если новый вариант перевода отсутствует, добавляем его к списку значений
                    _enRuDictionary[word] += $", {translation}";
                }
            }
            _ruEnDictionary[translation] = word;

            if (!string.IsNullOrEmpty(word) && !string.IsNullOrEmpty(translation))
            {
                SerializeAndSaveTranslation( translation, word,@"D:\College Labs\MyLabs\C#works\Practic\day.1\ConsoleApplication1\Day19Tasks\Data\RuEnDict.json");
                SerializeAndSaveTranslation( word, _enRuDictionary[word],@"D:\College Labs\MyLabs\C#works\Practic\day.1\ConsoleApplication1\Day19Tasks\Data\EnRuDict.json");
            }
            
            foreach (KeyValuePair<string, string> pair in _enRuDictionary)
            {
                listBox1.Items.Add($"{pair.Key} - {pair.Value}");
                listBox2.Items.Add($"{pair.Value} - {pair.Key}"); 
            }
        }

        private void DictionaryEnlarger_Load(object sender, EventArgs e)
        {
            using (StreamReader r = new StreamReader(@"D:\College Labs\MyLabs\C#works\Practic\day.1\ConsoleApplication1\Day19Tasks\Data\EnRuDict.json"))
            {
                string json = r.ReadToEnd();
                _enRuDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }

            using (StreamReader r = new StreamReader(@"D:\College Labs\MyLabs\C#works\Practic\day.1\ConsoleApplication1\Day19Tasks\Data\RuEnDict.json"))
            {
                string json = r.ReadToEnd();
                _ruEnDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
            
            foreach (var pair in _ruEnDictionary)
            {
                listBox2.Items.Add($"{pair.Key} - {pair.Value}"); 
                listBox1.Items.Add($"{pair.Value} - {pair.Key}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            
            string word = textBox4.Text.ToLower();
            string translation = textBox3.Text.ToLower();
            
            if (!_ruEnDictionary.ContainsKey(word))
            {
                // Если слово отсутствует в словаре, добавляем новую пару слов
                _ruEnDictionary.Add(word, translation);
            }
            else
            {
                // Если слово уже есть в словаре, проверяем, что новый вариант перевода еще не содержится в списке значений
                if (!_ruEnDictionary[word].Contains(translation))
                {
                    // Если новый вариант перевода отсутствует, добавляем его к списку значений
                    _ruEnDictionary[word] += $", {translation}";
                }
            }
            _enRuDictionary[translation] = word;
            
            if (!string.IsNullOrEmpty(word) && !string.IsNullOrEmpty(translation))
            {
                
                SerializeAndSaveTranslation( word, _ruEnDictionary[word],@"D:\College Labs\MyLabs\C#works\Practic\day.1\ConsoleApplication1\Day19Tasks\Data\RuEnDict.json");
                SerializeAndSaveTranslation( translation, word,@"D:\College Labs\MyLabs\C#works\Practic\day.1\ConsoleApplication1\Day19Tasks\Data\EnRuDict.json");
            }
            
            foreach (var pair in _ruEnDictionary)
            {
                listBox2.Items.Add($"{pair.Key} - {pair.Value}"); 
                listBox1.Items.Add($"{pair.Value} - {pair.Key}");
            }
            
        }
    }
}