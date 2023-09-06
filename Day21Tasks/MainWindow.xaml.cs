using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Newtonsoft.Json;

namespace Day21Tasks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private enum Player { None, X, O }
        private Player _currentPlayer;
        private Player[,] _board = null!;
        private Button[,] _buttons = null!;
        private const string StatsFilePath = "stats.json";
        private int _xWins;
        private int _oWins;
        

        public MainWindow()
        {
            LoadStats();
            InitializeComponent();
            InitializeGame();
        }
        
        private void InitializeGame()
        {
            _currentPlayer = Player.X;
            _board = new Player[3, 3];
            _buttons = new Button[3, 3];

            // Создание и настройка UniformGrid
            UniformGrid grid = new UniformGrid
            {
                Rows = 3,
                Columns = 3,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    // Создание кнопки
                    Button button = new Button
                    {
                        Width = 80,
                        Height = 80,
                        FontSize = 36
                    };
                    

                    // Привязка события Click
                    button.Click += Button_Click;

                    // Добавление кнопки в UniformGrid и сохранение ссылки в массив
                    _buttons[row, col] = button;
                    
                    grid.Children.Add(button);
                    
                    Grid.SetColumn(button,col);
                    Grid.SetRow(button,row);
                }
            }

            // Добавление UniformGrid на главную сетку окна
            MainGrid.Children.Add(grid);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int row = Grid.GetRow(button);
            int col = Grid.GetColumn(button);
            
            if (_board[row, col] == Player.None)
            {
                _board[row, col] = _currentPlayer;

                if (_currentPlayer == Player.X)
                {
                    button.Content = "X";
                    _currentPlayer = Player.O;
                }
                else if (_currentPlayer == Player.O)
                {
                    button.Content = "O";
                    _currentPlayer = Player.X;
                }

                if (CheckForWinner(row, col))
                {
                    DisableButtons();
                    if ((string)button.Content == "O") {
                        _oWins++;
                        MessageBox.Show($"{button.Content} wins! ({_oWins})");
                    }
                    else{
                        _xWins++;
                        MessageBox.Show($"{button.Content} wins! ({_xWins})");
                    }
                    UpdateStats();
                    InitializeGame();
                }
                else if (IsBoardFull())
                {
                    DisableButtons();
                    MessageBox.Show("It's a draw!");
                    InitializeGame();
                }
            }
        }
        private bool CheckForWinner(int row, int col)
        {
            Player player = _board[row, col];

            // Проверка строк
            if (_board[row, 0] == player && _board[row, 1] == player && _board[row, 2] == player)
                return true;

            // Проверка столбцов
            if (_board[0, col] == player && _board[1, col] == player && _board[2, col] == player)
                return true;

            // Проверка диагоналей
            return (_board[0, 0] == player && _board[1, 1] == player && _board[2, 2] == player) ||
                   (_board[0, 2] == player && _board[1, 1] == player && _board[2, 0] == player);
        }
        private bool IsBoardFull()
        {
            foreach (Player player in _board)
            {
                if (player == Player.None)
                    return false;
            }
            return true;
        }
        private void DisableButtons()
        {
            foreach (Button button in _buttons)
            {
                button.IsEnabled = false;
            }
        }
        private void UpdateStats()
        {
            // Вычисление процентов побед для каждого игрока
            double totalGames = _xWins + _oWins;
            double xWinPercentage = totalGames > 0 ? (_xWins / totalGames) * 100 : 0;
            double oWinPercentage = totalGames > 0 ? (_oWins / totalGames) * 100 : 0;

            // Создание объекта для сериализации в JSON
            var stats = new
            {
                xWins = _xWins,
                oWins = _oWins,
                xWinPercentage,
                oWinPercentage
            };

            try
            {
                // Сериализация объекта в JSON строку
                string json = JsonConvert.SerializeObject(stats, Formatting.Indented);

                // Запись JSON строки в файл
                File.WriteAllText(StatsFilePath, json);
            }
            catch (IOException)
            {
                MessageBox.Show("Failed to update stats.");
            }
        }
        private void LoadStats()
        {
            if (File.Exists(StatsFilePath))
            {
                try
                {
                    string json = File.ReadAllText(StatsFilePath);
                    Stats stats = JsonConvert.DeserializeObject<Stats>(json)!;
                    if (true)
                    {
                        _xWins = stats.XWins;
                        _oWins = stats.OWins;
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Failed to load stats.");
                }
            }
            else
            {
                _xWins = 0;
                _oWins = 0;
            }
        }

        private class Stats
        {
            [JsonProperty("xWins")]
            public int XWins { get; set; }

            [JsonProperty("oWins")]
            public int OWins { get; set; }
        }
    }
}