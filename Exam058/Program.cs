/*Задача 58: Задайте две матрицы. Напишите метод, 
который будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4  |   3 4
3 2  |   3 3
Результирующая матрица будет:
18 20
15 18*/

Console.WriteLine("Введите m - ");
bool isParsedM = int.TryParse(Console.ReadLine(), out int m);
Console.WriteLine("Введите n - ");
bool isParsedN = int.TryParse(Console.ReadLine(), out int n);

if (!isParsedM || !isParsedN)
{
    Console.WriteLine("Ошибка!");
    return;
}

int[,] matrice1 = CreateRandom2DArray(m, n);
int[,] matrice2 = CreateRandom2DArray(n, m);
Print2DArray(matrice1);
Console.WriteLine();
Print2DArray(matrice2);
int[,] result = Product2Matrices(matrice1, matrice2);
Console.WriteLine();
Print2DArray(result);


int[,] Product2Matrices(int[,] array1, int[,] array2)
{
    int[,] result = new int[array1.GetLength(0), array2.GetLength(1)];
    for (int row = 0; row < array1.GetLength(0); row++)
    {
        for (int i = 0; i < array1.GetLength(0); i++)
        {
            int productRow = 0; 
           // int row=0;
            for (int j = 0; j < array1.GetLength(1); j++)
            {
                productRow += array1[row, j] * array2[j, i];
            }
            result[row,i] = productRow;
            //row++;
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