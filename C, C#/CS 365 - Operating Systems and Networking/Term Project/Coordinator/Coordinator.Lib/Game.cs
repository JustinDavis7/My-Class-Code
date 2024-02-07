using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WarServer
{
    public class Game
    {
        public Socket Player1 { get; set; }

        public Socket Player2 { get; set; }

        private static void DealCards(out byte[] player1Stack, out byte[] player2Stack)
        {
            // Array with 52 numbers, then shuffle them using a random to just swap indexs.
            // Check to make sure indexs aren't the same, if they are just get a new number for 2.
            var cards = Enumerable.Range(1, 52)
                .Select(card => (byte)card)
                .ToList();
            cards.Shuffle();

            player1Stack = new List<byte>(cards.GetRange(0, 25)).ToArray();
            player2Stack = new List<byte>(cards.GetRange(26, 51)).ToArray();
        }

        private static int CompareCards(byte card1, byte card2)
        {
            throw new NotImplementedException();
        }

        public void Play()
        {
            /* 1. Deal Cards
             * 2. Send the cards to the players
             * 3. Recieve responses from the players
             * 4. While response from each player 
             *      is not QuitGame:
             * 5.   Compare cards from the players and returns a message back to each player
             * 6.   Send response back to each player
             * 7.   Recieve responses from the players
             * 8. After game is over, shutdown sockets --- Players.Shutdown
             */

                        
        }
    }
}
