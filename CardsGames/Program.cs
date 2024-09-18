using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CardsGames
{
    internal class Program
    {
        static List<(Deck deck, int playerId)> playersInfo = new List<(Deck, int)>();

        static void Main(string[] args)
        {
            do
            {
                playersInfo.Clear();
                Console.Clear();

                int numPlayers = GetNumOfPlayers();

                Deck initialDeck = new Deck();
                initialDeck.InitializeFullDeck();
                initialDeck.Shuffle();

                int cardsPerPlayer = initialDeck.CardCount / numPlayers;


                for (int playerNum = 0; playerNum < numPlayers; playerNum++)
                {
                    List<Card> temp = new List<Card>();

                    for (int count = 0; count < cardsPerPlayer; count++)
                        temp.Add(initialDeck.DrawCard());

                    playersInfo.Add((new Deck(temp), playerNum + 1));
                }

                PrintPlayersDecks();

                // Saca cada jugador una carta
                List<(Card card, int playerID)> turnCards = new List<(Card card, int playerID)>();

                foreach (var player in playersInfo)
                    turnCards.Add((player.deck.DrawCard(), player.playerId));

                // Se comparan las cartas y se devuelven todas las cartas al jugador que ha sacado la carta más alta
                (Card, int) winnerCard = GetWinnerCard(turnCards);

                Console.WriteLine(winnerCard.ToString());

                foreach(var player in playersInfo)
                {
                    if(player.deck.CardCount == 0)
                    {
                        Console.WriteLine($"El jugador {player.playerId} ha perdido");
                        playersInfo.Remove(player);
                    }
                }

                Console.ReadKey();
            }
            while (true);
        }

        static int GetNumOfPlayers()
        {
            while (true)
            {
                Console.Write("¿Cuantos jugadores jugarán la partida?");
                string response = Console.ReadLine();

                if (!int.TryParse(response, out int numPlayers))
                {
                    Console.WriteLine("Introduce un valor de jugadores válido");
                    continue;
                }

                if (numPlayers < 2 || numPlayers > 5)
                {
                    Console.WriteLine("El numero de jugadores tiene que ser un valor entre 2 y 5");
                    continue;
                }
                return numPlayers;
            }
        }

        static void PrintPlayersDecks()
        {
            foreach (var player in playersInfo)
            {
                Console.WriteLine($"Jugador: {player.playerId}");
                Console.WriteLine(player.deck.ToString());
                Console.WriteLine($"Count: {player.deck.CardCount}");
                Console.WriteLine("-----------------");
            }
        }

        static (Card,int) GetWinnerCard(List<(Card, int)> turnList)
        {
            if (turnList.Count == 0)
            {
                Console.WriteLine("No se ha podido jugar la ronda: La lista de jugadas está vacía");
                return (new Card(), 0);
            }

            (Card, int) maxCard = (new Card(Card.eSuit.Oros, 1), 0);

            foreach (var cardTurn in turnList)
            {
                if (cardTurn.Item1 > maxCard.Item1)
                {
                    maxCard = cardTurn;
                }
            }
            return maxCard;
        }
    }
}
