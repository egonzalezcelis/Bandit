using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            invertirCadena();
        }

        static void invertirCadena()
        {
            System.Console.Write("Ingrese la cadena: ");
            String value = System.Console.ReadLine();
            String result = "";
            for (int i = value.Length - 1; i >= 0; i--)
            {
                result += value.Substring(i, 1);
            }
            System.Console.WriteLine("El resultado es: " + result);
            System.Console.Write("Desea intentar con otra cadena (s/n): ");
            value = System.Console.ReadLine();
            if (value.Equals("s"))
            {
                invertirCadena();
            }
        }
    }
}
