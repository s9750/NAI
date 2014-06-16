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

            for (int i = 0; i < 50; i++)
            {
                listaOsobnikow = podstawoweKrzyzowanie(listaOsobnikow);

            }
            

            //int counter = 0;
            //foreach (var item in listaOsobnikow)
            //{
            //    Console.WriteLine("Osobnik[{0,2}]: {1,2}", counter, item.ocena);
            //    counter++;
            //}

            Console.ReadKey();
        }

        private static ChromosomReprezentacjaPorzadkowa[] podstawoweKrzyzowanie(ChromosomReprezentacjaPorzadkowa[] listaOsobnikow)
        {
            List<ChromosomReprezentacjaPorzadkowa> prawdziwaListaChromosomow = new List<ChromosomReprezentacjaPorzadkowa>();
            Console.WriteLine("Przed krzyzowaniem: ");
            int i = 1;
            int Total = 0;
            foreach (var item in listaOsobnikow)
	        {
		           prawdziwaListaChromosomow.Add(item);
                   Console.WriteLine("Rodzic[{0,3}]:{1},Ocena:{2,3}", i, displayHelper(item.ciagWiazan), item.ocena);
                   i++;
                   Total += item.ocena;
	        }
            Console.WriteLine("Total: {0}", Total);

            List<ChromosomReprezentacjaPorzadkowa> dzieci = new List<ChromosomReprezentacjaPorzadkowa>();

            int loopCounter = 0;

            while (prawdziwaListaChromosomow.Count > 1)
            {
                int g = GlobalVariables.random.Next(1, 3);

                int punktPrzeciecia = GlobalVariables.random.Next(1, GlobalVariables.miasta.Length - 2);

                int osobnik_B = GlobalVariables.random.Next(1,prawdziwaListaChromosomow.Count-1);

                ChromosomReprezentacjaPorzadkowa dziecko;
                ChromosomReprezentacjaPorzadkowa rodzic = prawdziwaListaChromosomow[0];

                //Console.WriteLine("Krzyzowanie, punkt przeciecia = {0}:", punktPrzeciecia);
                if (g % 3 == 1)
                {
                    //cross with the next one
                    dziecko =
                    ReprezentacjaPorzadkowa.krzyzowanieJednopunktowe(punktPrzeciecia, 
                        rodzic, prawdziwaListaChromosomow[1]);
                } else {
                    //cross with random next
                    dziecko =
                    ReprezentacjaPorzadkowa.krzyzowanieJednopunktowe(punktPrzeciecia,
                        rodzic, prawdziwaListaChromosomow[osobnik_B]);
                }

                if (rodzic.ocena > dziecko.ocena || rodzic.ocena == dziecko.ocena)
                {
                    dzieci.Add(dziecko);
                    prawdziwaListaChromosomow.RemoveAt(0);
                    loopCounter = 0;
                }

                loopCounter++;

                if (loopCounter == 250)
                {
                    prawdziwaListaChromosomow.RemoveAt(0);
                    loopCounter = 0;
                }
            }

            dzieci.Add(prawdziwaListaChromosomow[0]);

            Console.WriteLine("Po krzyzowaniu: ");
            i = 1;
            Total = 0;
            foreach (var item in dzieci)
            {
                listaOsobnikow[i - 1] = item;
                Console.WriteLine("Dziecko[{0,3}]:{1},Ocena:{2,3}", i, displayHelper(item.ciagWiazan), item.ocena);
                i++;
                Total += item.ocena;
            }
            //GlobalVariables.TheTotal = Total;
            Console.WriteLine("Total: {0}", Total);

            return listaOsobnikow;
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

        //for (int i = 0; i < listaOsobnikow.Length-1; i++)
        //{
        //    Console.WriteLine("----------------------------------------------------------------");
        //    Console.WriteLine("Rodzic[{0}]:{1},Ocena:{2,3}", i, displayHelper(listaOsobnikow[i].ciagWiazan), listaOsobnikow[i].ocena);
        //    Console.WriteLine("Rodzic[{0}]:{1},Ocena:{2,3}", i + 1, displayHelper(listaOsobnikow[i + 1].ciagWiazan), listaOsobnikow[i+1].ocena);
        //    //Console.WriteLine(" Trasa[{0}]: {1}", i, displayHelper(listaOsobnikow[i].trasa));
        //    //Console.WriteLine(" Trasa[{0}]: {1}", i+1, displayHelper(listaOsobnikow[i+1].trasa));
        //    int punktPrzeciecia = GlobalVariables.random.Next(1,GlobalVariables.miasta.Length-2);
        //    Console.WriteLine("Krzyzowanie, punkt przeciecia = {0}:", punktPrzeciecia);
        //    ReprezentacjaPorzadkowa.krzyzowanieJednopunktowe(punktPrzeciecia, listaOsobnikow[i], listaOsobnikow[i + 1]);
        //    Console.WriteLine("Rodzic[{0}]:{1},Ocena:{2,3}", i, displayHelper(listaOsobnikow[i].ciagWiazan), listaOsobnikow[i].ocena);
        //    Console.WriteLine("Rodzic[{0}]:{1},Ocena:{2,3}", i + 1, displayHelper(listaOsobnikow[i + 1].ciagWiazan), listaOsobnikow[i+1].ocena);
        //    //Console.WriteLine(" Trasa[{0}]: {1}", i, displayHelper(listaOsobnikow[i].trasa));
        //    //Console.WriteLine(" Trasa[{0}]: {1}", i + 1, displayHelper(listaOsobnikow[i + 1].trasa));

        //    if (GlobalVariables.Debug) Thread.Sleep(40);
        //}
    }
}
