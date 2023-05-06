using System.Security.Cryptography.X509Certificates;

namespace Programmieren2Praktikum2
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            // creatung Measurement list
            MeasurementSeriesList seriesList = new MeasurementSeriesList();

            Console.WriteLine("Geben Sie Messungen ein. Zum Beenden einfach Enter drücken.");
            //taking first input
            string input;
            while (true)
            {
                //if input is empty exit program
                Console.Write("Messung: ");
                input = Console.ReadLine().Trim();
                if (input == "")
                {
                    break;
                }

                NumberList numbers = new NumberList();
                //creating numberlist to add to measurement object
                while (true)
                {
                    Console.Write("Zahl: ");
                    string numberInput = Console.ReadLine().Trim();
                    if (numberInput == "")
                    {
                        break;
                    }

                    if (double.TryParse(numberInput, out double number))
                    {
                        numbers.Prepend(number);
                    }
                    else
                    {
                        Console.WriteLine($"'{numberInput}' ist keine gültige Zahl und wird ignoriert.");
                    }
                }

                seriesList.Prepend(input, numbers);
            }

            Console.WriteLine("Alle Messungen:");
            seriesList.WriteAll();

            Console.WriteLine($"Summe aller Zahlen: {seriesList.Sum()}");

            Console.WriteLine("Alle eingebenen Messungen:");
            StringList descriptions = seriesList.Descriptions();
            descriptions.WriteAll();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}