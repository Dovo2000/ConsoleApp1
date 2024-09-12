using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseTraductor
{
    internal class Program
    {
        static Dictionary<char, string> letterToMorseDictionary = new Dictionary<char, string>();
        static Dictionary<string, char> morseToLetters = new Dictionary<string, char>();
    
        static void Main(string[] args)
        {
            InitDictionary();
            InitTranslation();
        }

        static void InitTranslation()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"(1) Letter to Morse
(2) Morse to letter");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int result))
                    continue;

                Console.WriteLine("Introduce para traducir:");

                input = Console.ReadLine().ToUpperInvariant();

                string[] splited = input.Split(' ');

                string response = "";

                switch (result)
                {
                    case 1:
                        foreach (string word in splited)
                        {
                            for (int i = 0; i < word.Length; i++)
                            {
                                if (letterToMorseDictionary.ContainsKey(word[i]))
                                {
                                    response += letterToMorseDictionary[word[i]];
                                    response += " ";
                                }
                            }
                            response += @"\ ";
                        }
                    break;

                    case 2:
                        foreach (string letter in splited)
                        {
                            if(morseToLetters.ContainsKey(letter))
                                response += morseToLetters[letter];
                            
                            if (letter == @"\")
                                response += " ";
                        }
                        break;

                    default:
                    break;
                }

                

                
                Console.WriteLine(response);
                Console.ReadKey();
            }
        }

        static void InitDictionary()
        {
            letterToMorseDictionary.Add('A', "·-");
            letterToMorseDictionary.Add('B', "-···");
            letterToMorseDictionary.Add('C', "-·-·");
            letterToMorseDictionary.Add('D', "-··");
            letterToMorseDictionary.Add('E', "·");
            letterToMorseDictionary.Add('F', "··-·");
            letterToMorseDictionary.Add('G', "--·");
            letterToMorseDictionary.Add('H', "····");
            letterToMorseDictionary.Add('I', "··");
            letterToMorseDictionary.Add('J', "·---");
            letterToMorseDictionary.Add('K', "-·-");
            letterToMorseDictionary.Add('L', "·-··");
            letterToMorseDictionary.Add('M', "--");
            letterToMorseDictionary.Add('N', "-·");
            letterToMorseDictionary.Add('O', "---");
            letterToMorseDictionary.Add('P', "·--·");
            letterToMorseDictionary.Add('Q', "--·-");
            letterToMorseDictionary.Add('R', "·-·");
            letterToMorseDictionary.Add('S', "···");
            letterToMorseDictionary.Add('T', "-");
            letterToMorseDictionary.Add('U', "··-");
            letterToMorseDictionary.Add('V', "···-");
            letterToMorseDictionary.Add('W', "·--");
            letterToMorseDictionary.Add('X', "-··-");
            letterToMorseDictionary.Add('Y', "-·--");
            letterToMorseDictionary.Add('Z', "--··");
            letterToMorseDictionary.Add('1', "·----");
            letterToMorseDictionary.Add('2', "··---");
            letterToMorseDictionary.Add('3', "···--");
            letterToMorseDictionary.Add('4', "····-");
            letterToMorseDictionary.Add('5', "·····");
            letterToMorseDictionary.Add('6', "-····");
            letterToMorseDictionary.Add('7', "--···");
            letterToMorseDictionary.Add('8', "---··");
            letterToMorseDictionary.Add('9', "----·");
            letterToMorseDictionary.Add('0', "-----");
            letterToMorseDictionary.Add(',', "--·--");
            letterToMorseDictionary.Add('.', "·-·-·-");
            letterToMorseDictionary.Add('?', "··--··");
            letterToMorseDictionary.Add(';', "-·-·-");
            letterToMorseDictionary.Add(':', "---···");
            letterToMorseDictionary.Add('/', "-··-·");
            letterToMorseDictionary.Add('(', "-·--·-");

            morseToLetters = letterToMorseDictionary.ToDictionary(entry => entry.Value, entry => entry.Key);
        }
    }
}
