using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;



namespace WarServer
{
    public class Program
    {
        public static readonly BlockingCollection<Socket> Players = new();
        public static void Main(string[] args)
        {
            Task.Factory.StartNew(SocketServer.StartListening);

            while (true)
            {
                if (Players.Count >= 2)
                {
                    var player1 = Players.Take();
                    var player2 = Players.Take(); 

                    Task.Factory.StartNew(() => PlayGame(player1, player2));
                }
            }
        }

        private static void PlayGame(Socket player1, Socket player2)
        {
            (new Game { Player1 = player1, Player2 = player2}).Play();
            Console.WriteLine("Game over...");
        }
    }
}