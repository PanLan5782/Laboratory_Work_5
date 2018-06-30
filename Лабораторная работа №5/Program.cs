using System;

namespace ConsoleApp3
{
    class Program
    {

        static Random rnd = new Random();

        static void Main(string[] args)
        {
            int[] M = null;
            string userCommand = null;
            do
            {

                Console.WriteLine("1. Работа с одномерным массивом");
                Console.WriteLine("2. Работа с многомерным массивом");
                Console.WriteLine("3. Работа с рваным массивом");
                Console.WriteLine("4.Выход");
                Console.Write(">");
                userCommand = Console.ReadLine();


                switch (userCommand)
                {
                    case "1":
                        OneDimentionArr();
                        break;
                    case "2":
                        TwoDimentionArr();
                        break;
                    case "3":
                        RaggedArr();
                        break;
                    case "4":
                        break;

                    default:
                        Console.WriteLine("Неверная команда.");
                        break;
                }
            } while (userCommand != "4");
        }

        private static void RaggedArr()
        {
            int[][] M = null;
            string userCommand = null;
            do
            {

                Console.WriteLine("1. Создать рваный массив");
                Console.WriteLine("2. Добавить строку в начало массива");
                Console.WriteLine("3. Выход");
                Console.Write(">");
                userCommand = Console.ReadLine();


                switch (userCommand)
                {
                    case "1":
                        CreateRagArr(ref M);
                        break;
                    case "2":
                        AddRow(ref M);
                        break;
                    case "3":
                        break;
                    default:
                        Console.WriteLine("Неверная команда.");
                        break;
                }
            } while (userCommand != "3");
        }

        private static void PrintRag(ref int[][] Mass)
        {
            if (Mass == null)
            {
                Console.WriteLine("Массив пустой. Создайте массив.");
                return;
            }

            for (int i = 0; i < Mass.GetLength(0); i++)
            {
                for (int j = 0; j < Mass[i].Length; j++)
                {
                    Console.Write("{0,4}", Mass[i][j]);
                }
                Console.WriteLine();
            }
        }

        private static void AddRow(ref int[][] Mass)
        {
            if (Mass == null)
            {
               CreateRagArr(ref Mass);
            }
            int[][] N = new int[Mass.GetLength(0) + 1][];
            Random rnd = new Random();
            N[0] = new int[rnd.Next(0, 10)];
            for (int i = 0; i < N[0].Length; i++)
                N[0][i] = rnd.Next(0, 10);

            for (int i = 0; i < Mass.GetLength(0); i++)
            {
                N[i + 1] = new int[Mass[i].Length];
                for (int j = 0; j < N[i + 1].Length; j++)
                    N[i + 1][j] = Mass[i][j];
            }

            Mass = N;
            {
                if (Mass == null)
                {
                    Console.WriteLine("Массив пустой. Создайте массив.");
                    return;
                }

                for (int i = 0; i < Mass.GetLength(0); i++)
                {
                    for (int j = 0; j < Mass[i].Length; j++)
                    {
                        Console.Write("{0,4}", Mass[i][j]);
                    }
                    Console.WriteLine();
                }
            }
        }

        private static void CreateRagArr(ref int[][] m)
        {
            bool ok = true;
            Random rnd = new Random();
            int strings;
            
            do
            {
                Console.WriteLine("Введите количество строк");
                ok = Int32.TryParse(Console.ReadLine(), out strings);
                if (!ok) Console.WriteLine("Символ не является цифрой. Повторите ввод.");
            }
            while (!ok);

            m = new int[strings][];
            int i, j;
            for (i = 0; i < strings; i++)
            {
                m[i] = new int[rnd.Next(1, 10)];
                for (j = 0; j < m[i].Length; j++)
                {
                    m[i][j] = rnd.Next(0, 10);
                }
            }
            {
                if (m == null)
                {
                    Console.WriteLine("Массив пустой. Создайте массив.");
                    return;
                }

                for (i = 0; i < m.GetLength(0); i++)
                {
                    for (j = 0; j < m[i].Length; j++)
                    {
                        Console.Write("{0,4}", m[i][j]);
                    }
                    Console.WriteLine();
                }
            }
        }

        static void OneDimentionArr()
        {
            int[] M = null;
            string userCommand = null;
            do
            {

                Console.WriteLine("1. Создать одномерный массив");
                Console.WriteLine("2. Добавить К элементов в конец массива");
                Console.WriteLine("3. Выход");
                Console.Write(">");
                userCommand = Console.ReadLine();


                switch (userCommand)
                {
                    case "1":
                        CreateArray(ref M);
                        break;
                    case "2":
                        AddItems(ref M);
                        break;
                    case "3":
                        break;
                    default:
                        Console.WriteLine("Неверная команда.");
                        break;
                }
            } while (userCommand != "3");
        }
        private static void CreateArray(ref int[] M)
        {
            int n;
            bool ok = true;
            do
            {
                Console.Write("Введите колличество элементов массива:");
                ok = Int32.TryParse(Console.ReadLine(), out n);
                if (!ok) Console.WriteLine("Символ не является цифрой. Повторите ввод.");
            }
            while (!ok);
            M = new int[n];
            for (int i = 0; i < n; i++)
                M[i] = rnd.Next(-100, 100);
            {
                if (M == null)
                {
                    Console.WriteLine("Массив пустой. Создайте массив.");
                    return;
                }
                for (int i = 0; i < M.Length; i++)
                {
                    Console.Write("Item[{1}]={0} ", M[i], i);
                }
                Console.WriteLine();

            }



        }

        private static void AddItems(ref int[] Mass)
        {
            bool ok = true;
            if (Mass == null)
            {
                Console.WriteLine("Массив пустой. Создайте массив.");
                return;
            }
            int k;
            do
            {
                Console.Write("Введите колличество добавляемых элементов:");
                ok = Int32.TryParse(Console.ReadLine(), out k);
                if (!ok) Console.WriteLine("Символ не является цифрой. Повторите ввод.");
            }
            while (!ok);
            int[] T = new int[Mass.Length + k];


            for (int i = Mass.Length; i < T.Length; i++)
                T[i] = rnd.Next(-100, 100);

            Mass.CopyTo(T, 0);
            {
                if (Mass == null)
                {
                    Console.WriteLine("Массив пустой. Создайте массив.");
                    return;
                }
                for (int i = 0; i < Mass.Length; i++)
                {
                    Console.Write("Item[{1}]={0} ", Mass[i], i);
                }
                Console.WriteLine();

            }
            Mass = T;
        }

        static void Print(ref int[] Mass)
        {
            if (Mass == null)
            {
                Console.WriteLine("Массив пустой. Создайте массив.");
                return;
            }
            for (int i = 0; i < Mass.Length; i++)
            {
                Console.Write("Item[{1}]={0} ", Mass[i], i);
            }
            Console.WriteLine();

        }
        static void TwoDimentionArr()
        {
            int[,] M = null;
            string userCommand = null;
            do
            {
                Console.WriteLine("1. Создать двумерный массив");
                Console.WriteLine("2. Удалить столбцы, начиная со столбца К1 и до столбца К2");
                Console.WriteLine("3. Выход");
                Console.Write(">");
                userCommand = Console.ReadLine();


                switch (userCommand)
                {
                    case "1":
                        CreateArray2(ref M);
                        break;
                    case "2":
                        DeleteColumns(ref M);
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Неверная команда.");
                        break;
                }
            } while (userCommand != "4");
        }

        private static void DeleteColumns(ref int[,] Mass)
        {
            bool ok = true;
            int K1, K2;
            do
            {
                ok = true;
                InputNumber("Введите номер столбца K1:", out K1);
                if (K1 <= 0)
                {
                    ok = false;
                    Console.WriteLine("Вводимое число не может быть отрицательным");
                }

            }
            while (!ok);
            do
            {
                ok = true;
                InputNumber("Введите номер столбца K2:", out K2);
                if (K2 <= 0)
                {
                    ok = false;
                    Console.WriteLine("Вводимое число не может быть отрицательным");
                }

            }
            while (!ok);
            if (Mass == null)
            {
                Console.WriteLine("Массив пустой. Создайте массив.");
                return;
            }
            
          
            if (K1 > K2)
            {
                int tmp = K2;
                K2 = K1;
                K1 = tmp;
            }
            int[,] T = new int[Mass.GetLength(0), Mass.GetLength(1) - (K2 - K1) - 1];
            for (int j = 0; j < Mass.GetLength(0); j++)
            {
                int c = 0;
                for (int i = 0; i < Mass.GetLength(1); i++)
                {
                    if (i < K1 - 1 || i > K2 - 1)
                    {
                        T[j, c] = Mass[j, i];
                        c++;
                    }
                }

            }
            Mass = T;
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (Mass == null)
                {
                    Console.WriteLine("Массив пустой. Создайте массив.");
                    return;
                }
                int i, j;
                for (i = 0; i < Mass.GetLength(0); i++)
                {
                    for (j = 0; j < Mass.GetLength(1); j++)
                        Console.Write("{0,4}", Mass[i, j]);
                    Console.WriteLine();
                }
                Console.ForegroundColor = ConsoleColor.Gray;
            }


        }

        static void CreateArray2(ref int[,] table)
        {
            Random rnd = new Random();
            int strings, columns;
            bool ok = true;
            do
            {
                ok = true;
                InputNumber("Введите количество строк:", out strings);
                if (strings <= 0)
                {
                    ok = false;
                    Console.WriteLine("Количество не может быть отрицательным");
                }

            }
            while (!ok);

            do
            {
                ok = true;
                InputNumber("Введите количество столбцов:", out columns);
                if (columns <= 0)
                {
                    ok = false;
                    Console.WriteLine("Количество не может быть отрицательным");
                }

            }
            while (!ok);

            table = new int[strings, columns];
            int i, j;
            for (i = 0; i < strings; i++)
            {
                for (j = 0; j < columns; j++)
                {
                    table[i, j] = rnd.Next(1, 10);
                }
                Console.WriteLine();
            }
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (table == null)
                {
                    Console.WriteLine("Массив пустой. Создайте массив.");
                    return;
                }

                for (i = 0; i < table.GetLength(0); i++)
                {
                    for (j = 0; j < table.GetLength(1); j++)
                        Console.Write("{0,4}", table[i, j]);
                    Console.WriteLine();
                }
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        private static void InputNumber(string prompt, out int n)
        {
            bool ok = true;

            do
            {
                Console.Write(prompt);
                ok = Int32.TryParse(Console.ReadLine(), out n);
                if (!ok) Console.WriteLine("Символ не является цифрой. Повторите ввод.");
            }
            while (!ok);

        }

        static void PrintArray2(ref int[,] table)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (table == null)
            {
                Console.WriteLine("Массив пустой. Создайте массив.");
                return;
            }
            int i, j;
            for (i = 0; i < table.GetLength(0); i++)
            {
                for (j = 0; j < table.GetLength(1); j++)
                    Console.Write("{0,4}", table[i, j]);
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
