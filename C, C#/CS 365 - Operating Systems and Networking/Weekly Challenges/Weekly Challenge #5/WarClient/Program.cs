using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarClient
{
    public class Program
    {
        private static void ClientPlay()
        {
            Console.WriteLine("Starting client");

            SocketClient.StartClient(out var socket);

            SocketClient.Send(socket, new byte[] {Convert.ToByte(2), 0, 0});

            var cards = SocketClient.Receive(socket);

            var myScore = 0;

            foreach (var card in cards.Skip(2))
            {
                var payloadToSend = new[] {Convert.ToByte(2), (byte) CommandProtocol.PlayCard, card};
                SocketClient.Send(socket, payloadToSend);


                var result = SocketClient.Receive(socket);

                if (result[2] == (byte) PlayResult.Win)
                    ++myScore;
                else
                    --myScore;
            }

            SocketClient.Send(socket, new[] {Convert.ToByte(1), (byte) CommandProtocol.EndGame, Convert.ToByte(0)});

            var gameResult = myScore > 0 ? "won" : myScore < 0 ? "lost" : "drew";

            Console.WriteLine($"Game completed, I {gameResult}");

            SocketClient.Shutdown(socket);
        }

        public static void Main(string[] args)
        {
            const int numberOfClients = 2;
            var clients = new List<Task>();

            for (var i = 0; i < numberOfClients; ++i) clients.Add(Task.Factory.StartNew(ClientPlay));

            clients.ForEach(client => client.Wait());
            Console.WriteLine($"{numberOfClients} completed clients");

            Console.ReadKey();
        }
    }
}