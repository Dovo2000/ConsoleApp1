using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEquipos
{
    internal class Program
    {
        static Dictionary<string, int> teamsInfo = new Dictionary<string, int>();
        static string filePath = @".\teamsData.txt";

        static void Main(string[] args)
        {
            StartProgram();
        }

        static void StartProgram()
        {
            ReadFile();
            ConsoleKeyInfo key;
            do
            {
                PrintMenu();

                if (!ProcessMenuInputs())
                    return;

                Console.WriteLine("Press any key to continue or press ESC to exit...");
                key = Console.ReadKey();
                Console.Clear();
            } 
            while (key.Key != ConsoleKey.Escape);
        }

        static void PrintMenu()
        {
            Console.WriteLine("Bienvenido al gestor de equipos de la Liga, selecciona la acción que quieras realizar: ");
            Console.WriteLine(@"(1) Consultar puntuaciones
(2) Dar de alta un equipo
(3) Dar de baja un equipo
(4) Modificar una puntuación

(0) Salir");

        }

        static void ReadFile()
        {
            try
            {
                StreamReader sr = new StreamReader(filePath);

                string line = sr.ReadLine();

                while (line != null)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length == 2 && int.TryParse(parts[1], out int points))
                        teamsInfo.Add(parts[0], points);

                    line = sr.ReadLine();
                }

                sr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        static bool ProcessMenuInputs()
        {
            string userInput = Console.ReadLine();
            Console.Clear();

            switch (userInput)
            {
                case "1":
                    ShowTeamsInfo();
                    break;

                case "2":
                    SignUpNewTeam();
                    break;

                case "3":
                    RemoveTeam();
                    break;

                case "4":
                    ModifyPuntuation();
                    break;

                case "0":
                    return false;

                default:
                    break;
            }

            return true;
        }

        static void ShowTeamsInfo()
        {
            if (teamsInfo.Count == 0)
            {
                Console.WriteLine("No data.");
                return;
            }

            foreach (var team in teamsInfo)
                Console.WriteLine($"Equipo: {team.Key} | Puntuación: {team.Value}");
        }

        static void SignUpNewTeam()
        {
            Console.WriteLine("Introduce el nombre y la puntuación del equipo que quieres inscribir separados por una coma: ");
            string teamInfo = Console.ReadLine();

            try
            {
                string[] splittedInfo = teamInfo.Split(',');

                if (int.TryParse(splittedInfo[1], out int points))
                    teamsInfo.Add(splittedInfo[0], points);

                SaveToFile();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
        }

        static void RemoveTeam()
        {
            ShowTeamsInfo();

            Console.WriteLine("Introduce el nombre del equipo que quieres borrar: ");
            string teamName = Console.ReadLine();

            try
            {
                teamsInfo.Remove(teamName);
                SaveToFile();
            }
            catch (Exception e) 
            {
                Console.WriteLine($"Exception: {e.Message}");
            }

        }

        static void ModifyPuntuation()
        {
            ShowTeamsInfo();
            Console.WriteLine("Escribe el nombre del equipo y su puntuación modificada: ");
            string teamNewInfo = Console.ReadLine();

            try
            {
                string[] splittedInfo = teamNewInfo.Split(',');

                if (int.TryParse(splittedInfo[1], out int points))
                    teamsInfo[splittedInfo[0]] = points;

                SaveToFile();
            }
            catch (Exception e )
            {
                Console.WriteLine($"Exception {e.Message}");
            }
        }

        static void SaveToFile()
        {
            StreamWriter sw = new StreamWriter(filePath);
            string teamInfo;

            foreach (var team in teamsInfo)
            {
                teamInfo = team.Key + "," + team.Value.ToString();
                sw.WriteLine(teamInfo);
            }

            sw.Close();
        }
    }
}
