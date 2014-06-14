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
            Console.WriteLine("{1,12} {0}", displayHelper(GlobalVariables.miasta),"Trasa:");
            for (int i = 1; i < 101; i++)
            {
                int[] rodzic = repr.generatoRodzicow(GlobalVariables.miasta, new int[GlobalVariables.miasta.Length], 0);
                string rodzicString = String.Format("Rodzic[{0}]:", i);
                string trasaString = String.Format("Trasa[{0}]:",i);

                Console.WriteLine("{1,12} {0}", displayHelper(rodzic),rodzicString);
                Console.WriteLine("{1,12} {0}", displayHelper(repr.odczytTrasy(rodzic)),trasaString);
            }

            Console.ReadKey();
        }

        private static string displayHelper(int[] data)
        {
            string outputString = "{";
            int controlSum = 0;
            foreach (var item in data)
            {
                outputString += String.Format("{0,3}", item);
                controlSum += item;
            }
            outputString += " } Sum: ";
            outputString += controlSum.ToString();
            return outputString;
        }


    }
}
