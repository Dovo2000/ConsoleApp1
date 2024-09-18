using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                List<Deck> playersDecks = new List<Deck>();

                Console.Write("¿Cuantos jugadores jugarán la partida?");
                string response = Console.ReadLine();

                if (!int.TryParse(response, out int numPlayers))
                {
                    Console.WriteLine("Introduce un valor de jugadores válido");
                    continue;
                }
                
                if(numPlayers < 2 || numPlayers > 5)
                {
                    Console.WriteLine("El numero de jugadores tiene que ser un valor entre 2 y 5");
                    continue;
                }
                Deck initialDeck = new Deck();
                initialDeck.InitializeFullDeck();
                initialDeck.Shuffle();

                int cardsPerPlayer = initialDeck.CardCount / numPlayers;


                for (int playerNum = 0; playerNum < numPlayers; playerNum++)
                {
                    List<Card> temp = new List<Card>();

                    for (int count = 0; count < cardsPerPlayer; count++)
                        temp.Add(initialDeck.DrawCard());

                    playersDecks.Add(new Deck(temp));
                }

                foreach (Deck player in playersDecks)
                {
                    Console.WriteLine(player.ToString());
                    Console.WriteLine($"Count: {player.CardCount}");
                    Console.WriteLine("-----------------");
                }

                Console.ReadKey();
            }
            while (true);
        }
    }
}
