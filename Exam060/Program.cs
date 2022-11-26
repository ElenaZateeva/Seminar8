/*Задача 60. Сформируйте 3D массив из неповторяющихся 2х-значных чисел.
 Напишите метод, который будет построчно выводить массив,
  добавляя  индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)*/

int[,,] array = CreateRandom3DArray(2, 2, 2);
Print3DArray(array);

int[,,] CreateRandom3DArray(int x, int y, int z)
{
    string str = String.Empty;
    int temp = 0;
    int[,,] array = new int[x, y, z];
    Random random = new Random();
    for (var i = 0; i < array.GetLength(0); i++)
    {
        for (var j = 0; j < array.GetLength(1); j++)
        {
            for (var l = 0; l < array.GetLength(2); l++)
            {
                temp = random.Next(10, 100);
                while (str.IndexOf(Convert.ToString(temp))!=-1) // IndexOf при нахождении в строке str части строки возвращает 1, иначе -1
                {
                    temp = random.Next(10, 100);
                }
                array[i, j, l] = temp;
            }
        }
    }
    return array;
}

void Print3DArray(int[,,] array)
{
    for (var i = 0; i < array.GetLength(0); i++)
    {
        for (var j = 0; j < array.GetLength(1); j++)
        {
            for (var l = 0; l < array.GetLength(2); l++)
            {
                Console.Write($"{array[i, j, l]} ({i},{j},{l})  ");
            }
            Console.WriteLine();
        }

    }
}