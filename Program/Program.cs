using System;

namespace Program
{
    internal class Program
    {
        static int[][] ArrayRandom()
        {
            Console.Write("Введiть кiлькiсть рядкiв: ");
            int rowNumber = Convert.ToInt32(Console.ReadLine());
            int[][] array = new int[rowNumber][];
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"Введiть кiлькiсть елементiв у {i}-му рядку: ");
                int columnCount = Convert.ToInt32(Console.ReadLine());
                array[i] = new int[columnCount];

                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = random.Next(-100, 100);
                }
            }
            Console.WriteLine("Створений масив:");
            PrintArray(array);
            return array;
        }
        static int[][] ArraySpace()
        {
            Console.WriteLine("Введiть кiлькiсть рядкiв:");
            int rows = Convert.ToInt32(Console.ReadLine());
            int[][] array = new int[rows][];
            
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine($"Введiть елементи {i}-го рядка, через Space:");
                string[] numbers = Console.ReadLine().Split(' ');
                array[i] = new int[numbers.Length];
                
                for (int j = 0; j < numbers.Length; j++)
                {
                    array[i][j] = Convert.ToInt32(numbers[j]);
                }
            }
            return array;
        }
        static void PrintArray(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write("{0,4}", array[i][j]);
                }
                Console.WriteLine();
            }
        }
        static void PrintArraySecond(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
        static int[] CalculateArrayZ(int[][] arrayP)
        {
            int[] arrayZ = new int[arrayP.Length];
            int maxColumns = arrayP[0].Length;

            for (int i = 0; i < arrayP.Length; i++)
            {
                int lastZeroIndex = -1;
                
                for (int j = arrayP[i].Length - 1; j >= 0; j--)
                {
                    if (arrayP[i][j] == 0)
                    {
                        lastZeroIndex = j;
                        break;
                    }
                }
                arrayZ[i] = lastZeroIndex == -1 ? arrayP[i].Length : lastZeroIndex + 1;
                
                if (arrayZ[i] > maxColumns)
                {
                    maxColumns = arrayZ[i];
                }
            }
            return arrayZ;
        }

        static int[][] GenerateArrayQ(int[] arrayZ)
        {
            int[][] arrayQ = new int[arrayZ.Length][];
            Random rand = new Random();
            
            for (int i = 0; i < arrayQ.Length; i++)
            {
                arrayQ[i] = new int[arrayZ[i]];
                
                for (int j = 0; j < arrayQ[i].Length; j++)
                {
                    arrayQ[i][j] = rand.Next(-100, 100);
                }
            }
            return arrayQ;
        }

        static void InsertionSortQ(int[][] arrayQ)
        {
            for (int i = 0; i < arrayQ.Length; i++)
            {
                for (int j = 1; j < arrayQ[i].Length; j++)
                {
                    int key = arrayQ[i][j];
                    int k = j - 1;
                    
                    while (k >= 0 && arrayQ[i][k] < key)
                    {
                        arrayQ[i][k + 1] = arrayQ[i][k];
                        k--;
                    }
                    arrayQ[i][k + 1] = key;
                }
            }
        }
        static void BlockSecond(int[][] arrayP)
        {
            int[] arrayZ = CalculateArrayZ(arrayP);
            int[][] arrayQ = GenerateArrayQ(arrayZ);
            InsertionSortQ(arrayQ);

            Console.WriteLine("Матриця P:");
            PrintArray(arrayP);
            Console.WriteLine("Масив Z:");
            PrintArraySecond(arrayZ);
            Console.WriteLine("Матриця Q:");
            PrintArray(arrayQ);
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Як бажаєте заповнити масив?");
            Console.WriteLine("Введiть 1 для випадкового заповнення масиву:");
            Console.WriteLine("Введiть 2 для вводу вручну (через Space):");
            Console.WriteLine("Введiть 0 для виходу з програми!");
            int choice = Convert.ToInt32(Console.ReadLine());
            int[][] arrayP;
            
            switch (choice)
            {
                case 0:
                    break;
                case 1:
                    arrayP = ArrayRandom();
                    BlockSecond(arrayP);
                    break;
                case 2:
                    arrayP = ArraySpace();
                    BlockSecond(arrayP);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Команда не розпiзнана!");
                    Console.ResetColor();
                    break;
            }
        }
    }
}