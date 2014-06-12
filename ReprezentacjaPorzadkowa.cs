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
            int indexNumber = random.Next(1, miastaTemp.Length - 1);
            ciagWskazan[counter] = indexNumber;
            counter++;
            miastaTemp = miastaTemp.Where((val, idx) => idx != indexNumber).ToArray();
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
                output[i] = temp[ciagWskazan[i]-1];
                temp = temp.Where((val, idx) => idx != ciagWskazan[i]-1).ToArray();
            }
            return output;
        }

    }
}
