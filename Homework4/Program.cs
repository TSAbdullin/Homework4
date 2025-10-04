
class Start
{
    public static void Main(string[] args)
    {
        int num1 = 5;
        int num2 = 10;

        ////////////////////////////////////////
        Console.WriteLine("Упражнение 5.1 Написать метод, возвращающий наибольшее из двух чисел. Входные\r\nпараметры метода – два целых числа. Протестировать метод.\n");
        Console.WriteLine(PrintTheBiggestOfTwoNum(4, 10) + "\n");
        ////////////////////////////////////////

        ////////////////////////////////////////
        Console.WriteLine("Упражнение 5.2 Написать метод, который меняет местами значения двух передаваемых\r\nпараметров. Параметры передавать по ссылке. Протестировать метод.\n");
        Console.WriteLine($"Значения до вызова метода: num1 = {num1}, num2 = {num2}");
        ChangeValuesOfTwoNum(ref num1, ref num2);
        Console.WriteLine($"Значения после вызова метода: num1 = {num1}, num2 = {num2}");
        ////////////////////////////////////////

        ////////////////////////////////////////
        Console.WriteLine("Упражнение 5.3 Написать метод вычисления факториала числа, результат вычислений\r\nпередавать в выходном параметре. Если метод отработал успешно, то вернуть значение\r\ntrue; если в процессе вычисления возникло переполнение, то вернуть значение false. Для\r\nотслеживания переполнения значения использовать блок checked.\n");
        Console.Write("Введите число: ");
        if (!int.TryParse(Console.ReadLine(), out int num))
        {
            Console.WriteLine("Это не число!\n");
        }
        else
        {
            Console.WriteLine(Factorial(num, out int n));
            Console.WriteLine($"Факториал числа {num}! = {n}\n");
        }
        ////////////////////////////////////////

        ////////////////////////////////////////
        Console.WriteLine("Упражнение 5.4 Написать рекурсивный метод вычисления факториала числа.\n");
        Console.Write("Введите число: ");
        if (!long.TryParse(Console.ReadLine(), out long num3))
        {
            Console.WriteLine("Это не число!\n");
        }
        else
        {
            Console.WriteLine($"Факториал числа {num3}! = {Factorial(num3)}\n");
        }
        ////////////////////////////////////////
    
        ////////////////////////////////////////
        Console.WriteLine("Домашнее задание 5.1 Написать метод, который вычисляет НОД двух натуральных чисел\r\n(алгоритм Евклида). Написать метод с тем же именем, который вычисляет НОД трех\r\nнатуральных чисел.\n");
        Console.WriteLine($"Наименьший общий делитель: {SearchNOD(98, 56)}");

        Console.WriteLine($"Наименьший общий делитель: {SearchNOD(48, 18, 30)}");
        ////////////////////////////////////////

        ////////////////////////////////////////
        Console.WriteLine("Домашнее задание 5.2 Написать рекурсивный метод, вычисляющий значение n-го числа\r\nряда Фибоначчи. Ряд Фибоначчи – последовательность натуральных чисел 1, 1, 2, 3, 5, 8,\r\n13... Для таких чисел верно соотношение Fk = Fk-1 + Fk-2\n");
        Console.Write("Введите число N: ");

        if (!int.TryParse(Console.ReadLine(), out int NFibbonacchi)) {
            Console.WriteLine("Ошибка: Неверный формат!");
        }
        else
        {
            Console.WriteLine($"Число n в ряде Фиббоначчи равно: {Fibbonacchi(NFibbonacchi)}");
        }
        ////////////////////////////////////////
    }

    static int PrintTheBiggestOfTwoNum(int num1, int num2) // возвращаем наибольшее из двух чисел
    {

        return num1 > num2 ? num1 : num2;
    }

    static void ChangeValuesOfTwoNum(ref int num1, ref int num2) // меняем значения двух переменных
    {

        int temp = num1;
        num1 = num2;
        num2 = temp;

    }

    static bool Factorial(int num, out int n) // факториал через цикл
    {
        n = 1;

        try
        {
            checked
            {
                for (int i = 1; i <= num; i++)
                {
                    n *= i;
                }
                return true;
            }
        }
        catch (OverflowException)
        {
            {
                n = -1;
                Console.WriteLine("Ошибка: Число выходит за предел!");
                return false;
            }

        }
    }

    static long Factorial(long num) // рекурсивный факториал числа
    {
        return num <= 1 ? 1 : num * Factorial(num - 1);
    }

    static int SearchNOD(int num1, int num2) 
    {
        return num1 % num2 == 0 ? num2 : SearchNOD(num2, num1 % num2);
    }

    static int SearchNOD(int num1, int num2, int num3)
    {
        return SearchNOD(SearchNOD(num1, num2), num3);
    }

    static int Fibbonacchi(int n)
    {
        return (n == 1 || n == 2) ? 1 : Fibbonacchi(n - 1) + Fibbonacchi(n - 2);
    }
}