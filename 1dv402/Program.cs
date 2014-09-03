using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv402
{
    class Program
    {
        static void Main(string[] args)
        {
            double total = ReadPositiveDouble("Ange totalsumma\t\t: ");
            uint cash = ReadUint("Ange erhållet belopp\t: ", total);

            int[] ret = SplitIntoDenominations((int)(cash - total), new uint[] { 1, 5, 10, 20, 50, 100, 500 });

        }

        static double ReadPositiveDouble(string prompt = null)
        {
            double value = 0;
            while (true)
            {
                if (prompt != null)
                {
                    Console.Write(prompt);
                }

                value = 0;

                if (Double.TryParse(Console.ReadLine().Replace('.',','), out value))
                {
                    double roundedValue = Math.Round(value, MidpointRounding.AwayFromZero);
                    if (roundedValue > 0)
                        break;
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Whops! '{0}' är en för liten summa.", value);
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Whops! Du har inte skrivit in en giltig summa.");
                    Console.ResetColor();
                }
            }
            return value;

        }

        static uint ReadUint(string prompt, double min)
        {
            uint value = 0;

            while (true)
            {
                Console.Write(prompt);

                if (UInt32.TryParse(Console.ReadLine(), out value))
                {
                    if (value < min)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Whops! {0} är ett för litet belopp.", value);
                        Console.ResetColor();
                    }
                    else
                        break;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Whops! Du har inte skrivit in en giltig summa.");
                    Console.ResetColor();
                }
            }

            return value;
        }

        static int[] SplitIntoDenominations(int value, uint[] denominations)
        {
            int[] values = new int[denominations.Length];
            int sum = value;

            for (int i = denominations.Length - 1; i>=0; i--)
            {
                int rest = (int)(sum % denominations[i]);
                values[i] = (int)((sum - rest) / denominations[i]);

                sum = rest;
            }

            return values;
        }

        static void ShowMessage(string message, bool isError = false)
        {
            if (isError)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ResetColor();
                return;
            }
            else        //Egenteligen onödigt med tanke på return här över... men har den kvar för readability.
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine(message);
                Console.ResetColor();
                return;
            }

        }
    }
}
