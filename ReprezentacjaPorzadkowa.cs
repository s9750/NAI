﻿using System;
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

        public static void krzyzowanieJednopunktowe(int punktPrzeciecia, ChromosomReprezentacjaPorzadkowa pierwszyOsobnik, ChromosomReprezentacjaPorzadkowa drugiOsobnik)
        {
            for (int i = 0; i < punktPrzeciecia; i++)
            {
                pierwszyOsobnik.ciagWiazan[i] = pierwszyOsobnik.ciagWiazan[i] ^ drugiOsobnik.ciagWiazan[i];
                drugiOsobnik.ciagWiazan[i] = pierwszyOsobnik.ciagWiazan[i] ^ drugiOsobnik.ciagWiazan[i];
                pierwszyOsobnik.ciagWiazan[i] = pierwszyOsobnik.ciagWiazan[i] ^ drugiOsobnik.ciagWiazan[i];
            }
            pierwszyOsobnik.updateTrasy();
            drugiOsobnik.updateTrasy();
        }
    }
}
