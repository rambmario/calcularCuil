using System;
namespace calcularCuil
{
    public class Cuil
    {
        public Cuil()
        {
        }

        static public string calcularCuilCuit(string document_number, string gender)
        {
            /*
		     * Cuil-Cuit format has 11 digits: AB - document_number - C
		     * Author: Mario Antonio Ramb
		     *
		     * @param {str} document_number -> string has only numbers
		     * @param {str} gender -> char has 3 options: M (masculino) F (femenino) S (sociedad)
		     *
		     * @return {str}
            */

            string AB = "";
            string C = "";

            // Checks document_number has only numbers and length must be 8 digits.
            int result = 0;
            if (Int32.TryParse(document_number, out result))
            {
                switch (document_number.Length)
                {
                    case 8:
                        //8 digits is OK
                        break;
                    case 7:
                        document_number = String.Concat("0", document_number);
                        break;
                    case 6:
                        document_number = String.Concat("00", document_number);
                        break;
                    default:
                        Console.WriteLine("El número de DNI debe contener como mínimo 6 dígitos");
                        return null;
                }
            } else
            {
                Console.WriteLine("El número de DNI debe contener solo dígitos");
                return null;
            }

            // Converts gender char to upper case and calculates AB.
            gender = gender.ToUpper();

            if (gender == "M")
            {
                AB = "20";
            }
            else if (gender == "F")
            {
                AB = "27";
            }
            else
            {
                AB = "30";
            }

            // Fills an array with multipliers digits.
            int[] multiplicadores = { 3, 2, 7, 6, 5, 4, 3, 2 };

            // Does calculations for 2 first digits (AB).
            int calculo = ((Int32.Parse(AB.Substring(0,1)) * 5) + (Int32.Parse(AB.Substring(1,1)) * 4));

            // Loops through the array and do the calculations.
            for (int i = 0; i < 8; i++)
            {
                calculo += (Int32.Parse(document_number.Substring(i,1)) * multiplicadores[i]);
            }

            // Gets MOD and evaluates to get C value.
            int resto = calculo % 11;

            if (resto == 1)
            {
                if (gender == "M")
                {
                    C = "9";
                }
                else
                {
                    C = "4";
                }
                AB = "23";
            }
            else if (resto == 0)
            {
                C = "0";
            }
            else
            {
                C = (11 - resto).ToString();
            }

            // Shows example
            Console.WriteLine(String.Join("-", AB, document_number, C));

            // Generates Cuil - Cuit
            string cuil_cuit = String.Join("", AB, document_number, C);

            return cuil_cuit;
        }
    }
}
