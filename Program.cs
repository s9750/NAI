using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieKomiwojazera
{
    class Program
    {
        static void Main(string[] args)
        {
            ReprezentacjaPorzadkowa repr = new ReprezentacjaPorzadkowa();
            Console.WriteLine("Trasa: {0}", displayHelper(GlobalVariables.miasta));
            for (int i = 1; i < 101; i++)
            {
                int[] rodzic = repr.generatoRodzicow(GlobalVariables.miasta, new int[GlobalVariables.miasta.Length], 0);

                Console.WriteLine("Wygenerowany rodzic[{1}]: {0}", displayHelper(rodzic),i);
                Console.WriteLine("Wygenerowana trasa[{1}]: {0}", displayHelper(repr.odczytTrasy(rodzic)),i);
            }

            Console.ReadKey();
        }

        private static string displayHelper(int[] data)
        {
            string outputString = "{";
            foreach (var item in data)
            {
                outputString += " " + item.ToString();
            }
            outputString += " }";
            return outputString;
        }
    }
}
