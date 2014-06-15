using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZadanieKomiwojazera
{
    class Program
    {
        static void Main(string[] args)
        {
            GlobalVariables.Debug = false;

            int ilosc_miast = 15;

            int ilosc_osobnikow = 100;

            wygenerujMiasta(ilosc: ilosc_miast);

            ReprezentacjaPorzadkowa repr = new ReprezentacjaPorzadkowa();

            ChromosomReprezentacjaPorzadkowa[] listaOsobnikow = new ChromosomReprezentacjaPorzadkowa[ilosc_osobnikow];

            Console.WriteLine("{1,12} {0}", displayHelper(GlobalVariables.miasta),"Trasa:");
            for (int i = 0; i < ilosc_osobnikow; i++)
            {
                ChromosomReprezentacjaPorzadkowa chromosom = new ChromosomReprezentacjaPorzadkowa(repr.generatoRodzicow(GlobalVariables.miasta, new int[GlobalVariables.miasta.Length], 0));
                string rodzicString = String.Format("Rodzic[{0}]:",i+1);
                string trasaString = String.Format("Trasa[{0}]:",i+1);

                Console.WriteLine("{1,12} {0}", displayHelper(chromosom.ciagWiazan),rodzicString);
                Console.WriteLine("{1,12} {0}", displayHelper(chromosom.trasa),trasaString);

                listaOsobnikow[i] = chromosom;

                if(GlobalVariables.Debug) Thread.Sleep(40);

            }
            
            podstawoweKrzyzowanie(listaOsobnikow);

            int counter = 0;
            foreach (var item in listaOsobnikow)
            {
                Console.WriteLine("Osobnik[{0,2}]: {1,2}", counter, item.ocena);
                counter++;
            }

            Console.ReadKey();
        }

        private static void podstawoweKrzyzowanie(ChromosomReprezentacjaPorzadkowa[] listaOsobnikow)
        {
            for (int i = 0; i < listaOsobnikow.Length-1; i++)
            {
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine(" Ciąg[{0}]: {1}", i, displayHelper(listaOsobnikow[i].ciagWiazan));
                Console.WriteLine(" Ciąg[{0}]: {1}", i+1, displayHelper(listaOsobnikow[i+1].ciagWiazan));
                Console.WriteLine("Trasa[{0}]: {1}", i, displayHelper(listaOsobnikow[i].trasa));
                Console.WriteLine("Trasa[{0}]: {1}", i+1, displayHelper(listaOsobnikow[i+1].trasa));
                int punktPrzeciecia = GlobalVariables.random.Next(1,GlobalVariables.miasta.Length-2);
                Console.WriteLine("Krzyzowanie, punkt przeciecia = {0}:", punktPrzeciecia);
                ReprezentacjaPorzadkowa.krzyzowanieJednopunktowe(punktPrzeciecia, listaOsobnikow[i], listaOsobnikow[i + 1]);
                Console.WriteLine(" Ciąg[{0}]: {1}", i, displayHelper(listaOsobnikow[i].ciagWiazan));
                Console.WriteLine(" Ciąg[{0}]: {1}", i + 1, displayHelper(listaOsobnikow[i + 1].ciagWiazan));
                Console.WriteLine("Trasa[{0}]: {1}", i, displayHelper(listaOsobnikow[i].trasa));
                Console.WriteLine("Trasa[{0}]: {1}", i + 1, displayHelper(listaOsobnikow[i + 1].trasa));

                if (GlobalVariables.Debug) Thread.Sleep(40);
            }
        }

        private static void wygenerujMiasta(int ilosc)
        {
            GlobalVariables.miasta = new int[ilosc];
            for (int i = 0; i < ilosc; i++)
            {
                GlobalVariables.miasta[i] = i + 1;
            }
            GlobalVariables.generujMacierzKosztow();
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
