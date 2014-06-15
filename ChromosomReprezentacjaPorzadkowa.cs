using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieKomiwojazera
{
    class ChromosomReprezentacjaPorzadkowa
    {
        public int[] trasa;

        public int[] ciagWiazan;

        public int ocena;

        public ChromosomReprezentacjaPorzadkowa(int[] CiagWiazan) 
        {
            ciagWiazan = CiagWiazan;
            this.updateTrasy();
            this.updateOcena();
        }

        public void updateTrasy()
        {
            int[] temp = GlobalVariables.miasta;
            int[] output = new int[GlobalVariables.miasta.Length];
            for (int i = 0; i < this.ciagWiazan.Length; i++)
            {
                output[i] = temp[this.ciagWiazan[i] - 1];
                temp = temp.Where((val, idx) => idx != this.ciagWiazan[i] - 1).ToArray();
            }
            this.trasa = output;
        }

        public void updateOcena() 
        {
            this.ocena = 0;
            for (int i = 0; i < this.trasa.Length-1; i++)
            {
                this.ocena += GlobalVariables.macierzKosztow[trasa[i]-1][trasa[i + 1]-1];
            }
            Console.WriteLine("Ocena: {0,5}", ocena);
        }
    }
}
