using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGames
{
    internal class CardCombatGame
    {
        private List<Player> playersInfo;
        private int winnerId;
        private List<int> loosersId;

        public CardCombatGame()
        {
            playersInfo = new List<Player>();
            winnerId = 0;
            loosersId = new List<int>();
        }

        public void Play()
        {
            ConsoleKeyInfo ckf;

            do
            {
                InitGame();

                GameLoop();

                Console.WriteLine($"Gana el jugador {winnerId}");
                Console.WriteLine("Press any key to continue or ESC to exit...");
                ckf = Console.ReadKey();
            }
            while (ckf.Key != ConsoleKey.Escape);
        }

        private void InitGame()
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
                {
                    Card cardToAdd = initialDeck.DrawCard();
                    cardToAdd.PlayerId = playerNum;

                    temp.Add(cardToAdd);
                }

                playersInfo.Add(new Player(new Deck(temp), playerNum));
            }
        }

        private void GameLoop()
        {
            while (true)
            {
                PrintPlayersDecks();

                // Saca cada jugador una carta
                List<Card> turnCards = PlayCards();

                // Se comparan las cartas y se devuelven todas las cartas al jugador que ha sacado la carta más alta
                Card winnerCard = GetWinnerCard(turnCards);

                GiveWinnersCards(turnCards, winnerCard.PlayerId);

                CheckLoosers();

                if (loosersId.Count == playersInfo.Count - 1)   // Win check
                {
                    winnerId = winnerCard.PlayerId;
                    break;
                }

                System.Threading.Thread.Sleep(250);
            }
        }

        private int GetNumOfPlayers()
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

        private void PrintPlayersDecks()
        {
            Console.Clear();

            foreach (Player player in playersInfo)
                player.PrintPlayer();
        }

        private List<Card> PlayCards()
        {
            List<Card> turnCards = new List<Card>();

            foreach (Player player in playersInfo)
            {
                if (player.CardsCount != 0)
                {
                    Card cardToAdd = player.DrawCard();
                    cardToAdd.PlayerId = player.PlayerId;
                    turnCards.Add(cardToAdd);
                }
            }

            return turnCards;
        }


        private Card GetWinnerCard(List<Card> turnList)
        {
            if (turnList.Count == 0)
            {
                Console.WriteLine("No se ha podido jugar la ronda: La lista de jugadas está vacía");
                return null;
            }

            Card maxCard = new Card(Card.eSuit.Oros, 1, 0);

            foreach (var cardTurn in turnList)
            {
                if (cardTurn > maxCard)
                    maxCard = cardTurn;
            }

            Console.WriteLine($"La carta ganadora es el {maxCard.ToString()} del jugador {maxCard.PlayerId + 1}");

            return maxCard;
        }

        private void GiveWinnersCards(List<Card> turnCards, int winner)
        {
            List<Card> cardsToWinner = new List<Card>();

            foreach (var card in turnCards)
            {
                card.PlayerId = winner;
                cardsToWinner.Add(card);
            }

            playersInfo[winner].AddCards(cardsToWinner);
        }

        private void CheckLoosers()
        {
            foreach (Player player in playersInfo)
            {
                if (player.CardsCount == 0 && !loosersId.Contains(player.PlayerId))
                    loosersId.Add(player.PlayerId);
            }

            // Print loosers
            foreach (int playerId in loosersId)
                Console.WriteLine($"El jugador {playerId + 1} ha perdido");
        }
    }
}
