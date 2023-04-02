using System;

namespace CourseWork
{
    class Program
    {
        // Генерирует случайное отрицательное число в заданном диапазоне
        static int RandomNegative(int min, int max)
        {
            Random random = new Random();
            return -random.Next(min, max + 1);
        }

        // Выводит на экран приветствие и правила игры
        static void Greet()
        {
            Console.WriteLine("Добро пожаловать в программу по сложению и вычитанию отрицательных чисел!");
            Console.WriteLine("Вам будут предложены задания разной сложности, в которых нужно будет найти сумму или разность двух отрицательных чисел.");
            Console.WriteLine("Для каждого задания вы можете выбрать один из трех уровней сложности: легкий, средний или тяжелый.");
            Console.WriteLine("На легком уровне числа будут от -10 до -1, на среднем - от -100 до -11, на тяжелом - от -1000 до -101.");
            Console.WriteLine("Вы можете вводить ответы как со знаком минус, так и без него. Например, -5 и 5 оба являются правильными ответами на вопрос (-3) + (-2) = ?");
            Console.WriteLine("Если вы хотите закончить игру, введите слово \"стоп\" вместо ответа.");
            Console.WriteLine("Удачи!");
        }

        // Задает пользователю вопрос по сложению или вычитанию двух отрицательных чисел и проверяет его ответ
        static void AskQuestion()
        {
            // Выбираем случайно операцию: + или -
            char operation = (new Random().Next(2) == 0) ? '+' : '-';

            // Выбираем случайно уровень сложности: 1 - легкий, 2 - средний, 3 - тяжелый
            int level = new Random().Next(1, 4);

            // Генерируем два случайных отрицательных числа в зависимости от уровня сложности
            int a = 0;
            int b = 0;
            switch (level)
            {
                case 1:
                    a = RandomNegative(1, 10);
                    b = RandomNegative(1, 10);
                    break;
                case 2:
                    a = RandomNegative(11, 100);
                    b = RandomNegative(11, 100);
                    break;
                case 3:
                    a = RandomNegative(101, 1000);
                    b = RandomNegative(101, 1000);
                    break;
            }

            // Вычисляем правильный ответ
            int answer = (operation == '+') ? (a + b) : (a - b);

            // Выводим на экран вопрос
            Console.WriteLine($"Сколько будет {a} {operation} {b} ?");

            // Считываем ответ пользователя
            string input = Console.ReadLine();

            // Проверяем, не хочет ли пользователь закончить игру
            if (input.ToLower() == "стоп")
            {
                Console.WriteLine("Спасибо за игру! До свидания!");
                Environment.Exit(0);
            }

            // Проверяем правильность ответа пользователя
            if (int.TryParse(input, out int userAnswer))
            {
                if (userAnswer == answer || userAnswer == -answer)
                {
                    Console.WriteLine("Правильно!");
                }
                else
                {
                    Console.WriteLine($"Неправильно. Правильный ответ: {answer}");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
            }
        }

        
        static void Main(string[] args)
        {
            // Выводим на экран приветствие и правила игры
            Greet();

            // Задаем пользователю вопросы по сложению и вычитанию отрицательных чисел, пока он не захочет закончить игру
            while (true)
            {
                AskQuestion();
            }
        }
    }
}