using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEnRaya
{
    internal class Program
    {
        static int MaxSize = 3;
        static int NumOfDimensions = 1;
        static char[] tableInfo = new char[MaxSize ^ NumOfDimensions];


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
            Console.Clear();

            Console.WriteLine("¿Con cuantas dimensiones quieres jugar?");
            string response = Console.ReadLine();

            bool parseSucceedDimensions = int.TryParse(response, out int dimensions);

            Console.WriteLine("¿Con cuantas filas, columnas y profundidad quieres jugar?");
            response = Console.ReadLine();

            bool parseSucceed = int.TryParse(response, out int size);

            if (parseSucceed && parseSucceedDimensions)
            {
                NumOfDimensions = dimensions;                
                MaxSize = size;

                tableInfo = new char[MaxSize ^ NumOfDimensions];
            }

            InitDimensionalTables(0);
        }

        static void InitDimensionalTables(int dimension)
        {
            for (int x = 0; x < (MaxSize ^ NumOfDimensions); x++)
                tableInfo[x] = ' ';
        }

        static void ShowTable()
        {
            ShowDimensionalTables(0);
        }

        static void ShowDimensionalTables(int dimension)
        {
            Console.WriteLine($"Dimension: {dimension + 1}");
            for (int z = 0; z < MaxSize; z++)
            {
                Console.WriteLine($"Z = {z + 1}.");
                for (int x = 0; x < MaxSize; x++)
                {
                    for (int y = 0; y < MaxSize; y++)
                    {
                        Console.Write($"{tableInfo[dimension][x, y, z]}");
                        if (y >= MaxSize - 1)
                            break;
                        Console.Write("|");
                    }

                    Console.WriteLine();

                    if (x < MaxSize - 1)
                    {
                        for (int y = 0; y < MaxSize; y++)
                            Console.Write("--");
                    }

                    Console.WriteLine();
                }

                if (z < MaxSize - 1)
                    Console.WriteLine("/");

                Console.WriteLine();
            }

            if(dimension == NumOfDimensions - 1)
                return;

            ShowDimensionalTables(dimension + 1);
        }

        static bool StartTurn(int playerNum)
        {
            while (true)    // Turno
            {
                char playerSymbol = ' ';

                playerSymbol = playerNum == 1 ? 'O' : 'X';

                pos = GetPosition(playerNum, playerSymbol);
                pos.D--;
                pos.X--;
                pos.Y--;
                pos.Z--;

                if (MoveIsValid(pos))
                {
                    tableInfo[pos.D][pos.X, pos.Y, pos.Z] = playerSymbol;
                    // Check if this is a win move
                    bool? isWin = CheckWinConditions(playerSymbol);

                    if (isWin == false)
                        return true;
                    else
                    {
                        Console.Clear();

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

        static Vector4i GetPosition(int playerNum, char playerSymbol)
        {
            while (true)
            {
                Console.WriteLine($"Jugador {playerNum} ({playerSymbol}) introduce la dimension, la fila, la columna y la profundidad (fila,columna,profundidad) en la que quieres introducir tu ficha: ");
                string input = Console.ReadLine();
                string[] splittedInput = input.Split(',');

                if (splittedInput.Length > 2)
                {
                    Vector4i pos = new Vector4i();
                    bool parseSucceedD = int.TryParse(splittedInput[0], out pos.D);
                    bool parseSucceedX = int.TryParse(splittedInput[1], out pos.X);
                    bool parseSucceedY = int.TryParse(splittedInput[2], out pos.Y);
                    bool parseSucceedZ = int.TryParse(splittedInput[3], out pos.Z);

                    if (parseSucceedD && parseSucceedX && parseSucceedY && parseSucceedZ)
                        if (pos.X > 0 && pos.X <= MaxSize && pos.Y > 0 && pos.Y <= MaxSize && pos.Z > 0 && pos.Z <= MaxSize && pos.D > 0 && pos.D < NumOfDimensions)
                            return pos;
                }
            }
        }

        static bool MoveIsValid(Vector4i pos)
        {
            if (tableInfo[pos.D][pos.X, pos.Y, pos.Z] != ' ')
            {
                Console.WriteLine("El movimiento no es válido, ese espacio ya está ocupado por otra ficha");
                return false;
            }
            return true;
        }

        static bool? CheckWinConditions(char playerSymbol)
        {
            for (int deep = 0; deep < MaxSize; deep++)
            {
                if (NonDiagonalWinCheck(deep, playerSymbol))
                    return true;

                if (SamePlaneDiagonalWinCheck(deep, playerSymbol))
                    return true;
            }

            if (MultiPlaneDiagonalWinCheck(playerSymbol))
                return true;

            // Si el tablero está lleno significa que hay empate
            if (TableIsFull())
                return null;

            return false;
        }

        static bool NonDiagonalWinCheck(int deep, char playerSymbol)
        {
            //for (int fixedAxis = 0; fixedAxis < 3; fixedAxis++)
            //{
            //    for (int row = 0; row < MaxRows; row++)
            //    {
            //        for (int col = 0; col < MaxColumns; col++)
            //        {
            //            if (fixedAxis == 0)
            //            {
            //                if (tableInfo[row, col, deep] != playerSymbol)
            //                    break;

            //                if (col == MaxColumns - 1)   // final de línea
            //                    return true;
            //            }
            //            else if (fixedAxis == 1)
            //            {
            //                if (tableInfo[col, row, deep] != playerSymbol)
            //                    break;

            //                if (col == MaxColumns - 1)   // final de columna
            //                    return true;
            //            }
            //            else
            //            {
            //                if (tableInfo[row, deep, col] != playerSymbol)
            //                    break;

            //                if (col == MaxColumns - 1)   // final de linea en Z (profundidad)
            //                    return true;
            //            }
            //        }
            //    }
            //}

            return false;
        }

        static bool SamePlaneDiagonalWinCheck(int deep, char playerSymbol)
        {
            //int column = 0;
            //for (int row = 0; row < MaxRows || column < MaxColumns; row++, column++)
            //{
            //    if (tableInfo[row, column, deep] != playerSymbol) // Diagonal de arriba izquierda -> abajo derecha
            //        break;

            //    if (column == MaxColumns - 1 && row == MaxRows - 1)
            //        return true;
            //}

            //column = 0;
            //for (int row = 0; row < MaxRows || column < MaxColumns; row++, column++)
            //{
            //    if (tableInfo[deep, row, column] != playerSymbol) // Diagonal de delante izquierda -> fondo derecha
            //        break;

            //    if (column == MaxColumns - 1 && row == MaxRows - 1)
            //        return true;
            //}

            //column = MaxColumns - 1;
            //for (int row = 0; column < MaxColumns || row >= 0; row++, column--)
            //{
            //    if (tableInfo[row, column, deep] != playerSymbol)   // Diagonal abajo izquierda -> arriba derecha
            //        break;

            //    if (column == 0 && row == MaxRows - 1)
            //        return true;
            //}

            //column = MaxColumns - 1;
            //for (int row = 0; column < MaxColumns || row >= 0; row++, column--)
            //{
            //    if (tableInfo[deep, row, column] != playerSymbol)   // Diagonal fondo izquierda -> frente derecha
            //        break;

            //    if (column == 0 && row == MaxRows - 1)
            //        return true;
            //}

            return false;
        }

        static bool MultiPlaneDiagonalWinCheck(char playerSymbol)
        {
            //int row = 0;
            //int column = 0;
            //int deep = 0;

            //while (row < MaxRows && column < MaxColumns && deep < MaxDeep)
            //{
            //    if (tableInfo[row, column, deep] != playerSymbol)
            //        break;
            //    if (column == MaxColumns - 1 && row == MaxRows - 1 && deep == MaxDeep - 1)   // Diagonal arriba izquierda delante -> abajo derecha fondo
            //        return true;

            //    row++;
            //    column++;
            //    deep++;
            //}

            //row = 0;
            //column = 0;
            //deep = MaxDeep - 1;

            //while (row < MaxRows && column < MaxColumns && deep < MaxDeep)
            //{
            //    if (tableInfo[row, column, deep] != playerSymbol)
            //        break;
            //    if (column == MaxColumns - 1 && row == MaxRows - 1 && deep == 0)   // Diagonal arriba izquierda fondo -> abajo derecha delante
            //        return true;

            //    row++;
            //    column++;
            //    deep--;
            //}

            //row = MaxRows - 1;
            //column = 0;
            //deep = MaxDeep - 1;

            //while (row < MaxRows && column < MaxColumns && deep < MaxDeep)
            //{
            //    if (tableInfo[row, column, deep] != playerSymbol)
            //        break;
            //    if (column == MaxColumns - 1 && row == 0 && deep == 0)   // Diagonal abajo izquierda fondo -> arriba derecha delante
            //        return true;

            //    row--;
            //    column++;
            //    deep--;
            //}

            //row = MaxRows - 1;
            //column = 0;
            //deep = 0;

            //while (row < MaxRows && column < MaxColumns && deep < MaxDeep)
            //{
            //    if (tableInfo[row, column, deep] != playerSymbol)
            //        break;
            //    if (column == MaxColumns - 1 && row == 0 && deep == MaxDeep - 1)   // Diagonal abajo izquierda delante -> arriba derecha fondo
            //        return true;

            //    row--;
            //    column++;
            //    deep++;
            //}

            return false;
        }

        static bool TableIsFull()
        {
            //for (int x = 0; x < MaxRows; x++)
            //{
            //    for (int y = 0; y < MaxColumns; y++)
            //    {
            //        for (int z = 0; z < MaxDeep; z++)
            //        {
            //            if (tableInfo[x, y, z] == ' ')
                            return false;
            //        }
            //    }
            //}
            //return true;
        }
    }
}
