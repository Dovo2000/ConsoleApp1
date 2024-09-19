using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGames
{
    internal class Card
    {
        public enum eSuit
        {
            Oros,
            Bastos,
            Copas,
            Espadas,
            Picas,
            Treboles,
            Corazon,
            Diamantes
        };

        private eSuit palo;
        private int num;
        private int playerId;

        public eSuit Palo { get => palo; }

        public int Num { 
            
            get => num; 

            private set
            {
                if (value > 0 && value <= 12)
                {
                    num = value;
                }
            }
        }

        public int PlayerId { get => playerId; set => playerId = value; }

        public Card(eSuit palo, int num, int playerId)
        {
            this.palo = palo;
            this.num = num;
            this.playerId = playerId;
        }

        public override string ToString()
        {
            return num.ToString() + " de " + palo.ToString();
        } 

        static public bool operator >(Card a, Card b)
        {
            return a.num > b.num;
        }

        static public bool operator <(Card a, Card b)
        {
            return a.num < b.num;
        }

        static public bool operator ==(Card a, Card b)
        {
            return a.num == b.num && a.palo == b.palo;
        }

        static public bool operator !=(Card a, Card b)
        {
            return a.num != b.num || a.palo != b.palo;
        }
    }
}
