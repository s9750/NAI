using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieKomiwojazera
{
    class GlobalVariables
    {
        public static Random random = new Random();

        public static int[] miasta;

        public static int[][] macierzKosztow;

        public static bool Debug = false;

        public static void generujMacierzKosztow() 
        {
            List<string> rowsList = new List<string>();
            string firstLine = String.Format("{0,5}|", String.Empty);

            macierzKosztow = new int[miasta.Length][];
            for (int i = 0; i < miasta.Length; i++)
            {
                string temp = String.Format("{0,3}|", i);
                firstLine += String.Format("{0,3}", temp);
                string row = String.Empty;
                row += String.Format("[{0,3}]",i);
                macierzKosztow[i] = new int[miasta.Length];
                for (int j = 0; j < miasta.Length; j++)
                {
                    macierzKosztow[i][j] = i == j ? 0 : random.Next(1, 11);
                    row += String.Format(" {0,3}", macierzKosztow[i][j]);
                }
                rowsList.Add(row);

            }
            Console.WriteLine(firstLine);
            foreach (var item in rowsList)
            {
                Console.WriteLine(item);
            }
        }

    }
}
