//**************************************************************
//* Практическая работа                                        *
//* Выполнил: Ширкунов К.Е, группа 2-ИСП                       *
//* Задание: Нахождение суммы гармонических чисел от 1 до n    *
//*          (итеративный и рекурсивный методы)                *
//**************************************************************
using System;

namespace PR_HarmonicNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int answer = 1;

            while (answer == 1)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.Title = "Практическая работа: Гармонические числа";

                Console.WriteLine("Здравствуйте!");
                Console.WriteLine("Программа для вычисления суммы гармонических чисел от 1 до n.\n");

                // Ввод n
                int n = 0;
                bool isCorrectInput = false;

                while (!isCorrectInput)
                {
                    Console.Write("Введите натуральное число n (n >= 1): ");
                    try
                    {
                        n = Convert.ToInt32(Console.ReadLine());

                        if (n <= 0)
                        {
                            throw new ArgumentException("Число n должно быть строго больше нуля (n >= 1).");
                        }

                        isCorrectInput = true;
                    }
                    catch (Exception ex)
                    {
                        HandleError(ex);
                    }
                }

                // Вычисление и вывод
                try
                {
                    double iterativeSum = SumHarmonicIterative(n);
                    double recursiveSum = SumHarmonicRecursive(n);

                    Console.WriteLine("\n-------------------------------------------");
                    Console.WriteLine($"РЕЗУЛЬТАТЫ ДЛЯ n = {n}:");
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine($"1. Итеративный способ: {iterativeSum:F6}");
                    Console.WriteLine($"2. Рекурсивный способ: {recursiveSum:F6}");
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                }

                // Повтор программы
                answer = -1;
                while (answer != 0 && answer != 1)
                {
                    Console.Write("\nХотите начать заново? (1 — да, 0 — нет): ");
                    try
                    {
                        answer = Convert.ToInt32(Console.ReadLine());
                        if (answer != 0 && answer != 1)
                        {
                            throw new ArgumentException("Необходимо ввести строго 1 или 0.");
                        }
                    }
                    catch (Exception ex)
                    {
                        HandleError(ex);
                        answer = -1;
                    }
                }
            }
        }

        // Единая функция для обработки любых исключений
        static void HandleError(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Возникла ошибка ({ex.GetType().Name}). Детали: {ex.Message}");
            Console.ForegroundColor = ConsoleColor.Black;
        }

        // Итеративный способ
        static double SumHarmonicIterative(int n)
        {
            double totalSum = 0.0;
            double currentHarmonic = 0.0;

            for (int k = 1; k <= n; k++)
            {
                currentHarmonic += 1.0 / k;
                totalSum += currentHarmonic;
            }

            return totalSum;
        }

        // Рекурсивный способ
        static double SumHarmonicRecursive(int n)
        {
            if (n <= 1)
            {
                return 1.0;
            }

            return SumHarmonicRecursive(n - 1) + CalculateHarmonicNumber(n);
        }

        // Вспомогательная рекурсия для H(k)
        static double CalculateHarmonicNumber(int k)
        {
            if (k <= 1)
            {
                return 1.0;
            }

            return CalculateHarmonicNumber(k - 1) + (1.0 / k);
        }
    }
}