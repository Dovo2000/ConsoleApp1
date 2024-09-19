using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CardsGames
{
    internal class Program
    {

        static void Main(string[] args)
        {
            CardCombatGame game = new CardCombatGame();

            game.Play();
        }
    }
}
