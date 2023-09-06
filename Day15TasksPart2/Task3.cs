using System.Windows.Forms;

namespace Day15TasksPart2
{
    public partial class Task3 : Form
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        public Task3()
        {
            InitializeComponent();
            openFileDialog.Filter = @"Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog.Filter = @"Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }
        
    }
}