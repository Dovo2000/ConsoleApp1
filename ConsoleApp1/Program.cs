using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(@"Elige una función (introduce número):
(1) Transformador de camel case.
(2) Comparador de fechas.
(3) Comprobador de palindromos.
(4) Divisor de enteros.
(5) Calculadora de medias.
(6) Calculadora de exponentes.
(7) Comparador alfabético.
(8) Inversor de textos.
(9) Inversor de números.
(10) Adivina el número.
(11) Contador de números pares.");

                string selection = Console.ReadLine();
                
                switch (selection)
                {
                    case "1":
                        ProcessCamelCase();
                        break;

                    case "2":
                        ProcessDateComparator();
                        break;

                    case "3":
                        ProcessPalindrome();
                        break;

                    case "4":
                        ProcessIntegerDivision();
                        break;

                    case "5":
                        ProcessMean();
                        break;

                    case "6":
                        ProcessPow();
                        break;

                    case "7":
                        ProcessCompareAlphabeticOrder();
                        break;

                    case "8":
                        ProcessReverseString();
                        break;

                    case "9":
                        ProcessReverseNumber();
                        break; 

                    case "10":
                        ProcessGuessing();
                        break;

                    case "11":
                        EvenCountFor();
                        EvenCountWhile();
                        EvenCountDoWhile();
                        break;

                    default:
                        break;
                }

                while (true)
                {
                    Console.WriteLine("¿Quieres continuar? (Y/N)");
                    string response = Console.ReadLine();

                    if (response == "Y" || response == "y")
                        break;
                    else if (response == "N" || response == "n")
                        return;
                }
                Console.Clear();
            }
        }

        #region Transformador caselCase

        static void ProcessCamelCase()
        {
            Console.WriteLine("Hola! Introduce una frase:");
            // Introducir input
            string input = Console.ReadLine();

            Console.WriteLine($"El resultado en camelCase es: {TransformToCamelCase(input)}");
        }

        static string TransformToCamelCase(string input)
        {
            // Procesar camelCase, es decir, eliminar espacios y hacer todas las primeras letras de cada palabra mayúscula
            // a excepción de la primera palabra que sera en minúscula
            string result = "";
            char currentLetter = ' ';
            bool lastWasInvalid = false;

            if (input.Length > 0)
            {
                // Entramos aquí cuando el input NO está vacío
                currentLetter = input[0];
                // El primer char del string siempre será minúscula si se trata de una letra
                // input[0] es mayúscula lo transfomamos en minúscula y concatenamos a result
                currentLetter = ToLowerCase(currentLetter);
            }

            result += currentLetter;

            for (int i = 1; i < input.Length; i++)
            {
                currentLetter = input[i];

                if (currentLetter == ' ')
                {
                    // Carácter actual es inválido
                    lastWasInvalid = true;
                }
                else
                {
                    // Carácter actual es válido
                    if (lastWasInvalid)
                    {
                        // input[i] es minúscula lo transfomamos en mayúscula y concatenamos a result
                        currentLetter = ToUpperCase(currentLetter);
                    }
                    lastWasInvalid = false;
                    result += currentLetter;
                }
            }

            return result;
        }

        static char ToUpperCase(char character)
        {
            if (character >= 'a' && character <= 'z')
            {
                character -= (char)32; // Diferencia numérica entre A y a en el codigo ASCII
            }
            return character;
        }

        static char ToLowerCase(char character)
        {
            if (character >= 'A' && character <= 'Z')
            {
                character += (char)32; // Diferencia numérica entre A y a en el codigo ASCII
            }
            return character;
        }

        static string TransformToCamelCaseV2(string input) /// No mirar, es trampa el split
        {
            // Procesar camelCase, es decir, eliminar espacios y hacer todas las primeras letras de cada palabra mayúscula
            // a excepción de la primera palabra que sera en minúscula

            string[] dividedInput = input.Split(' ');   // no recordaba que estaba prohibido :p
            string result = "";

            // Primer carácter del input tiene que ser en minúscula
            result += dividedInput[0].First().ToString().ToLowerInvariant() + dividedInput[0].Substring(1);

            for (int i = 1; i < dividedInput.Length; i++)
            {
                result += dividedInput[i].First().ToString().ToUpperInvariant() + dividedInput[i].Substring(1);
            }

            return result;
        }

        #endregion

        #region Comparador de fechas

        static void ProcessDateComparator()
        {
            Console.WriteLine("Hola! Introduce la primera fecha (DD/MM/YYYY):");
            bool succeedParse1 = DateTime.TryParse(Console.ReadLine(), out DateTime inputDate1);

            Console.WriteLine("Hola! Introduce la segunda fecha (DD/MM/YYYY):");
            bool succeedParse2 = DateTime.TryParse(Console.ReadLine(), out DateTime inputDate2);

            if (!(succeedParse1 && succeedParse2))
            {
                Console.WriteLine("No se ha podido identificar las fechas introducidas");
                return;
            }

            int dateDiff = CompareDates(inputDate1, inputDate2);

            if (dateDiff == 1)
                Console.WriteLine($"{inputDate1.ToShortDateString()} es posterior a {inputDate2.ToShortDateString()}");
            else if (dateDiff == -1)
                Console.WriteLine($"{inputDate2.ToShortDateString()} es posterior a {inputDate1.ToShortDateString()}");
            else
                Console.WriteLine($"{inputDate1.ToShortDateString()} y {inputDate2.ToShortDateString()} son la misma fecha");
            
        }

        static int CompareDates(DateTime firstDate, DateTime secondDate)
        {
            if (firstDate.Year != secondDate.Year)
                return firstDate.Year > secondDate.Year ? 1 : -1;
            else
            {
                if (firstDate.Month != secondDate.Month)
                    return firstDate.Month > secondDate.Month ? 1 : -1;
                else
                {
                    if (firstDate.Day != secondDate.Day)
                        return firstDate.Day > secondDate.Day ? 1 : -1;
                }
            }
            return 0;
        }

        #endregion

        #region Comprobador de palíndromos

        static void ProcessPalindrome()
        {
            Console.WriteLine("Hola! Introduce una palabra: ");

            string input = Console.ReadLine();

            Console.WriteLine($"¿La palabra es un palíndromo? {IsPalindrome(input)}");
        }

        static bool IsPalindrome(string input)
        {
            int frontCounter = 0; // Apuntamos al primer carácter del input con frontCounter
            int backCounter = input.Length - 1; // Apuntamos con backCounter al último carácter del input

            string normalizedInput = input.ToLowerInvariant(); // pasamos todo el input a minúscula para comprobar que son
                                                               // iguales carácteres sin importar si son mayuscula o minuscula

            // Si frontCounter deja de ser mas pequeño que backCounter significa que
            // o estan apuntado al mismo carácter o que están apuntando a un carácter que ya se ha comprobado anteriormente
            // por lo tanto todas las letras del derecho y del revés estan en el mismo orden y se cumple la simetría.
            while (frontCounter < backCounter)
            {
                // No coincide algún carácter por lo tanto no hay posibilidad de que sea palíndromo
                if (normalizedInput[frontCounter] != normalizedInput[backCounter])
                    return false;

                frontCounter++; // Pasamos al siguiente carácter hacia la derecha
                backCounter--; // Pasamos al siguiente carácter hacia la izquierda
            }
            // Salimos del bucle así que se cumple la simetría por lo tanto el input es palíndromo
            return true;
        }

        #endregion

        #region División de enteros

        static void ProcessIntegerDivision()
        {
            Console.WriteLine("Introduce una división (Num/Den): ");
            string input = Console.ReadLine();

            string[] divisionComponents = input.Split('/');

            Console.WriteLine($"El resultado de la división entre {divisionComponents[0]} y {divisionComponents[1]} es: ");
            bool numeratorSucceed = int.TryParse(divisionComponents[0], out int numerator);
            bool denominatorSucceed = int.TryParse(divisionComponents[1], out int denominator);

            if (!(numeratorSucceed && denominatorSucceed))
            {
                Console.WriteLine("Error en los valores introducidos, no se ha podido identificar alguno de los valores.");
                return;
            }

            int coefficient = DivideIntegers(numerator, denominator);
            Console.WriteLine(coefficient);
        }

        static int DivideIntegers(int numerator, int denominator)
        {
            int result = 0;

            while (numerator >= denominator)
            {
                numerator -= denominator;
                result++;
            }

            return result;
        }

        #endregion

        #region Calculadora de medias

        /// TODO: refactor this to prevent using that many arrays
        static void ProcessMean() 
        {
            Console.WriteLine("Introduce una cadena de números separados por espacios: ");

            string input = Console.ReadLine();
            string[] separatedNumbers = input.Split(' ');
            int[] numbers = new int[separatedNumbers.Length];

            for (int i = 0; i < separatedNumbers.Length; i++)
            {
                bool parseSucceed = int.TryParse(separatedNumbers[i], out numbers[i]);
                if (!parseSucceed)
                {
                    Console.WriteLine($"No ha sido posible leer correctamente todos los valores. Error en el valor de la posición {i} de la lista.");
                    return;
                }
            }

            Console.WriteLine($"La media aritmética es: {CalculateArithmeticMean(numbers)}");
        }

        static float CalculateArithmeticMean(int[] numbers)
        {
            float result = 0, accumulative = 0;

            if (numbers.Length > 0)
            {
                foreach (int number in numbers)
                {
                    accumulative += number;
                }

                result = accumulative / numbers.Length;
            }

            return result;
        }

        #endregion

        #region Calculadora de exponentes

        static void ProcessPow()
        {
            Console.WriteLine("Introduce una potencia, int separados por '^' (x^y):");
            string input = Console.ReadLine();
            string[] numberInputString = input.Split('^');

            bool parseBaseSucceed = int.TryParse(numberInputString[0], out int powerBase);
            bool parseExponentSucceed = int.TryParse(numberInputString[1], out int powerExponent);


            if (!parseBaseSucceed)
            {
                Console.WriteLine("No ha sido posible leer correctamente todos los valores. Error en la base.");
                return;
            }

            if (!parseExponentSucceed)
            {
                Console.WriteLine("No ha sido posible leer correctamente todos los valores. Error en el exponente.");
                return;
            }

            Console.WriteLine($"El resultado de {powerBase} elevado a {powerExponent}: es {MyPow(powerBase, powerExponent)}");
        }

        static long MyPow(int baseNum, int exponent)
        {
            long result = 1;

            for (int i = 0; i < exponent; i++)
            {
                result *= baseNum;
            }
            return result;
        }

        #endregion

        #region Comparador alfabético

        static void ProcessCompareAlphabeticOrder()
        {
            Console.WriteLine("Introduce dos textos separados por '/' :");
            string input = Console.ReadLine();
            string[] strings = input.Split('/');

            if (strings.Length < 2)
            {
                Console.WriteLine("Error al introducir correctamente los datos.");
                return;
            }
            
            Console.WriteLine($"Es el primer texto anterior alfabeticamente? {CompareAlphabeticOrder(strings[0], strings[1])}");
        }

        static bool CompareAlphabeticOrder(string inputString1, string inputString2)
        {
            // Los input pueden ser de diferentes tamaños, no podemos usar un indice de un string en una posición en la que estaría vacío
            // por lo que asigno el max length para la comprovación en el Length del string más pequeño,
            // en el caso de coincidir todas las letras pero una ser más larga que la otra
            // p.ej. Adivina y Adivinanza
            // devolveré true si el primer string es mayor y false si es el segundo.

            int maxLength = inputString1.Length <= inputString2.Length ? inputString1.Length : inputString2.Length;

            // hago minuscula los dos input para facilitar las comparaciones
            string lowerString1 = inputString1.ToLowerInvariant();
            string lowerString2 = inputString2.ToLowerInvariant();

            for (int i = 0; i < maxLength; i++)
            {
                if (lowerString1[i] >= lowerString2[i])
                {
                    if (lowerString1[i] > lowerString2[i])
                        return false;
                }
                else
                    return true;
            }
            // sale del bucle por lo que todas las letras hasta ahora son iguales y puede (o no) que sean dos string de diferente tamaño
            if (inputString1.Length < inputString2.Length)
                return false;

            return true;
        }

        #endregion

        #region Inversor de textos

        static void ProcessReverseString()
        {
            Console.WriteLine("Escribe lo que quieras invertir: ");
            string input = Console.ReadLine();

            Console.WriteLine($"El input al revés es: {ReverseString(input)}");
        }

        static string ReverseString(string inputString)
        {
            string result = "";

            for (int i = inputString.Length - 1; i >= 0; i--)
            {
                // Añadimos a result los carácteres del input en sentido inverso con i empezando desde el último carácter y acabando en 0
                result += inputString[i];
            }

            return result;
        }

        #endregion

        #region Inversor de números

        static void ProcessReverseNumber()
        {
            Console.WriteLine("Introduce el numero que quieras invertir: ");
            string input = Console.ReadLine();
            bool parseToIntSucceed = int.TryParse(input, out int parsedInput);

            if (!parseToIntSucceed)
            {
                Console.WriteLine("Error al introduccir el valor.");
                return;
            }

            Console.WriteLine($"{parsedInput} invertido es: {ReverseNumber(parsedInput)}");
        }

        static int ReverseNumber(int inputNumber)
        {
            int result = 0;

            while (inputNumber > 0)
            {
                // Para invertir un numero tenemos que extraer cada dígito en orden,
                // para ello dividimos entre 10 y guardamos el residuo para avanzar al siguiente digito,
                // multiplicamos por 10 para evitar que al sumar se pierdan los valores haciendo una suma a 0,
                // por lo tanto el último digito del resultado acaba siendo el que extraemos del residuo.
                // Repetimos hasta que el numero inicial sea 0.

                int nextDigit = inputNumber % 10;
                result *= 10;
                result += nextDigit;
                inputNumber /= 10;
            }

            return result;
        }

        #endregion

        #region Adivina el número

        static void ProcessGuessing()
        {
            Random random = new Random();
            int randomNum = random.Next(1, 21);

            do
            {
                Console.WriteLine("Introduce una predicción (del 1 al 20): ");
                string inputString = Console.ReadLine();
                bool parseSucceed = int.TryParse(inputString, out int inputNumber);

                if (!parseSucceed)
                {
                    Console.WriteLine("Error al identificar el valor introducido. Introduzca un valor entero válido");
                    continue;
                }

                if (inputNumber == randomNum)
                    break;

                if (inputNumber > randomNum)
                    Console.WriteLine("¡El numero oculto está por debajo de tu prediccón!");
                else
                    Console.WriteLine("¡El numero oculto está por encima de tu predicción!");
            } while (true);

            Console.WriteLine($"El numero oculto era: {randomNum} ¡Lo has adivinado, felicidades!");
        }

        #endregion

        #region Contadores de pares
        static void EvenCountFor()
        {
            Console.WriteLine("Contamos los pares usando un for: ");
            for (int count = 0; count <= 20; count++)
                if (count % 2 == 0)
                    Console.WriteLine(count);
        }

        static void EvenCountWhile()
        {
            int count = 0;

            Console.WriteLine("Contamos los pares usando un while: ");
            while (count <= 20)
            {
                if (count % 2 == 0)
                    Console.WriteLine(count);
                count++;
            }
        }

        static void EvenCountDoWhile()
        {
            int count = 0;

            Console.WriteLine("Contamos los pares usando un do/while: ");
            do
            {
                if (count % 2 == 0)
                    Console.WriteLine(count);
                count++;
            } while (count <= 20);
        }

        #endregion

    }
}
