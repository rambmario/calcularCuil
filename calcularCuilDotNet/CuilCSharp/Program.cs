using System;
using static calcularCuil.Cuil;
namespace calcularCuil
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Examples Get Cuil");
            Console.WriteLine(calcularCuilCuit("22098567", "M"));
            Console.WriteLine(calcularCuilCuit("2098567", "F"));
            Console.WriteLine(calcularCuilCuit("198567", "m"));
            Console.WriteLine(calcularCuilCuit("22098567", "f"));
        }
    }
}
