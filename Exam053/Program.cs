/*Задача 53: Задайте двумерный массив. Напишите программу, 
которая поменяет местами первую и последнюю строку массива.*/

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
SwapFirstAndLastRow(array);
Console.WriteLine();
Print2DArray(array);

void SwapFirstAndLastRow(int[,] array)
{
    for (int i = 0; i < array.GetLength(1); i++)
    {
        int temp = array[0, i];
        array[0,i]=array[array.GetUpperBound(0),i];
        array[array.GetUpperBound(0),i]=temp;
    }
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