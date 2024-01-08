using System;

class MyMatrix
{
    private int[,] matrix;
    private Random random = new Random();

    // Свойства для получения числа строк и столбцов матрицы
    public int Rows { get; private set; }
    public int Columns { get; private set; }

    // Конструктор для создания матрицы с заданным числом строк, столбцов, минимальным и максимальным значениями
    public MyMatrix(int rows, int columns, int minValue, int maxValue)
    {
        if (rows <= 0 || columns <= 0)
        {
            throw new ArgumentException("Число строк и столбцов должно быть больше 0.");
        }

        Rows = rows;
        Columns = columns;
        matrix = new int[Rows, Columns];
        Fill(minValue, maxValue);
    }

    // Индексатор для доступа к элементам матрицы
    public int this[int index1, int index2]
    {
        get
        {
            return matrix[index1, index2];
        }
        set
        {
            matrix[index1, index2] = value;
        }
    }

    // Метод для заполнения матрицы случайными значениями в заданном диапазоне
    public void Fill(int minValue, int maxValue)
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                matrix[i, j] = random.Next(minValue, maxValue + 1);
            }
        }
    }

    // Метод для изменения размера матрицы
    public void ChangeSize(int newRows, int newColumns)
    {
        if (newRows <= 0 || newColumns <= 0)
        {
            throw new ArgumentException("Новое число строк и столбцов должно быть больше 0.");
        }

        int[,] newMatrix = new int[newRows, newColumns];

        for (int i = 0; i < Math.Min(Rows, newRows); i++)
        {
            for (int j = 0; j < Math.Min(Columns, newColumns); j++)
            {
                newMatrix[i, j] = matrix[i, j];
            }
        }

        Rows = newRows;
        Columns = newColumns;
        matrix = newMatrix;

        // Если новая матрица больше существующей, дозаполняем случайными значениями.
        if (newRows > Rows || newColumns > Columns)
        {
            for (int i = Rows; i < newRows; i++)
            {
                for (int j = Columns; j < newColumns; j++)
                {
                    matrix[i, j] = random.Next();
                }
            }
        }
    }

    // Метод для отображения всей матрицы
    public void Show()
    {
        ShowPartialy(0, Rows - 1, 0, Columns - 1);
    }

    // Метод для отображения части матрицы
    public void ShowPartialy(int startRow, int endRow, int startColumn, int endColumn)
    {
        for (int i = startRow; i <= endRow; i++)
        {
            for (int j = startColumn; j <= endColumn; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Введите количество строк: ");
            int rows = int.Parse(Console.ReadLine());

            Console.Write("Введите количество столбцов: ");
            int columns = int.Parse(Console.ReadLine());

            Console.Write("Введите минимальное значение: ");
            int minValue = int.Parse(Console.ReadLine());

            Console.Write("Введите максимальное значение: ");
            int maxValue = int.Parse(Console.ReadLine());

            MyMatrix matrix = new MyMatrix(rows, columns, minValue, maxValue);

            Console.WriteLine("Исходная матрица:");
            matrix.Show();

            Console.WriteLine("\nИзменение размера матрицы:");
            Console.Write("Введите новое количество строк: ");
            int newRows = int.Parse(Console.ReadLine());

            Console.Write("Введите новое количество столбцов: ");
            int newColumns = int.Parse(Console.ReadLine());

            matrix.ChangeSize(newRows, newColumns);
            matrix.Show();

            Console.WriteLine("\nЧасть матрицы:");
            matrix.ShowPartialy(0, 1, 0, 1);

            Console.WriteLine("\nИзменение значения через индексатор:");
            Console.Write("Введите индекс строки: ");
            int rowIndex = int.Parse(Console.ReadLine());

            Console.Write("Введите индекс столбца: ");
            int columnIndex = int.Parse(Console.ReadLine());

            Console.Write("Введите новое значение: ");
            int newValue = int.Parse(Console.ReadLine());

            matrix[rowIndex, columnIndex] = newValue;

            Console.WriteLine("Измененная матрица:");
            matrix.Show();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}