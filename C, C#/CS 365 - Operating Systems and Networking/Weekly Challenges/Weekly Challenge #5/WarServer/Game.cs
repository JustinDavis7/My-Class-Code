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
        private enum PayloadIndexs
        {
            Size, 
            Command,
            Payload
        }
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

            player1Stack = new List<byte>(cards.GetRange(0, 26)).ToArray();
            player2Stack = new List<byte>(cards.GetRange(0, 26)).ToArray();
        }

        private static int CompareCards(byte card1, byte card2)
        {
            return card1.CompareTo(card2);
        }

        public void Play()
        {
            /* 1. Deal Cards
             * 2. Send the cards to the players (a. construct payloads, b. send)
             * 3. Recieve responses from the players
             * 4. While response from each player 
             *      is not QuitGame:
             * 5.   Compare cards from the players and returns a message back to each player
             * 6.   Send response back to each player
             * 7.   Recieve responses from the players
             * 8. After game is over, shutdown sockets --- Players.Shutdown
             */

            // 1.
            DealCards(out var player1Stack, out var player2Stack);

            // 2.
            var player1PayLoad = new List<byte>(player1Stack);
            player1PayLoad.Insert(0, (byte)CommandProtocol.GameStart);
            player1PayLoad.Insert(0, Convert.ToByte(player1Stack.Length));


            var player2PayLoad = new List<byte>(player2Stack);
            player2PayLoad.Insert(0, (byte)CommandProtocol.GameStart);
            player2PayLoad.Insert(0, Convert.ToByte(player2Stack.Length));

            SocketServer.Send(Player1, player1PayLoad.ToArray());
            SocketServer.Send(Player2, player2PayLoad.ToArray());

            // 3.
            var player1Response = SocketServer.Receive(Player1);
            var player2Response = SocketServer.Receive(Player2);

            // 4. Ensure that the response is to play a game...
            // Assuming it's true, then we get the next response

            //player1Response = SocketServer.Receive(Player1);
            //player2Response = SocketServer.Receive(Player2);

            while (player1Response[(int)PayloadIndexs.Command] != (byte) CommandProtocol.QuitGame || 
                    player2Response[(int)PayloadIndexs.Command] != (byte) CommandProtocol.QuitGame)
            {
                switch (CompareCards(player1Response[(int)PayloadIndexs.Payload],
                    player2Response[(int)PayloadIndexs.Payload]))
                {
                    case -1:
                        SocketServer.Send(Player1, new byte[]
                        {
                            2,
                            (byte)CommandProtocol.PlayResult,
                            (byte) PlayResult.Lose
                        });

                        SocketServer.Send(Player2, new byte[]
                        {
                            2,
                            (byte) CommandProtocol.PlayResult,
                            (byte) PlayResult.Win
                        });
                        break;
                    case 0:
                        SocketServer.Send(Player1, new byte[]
                        {
                            2,
                            (byte)CommandProtocol.PlayResult,
                            (byte) PlayResult.Draw
                        });

                        SocketServer.Send(Player2, new byte[]
                        {
                            2,
                            (byte) CommandProtocol.PlayResult,
                            (byte) PlayResult.Draw
                        });
                        break;
                    case 1:
                        SocketServer.Send(Player1, new byte[]
                        {
                            2,
                            (byte)CommandProtocol.PlayResult,
                            (byte) PlayResult.Win
                        });

                        SocketServer.Send(Player2, new byte[]
                        {
                            2,
                            (byte) CommandProtocol.PlayResult,
                            (byte) PlayResult.Lose
                        });
                        break;
                }
                player1Response = SocketServer.Receive(Player1);            
                player2Response = SocketServer.Receive(Player2);
            }
        }
    }
}