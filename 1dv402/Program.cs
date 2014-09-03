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
            Console.WriteLine(ReadPositiveDouble("Ange totalsumma\t\t: "));
        }

        static double ReadPositiveDouble(string prompt = null)
        {
            bool reading = true;
            double value = 0;
            while (reading)
            {
                if (prompt != null)
                {
                    Console.Write(prompt);
                }

                value = 0;

                if (Double.TryParse(Console.ReadLine().Replace('.',','), out value))
                {
                    double roundedValue = Math.Round(value, MidpointRounding.AwayFromZero);
                    if (roundedValue>0)
                    {
                        reading = false;
                    }
                    else
                    {
                        Console.WriteLine("Whops! '{0}' är en för liten summa.",value);
                    }
                }
                else
                {
                    Console.WriteLine("Whops! Du har inte skrivit in en giltig summa.");
                }
            }
            return value;

        }
    }
}
