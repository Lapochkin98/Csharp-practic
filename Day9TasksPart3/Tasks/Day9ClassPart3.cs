using System;
using System.Linq;

namespace Day9TasksPart3.Tasks
{
    public class Day9ClassPart3
    {
        public class Massive
        {
            private readonly int[] _userMassive;

            public Massive(int[] array)
            {
                _userMassive = array;
            }

            public int Sum()
            {
                return _userMassive.Sum();
            }

            public int Sum(int n)
            {
                int sum = 0;
                for (int i = 0; i < n && i < _userMassive.Length; i++)
                {
                    sum += _userMassive[i];
                }
                return sum;
            }

            public int Sum(int startIndex, int endIndex)
            {
                int sum = 0;
                for (int i = startIndex; i <= endIndex && i < _userMassive.Length; i++)
                {
                    sum += _userMassive[i];
                }
                return sum;
            }
            
            public static Massive operator +(Massive array1, Massive array2)
            {
                if (array1._userMassive.Length != array2._userMassive.Length)
                {
                    return new Massive(Array.Empty<int>());
                }

                int[] result = new int[array1._userMassive.Length];
                for (int i = 0; i < array1._userMassive.Length; i++)
                {
                    result[i] = array1._userMassive[i] + array2._userMassive[i];
                }

                return new Massive(result);
            }

            public static Massive operator *(Massive array, int multiplier)
            {
                int[] result = new int[array._userMassive.Length];
                for (int i = 0; i < array._userMassive.Length; i++)
                {
                    result[i] = array._userMassive[i] * multiplier;
                }

                return new Massive(result);
            }

            public static Massive operator ++(Massive array)
            {
                int[] result = new int[array._userMassive.Length + 1];
                for (int i = 0; i < array._userMassive.Length; i++)
                {
                    result[i] = array._userMassive[i];
                }

                return new Massive(result);
            }

            public static Massive operator --(Massive array)
            {
                if (array._userMassive.Length == 0)
                {
                    return new Massive(Array.Empty<int>());
                }

                int[] result = new int[array._userMassive.Length - 1];
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = array._userMassive[i];
                }

                return new Massive(result);
            }
            
        }
    }
    class TwoDimArray
    {
        private readonly int[,] _array;
        private readonly int _rows;
        private readonly int _columns;

        // Конструкторы
        public TwoDimArray(int rows, int columns)
        {
            this._rows = rows;
            this._columns = columns;
            _array = new int[rows, columns];
        }

        public TwoDimArray(int[,] array)
        {
            this._array = array;
            _rows = array.GetLength(0);
            _columns = array.GetLength(1);
        }

        // Свойства для доступа к скрытым полям
        public int Rows => _rows;

        public int Columns => _columns;

        // Индексатор для доступа к элементам массива
        public int this[int row, int column]
        {
            get => _array[row, column];
            set => _array[row, column] = value;
        }

        // Метод для вычисления суммы элементов главной диагонали
        private int GetMainDiagonalSum()
        {
            int sum = 0;
            for (int i = 0; i < _rows && i < _columns; i++)
            {
                sum += _array[i, i];
            }
            return sum;
        }

        // Перегруженные операции отношений для сравнения сумм элементов главной диагонали
        public static bool operator >(TwoDimArray array1, TwoDimArray array2)
        {
            return array1.GetMainDiagonalSum() > array2.GetMainDiagonalSum();
        }

        public static bool operator <(TwoDimArray array1, TwoDimArray array2)
        {
            return array1.GetMainDiagonalSum() < array2.GetMainDiagonalSum();
        }
    }
}