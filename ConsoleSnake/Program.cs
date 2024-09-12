using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnake
{
    internal class Program
    {
        enum eCellType
        {
            Empty,
            Wall,
            PowerUp,
            Pill,
            PlayerHead,
            PlayerBodyH,
            PlayerBodyV,
            PlayerBodyUpToLeft,
            PlayerBodyUpToRight,
            PlayerBodyDownToLeft,
            PlayerBodyDownToRight
        }

        struct CellInfo
        {
            public eCellType cellType;
            public ConsoleColor color;
        }

        struct Vector2i
        {
            public int X;
            public int Y;

            public Vector2i(int posX, int posY)
            {
                X = posX; 
                Y = posY;
            }

            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public override string ToString()
            {
                return base.ToString();
            }

            public static Vector2i operator +(Vector2i a, Vector2i b) 
            { 
                return new Vector2i(a.X + b.X, a.Y + b.Y);
            }

            public static Vector2i operator -(Vector2i a, Vector2i b)
            {
                return new Vector2i(a.X - b.X, a.Y - b.Y);
            }

            public static bool operator ==(Vector2i a, Vector2i b)
            {
                return a.X == b.X &&  a.Y == b.Y;
            }
            public static bool operator !=(Vector2i a, Vector2i b)
            {
                return a.X != b.X || a.Y != b.Y;
            }

        }

        static Dictionary<eCellType, char> cellNamesToVisuals = new Dictionary<eCellType, char>();
        static Vector2i mapSize = new Vector2i();
        static CellInfo[,] gameMapInfo = new CellInfo[0,0];
        
        static Vector2i playerPos = new Vector2i();
        static Vector2i lastDir = new Vector2i();

        static Queue<Vector2i> snakeBody = new Queue<Vector2i>();
        static int maxSnakeLenght = 3;

        static void Main(string[] args)
        {
            InitGame();
        }

        static void InitGame()
        {
            InitCellsDictionary();
            InitGameCells();
        }

        static void InitCellsDictionary()
        {
            cellNamesToVisuals.Clear();
            cellNamesToVisuals.Add(eCellType.Empty, ' ');
            cellNamesToVisuals.Add(eCellType.Wall, '█');
            cellNamesToVisuals.Add(eCellType.PowerUp, '$');
            cellNamesToVisuals.Add(eCellType.Pill, '%');
            cellNamesToVisuals.Add(eCellType.PlayerHead, '·');
            cellNamesToVisuals.Add(eCellType.PlayerBodyH, '═');
            cellNamesToVisuals.Add(eCellType.PlayerBodyV, '║');
            cellNamesToVisuals.Add(eCellType.PlayerBodyUpToLeft, '╝');
            cellNamesToVisuals.Add(eCellType.PlayerBodyUpToRight, '╚');
            cellNamesToVisuals.Add(eCellType.PlayerBodyDownToLeft, '╗');
            cellNamesToVisuals.Add(eCellType.PlayerBodyDownToRight, '╔');
        }

        static void InitGameCells()
        {
            AskUserMapSize();
            InitGameMap();
            InitPlayer();
            UpdateGame();
        }

        static void AskUserMapSize()
        {
            while (true)
            {
                Console.WriteLine("Introduce el tamaño del mapa en el que quieres jugar (X,Y): ");

                string input = Console.ReadLine();
                string[] splittedInput = input.Split(',');


                if (splittedInput.Length > 1)
                {
                    if (int.TryParse(splittedInput[0], out mapSize.X) && int.TryParse(splittedInput[1], out mapSize.Y))
                        return;
                    else
                        Console.WriteLine("No se han podido leer los valores introducidos");

                }
                else
                    Console.WriteLine("Tienes que introducir 2 valores (X,Y)");
            }
        }

        static void InitGameMap()
        {
            gameMapInfo = new CellInfo[mapSize.X, mapSize.Y];
            for (int posX = 0; posX < mapSize.X; posX++)
            {
                for (int posY = 0; posY < mapSize.Y; posY++)
                {
                    if (posX == 0 || posY == 0 || posX == mapSize.X - 1 || posY == mapSize.Y - 1)   // Límites del mapa
                    {
                        gameMapInfo[posX, posY].cellType = eCellType.Wall;
                        gameMapInfo[posX, posY].color = ConsoleColor.White;
                        continue;
                    }

                    gameMapInfo[posX, posY].cellType = eCellType.Empty;
                    gameMapInfo[posX, posY].color = ConsoleColor.White;
                }
            }
        }

        static void InitPlayer()
        {
            // El jugador aparece en el centro del mapa
            playerPos = new Vector2i(mapSize.X / 2, mapSize.Y / 2);
            gameMapInfo[playerPos.X, playerPos.Y].cellType = eCellType.PlayerHead;
        }

        static void UpdateGame()
        {
            while (true)
            {
                ShowMap();
                ProcessPlayerInput();
            }
        }

        static void ShowMap()
        {
            Console.Clear();

            for (int posY = 0; posY < mapSize.Y; posY++)
            {
                for (int posX = 0; posX < mapSize.X; posX++) 
                {
                    Console.ForegroundColor = gameMapInfo[posX, posY].color;

                    if (posX == mapSize.X - 1)
                        Console.WriteLine(cellNamesToVisuals[gameMapInfo[posX, posY].cellType]);
                    else
                        Console.Write(cellNamesToVisuals[gameMapInfo[posX, posY].cellType]);
                }
            }
        }

        static void ProcessPlayerInput()
        {
            ConsoleKeyInfo playerInput = Console.ReadKey();

            switch (playerInput.Key)
            {
                case ConsoleKey.RightArrow:
                    MovePlayer(new Vector2i(1,0));
                    break;
                case ConsoleKey.LeftArrow:
                    MovePlayer(new Vector2i(-1, 0));
                    break;
                case ConsoleKey.UpArrow:
                    MovePlayer(new Vector2i(0, -1));     // Al estar en formato lista el mapa es positivo hacia abajo y negativo hacia arriba
                    break;
                case ConsoleKey.DownArrow:
                    MovePlayer(new Vector2i(0, 1));
                    break;

                default:
                    break;
            }
        }

        static void MovePlayer(Vector2i moveDir)
        {
            if (gameMapInfo[playerPos.X + moveDir.X, playerPos.Y + moveDir.Y].cellType == eCellType.Wall ||
                gameMapInfo[playerPos.X + moveDir.X, playerPos.Y + moveDir.Y].cellType >= eCellType.PlayerHead)
                return;
            else
            {
                if(lastDir != new Vector2i(0, 0) && lastDir != moveDir)
                {
                    if (moveDir.Y == 0)
                    {
                        if(lastDir.Y == 1)
                            gameMapInfo[playerPos.X, playerPos.Y].cellType = moveDir.X == 1 ? eCellType.PlayerBodyUpToRight : eCellType.PlayerBodyUpToLeft;

                        if(lastDir.Y == -1)
                            gameMapInfo[playerPos.X, playerPos.Y].cellType = moveDir.X == 1 ? eCellType.PlayerBodyDownToRight : eCellType.PlayerBodyDownToLeft;
                    }
                    else
                    {
                        if(lastDir.X == 1)
                            gameMapInfo[playerPos.X, playerPos.Y].cellType = moveDir.Y == 1 ? eCellType.PlayerBodyDownToLeft : eCellType.PlayerBodyUpToLeft;
                            
                        if (lastDir.X == -1)
                            gameMapInfo[playerPos.X, playerPos.Y].cellType = moveDir.Y == 1 ? eCellType.PlayerBodyDownToRight : eCellType.PlayerBodyUpToRight;
                    }
                }
                else
                    gameMapInfo[playerPos.X, playerPos.Y].cellType = moveDir.Y == 0 ? eCellType.PlayerBodyH : eCellType.PlayerBodyV;

                if(snakeBody.Count < maxSnakeLenght)
                {
                    snakeBody.Enqueue(playerPos);
                }
                else
                {
                    Vector2i tailPos = snakeBody.Dequeue();
                    gameMapInfo[tailPos.X, tailPos.Y].cellType = eCellType.Empty;

                    snakeBody.Enqueue(playerPos);
                }

                playerPos += moveDir;
                gameMapInfo[playerPos.X, playerPos.Y].cellType = eCellType.PlayerHead;
            }

            lastDir = moveDir;
        }
    }
}
