using AnotherTasks.Structs;
using AnotherTasks.Enums;
class Start
{
    public static void Main(string[] args)
    {
        ////////////////////////////////
        try
        {
            Console.WriteLine("Задание 1. Вывести на экран массив из 20 случайных чисел. Ввести два числа из этого массива, которые нужно поменять местами.Вывести на экран получившийся массив.\n");
            ChangePlacesOfTwoNums(-1000, 1000);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка: {e.Message}");
        }
        finally
        {
            Console.WriteLine("Конец выполнения первого задания");
        }
        ////////////////////////////////

        ////////////////////////////////
        try
        {
            long num = 1;
            Console.WriteLine("\n\nЗадание 2. Написать метод, где в качества аргумента будет передан массив (ключевое слово\r\nparams). Вывести сумму элементов массива (вернуть). Вывести (ref) произведение\r\nмассива. Вывести (out) среднее арифметическое в массиве.\r\n");
            int sum = CalculateSumOfArray(ref num, out double arifmeticMean, 1, 2, 422221, 32333, 4, 14333, 6); // присваиваем сумму элементов всех значений
            Console.WriteLine($"Произведение элементов массива: {num}\nСреднее арифметическое элементов массива: {Math.Round(arifmeticMean, 2)}\nСумма элементов массива: {sum}\n");
        }
        catch (OverflowException e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.WriteLine("Конец второго задания");
        }
        ////////////////////////////////

        ////////////////////////////////
        Console.WriteLine("\nЗадание 3. Пользователь вводит числа. Если числа от 0 до 9, то необходимо в консоли нарисовать\r\nизображение цифры в виде символа #.Если число больше 9 или меньше 0, то консоль\r\nдолжна окраситься в красный цвет на 3 секунды и вывести сообщение об ошибке.\r\nЕсли пользователь ввёл не цифру, то программа должна выпасть в исключение.\r\nПрограмма завершает работу, если пользователь введёт слово: exit или закрыть (оба\r\nварианта должны сработать) - консоль закроется.\n");
        PrintDigit();
        ////////////////////////////////

        ////////////////////////////////
        Console.WriteLine("\nЗадание 4. Создать структуру Дед. У деда есть имя, уровень ворчливости (перечисление), массив\r\nфраз для ворчания (прим.: “Проститутки!”, “Гады!”), количество синяков от ударов\r\nбабки = 0 по умолчанию. Создать 5 дедов. У каждого деда - разное количество фраз\r\nдля ворчания. Напишите метод (внутри структуры), который на вход принимает деда,\r\nсписок матерных слов (params). Если дед содержит в своей лексике матерные слова из\r\nсписка, то бабка ставит фингал за каждое слово. Вернуть количество фингалов.\n");
        Grandfather grandfather1 = new Grandfather("Sergei", Grouchiness.FirstLevel, "ПростИтуки!", "Гады");
        Grandfather grandfather2 = new Grandfather("Vladimir", Grouchiness.SecondLevel, "Суки!", "Гады", "Сволочи");
        Grandfather grandfather3 = new Grandfather("Roman", Grouchiness.FirstLevel, "Проституки!", "Гады", "Сволочи");
        Grandfather grandfather4 = new Grandfather("Ilya", Grouchiness.ThirdLevel, "Проституки!", "Гады", "Сволочи", "Суки", "Твари", "Жлобы");
        Grandfather grandfather5 = new Grandfather("Art", Grouchiness.FirstLevel, "Проституки!", "Гады", "Сволочи");

        Console.WriteLine(Grandfather.CalculateAmountOfFingals(ref grandfather4, "простиТутки", "гады", "суки"));
        Console.WriteLine(grandfather4.AmountOfFingals);
        ////////////////////////////////

    }

    // Вывести на экран массив из 20 случайных чисел. Ввести два числа из этого массива, которые нужно поменять местами.Вывести на экран получившийся массив.
    static void ChangePlacesOfTwoNums(int minValue, int maxValue)
    {
        Random random = new Random();
        int amountOfNums = 20; // количество элементов в массиве

        int[] arrayNums = new int[amountOfNums];

        for (int i = 0; i < arrayNums.Length; i++)
        {
            arrayNums[i] = random.Next(minValue, maxValue); // заполняем массив рандомными числами
        }

        Console.WriteLine("Выводим массив до изменений: ");
        
        foreach (int n in arrayNums)
        {
            Console.Write(n + " "); // выводим все элементы массива чисел
        }

        Console.Write("\nВведите первое число из массива: ");
        
        if (!int.TryParse(Console.ReadLine(), out int num1))
        {
            throw new FormatException("Неверный формат! Вероятнее было введено не число");
        }
        
        Console.Write("\nВведите второе число из массива: ");

        if (!int.TryParse(Console.ReadLine(), out int num2))
        {
            throw new FormatException("Неверный формат! Вероятнее было введено не число");
        }
            
        if (!arrayNums.Contains(num1) || !arrayNums.Contains(num2))
        {
            throw new ArgumentException("Одного из чисел не было в массиве!");
        }

        if (num1 == num2)
        {
            Console.WriteLine("Два числа одинаковые, смысла в перестановке нет!");
            return;
        } 
        else
        {
            int temp = num1; // копируем введенное число от пользователя во временную переменную

            for (int i = 0;  i < arrayNums.Length; i++)
            {
                if (arrayNums[i] == num1)
                {
                    arrayNums[i] = num2; // меняем значение элемента массива на число, введенное от пользователя
                }
                else if (arrayNums[i] == num2)
                {
                    arrayNums[i] = num1; // меняем значение элемента массива на число, введенное от пользователя
                }
            }

            Console.WriteLine("Массив после изменения: ");

            foreach (int n in arrayNums)
            {
                Console.Write(n + " ");
            }
        }

    }

    static int CalculateSumOfArray(ref long num, out double arifmeticMean, params int[] array)
    {
        int sum = 0; // сумма элементов массива

        checked
        {
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i]; // суммируем элементы массива
                num *= array[i]; // произведение элементов массива
            }
        }

        if (array.Length != 0)
        {
            arifmeticMean = (double)sum / (double)array.Length; // вычисляем среднее арифметическое
        }
        else
        {
            Console.WriteLine("Длина массива равна нулю!");
            arifmeticMean = 0; // на случай, если длина массива окажется 0, то присвоим переменной среднее арифметическое равное 0
        }

        return sum;
    }


    static void PrintDigit()
    {
        string[] numsArr = // массив для хранения чисел в виде решеток
        {
            "#####\n" +
            "#   #\n" +
            "#   #\n" +
            "#   #\n" +
            "#####\n",

            "  #\n" +
            " ##\n" +
            "# #\n" +
            "  #\n" +
            "#####\n",

            "#####\n" +
            "    #\n" +
            "#####\n" +
            "#\n" +
            "#####\n",

            "#####\n" +
            "    #\n" +
            "#####\n" +
            "    #\n" +
            "#####\n",

            "#   #\n" +
            "#   #\n" +
            "#####\n" +
            "    #\n" +
            "    #\n",

            "#####\n" +
            "#\n" +
            "#####\n" +
            "    #\n" +
            "#####\n",

            " ####\n" +
            "#\n" +
            "#####\n" +
            "#   #\n" +
            "#####\n",

            "#####\n" +
            "    #\n" +
            "   #\n" +
            "  #\n" +
            " #\n",

            "#####\n" +
            "#   #\n" +
            "#####\n" +
            "#   #\n" +
            "#####\n",

            "#####\n" +
            "#   #\n" +
            "#####\n" +
            "    #\n" +
            "#####\n"
        };

        while (true)
        {
            Console.Write("Введите число от 0 до 9(для выхода пропишите exit/закрыть): ");
            string input = Console.ReadLine(); // получаем строку от пользователя

            if (int.TryParse(input, out int num))
            {
                if (num < 0 || num > 9)
                {
                    Console.BackgroundColor = ConsoleColor.Red; // меняем цвет консоли на красный
                    Console.WriteLine("Ошибка: Введенное число не входит в диапазон от 0 до 9");
                    Thread.Sleep(3000); // останавливаем поток на 3 секунды
                    Console.ResetColor(); // возвращаем дефолтный цвет
                }
                else
                {
                    Console.WriteLine(numsArr[num]);
                }
            }
            else if (input.Equals("закрыть", StringComparison.OrdinalIgnoreCase) ||
                       input.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Выходим из цикла!");
                return;
            }
            else
            {
                throw new FormatException("Введено не число!");
            }
        }
    }
}