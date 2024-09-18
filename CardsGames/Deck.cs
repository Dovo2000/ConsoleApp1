using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGames
{
    internal class Deck
    {
        private List<Card> cartas;

        public int CardCount { get => cartas.Count; }

        public Deck() 
        {
            cartas = new List<Card>();
        }

        public Deck(List<Card> cartas)
        {
            this.cartas = cartas;
        }

        public void InitializeFullDeck()
        {
            foreach (Card.eSuit palo in Enum.GetValues(typeof(Card.eSuit)))
            {
                for (int i = 1; i < 13; i++)
                    cartas.Add(new Card(palo, i));
            }
        }

        public void Shuffle()
        {
            Random random = new Random();

            int maxCards = cartas.Count - 1;

            while (maxCards > 1)    // Fisher-Yates shuffle method
            {
                int randomPos = random.Next(maxCards + 1);

                Card tempCard = cartas[randomPos];
                cartas[randomPos] = cartas[maxCards];
                cartas[maxCards] = tempCard;

                maxCards--;
            }
        }

        public Card DrawCard()
        {
            Card drawedCard = cartas.First();
            cartas.Remove(drawedCard);

            return drawedCard;
        }

        public Card DrawRandomCard()
        {
            Random randNum = new Random();

            Card drawedCard = cartas[randNum.Next(0, cartas.Count)];
            cartas.Remove(drawedCard);

            return drawedCard;
        }

        public Card DrawCardAt(int position)
        {
            Card drawedCard = cartas[position];
            cartas.RemoveAt(position);

            return drawedCard;
        }

        public void AddCards(List<Card> newCards)
        {
            foreach (Card card in newCards)
                cartas.Add(card);
        }

        public override string ToString()
        {
            string output = "";
            foreach (Card card in cartas)
                output += card.ToString() + "\n";

            return output;
        }
    }
}
