using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.CompilerServices;

class Program
{
    static double[] numbers = new double[5];
    static int count = 0;
    static int errors = 0;

    static void Main(string[] args)
    {
        Input();
    }

    static void Input()
    {
        string inputData = "";
        while (true)
        {
            try
            {
                Console.WriteLine("Введите число:");
                inputData = Console.ReadLine().ToLower();

                if (inputData == "q")
                {
                    Output();
                    Menu();
                }
                if (count == numbers.Length)
                {
                    SizeIncrease();
                }
                numbers[count] = double.Parse(inputData);
                count++;
            }
            catch (FormatException)
            {
                Console.WriteLine("Неправильный ввод данных");
                errors++;
            }
        }
    }

    static void Output()
    {
        if (count == 0)
        {
            Console.WriteLine("\nМассив не заполнен\n");
        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"число {i + 1} = {numbers[i]}");
            }
            Console.WriteLine($"Количество введенных чисел = {count}");
            Console.WriteLine($"Число ошибок = {errors} \n");
        }
        Console.WriteLine("Нажмите любую клавишу для продолжения или \n нажмите ESC для завершения программы");
        if (Console.ReadKey().Key == ConsoleKey.Escape)
        {
            Exit();
        }
        else
        {
            Menu();
        }
    }

    static void Menu()
    {
        Console.WriteLine("\n1 - Ввести числа\n2 - Очистить массив\n3 - Вывод данных.\n4 - Закрыть приложение\n");
        string сhoise = Console.ReadLine();
        switch (сhoise)
        {
            case "1":
                Input();
                break;
            case "2":
                Clear();
                break;
            case "3":
                Output();
                break;
            case "4":
                Exit();
                break;
            default:
                Console.WriteLine("Введите цифру от 1 до 4");
                Menu();
                break;
        }
    }

    static void SizeIncrease()
    {
        double[] increasedArray = new double[numbers.Length * 2];
        for (int i = 0; i < numbers.Length; i++)
        {
            increasedArray[i] = numbers[i];
        }
        numbers = increasedArray;
    }

    static void Clear()
    {
        numbers = new double[5];
        count = 0;
        errors = 0;
        Console.WriteLine("Массив очищен.");
        Menu();
    }

    static void Exit()
    {
        Environment.Exit(0);
    }
}