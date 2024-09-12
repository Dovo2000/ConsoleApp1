using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TresEnLinea
{
    internal class Program
    {
        static int MaxRows = 3;
        static int MaxColumns = 3;
        static char[,] tableInfo = new char[MaxRows, MaxColumns];

        static void Main(string[] args)
        {
            StartGame();
        }

        static void StartGame()
        {
            while (true)
            {
                InitTable();

                Random rand = new Random();
                int playerNum = rand.Next(1, 3);

                while (true) // upadate juego
                {
                    Console.Clear();
                    ShowTable();

                    if (!StartTurn(playerNum))
                        break;

                    playerNum = playerNum == 1 ? 2 : 1; // Cambio de turno
                }
                while (true)
                {
                    Console.WriteLine("¿Quieres volver a jugar? (Y/N)");
                    string response = Console.ReadLine();

                    if (response == "Y" || response == "y")
                        break;
                    else if (response == "N" || response == "n")
                        return;
                }
            }
        }

        static void InitTable()
        {
            Console.WriteLine("¿Con cuantas filas y columnas quieres jugar?");
            string response = Console.ReadLine();

            bool parseSucceed = int.TryParse(response, out int size);

            if (parseSucceed)
            {
                MaxRows = size;
                MaxColumns = size;
                tableInfo = new char[MaxRows, MaxColumns];
            }

            for (int x = 0; x < MaxRows; x++)
            {
                for (int y = 0; y < MaxColumns; y++)
                {
                    tableInfo[x, y] = ' ';
                }
            }
        }

        static void ShowTable()
        {
            for (int x = 0; x < MaxRows; x++)
            {
                for (int y = 0; y < MaxColumns; y++)
                {
                    Console.Write($"{tableInfo[x, y]}");
                    if (y >= MaxColumns - 1)
                        break;
                    Console.Write("|");
                }

                Console.WriteLine();

                for (int y = 0;y < MaxColumns; y++)
                    Console.Write("--");

                Console.WriteLine();
            }
        }

        static bool StartTurn(int playerNum)
        {
            while (true)    // Turno
            {
                int posX = 0;
                int posY = 0;
                char playerSymbol = ' ';

                playerSymbol = playerNum == 1 ? 'O' : 'X';

                (posX, posY) = GetPosition(playerNum, playerSymbol);

                if (MoveIsValid(--posX, --posY))
                {
                    tableInfo[posX, posY] = playerSymbol;
                    // Check if this is a win move
                    bool? isWin = CheckWinConditions(playerSymbol);

                    if (isWin == false)
                        return true;
                    else
                    {
                        if (isWin == true)
                            Console.WriteLine($"¡Jugador {playerNum} ({playerSymbol}) gana!");
                        else
                            Console.WriteLine("¡Empate!");

                        ShowTable();
                        return false;
                    }
                }
            }
        }

        static (int, int) GetPosition(int playerNum, char playerSymbol)
        {
            while (true)
            {
                Console.WriteLine($"Jugador {playerNum} ({playerSymbol}) introduce la fila y la columna (fila,columna) en la que quieres introducir tu ficha: ");
                string input = Console.ReadLine();
                string[] splittedInput = input.Split(',');

                if(splittedInput.Length > 1)
                {
                    bool parseSucceedX = int.TryParse(splittedInput[0], out int posX);
                    bool parseSucceedY = int.TryParse(splittedInput[1], out int posY);

                    if (parseSucceedX && parseSucceedY)
                        if (posX > 0 && posX <= MaxRows && posX > 0 && posX <= MaxColumns)
                            return (posX, posY);
                }
            }
        }

        static bool MoveIsValid(int posX, int posY)
        {
            if (tableInfo[posX, posY] != ' ')
            {
                Console.WriteLine("El movimiento no es válido, ese espacio ya está ocupado por otra ficha");
                return false;
            }
            return true;
        }

        static bool? CheckWinConditions(char playerSymbol)
        {
            for (int row = 0; row < MaxRows; row++)
            {
                for(int col = 0; col < MaxColumns; col++)
                {
                    if(tableInfo[row, col] != playerSymbol)
                        break;

                    if(col == MaxColumns - 1)   // final de línea
                        return true;
                }
            }

            for(int col = 0; col < MaxColumns; col++)
            {
                for (int row = 0; row < MaxRows; row++)
                {
                    if (tableInfo[row, col] != playerSymbol)
                        break;

                    if (row == MaxRows - 1) // final de columna
                        return true;
                }
            }

            int column = 0;
            for(int row = 0; row < MaxRows || column < MaxColumns; row++, column++)
            {
                if (tableInfo[row, column] != playerSymbol)
                    break;
                if(column == MaxColumns - 1 || row == MaxRows - 1) // Diagonal de arriba izquierda -> abajo derecha
                    return true;
            }

            column = MaxColumns - 1;
            for (int row = 0; column < MaxColumns || row >= 0; row++, column--)
            {
                if (tableInfo[row, column] != playerSymbol)
                    break;
                if (column == 0 && row == MaxRows - 1)   // Diagonal abajo izquierda -> arriba derecha
                    return true;
            }

            // Si el tablero está lleno significa que hay empate
            if (TableIsFull())
                return null;

            return false;
        }

        static bool TableIsFull()
        {
            for (int x = 0; x < MaxRows; x++)
            {
                for (int y = 0; y < MaxColumns; y++)
                {
                    if (tableInfo[x, y] == ' ')
                        return false;
                }
            }
            return true;
        }
    }
}
