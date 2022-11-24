/*Задача 57: Составить частотный словарь элементов двумерного массива.
 Частотный словарь содержит информацию о том, 
сколько раз встречается элемент входных данных.
1, 9, 9, 0, 2, 8, 0, 9
0 встречается 2 раза
1 встречается 1 раз
2 встречается 1 раз
8 встречается 1 раз
9 встречается 3 раза*/

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
int[,] array2 = CountSimbols(array);
Console.WriteLine();
Print2DArray(array2);

int[,] CountSimbols(int[,] array)
{
    int[,] result = new int[2, array.Length];
    int index = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            int find = Check(result, array[i, j]);
            if (find != -1)
            {
                result[1, find]++;
            }
            else
            {
                result[0, index] = array[i, j];
                result[1, index] = 1;
                index++;
            }
        }
    }
    return Trim(result);
}

int Check(int[,] array, int number)
{
    for (int i = 0; i < array.GetLength(1); i++)
    {
        if (array[0, i] == number)
        {
            return i;
        }
    }
    return -1;
}

int[,] Trim(int[,] array)
{
    int index = 0;
    for (int i = 0; i < array.GetLength(1); i++)
    {
        if (array[1, i] == 0)
        {
            index = i;
            break;
        }
    }
    int[,] result = new int[2, index];
    for (int j = 0; j < result.GetLength(1); j++)
    {
        result[0, j] = array[0, j];
        result[1, j] = array[1, j];
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