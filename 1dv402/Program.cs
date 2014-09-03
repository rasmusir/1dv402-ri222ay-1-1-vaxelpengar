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
            double subtotal = ReadPositiveDouble("Ange totalsumma\t\t: ");
            uint total = (uint)Math.Round(subtotal, MidpointRounding.AwayFromZero);
            uint cash = ReadUint("Ange erhållet belopp\t: ", total);
            uint change = cash - total;
            double roundingOffAmount = total - subtotal;

            uint[] ret = SplitIntoDenominations(change, new uint[] { 1, 5, 10, 20, 50, 100, 500 });

            PrintReceipt(subtotal, roundingOffAmount, total, cash, change, ret, null);
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

                if (Double.TryParse(Console.ReadLine(), out value))
                {
                    double roundedValue = Math.Round(value, MidpointRounding.AwayFromZero);
                    if (roundedValue > 0)
                        break;
                    else
                        ShowMessage("Whops! '" + value + "' är en för liten summa.", true);
                }
                else
                    ShowMessage("Whops! Du har inte skrivit in en giltig summa.", true);
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
                        ShowMessage("Whops! '" + value + "' är ett för litet belopp.", true);
                    else
                        break;
                }
                else
                    ShowMessage("Whops! Du har inte skrivit in en giltig summa.", true);
            }

            return value;
        }

        static uint[] SplitIntoDenominations(uint value, uint[] denominations)
        {
            uint[] values = new uint[denominations.Length];
            uint sum = value;

            for (int i = denominations.Length - 1; i>=0; i--)
            {
                uint rest = (uint)(sum % denominations[i]);
                values[i] = (uint)((sum - rest) / denominations[i]);

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

        static void PrintReceipt(double subtotal, double roundingOffAmount, uint total, uint cash, uint change, uint[] notes, uint[] denominations)
        {
            Console.WriteLine("KVITTO");
            Console.WriteLine("Totalt\t\t\t:{0,5}", subtotal);
            Console.WriteLine("Öresavrundning\t\t:{0,5}", roundingOffAmount);
            Console.WriteLine("Att betala\t\t:{0,5}", total);
        }
    }
}
