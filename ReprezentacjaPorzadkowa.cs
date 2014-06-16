using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieKomiwojazera
{
    class ReprezentacjaPorzadkowa : GlobalVariables
    {
        public int[] generatoRodzicow(int[] miastaTemp, int[] ciagWskazan, int counter)
        {
            int indexNumber = random.Next(1, miastaTemp.Length+1);
            ciagWskazan[counter] = indexNumber;
            counter++;
            miastaTemp = miastaTemp.Where((val, idx) => idx != indexNumber-1).ToArray();
            if(miasta.Length-1 > counter) generatoRodzicow(miastaTemp, ciagWskazan, counter);
            if(miasta.Length - 1 == counter) ciagWskazan[counter] = 1;
            return ciagWskazan;
        }

        public int[] odczytTrasy(int[] ciagWskazan) 
        {
            int[] temp = miasta;
            int[] output = new int[miasta.Length];
            for (int i = 0; i < ciagWskazan.Length; i++)
            {
                // odczyt od 0 do 16
                // 0 => 13
                // temp[12]
                //output = temp[ ciagwskazan[0], ciagwskazan[1] ...] 
                output[i] = temp[ciagWskazan[i]-1];
                temp = temp.Where((val, idx) => idx != ciagWskazan[i]-1).ToArray();
            }
            return output;
        }

        public static ChromosomReprezentacjaPorzadkowa krzyzowanieJednopunktowe(int punktPrzeciecia, ChromosomReprezentacjaPorzadkowa pierwszyOsobnik, ChromosomReprezentacjaPorzadkowa drugiOsobnik)
        {
            ChromosomReprezentacjaPorzadkowa klonA = new ChromosomReprezentacjaPorzadkowa(pierwszyOsobnik.ciagWiazan);
            ChromosomReprezentacjaPorzadkowa klonB = new ChromosomReprezentacjaPorzadkowa(drugiOsobnik.ciagWiazan);
            for (int i = 0; i < punktPrzeciecia; i++)
            {
                klonA.ciagWiazan[i] = klonA.ciagWiazan[i] ^ klonB.ciagWiazan[i];
                klonB.ciagWiazan[i] = klonA.ciagWiazan[i] ^ klonB.ciagWiazan[i];
                klonA.ciagWiazan[i] = klonA.ciagWiazan[i] ^ klonB.ciagWiazan[i];
            }
            klonA.updateTrasy();
            klonA.updateOcena();
            return klonA;
        }

        /// <summary>
        /// Zwraca true, gdy dziecko jest lepsze od rodzica
        /// </summary>
        /// <param name="rodzic"></param>
        /// <param name="dziecko"></param>
        /// <returns></returns>
        //public static bool ocena(ChromosomReprezentacjaPorzadkowa _rodzic, ChromosomReprezentacjaPorzadkowa _dziecko) 
        //{
        //    //ChromosomReprezentacjaPorzadkowa rodzic = new ChromosomReprezentacjaPorzadkowa(_rodzic.ciagWiazan);
        //    //ChromosomReprezentacjaPorzadkowa dziecko = new ChromosomReprezentacjaPorzadkowa(_dziecko.ciagWiazan);
        //    //rodzic.updateTrasy();
        //    //rodzic.updateOcena();
        //    //dziecko.updateTrasy();
        //    //dziecko.updateOcena();
        //    if (rodzic.ocena < dziecko.ocena)
        //        return false;
        //    else 
        //        return true;
        //}
    }
}
