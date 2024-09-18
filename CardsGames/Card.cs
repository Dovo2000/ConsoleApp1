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
            Espadas
        };

        private eSuit palo;
        private int num;

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

        public Card() 
        {
            palo = new eSuit();
            num = 1;
        }

        public Card(eSuit palo, int num)
        {
            this.palo = palo;
            this.num = num;
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
