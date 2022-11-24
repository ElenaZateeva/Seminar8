/*Задача 59: Задайте двумерный массив из целых чисел. Напишите программу, 
которая удалит строку и столбец, на пересечении которых расположен 
наименьший элемент массива. Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
Наименьший элемент - 1, на выходе получим следующий массив:
9 2 3
4 2 4*/

Console.WriteLine("Введите m - ");
bool isParsedM = int.TryParse(Console.ReadLine(), out int m);
Console.WriteLine("Введите n - ");
bool isParsedN = int.TryParse(Console.ReadLine(), out int n);

if (!isParsedM || !isParsedN)
{
    Console.WriteLine("Ошибка!");
    return;
}

int[,] array = CreateRandom2DArray(m, n);
Print2DArray(array);
(int, int) indexes = FindMinNumber(array);
int[,] result = DeleteRowAndColumn(array, indexes.Item1, indexes.Item2);
Console.WriteLine();
Print2DArray(result);

(int, int) FindMinNumber(int[,] array)
{
    int indexX = 0;
    int indexY = 0;
    int min = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] < min)
            {
                min = array[i, j];
                indexX = i;
                indexY = j;
            }
        }
    }
    return (indexX, indexY);
}

int[,] DeleteRowAndColumn(int[,] array, int indexRow, int indexColumn)
{
    int[,] result = new int[array.GetLength(0) - 1, array.GetLength(1) - 1];
    int row = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int column = 0;
        if (i != indexRow)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (j != indexColumn)
                {
                    result[row, column] = array[i, j];
                    column++;
                }
            }
            row++;
        }
    }
    return result;
}

int[,] CreateRandom2DArray(int m, int n)
{
    int[,] array = new int[m, n];
    Random random = new Random();
    for (var i = 0; i < array.GetLength(0); i++)
    {
        for (var j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = random.Next(1, 10);
        }
    }
    return array;
}

void Print2DArray(int[,] array)
{
    for (var i = 0; i < array.GetLength(0); i++)
    {
        for (var j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}
