using System;
using System.Collections.Generic;
using System.Linq;

namespace Шифр_Кардано
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string word = SetYourChouse();
            if (word == "_-_-___-")
            {
                return;
            }

            Console.Write("Исходное сообщение: " + word);

            char[][] Matrix = CreateSorceMatrix(word); 
            List<int> x = new List<int>();
            List<int> y = new List<int>();
            List<char> chars = word.ToList();
            int[] index = { 2, 6, 10, 14, 18, 21, 25,
                            27, 36, 37, 41, 45, 49,
                            53, 59, 60, 64, 67, 71,
                            75, 79, 83, 86, 90, 98};

            for (int i = 0; i < index.Length; i++)
            {
                SetIndexies(Matrix, chars, index[i], i);
            }
            chars.RemoveRange(0, 25);


            for (int i = 0; i < Matrix.Length; i++)
            {
                for (int j = 0; j < Matrix.Length; j++)
                {
                    if (Matrix[i][j] != 0)
                    {
                        x.Add(i);
                        y.Add(j);
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Решетка Кардано Этап 1:");
            PrintSorceMatrix(Matrix);

            

            RotateMatrix(x, y, index);
            for (int i = 0; i < index.Length; i++)
            {
                SetIndexies(Matrix, chars, index[i], i);
            }
            chars.RemoveRange(0, 25);
            Console.WriteLine();
            Console.WriteLine("Решетка Кардано Этап 2:");
            PrintSorceMatrix(Matrix);

            RotateMatrix(x, y, index);
            for (int i = 0; i < index.Length; i++)
            {
                SetIndexies(Matrix, chars, index[i], i);
            }
            chars.RemoveRange(0, 25);

            Console.WriteLine();
            Console.WriteLine("Решетка Кардано Этап 3:");
            PrintSorceMatrix(Matrix);

            RotateMatrix(x, y, index);
            for (int i = 0; i < index.Length; i++)
            {
                SetIndexies(Matrix, chars, index[i], i);
            }
            chars.RemoveRange(0, 25);

            Console.WriteLine();
            Console.WriteLine("Решетка Кардано Этап 4:");
            PrintSorceMatrix(Matrix);

            string result = "";
            Console.WriteLine();
            Console.Write("Итоговое сообщение: ");
            result = RotateMatrix(Matrix, x, y, result);
            Console.Write(" + ");
            result = RotateMatrix(Matrix, x, y, result);
            Console.Write(" + ");
            result = RotateMatrix(Matrix, x, y, result);
            Console.Write(" + ");
            result = RotateMatrix(Matrix, x, y, result);
            Console.Write(" = " + result);
            Console.WriteLine();

        }

        private static string RotateMatrix(char[][] Matrix, List<int> x, List<int> y, string result)
        {
            for (int i = 0; i < x.Count; i++)
            {
                int temp = x[i];
                x[i] = y[i];
                y[i] = 9 - temp;
                Console.Write(Matrix[x[i]][y[i]]);
                result += Matrix[x[i]][y[i]];
            }
            return result;
        }
        private static string SetYourChouse()
        {
            Console.WriteLine("Выберите необходимый вариант");
            Console.WriteLine("1) Ввести собственное сообщение");
            Console.WriteLine("2) Использовать готовый шаблон");
            Console.WriteLine("3) Выход");
            string word = "";
            int key = int.Parse(Console.ReadLine());
            switch (key)
            {
                case 1:
                    {
                        Console.WriteLine("Введите сообщение, состоящие из 100 символов: ");
                        word = Console.ReadLine();
                        if (word.Length != 100)
                        {
                            Console.Clear();
                            Console.WriteLine($"Введенное сообщение состоит из {word.Length} символов");
                            Console.WriteLine("Необходимо сообщение из 100 символов");
                            Console.WriteLine();
                            word = SetYourChouse();
                        }
                        break;
                    }
                case 2:
                    {
                        word = "HEREISASENTENCEWITHEXACTLYNINETYSIXCHARACTERSANDALLLETTERSARECAPITALWITHNOSPACESORPUNCTUATIONWOWITEM";
                        break;
                    }
                case 3:
                    {
                        return "_-_-___-";
                    }
            }
            if (key > 3 || key < 1)
            {
                Console.Clear();
                word = SetYourChouse();
            }
            Console.Clear();
            return word;
        }

        private static void RotateMatrix(List<int> x, List<int> y, int[] index)
        {
            for (int i = 0; i < index.Length; i++)
            {
                int temp = x[i];
                x[i] = y[i];
                y[i] = 9 - temp;
                index[i] = x[i] * 10 + y[i];
            }
        }

        private static char[][] CreateSorceMatrix(string word)
        {
            char[][] Matrix = new char[10][];

            for (int i = 0; i < Matrix.Length; i++)
            {
                char[] cols = new char[10];
                Matrix[i] = cols;
            }
            return Matrix;
        }

        private static void SetIndexies(char[][] Matrix, List<char> chars, int num, int k)
        {

            int j = num % 10;
            int i = num / 10;

            Matrix[i][j] = chars[k];
            
        }

        private static void PrintSorceMatrix(char[][] Matrix)
        {
            
            for (int i = 0; i < Matrix.Length; i++)
            {
                for (int j = 0; j < Matrix.Length; j++)
                {
                    Console.Write(Matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
