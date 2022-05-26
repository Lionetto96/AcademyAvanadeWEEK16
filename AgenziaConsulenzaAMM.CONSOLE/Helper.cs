using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenziaConsulenzaAMM.CONSOLE
{
    public class Helpers
    {
        public static string CheckStringa(string messaggio)
        {
            string info;
            do
            {
                Console.WriteLine($"inserisci {messaggio}");
                info = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(info));
            return info;
        }

        public static int CheckIntero(string messaggio)
        {
            int intero;
            do
            {
                Console.WriteLine($"inserisci {messaggio}");


            } while (!(int.TryParse(Console.ReadLine(), out intero)));
            return intero;
        }
        public static decimal CheckDecimal(string messaggio)
        {
            decimal dec;
            do
            {
                Console.WriteLine($"inserisci {messaggio}");


            } while (!(decimal.TryParse(Console.ReadLine(), out dec)));
            return dec;
        }
        public static double Checkdouble(string messaggio)
        {
            double doub;
            do
            {
                Console.WriteLine($"inserisci {messaggio}");


            } while (!(double.TryParse(Console.ReadLine(), out doub)));
            return doub;
        }
        public static DateTime CheckData(string messaggio)
        {
            DateTime data;
            do
            {
                Console.WriteLine($"inserisci {messaggio}");


            } while (!(DateTime.TryParse(Console.ReadLine(), out data)));
            return data;
        }
       
    }


}

