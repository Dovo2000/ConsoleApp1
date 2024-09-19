using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGames
{
    internal class Player
    {
        Deck deck;
        int playerId;

        public int PlayerId { get => playerId; }
        public int CardsCount { get => deck.CardCount; }

        public Player()
        {
            deck = new Deck();
            playerId = 0;
        }

        public Player(Deck deck, int playerId)
        {
            this.deck = deck;
            this.playerId = playerId;
        }

        public Card DrawCard()
        {
            return deck.DrawCard();
        }

        public void AddCards(List<Card> cards)
        {
            deck.AddCards(cards);
        }

        public void PrintPlayer()
        {
            Console.WriteLine($"Jugador: {playerId + 1}");
            Console.WriteLine(deck.ToString());
            Console.WriteLine($"Count: {deck.CardCount}");
            Console.WriteLine("-----------------");
        }
    }
}
