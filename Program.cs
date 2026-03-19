using System;
using System.Diagnostics.CodeAnalysis;

namespace fak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] mas = { };
            // создать объект пользовательского класса
            ConsoleKeyInfo K;
            do
            {
                Console.Clear(); //очистка экрана перед выводом меню
                Console.WriteLine("1.Create List");
                Console.WriteLine("2.Print List");
                Console.WriteLine("3.Search 1");
                Console.WriteLine("4.Search 2");
                Console.WriteLine("Esc.Escape");
                K = Console.ReadKey(); //считывание кода вводимой клавиши
                switch (K.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1: // если нажата клавиша с цифрой 1
                        {
                            mas = Create(Enter("Size"));
                            breakme();
                            break;
                        }
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:// если нажата клавиша с цифрой 2 выведет масив
                        {
                            print(mas);
                            breakme();
                            break;
                        }
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:// если нажата клавиша с цифрой 3 способ 1
                        {
                            DateTime start = DateTime.Now;
                            Console.WriteLine(first(mas));
                            DateTime end = DateTime.Now;
                            Console.WriteLine($"time: {(end - start).ToString("fffffff")} ms");
                            breakme();
                            break;
                        }
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:// если нажата клавиша с цифрой 4
                        {
                            DateTime start = DateTime.Now;
                            Console.WriteLine(second(mas));
                            DateTime end = DateTime.Now;
                            Console.WriteLine($"time: {(end - start).ToString("fffffff")} ms");
                            breakme();
                            break;
                        }
                    default: break;
                }
            }
            while (K.Key != ConsoleKey.Escape);// цикл заканчивается, если нажата клавиша Esc
        }
        static void breakme()
        {
            ConsoleKeyInfo L;
            Console.WriteLine("Press Enter to main");
            L = Console.ReadKey();
            while (L.Key != ConsoleKey.Enter) L = Console.ReadKey();
            return;
        }
        /// <summary>ввод</summary><returns>обозначенное число</returns>
        static int Enter(string n)
        {
            Console.Write($"\n{n}: ");
            return int.Parse(Console.ReadLine());
        }
        ///<summary>сгенерирует массив</summary><returns>2д массив</returns>
        static int[] Create(int x)
        {
            int[] mas = new int[x];
            Random rnd = new Random();
            for (int i = 0; i < x; i++) mas[i] = rnd.Next(0, 50);
            Array.Sort(mas);
            return mas;
        }
        ///<summary>вывод массива</summary><returns>массив вывод</returns>
        static void print(int[] a)
        {
            Console.WriteLine();
            for (int i = 0; i < a.Length; i++) Console.Write($"{a[i]} ");
        }
        static int first(int[] a)
        {
            int u = Enter("Number");

            int x = 0;
            int y = a.Length - 1;
            int mid = 0;

            while (x - y != 1)
            {
                mid = (x + y) / 2;

                if (a[mid] == u) return mid;
                if (a[mid] < u)
                {
                    x = mid + 1;
                    continue;
                }
                else if (a[mid] > u)
                {
                    y = mid - 1;
                    continue;
                }
            }
            if (a[mid] == u) return x;
            return -1;
        }
        static int second(int[] a)
        {
            int u = Enter("Number");
            int mid;
            // Возвращает индекс элемента со значением u или -1, если такого элемента не существует
            int low = 0;
            int high = a.Length - 1;

            while (a[low] < u && a[high] > u)
            {
                if (a[high] == a[low])
                    break;
                mid = low + ((u - a[low]) * (high - low)) / (a[high] - a[low]);

                if (a[mid] < u)
                    low = mid + 1;
                else if (a[mid] > u)
                    high = mid - 1;
                else
                    return mid;
            }


            if (a[low] == u)
                return low;
            if (a[high] == u)
                return high;

            return -1; // Not found

        }
    }
}
